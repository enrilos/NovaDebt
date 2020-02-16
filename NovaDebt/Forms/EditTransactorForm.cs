using NovaDebt.Models.Enums;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Text.RegularExpressions;
using System.Threading;
using System.Windows.Forms;
using System.Xml.Linq;

using static NovaDebt.DataSettings;

namespace NovaDebt.Forms
{
    public partial class EditTransactorForm : Form
    {
        private MainForm mainForm;

        private int no;

        private string oldName;
        private string oldSince;
        private string oldDueDate;
        private string oldPhoneNumber;
        private string oldEmail;
        private string oldFacebook;
        private decimal oldAmount;
        private string oldTransactorType;

        private string newName;
        private string newSince;
        private string newDueDate;
        private string newPhoneNumber;
        private string newEmail;
        private string newFacebook;
        private decimal newAmount;
        private string newTransactorType;

        public EditTransactorForm()
        {
            InitializeComponent();

            this.sinceDatePicker.Format = DateTimePickerFormat.Custom;
            this.sinceDatePicker.CustomFormat = "dd/MM/yyyy";

            this.dueDatePicker.Format = DateTimePickerFormat.Custom;
            this.dueDatePicker.CustomFormat = "dd/MM/yyyy";
        }

        public EditTransactorForm(MainForm mainForm, int no, string name, string since, string dueDate, string phoneNumber, string email, string facebook, decimal amount, string transactorType)
        {
            InitializeComponent();
            this.mainForm = mainForm;
            this.no = no;
            this.oldName = name;
            this.oldSince = since;
            this.oldDueDate = dueDate;
            this.oldPhoneNumber = phoneNumber;
            this.oldEmail = email;
            this.oldFacebook = facebook;
            this.oldAmount = amount;
            this.oldTransactorType = transactorType;
            SetFieldValues();
        }

        private void SetFieldValues()
        {
            this.nameTextBox.Text = this.oldName;

            this.sinceDatePicker.Format = DateTimePickerFormat.Custom;
            this.sinceDatePicker.CustomFormat = "dd/MM/yyyy";

            this.dueDatePicker.Format = DateTimePickerFormat.Custom;
            this.dueDatePicker.CustomFormat = "dd/MM/yyyy";

            this.sinceDatePicker.Value = DateTime.ParseExact(this.oldSince, "dd/MM/yyyy", CultureInfo.InvariantCulture);
            this.dueDatePicker.Value = DateTime.ParseExact(this.oldDueDate, "dd/MM/yyyy", CultureInfo.InvariantCulture);

            this.phoneTextBox.Text = this.oldPhoneNumber;
            this.emailTextBox.Text = this.oldEmail;
            this.facebookTextBox.Text = this.oldFacebook;
            this.amountTextBox.Text = this.oldAmount.ToString();

            if (this.oldTransactorType == TransactorType.Debtor.ToString())
            {
                this.btnDebtor.FlatAppearance.BorderColor = Color.FromArgb(0, 208, 255);
                this.btnDebtor.BackColor = Color.FromArgb(0, 208, 255);
            }
            else
            {
                this.btnCreditor.FlatAppearance.BorderColor = Color.FromArgb(0, 208, 255);
                this.btnCreditor.BackColor = Color.FromArgb(0, 208, 255);
            }
        }

        private void EditTransactorForm_Load(object sender, EventArgs e)
        {
            Thread.CurrentThread.CurrentCulture = CultureInfo.InvariantCulture;

            this.btnConfirm.FlatAppearance.BorderColor = Color.FromArgb(0, 208, 255);
            this.btnCancel.FlatAppearance.BorderColor = Color.FromArgb(0, 208, 255);

            this.FormClosing += new FormClosingEventHandler(AlertUserOnExit);
        }

