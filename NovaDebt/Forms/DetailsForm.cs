using NovaDebt.Models.Enums;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using System.Xml.Linq;

using static NovaDebt.DataSettings;

namespace NovaDebt.Forms
{
    public partial class DetailsForm : Form
    {
        private MainForm mainForm;

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

        public DetailsForm(MainForm mainForm, int no, string name, string since, string dueDate, string phoneNumber, string email, string facebook, decimal amount, string transactorType)
        {
            InitializeComponent();
            this.mainForm = mainForm;
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
            // Font - Primary Buttons
            this.detailsBtnEdit.Font = DefaultFontSixteen;
            this.detailsBtnDelete.Font = DefaultFontSixteen;

            // Font - Labels (layouts)
            this.detailsNoLabelLayout.Font = DefaultFontThirteen;
            this.detailsNameLabelLayout.Font = DefaultFontThirteen;
            this.detailsPhoneLabelLayout.Font = DefaultFontThirteen;
            this.detailsEmailLabelLayout.Font = DefaultFontThirteen;
            this.detailsFacebookLabelLayout.Font = DefaultFontThirteen;
            this.detailsAmountLabelLayout.Font = DefaultFontThirteen;
            this.detailsTransactorTypeLabelLayout.Font = DefaultFontThirteen;
            this.detailsSinceLabelLayout.Font = DefaultFontThirteen;
            this.detailsDueDateLabelLayout.Font = DefaultFontThirteen;

            // Font - Labels (values)
            this.detailsNoLabel.Font = DefaultFontSixteen;
            this.detailsNameLabel.Font = DefaultFontSixteen;
            this.detailsPhoneLabel.Font = DefaultFontSixteen;
            this.detailsEmailLabel.Font = DefaultFontSixteen;
            this.detailsFacebookLabel.Font = DefaultFontSixteen;
            this.detailsAmountLabel.Font = DefaultFontSixteen;
            this.detailsTransactorTypeLabel.Font = DefaultFontSixteen;
            this.detailsSinceLabel.Font = DefaultFontSixteen;
            this.detailsDueDateLabel.Font = DefaultFontSixteen;

            this.detailsBtnEdit.FlatAppearance.BorderColor = DefaultButtonColor;
            this.detailsBtnDelete.FlatAppearance.BorderColor = DefaultButtonColor;

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
            EditTransactorForm editTransactorForm = new EditTransactorForm(
                this.mainForm,
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
                IEnumerable<XElement> debtors = xmlDocument.Element(XmlRoot)
                                                           .Elements(XmlElement);

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

                xmlDocument.Save(TransactorsFilePath, SaveOptions.DisableFormatting);

                this.Close();
            }
        }
    }
}
