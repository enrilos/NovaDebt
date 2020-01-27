using System;
using System.Drawing;
using System.Text.RegularExpressions;
using System.Windows.Forms;

namespace NovaDebt
{
    public partial class frmAddTransactor : Form
    {
        private const string ErrorMessageBoxCaption = "Грешка";
        private const string ExitMessageBoxCaption = "Изход";

        public frmAddTransactor()
        {
            InitializeComponent();
            btnAddConfirm.FlatAppearance.BorderColor = Color.FromArgb(0, 208, 255);
            btnAddCancel.FlatAppearance.BorderColor = Color.FromArgb(0, 208, 255);

            // Settins the default transactor select button as Debtor
            btnAddDebtor.FlatAppearance.BorderColor = Color.FromArgb(0, 208, 255);
            btnAddDebtor.BackColor = Color.FromArgb(0, 208, 255);
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
                // Removing all unnecessary whitespaces.

                for (int i = 0; i < inputFields.Length; i++)
                {
                    inputFields[i] = inputFields[i].TrimStart().TrimEnd();
                    inputFields[i] = regex.Replace(inputFields[i], " ");
                }

                // Spacing problem should be done by now.

                if (btnAddDebtor.BackColor == Color.FromArgb(0, 208, 255))
                {
                    // Add the transactor in the Debtors section (serialize it as XML and then refresh the data grid)
                }
                else if (btnAddCreditor.BackColor == Color.FromArgb(0, 208, 255))
                {
                    // The exact same but with a Creditor
                }
            }
        }

        private void btnAddCancel_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show($"Данните няма да бъдат запазени.{Environment.NewLine}Наистина ли искате да излезете?",
                ExitMessageBoxCaption,
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question) == DialogResult.Yes)
            {
                this.Close();
            }
        }

        private bool ValidateInputFields()
        {
            //
            // Име - Name (Required)
            //
            Regex regex = new Regex("^[a-zA-Z0-9 ]*$");

            if (!regex.IsMatch(addNameTextBox.Text))
            {
                MessageBox.Show($"Името може да се състои само от букви и цифри.",
                    ErrorMessageBoxCaption,
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);

                return false;
            }
            else if (string.IsNullOrEmpty(addNameTextBox.Text) || string.IsNullOrWhiteSpace(addNameTextBox.Text))
            {
                MessageBox.Show($"Името e задължително.",
                    ErrorMessageBoxCaption,
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);

                return false;
            }

            //
            // Тел № - PhoneNumber
            //
            regex = new Regex("^[+0-9-() ]*$");

            if (!regex.IsMatch(addPhoneTextBox.Text))
            {
                MessageBox.Show($"Невалиден Тел №.",
                    ErrorMessageBoxCaption,
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);

                return false;
            }

            //
            // Имейл - Email
            //
            regex = new Regex(@"^\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*$");

            if (!regex.IsMatch(addEmailTextBox.Text.Trim()) && !string.IsNullOrEmpty(addEmailTextBox.Text.Trim()))
            {
                MessageBox.Show($"Невалиден Имейл.",
                    ErrorMessageBoxCaption,
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);

                return false;
            }

            //
            // Фейсбук - Facebook
            //
            regex = new Regex("^[A-z ]*$");

            if (!regex.IsMatch(addFacebookTextBox.Text))
            {
                MessageBox.Show($"Невалиден Фейсбук.",
                    ErrorMessageBoxCaption,
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);

                return false;
            }

            //
            // Количество - Amount (Required)
            //
            regex = new Regex("^[0-9]+([.,][0-9]{1,2})?$");
            decimal amount;

            if (regex.IsMatch(addAmountTextBox.Text.Trim()))
            {
                amount = decimal.Parse(addAmountTextBox.Text);

                if (amount < 0.01m || amount > 4294967295m)
                {
                    MessageBox.Show($"Количеството трябва да е в интервала 0.01 - 4294967295.",
                           ErrorMessageBoxCaption,
                           MessageBoxButtons.OK,
                           MessageBoxIcon.Error);

                    return false;
                }
            }
            else if (string.IsNullOrEmpty(addAmountTextBox.Text) || string.IsNullOrWhiteSpace(addAmountTextBox.Text))
            {
                MessageBox.Show($"Количеството е задължително.",
                    ErrorMessageBoxCaption,
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);

                return false;
            }
            else
            {
                MessageBox.Show($"Невалидно количество.",
                    ErrorMessageBoxCaption,
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);

                return false;
            }

            return true;
        }

        private void btnAddDebtor_Click(object sender, EventArgs e)
        {
            // other
            btnAddCreditor.FlatAppearance.BorderColor = Color.WhiteSmoke;
            btnAddCreditor.BackColor = Color.FromArgb(50, 50, 50);

            // this
            btnAddDebtor.FlatAppearance.BorderColor = Color.FromArgb(0, 208, 255);
            btnAddDebtor.BackColor = Color.FromArgb(0, 208, 255);
        }

        private void btnAddCreditor_Click(object sender, EventArgs e)
        {
            // other
            btnAddDebtor.FlatAppearance.BorderColor = Color.WhiteSmoke;
            btnAddDebtor.BackColor = Color.FromArgb(50, 50, 50);

            // this
            btnAddCreditor.FlatAppearance.BorderColor = Color.FromArgb(0, 208, 255);
            btnAddCreditor.BackColor = Color.FromArgb(0, 208, 255);
        }
    }
}