        private void btnConfirm_Click(object sender, EventArgs e)
        {
            bool areFieldsValid = ValidateInputFields();

            if (areFieldsValid)
            {
                string[] inputFields = new string[] {
                    this.nameTextBox.Text,
                    this.sinceDatePicker.Text,
                    this.dueDatePicker.Text,
                    this.phoneTextBox.Text,
                    this.emailTextBox.Text,
                    this.facebookTextBox.Text,
                    this.amountTextBox.Text,
                    this.interestWithCurrencyTextBox.Text,
                    this.interestWithPercentageTextBox.Text
                };

                RegexOptions options = RegexOptions.None;
                Regex regex = new Regex("[ ]{2,}", options);

                for (int i = 0; i < inputFields.Length; i++)
                {
                    // Removing all unnecessary whitespaces.
                    inputFields[i] = inputFields[i].TrimStart().TrimEnd();
                    inputFields[i] = regex.Replace(inputFields[i], " ");
                }

                decimal currencyInterest = decimal.Parse(inputFields[7]);
                decimal percentageInterest = 1.00m + (decimal.Parse(inputFields[8]) / 100.00m);

                this.newName = inputFields[0];
                this.newSince = inputFields[1];
                this.newDueDate = inputFields[2];
                this.newPhoneNumber = inputFields[3];
                this.newEmail = inputFields[4];
                this.newFacebook = inputFields[5];
                this.newAmount = decimal.Parse(inputFields[6]) + currencyInterest;

                if (percentageInterest > 1.00m)
                {
                    newAmount *= percentageInterest;
                }

                this.newTransactorType = string.Empty;
                XDocument xmlDocument = XDocument.Load(TransactorsFilePath);

                if (btnDebtor.BackColor == Color.FromArgb(0, 208, 255))
                {
                    this.newTransactorType = TransactorType.Debtor.ToString();
                }
                else if (btnCreditor.BackColor == Color.FromArgb(0, 208, 255))
                {
                    this.newTransactorType = TransactorType.Creditor.ToString();
                }

                if (this.oldTransactorType != this.newTransactorType)
                {
                    xmlDocument.Root.Elements().FirstOrDefault(x => x.Attribute("no").Value == this.no.ToString()
                                                               && x.Element("TransactorType").Value == this.oldTransactorType)
                                .Remove();

                    int noCounter = 1;
                    IEnumerable<XElement> transactorsWithType = xmlDocument
                            .Element("Transactors")
                            .Elements("Transactor")
                            .Where(x => x.Element("TransactorType").Value == this.oldTransactorType);

                    foreach (XElement debtor in transactorsWithType)
                    {
                        debtor.SetAttributeValue("no", noCounter++);
                    }

                    xmlDocument.Save(TransactorsFilePath, SaveOptions.DisableFormatting);

                    XmlProcess.AddTransactorToXml(TransactorsFilePath,
                        this.newName,
                        this.newSince,
                        this.newDueDate,
                        this.newPhoneNumber,
                        this.newEmail,
                        this.newAmount,
                        this.newFacebook,
                        this.newTransactorType);
                }
                else if (this.oldTransactorType == this.newTransactorType)
                {
                    XmlProcess.EditTransactorFromXml(
                        TransactorsFilePath,
                        this.no,
                        this.newName,
                        this.newSince,
                        this.newDueDate,
                        this.newPhoneNumber,
                        this.newEmail,
                        this.newFacebook,
                        this.newAmount,
                        this.oldTransactorType);
                }

                this.mainForm.EnableMainFormAndRefreshDataGrid(this.mainForm);
                this.FormClosing -= AlertUserOnExit;
                this.Close();
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show(MessageBoxText.ExitConfirmation,
                MessageBoxCaption.Exit,
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question) == DialogResult.Yes)
            {
                this.mainForm.Enabled = true;
                this.FormClosing -= AlertUserOnExit;
                this.Close();
            }
        }

        private void btnDebtor_Click(object sender, EventArgs e)
        {
            // other
            this.btnCreditor.FlatAppearance.BorderColor = Color.WhiteSmoke;
            this.btnCreditor.BackColor = Color.FromArgb(50, 50, 50);

            // this
            this.btnDebtor.FlatAppearance.BorderColor = Color.FromArgb(0, 208, 255);
            this.btnDebtor.BackColor = Color.FromArgb(0, 208, 255);
        }

