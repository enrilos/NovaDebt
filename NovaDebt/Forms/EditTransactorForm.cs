using NovaDebt.Models;
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
        private int oldNo;
        private string oldName;
        private string oldSince;
        private string oldDueDate;
        private string oldPhoneNumber;
        private string oldEmail;
        private string oldFacebook;
        private decimal oldAmount;
        private string oldTransactorType;

        private int newNo;
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
            this.sinceDatePicker.Value = DateTime.UtcNow;

            this.dueDatePicker.Format = DateTimePickerFormat.Custom;
            this.dueDatePicker.CustomFormat = "dd/MM/yyyy";
            this.dueDatePicker.Value = DateTime.UtcNow;
        }

        public EditTransactorForm(int no, string name, string since, string dueDate, string phoneNumber, string email, string facebook, decimal amount, string transactorType)
        {
            InitializeComponent();
            this.oldNo = no;
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
                    this.amountTextBox.Text
                };

                RegexOptions options = RegexOptions.None;
                Regex regex = new Regex("[ ]{2,}", options);

                for (int i = 0; i < inputFields.Length; i++)
                {
                    // Removing all unnecessary whitespaces.
                    inputFields[i] = inputFields[i].TrimStart().TrimEnd();
                    inputFields[i] = regex.Replace(inputFields[i], " ");
                }

                decimal currencyInterest = decimal.Parse(this.interestWithCurrencyTextBox.Text);
                decimal percentageInterest = 1.00m + (decimal.Parse(this.interestWithPercentageTextBox.Text) / 100.00m);

                this.newName = inputFields[0];
                this.newSince = inputFields[1];
                this.newDueDate = inputFields[2];
                this.newPhoneNumber = inputFields[3];
                this.newEmail = inputFields[4];
                this.newFacebook = inputFields[5];
                this.newAmount = decimal.Parse(inputFields[6]) + currencyInterest;

                if (percentageInterest > 0)
                {
                    newAmount *= percentageInterest;
                }

                this.newTransactorType = string.Empty;
                string path = TransactorsFilePath;

                XDocument xmlDocument = XDocument.Load(TransactorsFilePath);
                IEnumerable<XElement> transactorsWithType = xmlDocument
                            .Element("Transactors")
                            .Elements("Transactor")
                            .Where(x => x.Element("TransactorType").Value == this.oldTransactorType
                                   && x.Attribute("no").Value == this.oldNo.ToString());

                if (btnDebtor.BackColor == Color.FromArgb(0, 208, 255))
                {
                    this.newTransactorType = TransactorType.Debtor.ToString();
                }
                else if (btnCreditor.BackColor == Color.FromArgb(0, 208, 255))
                {
                    this.newTransactorType = TransactorType.Creditor.ToString();
                }

                if (this.oldTransactorType != newTransactorType)
                {
                    // CHANGING THE COLLECTION OF THE RECORD
                    // I could just use the AddTransactorToXml method when the user changes the transactor type
                    // and add it to the other collection of transactors.
                    // Don't forget to remove the transactor from the old collection.
                    if (this.newTransactorType == TransactorType.Debtor.ToString())
                    {
                        HashSet<Transactor> debtors = XmlProcess.DeserializeXmlWithTransactorType(path, TransactorType.Debtor).ToHashSet();
                        this.newNo = debtors.Count + 1;

                        // Here I should put the edited transactor in the collection of debtors.
                    }
                    else if (this.newTransactorType == TransactorType.Creditor.ToString())
                    {
                        HashSet<Transactor> creditors = XmlProcess.DeserializeXmlWithTransactorType(path, TransactorType.Creditor).ToHashSet();
                        this.newNo = creditors.Count + 1;

                        // Here I should put the edited transactor in the collection of creditors.
                    }
                }
                else if (this.oldTransactorType == this.newTransactorType)
                {
                    // NOT CHANGING THE COLLECTION OF THE RECORD
                    // If the user didn't change the transactor type I should just replace the properties
                    // and refresh the grid.
                    // Replace the old data fields with the new ones and refresh the grid.
                }

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
            // Since
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
            // Due Date
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
                // Количествена лихва

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

                // Процентна лихва
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
