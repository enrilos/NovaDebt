using NovaDebt.Common;
using NovaDebt.Models;
using NovaDebt.Models.Enums;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Globalization;
using System.Text.RegularExpressions;
using System.Threading;
using System.Windows.Forms;

using static NovaDebt.Common.DataSettings;

namespace NovaDebt.Forms
{
    public partial class AddTransactorForm : Form
    {
        public AddTransactorForm()
        {
            InitializeComponent();

            // Setting the default select button as Debtor
            this.btnDebtor.FlatAppearance.BorderColor = DefaultButtonColor;
            this.btnDebtor.BackColor = DefaultButtonColor;

            this.sinceDatePicker.Format = DateTimePickerFormat.Custom;
            this.sinceDatePicker.CustomFormat = "dd/MM/yyyy";
            this.sinceDatePicker.Value = DateTime.UtcNow;

            this.dueDatePicker.Format = DateTimePickerFormat.Custom;
            this.dueDatePicker.CustomFormat = "dd/MM/yyyy";
            this.dueDatePicker.Value = DateTime.UtcNow;
        }

        private void AddTransactorForm_Load(object sender, EventArgs e)
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

            IEnumerable<Currency> currencies = GetCurrencies();

            this.currencyComboBox.DataSource = currencies;
            this.currencyComboBox.ValueMember = "Id";
            this.currencyComboBox.DisplayMember = "Abbreviation";

            this.FormClosing += new FormClosingEventHandler(AlertUserOnExit);
        }

        private void btnAddConfirm_Click(object sender, EventArgs e)
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

                string name = inputFields[0];
                string since = inputFields[1];
                string dueDate = inputFields[2];
                string phone = inputFields[3];
                string email = inputFields[4];
                string facebook = inputFields[5];
                decimal amount = (decimal.Parse(inputFields[6]) + currencyInterest);
                Currency currencyObj = this.currencyComboBox.SelectedItem as Currency;
                string currencyAbbreviation = currencyObj.Abbreviation;

                if (percentageInterest > 1.00m)
                {
                    amount = decimal.Parse((amount * percentageInterest).ToString("f2"));
                }

                string addTransactorType = string.Empty;

                if (btnDebtor.BackColor == DefaultButtonColor)
                {
                    addTransactorType = TransactorType.Debtor.ToString();
                    XmlProcess.AddTransactorToXml(TransactorsFilePath, name, since, dueDate, phone, email, amount, currencyAbbreviation, facebook, addTransactorType);
                }
                else if (btnCreditor.BackColor == DefaultButtonColor)
                {
                    addTransactorType = TransactorType.Creditor.ToString();
                    XmlProcess.AddTransactorToXml(TransactorsFilePath, name, since, dueDate, phone, email, amount, currencyAbbreviation, facebook, addTransactorType);
                }

                this.FormClosing -= AlertUserOnExit;
                this.Close();
            }
        }

        private void btnAddCancel_Click(object sender, EventArgs e)
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

        private void btnAddDebtor_Click(object sender, EventArgs e)
        {
            // other
            this.btnCreditor.FlatAppearance.BorderColor = Color.WhiteSmoke;
            this.btnCreditor.BackColor = Color.FromArgb(50, 50, 50);

            // this
            this.btnDebtor.FlatAppearance.BorderColor = DefaultButtonColor;
            this.btnDebtor.BackColor = DefaultButtonColor;
        }

        private void btnAddCreditor_Click(object sender, EventArgs e)
        {
            // other
            this.btnDebtor.FlatAppearance.BorderColor = Color.WhiteSmoke;
            this.btnDebtor.BackColor = Color.FromArgb(50, 50, 50);

            // this
            this.btnCreditor.FlatAppearance.BorderColor = DefaultButtonColor;
            this.btnCreditor.BackColor = DefaultButtonColor;
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

        private void addInterestCheckBox_CheckedChanged(object sender, EventArgs e)
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