        private void btnCreditor_Click(object sender, EventArgs e)
        {
            // other
            this.btnDebtor.FlatAppearance.BorderColor = Color.WhiteSmoke;
            this.btnDebtor.BackColor = Color.FromArgb(50, 50, 50);

            // this
            this.btnCreditor.FlatAppearance.BorderColor = Color.FromArgb(0, 208, 255);
            this.btnCreditor.BackColor = Color.FromArgb(0, 208, 255);
        }

        private void AlertUserOnExit(object sender, FormClosingEventArgs e)
        {
            DialogResult dialog = MessageBox.Show(MessageBoxText.ExitConfirmation,
                   MessageBoxCaption.Exit,
                   MessageBoxButtons.YesNo,
                   MessageBoxIcon.Question);

            if (dialog == DialogResult.Yes)
            {
                this.FormClosing -= AlertUserOnExit;
                this.Close();
            }
            else if (dialog == DialogResult.No)
            {
                e.Cancel = true;
            }
        }

        private void interestCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            if (this.interestCheckBox.Checked)
            {
                this.interestWithCurrencyLabel.Visible = true;
                this.interestWithCurrencyTextBox.Visible = true;
                this.interestWithPercentageLabel.Visible = true;
                this.interestWithPercentageTextBox.Visible = true;
                this.interestsSeparator.Visible = true;
            }
            else if (!this.interestCheckBox.Checked)
            {
                this.interestWithCurrencyLabel.Visible = false;
                this.interestWithCurrencyTextBox.Visible = false;
                this.interestWithPercentageLabel.Visible = false;
                this.interestWithPercentageTextBox.Visible = false;
                this.interestsSeparator.Visible = false;
            }
        }

