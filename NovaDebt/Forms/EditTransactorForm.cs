using System;
using System.Drawing;
using System.Globalization;
using System.Threading;
using System.Windows.Forms;

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

            this.btnDebtor.FlatAppearance.BorderColor = Color.FromArgb(0, 208, 255);
            this.btnDebtor.BackColor = Color.FromArgb(0, 208, 255);

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
        }

        private void EditTransactorForm_Load(object sender, EventArgs e)
        {
            Thread.CurrentThread.CurrentCulture = CultureInfo.InvariantCulture;

            this.btnConfirm.FlatAppearance.BorderColor = Color.FromArgb(0, 208, 255);
            this.btnCancel.FlatAppearance.BorderColor = Color.FromArgb(0, 208, 255);
            // The initial load up should be done just like in the AddTransactorForm. 
            // (both in the Load method and in the default constructor)

            this.FormClosing += new FormClosingEventHandler(AlertUserOnExit);
        }

        private void btnConfirm_Click(object sender, EventArgs e)
        {
            this.FormClosing -= AlertUserOnExit;
            this.Close();
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
    }
}
