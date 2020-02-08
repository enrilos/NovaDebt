using NovaDebt.Models.Enums;
using System;
using System.Drawing;
using System.IO;
using System.Reflection;
using System.Text.RegularExpressions;
using System.Windows.Forms;

using static NovaDebt.DataSettings;

namespace NovaDebt
{
    public partial class AddTransactorForm : Form
    {
        public AddTransactorForm()
        {
            InitializeComponent();
        }

        private void frmAddTransactor_Load(object sender, EventArgs e)
        {
            this.btnAddConfirm.FlatAppearance.BorderColor = Color.FromArgb(0, 208, 255);
            this.btnAddCancel.FlatAppearance.BorderColor = Color.FromArgb(0, 208, 255);

            // Setting the default select button as Debtor
            this.btnAddDebtor.FlatAppearance.BorderColor = Color.FromArgb(0, 208, 255);
            this.btnAddDebtor.BackColor = Color.FromArgb(0, 208, 255);

            // Attaching an event will will warn the user upon cancel/exit.
            this.FormClosing += new FormClosingEventHandler(AlertUserOnExit);
        }

        private void btnAddConfirm_Click(object sender, EventArgs e)
        {
            bool areFieldsValid = ValidateInputFields();

            if (areFieldsValid)
            {
                string[] inputFields = new string[] {
                    addNameTextBox.Text,
                    addPhoneTextBox.Text,
                    addEmailTextBox.Text,
                    addFacebookTextBox.Text,
                    addAmountTextBox.Text
                };

                RegexOptions options = RegexOptions.None;
                Regex regex = new Regex("[ ]{2,}", options);

                for (int i = 0; i < inputFields.Length; i++)
                {
                    // Removing all unnecessary whitespaces.
                    inputFields[i] = inputFields[i].TrimStart().TrimEnd();
                    inputFields[i] = regex.Replace(inputFields[i], " ");
                }


                string name = inputFields[0];
                string phone = inputFields[1];
                string email = inputFields[2];
                string facebook = inputFields[3];
                decimal amount = decimal.Parse(inputFields[4]);
                string transactorType = string.Empty;
                string path = TransactorsFilePath;

                if (btnAddDebtor.BackColor == Color.FromArgb(0, 208, 255))
                {
                    transactorType = TransactorType.Debtor.ToString();
                    XmlProcess.AddTransactorToXml(path, name, phone, email, amount, facebook, transactorType);
                }
                else if (btnAddCreditor.BackColor == Color.FromArgb(0, 208, 255))
                {
                    transactorType = TransactorType.Creditor.ToString();
                    XmlProcess.AddTransactorToXml(path, name, phone, email, amount, facebook, transactorType);
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
            this.btnAddCreditor.FlatAppearance.BorderColor = Color.WhiteSmoke;
            this.btnAddCreditor.BackColor = Color.FromArgb(50, 50, 50);

            // this
            this.btnAddDebtor.FlatAppearance.BorderColor = Color.FromArgb(0, 208, 255);
            this.btnAddDebtor.BackColor = Color.FromArgb(0, 208, 255);
        }

        private void btnAddCreditor_Click(object sender, EventArgs e)
        {
            // other
            this.btnAddDebtor.FlatAppearance.BorderColor = Color.WhiteSmoke;
            this.btnAddDebtor.BackColor = Color.FromArgb(50, 50, 50);

            // this
            this.btnAddCreditor.FlatAppearance.BorderColor = Color.FromArgb(0, 208, 255);
            this.btnAddCreditor.BackColor = Color.FromArgb(0, 208, 255);
        }

        private bool ValidateInputFields()
        {
            //
            // Име - Name (Required)
            //
            Regex regex = new Regex("^[a-zA-Z0-9., ]*$");

            if (!regex.IsMatch(this.addNameTextBox.Text))
            {
                MessageBox.Show(ErrorMessage.InvalidName,
                    MessageBoxCaption.Error,
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);

                return false;
            }
            else if (string.IsNullOrEmpty(this.addNameTextBox.Text) || string.IsNullOrWhiteSpace(this.addNameTextBox.Text))
            {
                MessageBox.Show(ErrorMessage.MissingName,
                    MessageBoxCaption.Error,
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);

                return false;
            }

            //
            // Тел № - PhoneNumber
            //
            regex = new Regex("^[+0-9-() ]*$");

            if (!regex.IsMatch(this.addPhoneTextBox.Text))
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
            regex = new Regex(@"^\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*$");

            if (!regex.IsMatch(this.addEmailTextBox.Text.Trim()) && !string.IsNullOrEmpty(this.addEmailTextBox.Text.Trim()))
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
            regex = new Regex("^[A-z ]*$");

            if (!regex.IsMatch(this.addFacebookTextBox.Text))
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
            regex = new Regex("^[0-9]+([.,][0-9]{1,2})?$");
            decimal amount;

            if (regex.IsMatch(this.addAmountTextBox.Text.Trim()))
            {
                amount = decimal.Parse(addAmountTextBox.Text);

                if (amount < 0.01m || amount > 4294967295m)
                {
                    MessageBox.Show(string.Format(string.Format(ErrorMessage.InvalidAmountInterval, MinAmountValue, MaxAmountValue)),
                           MessageBoxCaption.Error,
                           MessageBoxButtons.OK,
                           MessageBoxIcon.Error);

                    return false;
                }
            }
            else if (string.IsNullOrEmpty(this.addAmountTextBox.Text) || string.IsNullOrWhiteSpace(this.addAmountTextBox.Text))
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
    }
}