        private bool ValidateInputFields()
        {
            //
            // Име - Name (Required)
            //
            Regex mainRegex = new Regex("^[a-zA-Z0-9., ]*$");
            Regex cyrillicRegex = new Regex("^[АБВГДЕЁЖЗИЙКЛМНОПРСТУФХЦЧШЩЪЫЬЭЮЯабвгдеёжзийклмнопрстуфхцчшщъыьэюя0-9., ]*$");

            if (!mainRegex.IsMatch(this.nameTextBox.Text)
             && !cyrillicRegex.IsMatch(this.nameTextBox.Text))
            {
                MessageBox.Show(ErrorMessage.InvalidName,
                    MessageBoxCaption.Error,
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);

                return false;
            }
            else if (string.IsNullOrEmpty(this.nameTextBox.Text)
                  || string.IsNullOrWhiteSpace(this.nameTextBox.Text))
            {
                MessageBox.Show(ErrorMessage.MissingName,
                    MessageBoxCaption.Error,
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);

                return false;
            }

            //
            // От - Since (Required)
            //
            if (this.sinceDatePicker.Value > this.dueDatePicker.Value)
            {
                MessageBox.Show(ErrorMessage.InvalidSinceDate,
                    MessageBoxCaption.Error,
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);

                return false;
            }

            //
            // До - Due Date (Required)
            //
            if (this.dueDatePicker.Value < this.sinceDatePicker.Value)
            {
                MessageBox.Show(ErrorMessage.InvalidDueDate,
                    MessageBoxCaption.Error,
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);

                return false;
            }

            //
            // Тел № - PhoneNumber
            //
            mainRegex = new Regex("^[+0-9-() ]*$");

            if (!mainRegex.IsMatch(this.phoneTextBox.Text))
            {
                MessageBox.Show(ErrorMessage.InvalidPhoneNumber,
                    MessageBoxCaption.Error,
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);

                return false;
            }

            //
            // Имейл - Email
            //
            mainRegex = new Regex(@"^\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*$");

            if (!mainRegex.IsMatch(this.emailTextBox.Text.Trim())
                && !string.IsNullOrEmpty(this.emailTextBox.Text.Trim())
                && !cyrillicRegex.IsMatch(this.emailTextBox.Text.Trim()))
            {
                MessageBox.Show(ErrorMessage.InvalidEmail,
                    MessageBoxCaption.Error,
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);

                return false;
            }

            //
            // Фейсбук - Facebook
            //
            mainRegex = new Regex("^[A-z ]*$");

            if (!mainRegex.IsMatch(this.facebookTextBox.Text)
                && !cyrillicRegex.IsMatch(this.facebookTextBox.Text))
            {
                MessageBox.Show(ErrorMessage.InvalidFacebook,
                    MessageBoxCaption.Error,
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);

                return false;
            }

            //
            // Количество - Amount (Required)
            //
            mainRegex = new Regex("^[0-9]+([.,][0-9]{1,2})?$");
            decimal amount;

            if (mainRegex.IsMatch(this.amountTextBox.Text.Trim()))
            {
                amount = decimal.Parse(this.amountTextBox.Text);

                if (amount < MinAmountValue || amount > MaxAmountValue)
                {
                    MessageBox.Show(string.Format(ErrorMessage.InvalidAmountInterval, MinAmountValue, MaxAmountValue),
                           MessageBoxCaption.Error,
                           MessageBoxButtons.OK,
                           MessageBoxIcon.Error);

                    return false;
                }
            }
            else if (string.IsNullOrEmpty(this.amountTextBox.Text) || string.IsNullOrWhiteSpace(this.amountTextBox.Text))
            {
                MessageBox.Show(ErrorMessage.MissingAmount,
                    MessageBoxCaption.Error,
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);

                return false;
            }
            else
            {
                MessageBox.Show(ErrorMessage.InvalidAmount,
                    MessageBoxCaption.Error,
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);

                return false;
            }

            if (this.interestCheckBox.Checked)
            {
                // Количествена лихва - Currency interest
                if (string.IsNullOrWhiteSpace(this.interestWithCurrencyTextBox.Text)
                    || string.IsNullOrEmpty(this.interestWithCurrencyTextBox.Text))
                {
                    this.interestWithCurrencyTextBox.Text = "0";
                }
                if (mainRegex.IsMatch(this.interestWithCurrencyTextBox.Text.Trim()))
                {
                    decimal currencyInterest = decimal.Parse(this.interestWithCurrencyTextBox.Text);

                    if (currencyInterest < MinInterestCurrencyValue || currencyInterest > MaxInterestCurrencyValue)
                    {
                        MessageBox.Show(string.Format(ErrorMessage.InvalidInterestCurrencyInterval, MinInterestCurrencyValue, MaxInterestCurrencyValue),
                               MessageBoxCaption.Error,
                               MessageBoxButtons.OK,
                               MessageBoxIcon.Error);

                        return false;
                    }
                }
                else
                {
                    MessageBox.Show(ErrorMessage.InvalidInterestCurrency,
                        MessageBoxCaption.Error,
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Error);

                    return false;
                }

                // Процентна лихва - Percentage interest
                if (string.IsNullOrWhiteSpace(this.interestWithPercentageTextBox.Text)
                    || string.IsNullOrEmpty(this.interestWithPercentageTextBox.Text))
                {
                    this.interestWithPercentageTextBox.Text = "0";
                }
                if (mainRegex.IsMatch(this.interestWithPercentageTextBox.Text.Trim()))
                {
                    decimal percentageInterest = decimal.Parse(this.interestWithPercentageTextBox.Text);

                    if (percentageInterest < MinInterestPercentageValue || percentageInterest > MaxInterestPercentageValue)
                    {
                        MessageBox.Show(string.Format(ErrorMessage.InvalidInterestPercentageInterval, MinInterestPercentageValue, MaxInterestPercentageValue),
                           MessageBoxCaption.Error,
                           MessageBoxButtons.OK,
                           MessageBoxIcon.Error);

                        return false;
                    }
                }
                else
                {
                    MessageBox.Show(ErrorMessage.InvalidInterestPercentage,
                        MessageBoxCaption.Error,
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Error);

                    return false;
                }
            }

            return true;
        }
    }
}
