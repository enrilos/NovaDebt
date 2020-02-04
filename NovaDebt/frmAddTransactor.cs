using NovaDebt.Models;
using NovaDebt.Models.Enums;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text.RegularExpressions;
using System.Windows.Forms;

namespace NovaDebt
{
    public partial class frmAddTransactor : Form
    {
        private const decimal MinAmountValue = 0.01m;
        private const decimal MaxAmountValue = 4294967295m;
        private const string PathCannotBeNullErrorMessage = "Path cannot be null.";
        private const string FileDoesntExistErrorMessage = "File doesn't exist.";
        private const string NameCannotBeNullErrorMessage = "Name cannot be null.";
        private const string InvalidNameErrorMessage = "Името може да се състои само от букви и цифри.";
        private const string MissingNameErrorMessage = "Името e задължително.";
        private const string InvalidPhoneNumberErrorMessage = "Невалиден Тел №.";
        private const string InvalidEmailErrorMessage = "Невалиден Имейл.";
        private const string InvalidFacebookErrorMessage = "Невалиден Фейсбук.";
        private const string InvalidAmountInterval = "Количеството трябва да е в интервала {0} - {1}.";
        private const string MissingAmountErrorMessage = "Количеството е задължително.";
        private const string InvalidAmountErrorMessage = "Невалидно количество.";
        private const string ErrorMessageBoxCaption = "Грешка";
        private const string ExitMessageBoxCaption = "Изход";

        public frmAddTransactor()
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
                string path = Environment.GetFolderPath(Environment.SpecialFolder.Desktop) + "\\transactors.xml";

                if (btnAddDebtor.BackColor == Color.FromArgb(0, 208, 255))
                {
                    transactorType = TransactorType.Debtor.ToString();
                    AddTransactorToXml(path, name, phone, email, amount, facebook, transactorType);
                }
                else if (btnAddCreditor.BackColor == Color.FromArgb(0, 208, 255))
                {
                    transactorType = TransactorType.Creditor.ToString();
                    AddTransactorToXml(path, name, phone, email, amount, facebook, transactorType);
                }

                this.FormClosing -= AlertUserOnExit;
                this.Close();
            }
        }

        private void btnAddCancel_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show($"Данните няма да бъдат запазени.{Environment.NewLine}Наистина ли искате да излезете?",
                ExitMessageBoxCaption,
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

        private void AddTransactorToXml(string path, string name, string phone, string email, decimal amount, string facebook, string transactorType)
        {
            if (path == null)
            {
                throw new ArgumentNullException(PathCannotBeNullErrorMessage);
            }
            if (!File.Exists(path))
            {
                throw new InvalidOperationException(FileDoesntExistErrorMessage);
            }
            if (name == null)
            {
                throw new ArgumentNullException(NameCannotBeNullErrorMessage);
            }

            Transactor transactor = new Transactor(name, phone, email, facebook, amount, transactorType);
            HashSet<Transactor> transactors = XmlProcess.DeserializeXml(path).ToHashSet();

            transactor.Id = transactors.Count + 1;
            // Here I should get the transactor collection with the corresponding transactorType
            // and set the new transactor's object No to the last No + 1.

            HashSet<Transactor> transactorTypeNos = transactors.Where(t => t.TransactorType == transactorType).ToHashSet();
            transactor.No = transactorTypeNos.Count + 1;

            transactors.Add(transactor);
            XmlProcess.SerializeXmlWithTransactors(path, transactors.ToArray());
        }

        private bool ValidateInputFields()
        {
            //
            // Име - Name (Required)
            //
            Regex regex = new Regex("^[a-zA-Z0-9., ]*$");

            if (!regex.IsMatch(this.addNameTextBox.Text))
            {
                MessageBox.Show(InvalidNameErrorMessage,
                    ErrorMessageBoxCaption,
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);

                return false;
            }
            else if (string.IsNullOrEmpty(this.addNameTextBox.Text) || string.IsNullOrWhiteSpace(this.addNameTextBox.Text))
            {
                MessageBox.Show(MissingNameErrorMessage,
                    ErrorMessageBoxCaption,
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
                MessageBox.Show(InvalidPhoneNumberErrorMessage,
                    ErrorMessageBoxCaption,
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
                MessageBox.Show(InvalidEmailErrorMessage,
                    ErrorMessageBoxCaption,
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
                MessageBox.Show(InvalidFacebookErrorMessage,
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

            if (regex.IsMatch(this.addAmountTextBox.Text.Trim()))
            {
                amount = decimal.Parse(addAmountTextBox.Text);

                if (amount < 0.01m || amount > 4294967295m)
                {
                    MessageBox.Show(string.Format(InvalidAmountInterval, MinAmountValue, MaxAmountValue),
                           ErrorMessageBoxCaption,
                           MessageBoxButtons.OK,
                           MessageBoxIcon.Error);

                    return false;
                }
            }
            else if (string.IsNullOrEmpty(this.addAmountTextBox.Text) || string.IsNullOrWhiteSpace(this.addAmountTextBox.Text))
            {
                MessageBox.Show(MissingAmountErrorMessage,
                    ErrorMessageBoxCaption,
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);

                return false;
            }
            else
            {
                MessageBox.Show(InvalidAmountErrorMessage,
                    ErrorMessageBoxCaption,
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);

                return false;
            }

            return true;
        }

        private void AlertUserOnExit(object sender, FormClosingEventArgs e)
        {
            DialogResult dialog = MessageBox.Show($"Данните няма да бъдат запазени.{Environment.NewLine}Наистина ли искате да излезете?",
                   ExitMessageBoxCaption,
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
