using NovaDebt.Models.Enums;
using System;
using System.Drawing;
using System.Globalization;
using System.IO;
using System.Reflection;
using System.Text.RegularExpressions;
using System.Threading;
using System.Windows.Forms;

using static NovaDebt.DataSettings;

namespace NovaDebt
{
    public partial class AddOrEditTransactorForm : Form
    {
        private int no;
        private string name;
        private string since;
        private string dueDate;
        private string phoneNumber;
        private string email;
        private string facebook;
        private decimal amount;
        private string transactorType;
        
        public AddOrEditTransactorForm()
        {
            InitializeComponent();

            // Setting the default select button as Debtor
            this.btnDebtor.FlatAppearance.BorderColor = Color.FromArgb(0, 208, 255);
            this.btnDebtor.BackColor = Color.FromArgb(0, 208, 255);
        }

        public AddOrEditTransactorForm(int no, string name, string since, string dueDate, string phoneNumber, string email, string facebook, decimal amount, string transactorType)
        {
            InitializeComponent();
            this.no = no;
            this.name = name;
            this.since = since;
            this.dueDate = dueDate;
            this.phoneNumber = phoneNumber;
            this.email = email;
            this.facebook = facebook;
            this.amount = amount;
            this.transactorType = transactorType;
            InitializeEditSection();
        }

        private void InitializeEditSection()
        {
            this.nameTextBox.Text = this.name;
            this.sinceDatePicker.Value = DateTime.ParseExact(this.since, "dd/MM/yyyy", CultureInfo.InvariantCulture);
            this.dueDatePicker.Value = DateTime.ParseExact(this.dueDate, "dd/MM/yyyy", CultureInfo.InvariantCulture);
            this.phoneTextBox.Text = this.phoneNumber;
            this.emailTextBox.Text = this.email;
            this.facebookTextBox.Text = this.facebook;
            this.amountTextBox.Text = this.amount.ToString();

            if (this.transactorType == "Debtor")
            {
                this.btnCreditor.FlatAppearance.BorderColor = Color.WhiteSmoke;
                this.btnCreditor.BackColor = Color.FromArgb(50, 50, 50);
                this.btnDebtor.FlatAppearance.BorderColor = Color.FromArgb(0, 208, 255);
                this.btnDebtor.BackColor = Color.FromArgb(0, 208, 255);
            }
            else if (this.transactorType == "Creditor")
            {
                this.btnDebtor.FlatAppearance.BorderColor = Color.WhiteSmoke;
                this.btnDebtor.BackColor = Color.FromArgb(50, 50, 50);
                this.btnCreditor.FlatAppearance.BorderColor = Color.FromArgb(0, 208, 255);
                this.btnCreditor.BackColor = Color.FromArgb(0, 208, 255);
            }
        }

        private void AddTransactorForm_Load(object sender, EventArgs e)
        {
            Thread.CurrentThread.CurrentCulture = CultureInfo.InvariantCulture;

            this.btnConfirm.FlatAppearance.BorderColor = Color.FromArgb(0, 208, 255);
            this.btnCancel.FlatAppearance.BorderColor = Color.FromArgb(0, 208, 255);

            this.sinceDatePicker.Format = DateTimePickerFormat.Custom;
            this.sinceDatePicker.CustomFormat = "dd/MM/yyyy";
            this.sinceDatePicker.Value = DateTime.UtcNow;

            this.dueDatePicker.Format = DateTimePickerFormat.Custom;
            this.dueDatePicker.CustomFormat = "dd/MM/yyyy";
            this.dueDatePicker.Value = DateTime.UtcNow;

            // Attaching an event will will warn the user upon cancel/exit.
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

                string transactorType = string.Empty;
                string path = TransactorsFilePath;

                if (btnDebtor.BackColor == Color.FromArgb(0, 208, 255))
                {
                    transactorType = TransactorType.Debtor.ToString();
                    XmlProcess.AddTransactorToXml(path, name, since, dueDate, phone, email, amount, facebook, transactorType);
                }
                else if (btnCreditor.BackColor == Color.FromArgb(0, 208, 255))
                {
                    transactorType = TransactorType.Creditor.ToString();
                    XmlProcess.AddTransactorToXml(path, name, since, dueDate, phone, email, amount, facebook, transactorType);
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
            this.btnDebtor.FlatAppearance.BorderColor = Color.FromArgb(0, 208, 255);
            this.btnDebtor.BackColor = Color.FromArgb(0, 208, 255);
        }

        private void btnAddCreditor_Click(object sender, EventArgs e)
        {
            // other
            this.btnDebtor.FlatAppearance.BorderColor = Color.WhiteSmoke;
            this.btnDebtor.BackColor = Color.FromArgb(50, 50, 50);

            // this
            this.btnCreditor.FlatAppearance.BorderColor = Color.FromArgb(0, 208, 255);
            this.btnCreditor.BackColor = Color.FromArgb(0, 208, 255);
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
            if (sinceDatePicker.Value > dueDatePicker.Value)
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
            if (dueDatePicker.Value < sinceDatePicker.Value)
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
                amount = decimal.Parse(amountTextBox.Text);

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
                if (mainRegex.IsMatch(this.interestWithCurrencyTextBox.Text.Trim())
                    && !string.IsNullOrEmpty(this.interestWithCurrencyTextBox.Text.Trim()))
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
                if (mainRegex.IsMatch(this.interestWithPercentageTextBox.Text.Trim())
                    && !string.IsNullOrEmpty(this.interestWithPercentageTextBox.Text.Trim()))
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
    }
}
