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
        }
        
        private void btnAddConfirm_Click(object sender, EventArgs e)
        {
            ValidateInputFields();

            // After validating:
            // Trimming at the beginning and the end of each string is a mandatory tasks!
            // Also trying to validate through a regex which replaces multiple whitespaces with a single one.
            // (which can occur in the middle of several words/characters in a string)
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

        private void ValidateInputFields()
        {
            // Име - Name

            Regex regex = new Regex("^[a-zA-Z0-9]*$");

            if (!regex.IsMatch(addNameTextBox.Text) && !string.IsNullOrEmpty(addNameTextBox.Text))
            {
                MessageBox.Show($"Името може да се състои само от букви и цифри.",
                    ErrorMessageBoxCaption,
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
                return;
            }

            // Тел № - PhoneNumber

            regex = new Regex("^[+0-9-()]*$");

            if (!regex.IsMatch(addPhoneTextBox.Text) && !string.IsNullOrEmpty(addPhoneTextBox.Text))
            {
                MessageBox.Show($"Невалиден Тел №.",
                    ErrorMessageBoxCaption,
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
                return;
            }

            // Имейл - Email

            regex = new Regex(@"^\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*$");

            if (!regex.IsMatch(addEmailTextBox.Text) && !string.IsNullOrEmpty(addEmailTextBox.Text))
            {
                MessageBox.Show($"Невалиден Имейл.",
                    ErrorMessageBoxCaption,
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
                return;
            }

            // Фейсбук - Facebook

            regex = new Regex("^[A-z ]*$");

            if (!regex.IsMatch(addFacebookTextBox.Text) && !string.IsNullOrEmpty(addFacebookTextBox.Text))
            {
                MessageBox.Show($"Невалиден Фейсбук.",
                    ErrorMessageBoxCaption,
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
                return;
            }

            // Количество - Amount

            if (!string.IsNullOrEmpty(addAmountTextBox.Text.Trim()))
            {
                decimal amount;

                if (decimal.TryParse(addAmountTextBox.Text, out amount) == false)
                {
                    MessageBox.Show($"Количеството трябва да се състои само от цифри.",
                        ErrorMessageBoxCaption,
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Error);
                    return;
                }
                else
                {
                    amount = decimal.Parse(addAmountTextBox.Text);

                    if (amount < 0.01m || amount > 4294967295m)
                    {
                        MessageBox.Show($"Количеството трябва да е в интервала 0.01 - 4294967295.",
                               ErrorMessageBoxCaption,
                               MessageBoxButtons.OK,
                               MessageBoxIcon.Error);
                        return;
                    }
                }
            }
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
