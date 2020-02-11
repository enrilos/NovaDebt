using NovaDebt.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using System.Xml.Linq;
using static NovaDebt.DataSettings;

namespace NovaDebt
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
            // Get the collection with transactor type
            // The transactor type is based upon which of the 2 buttons (debtors/creditors) the user has chosen.
            // And then filter the deserialized from xml collection with .Where(No = x && TransactorType = Debtor/Creditor)
            // And then fill all the labels with the transactor data
            // If a field is empty it should have a default value of None - (няма)
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

            if (this.transactorType == "Debtor")
            {
                this.detailsTransactorTypeLabel.Text = "Дебитор";
            }
            else if (this.transactorType == "Creditor")
            {
                this.detailsTransactorTypeLabel.Text = "Кредитор";
            }
        }

        private void detailsBtnEdit_Click(object sender, EventArgs e)
        {
            // Closes the Details form
            // Opens up the Edit form with the same data
        }

        private void detailsBtnDelete_Click(object sender, EventArgs e)
        {
            // Asks if the user is certain to delete the record
            // Just with the delete button in the Main form.

            DialogResult dialog = MessageBox.Show("Изтрий записа?",
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
            }

            this.Close();
        }
    }
}
