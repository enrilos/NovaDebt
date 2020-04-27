using NovaDebt.Common;
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

using static NovaDebt.Common.DataSettings;

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
        private Currency oldCurrency;
        private string oldTransactorType;

        private string newName;
        private string newSince;
        private string newDueDate;
        private string newPhoneNumber;
        private string newEmail;
        private string newFacebook;
        private decimal newAmount;
        private Currency newCurrency;
        private string newTransactorType;

        public EditTransactorForm()
        {
            InitializeComponent();

            this.sinceDatePicker.Format = DateTimePickerFormat.Custom;
            this.sinceDatePicker.CustomFormat = "dd/MM/yyyy";

            this.dueDatePicker.Format = DateTimePickerFormat.Custom;
            this.dueDatePicker.CustomFormat = "dd/MM/yyyy";
        }

        public EditTransactorForm(MainForm mainForm, int no, string name, string since, string dueDate, string phoneNumber, string email, string facebook, decimal amount, Currency currency, string transactorType)
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
            this.oldCurrency = currency;
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

            IEnumerable<Currency> currencies = GetCurrencies();
            this.currencyComboBox.DataSource = currencies;
            this.currencyComboBox.ValueMember = "Id";
            this.currencyComboBox.DisplayMember = "Abbreviation";
            this.currencyComboBox.SelectedItem = currencies.Where(x => x.Abbreviation == oldCurrency.Abbreviation).First();

            if (this.oldTransactorType == TransactorType.Debtor.ToString())
            {
                this.btnDebtor.FlatAppearance.BorderColor = DefaultButtonColor;
                this.btnDebtor.BackColor = DefaultButtonColor;
            }
            else
            {
                this.btnCreditor.FlatAppearance.BorderColor = DefaultButtonColor;
                this.btnCreditor.BackColor = DefaultButtonColor;
            }
        }

        private void EditTransactorForm_Load(object sender, EventArgs e)
        {
            Thread.CurrentThread.CurrentCulture = CultureInfo.InvariantCulture;

            // Font - Primary Buttons
            this.btnCancel.Font = DefaultFontSixteen;
            this.btnConfirm.Font = DefaultFontSixteen;

            // Font - Labels
            this.nameLabel.Font = DefaultFontThirteen;
            this.phoneLabel.Font = DefaultFontThirteen;
            this.emailLabel.Font = DefaultFontThirteen;
            this.facebookLabel.Font = DefaultFontThirteen;
            this.amountLabel.Font = DefaultFontThirteen;
            this.sinceLabel.Font = DefaultFontThirteen;
            this.dueDateLabel.Font = DefaultFontThirteen;
            this.interestPriorityOneLabel.Font = DefaultFontTwelve;
            this.interestPriorityTwoLabel.Font = DefaultFontTwelve;
            this.interestWithCurrencyLabel.Font = DefaultFontThirteen;
            this.interestWithPercentageLabel.Font = DefaultFontThirteen;

            // Font - Transactor Buttons
            this.btnDebtor.Font = DefaultFontFifteen;
            this.btnCreditor.Font = DefaultFontFifteen;

            // Font - Interest checkbox (not the default font)
            this.interestCheckBox.Font = new Font("Calibri", 12f, FontStyle.Regular);

            this.btnConfirm.FlatAppearance.BorderColor = DefaultButtonColor;
            this.btnCancel.FlatAppearance.BorderColor = DefaultButtonColor;

            this.FormClosing += new FormClosingEventHandler(AlertUserOnExit);
        }

        private void btnConfirm_Click(object sender, EventArgs e)
        {
            bool areInputFieldsValid = AreInputFieldsValid(
                this.nameTextBox,
                this.sinceDatePicker,
                this.dueDatePicker,
                this.phoneTextBox,
                this.emailTextBox,
                this.facebookTextBox,
                this.amountTextBox,
                this.interestCheckBox,
                this.interestWithCurrencyTextBox,
                this.interestWithPercentageTextBox);

            if (areInputFieldsValid)
            {
                // The array is necessary so we can later trim each textbox.
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
                Currency currencyObj = this.currencyComboBox.SelectedItem as Currency;
                this.newCurrency = currencyObj;

                if (percentageInterest > 1.00m)
                {
                    newAmount = decimal.Parse((newAmount * percentageInterest).ToString("f2"));
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
                    // Deleting the transactor from the old collection and putting it (with the new data) into the new collection.
                    xmlDocument.Root.Elements().FirstOrDefault(x => x.Attribute("no").Value == this.no.ToString()
                                                               && x.Element("TransactorType").Value == this.oldTransactorType)
                                .Remove();

                    int noCounter = 1;
                    IEnumerable<XElement> transactorsWithType = xmlDocument
                            .Element(XmlRoot)
                            .Elements(XmlElement)
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
                        this.newCurrency.Abbreviation,
                        this.newFacebook,
                        this.newTransactorType);
                }
                else if (this.oldTransactorType == this.newTransactorType)
                {
                    // Overwriting the old data with the new one and keeping the record in the same collection.
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
                        this.newCurrency.Abbreviation,
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
                this.mainForm.Enabled = true;
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
                this.interestPriorityOneLabel.Visible = true;
                this.interestPriorityTwoLabel.Visible = true;
                this.interestWithCurrencyLabel.Visible = true;
                this.interestWithCurrencyTextBox.Visible = true;
                this.interestWithPercentageLabel.Visible = true;
                this.interestWithPercentageTextBox.Visible = true;
                this.interestsSeparator.Visible = true;
            }
            else if (!this.interestCheckBox.Checked)
            {
                this.interestWithCurrencyTextBox.Text = "0";
                this.interestWithPercentageTextBox.Text = "0";

                this.interestPriorityOneLabel.Visible = false;
                this.interestPriorityTwoLabel.Visible = false;
                this.interestWithCurrencyLabel.Visible = false;
                this.interestWithCurrencyTextBox.Visible = false;
                this.interestWithPercentageLabel.Visible = false;
                this.interestWithPercentageTextBox.Visible = false;
                this.interestsSeparator.Visible = false;
            }
        }
    }
}
