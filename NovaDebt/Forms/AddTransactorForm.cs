using NovaDebt.Models.Enums;
using System;
using System.Drawing;
using System.Globalization;
using System.Text.RegularExpressions;
using System.Threading;
using System.Windows.Forms;

using static NovaDebt.DataSettings;

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

            this.btnConfirm.Font = DefaultButtonFont;
            this.btnCancel.Font = DefaultButtonFont;

            this.btnConfirm.FlatAppearance.BorderColor = DefaultButtonColor;
            this.btnCancel.FlatAppearance.BorderColor = DefaultButtonColor;

            this.FormClosing += new FormClosingEventHandler(AlertUserOnExit);
        }

        private void btnAddConfirm_Click(object sender, EventArgs e)
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

                string name = inputFields[0];
                string since = inputFields[1];
                string dueDate = inputFields[2];
                string phone = inputFields[3];
                string email = inputFields[4];
                string facebook = inputFields[5];
                decimal amount = (decimal.Parse(inputFields[6]) + currencyInterest);

                if (percentageInterest > 0)
                {
                    amount *= percentageInterest;
                }

                string addTransactorType = string.Empty;

                if (btnDebtor.BackColor == DefaultButtonColor)
                {
                    addTransactorType = TransactorType.Debtor.ToString();
                    XmlProcess.AddTransactorToXml(TransactorsFilePath, name, since, dueDate, phone, email, amount, facebook, addTransactorType);
                }
                else if (btnCreditor.BackColor == DefaultButtonColor)
                {
                    addTransactorType = TransactorType.Creditor.ToString();
                    XmlProcess.AddTransactorToXml(TransactorsFilePath, name, since, dueDate, phone, email, amount, facebook, addTransactorType);
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
