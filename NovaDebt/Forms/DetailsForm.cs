using NovaDebt.Models.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using System.Xml.Linq;

using static NovaDebt.DataSettings;

namespace NovaDebt.Forms
{
    public partial class DetailsForm : Form
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

        public DetailsForm()
        {
            InitializeComponent();
        }

        public DetailsForm(int no, string name, string since, string dueDate, string phoneNumber, string email, string facebook, decimal amount, string transactorType)
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

        }

        private void DetailsForm_Load(object sender, EventArgs e)
        {
            // The same way I will send the data to the Edit section
            // Just like the Main form send to this object through the constructor.
            this.detailsNoLabel.Text = no.ToString();
            this.detailsNameLabel.Text = name;
            this.detailsSinceLabel.Text = since;
            this.detailsDueDateLabel.Text = dueDate;
            this.detailsPhoneLabel.Text = phoneNumber;
            this.detailsEmailLabel.Text = email;
            this.detailsFacebookLabel.Text = facebook;
            this.detailsAmountLabel.Text = amount.ToString();

            if (this.transactorType == TransactorType.Debtor.ToString())
            {
                this.detailsTransactorTypeLabel.Text = "Дебитор";
            }
            else if (this.transactorType == TransactorType.Creditor.ToString())
            {
                this.detailsTransactorTypeLabel.Text = "Кредитор";
            }
        }

        private void detailsBtnEdit_Click(object sender, EventArgs e)
        {
            // Closes the Details form
            // Opens up the Edit form with the same data
            // The edit form should have a separate constructor which accepts all of these private fields data.
            // And when Edit is clicked the new Edit form will open and this form should close.

            EditTransactorForm editTransactorForm = new EditTransactorForm(
                this.no,
                this.name,
                this.since,
                this.dueDate,
                this.phoneNumber,
                this.email,
                this.facebook,
                this.amount,
                this.transactorType);

            editTransactorForm.Show();

            // I have to find a way to disable the main form.

            this.Close();
        }

        private void detailsBtnDelete_Click(object sender, EventArgs e)
        {
            DialogResult dialog = MessageBox.Show(MessageBoxText.DeleteConfirmationSingular,
                   MessageBoxCaption.Confirm,
                   MessageBoxButtons.YesNo,
                   MessageBoxIcon.Question);

            if (dialog == DialogResult.Yes)
            {
                XDocument xmlDocument = XDocument.Load(TransactorsFilePath);
                IEnumerable<XElement> debtors = xmlDocument.Element("Transactors")
                                                           .Elements("Transactor");

                if (this.transactorType == "Debtor")
                {
                    xmlDocument.Root.Elements().FirstOrDefault(x => x.Attribute("no").Value == no.ToString()
                                                               && x.Element("TransactorType").Value == "Debtor")
                                .Remove();
                }
                else if (this.transactorType == "Creditor")
                {
                    xmlDocument.Root.Elements().FirstOrDefault(x => x.Attribute("no").Value == no.ToString()
                                                               && x.Element("TransactorType").Value == "Creditor")
                                .Remove();
                }

                int noCounter = 1;

                // Setting the id -1 for each record with transactor type filtered.
                foreach (XElement debtor in debtors.Where(x => x.Element("TransactorType").Value == transactorType))
                {
                    debtor.SetAttributeValue("no", noCounter++);
                }

                xmlDocument.Save(TransactorsFilePath);
                this.Close();
            }

        }
    }
}
