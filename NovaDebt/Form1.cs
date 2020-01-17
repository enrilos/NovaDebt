using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Data;
using System.IO;
using System.Linq;
using System.Windows.Forms;
using System.Xml.Serialization;

namespace NovaDebt
{
    public partial class Form1 : Form
    {
        private DataTable table;

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            // This can prove more useful. Having the columns when the app stars and letting the user to make CRUD.
            table = new DataTable();

            table.Columns.Add("№", typeof(int)); // Id
            table.Columns.Add("Name", typeof(string));
            table.Columns.Add("Tel №", typeof(string)); // Phone Number
            table.Columns.Add("Email", typeof(string));
            table.Columns.Add("Facebook", typeof(string));
            table.Columns.Add("Amount", typeof(decimal));

            debtorsDataGrid.DataSource = table;

            //May be required to change columns color.
            //DataGridViewCellStyle style = new DataGridViewCellStyle();
            //debtorsDataGrid.Columns["№"].DefaultCellStyle.ForeColor = Color.Red;
            //debtorsDataGrid.Columns["№"].DefaultCellStyle.BackColor = Color.Red;
        }

        private void btnDebtors_Click(object sender, EventArgs e)
        {
            table.Rows.Clear();
            string path = Environment.GetFolderPath(Environment.SpecialFolder.Desktop) + "\\debtors.txt";

            this.debtorsDataGrid.AdvancedCellBorderStyle.All = DataGridViewAdvancedCellBorderStyle.None;

            InitializeDataGridView(path, TransactorType.Debtors);
        }

        private void btnCreditors_Click(object sender, EventArgs e)
        {
            table.Rows.Clear();
            string path = Environment.GetFolderPath(Environment.SpecialFolder.Desktop) + "\\creditors.txt";

            this.debtorsDataGrid.AdvancedCellBorderStyle.All = DataGridViewAdvancedCellBorderStyle.None;

            InitializeDataGridView(path, TransactorType.Creditors);
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            table.Rows.Clear();
        }

        private void InitializeDataGridView(string path, TransactorType transactorType)
        {
            ICollection<object> people = DeserializeXml(path, transactorType).ToHashSet();

            foreach (var person in people)
            {
                // I should make validating methods for properties like Email manually
                // Sometimes the user won't know the person's email
                // And if left null the whole object is considered invalid and doesn't go in.
                if (IsValid(person))
                {
                    // Made the code a more generic/abstract.
                    ITransactor creditor = ((Transactor)person);

                    table.Rows.Add(
                        creditor.Id,
                        creditor.Name,
                        creditor.PhoneNumber,
                        creditor.Email,
                        creditor.Facebook,
                        creditor.Amount);
                }
            }
        }

        private IEnumerable<object> DeserializeXml(string path, TransactorType transactorType)
        {
            string xmlText = File.ReadAllText(path);

            ICollection<object> people = new List<object>();

            // Separate classes must be made for each XmlType so the XML can understand.
            if (transactorType == TransactorType.Debtors)
            {
                XmlSerializer xmlSerializer = new XmlSerializer(typeof(DebtorDTO[]),
                                              new XmlRootAttribute(transactorType.ToString())); // Can present the xmlRoot as an enum.

                ITransactor[] debtors = (Transactor[])xmlSerializer.Deserialize(new StringReader(xmlText));

                foreach (var debtor in debtors)
                {
                    people.Add(debtor);
                }
            }
            else
            {
                XmlSerializer xmlSerializer = new XmlSerializer(typeof(CreditorDTO[]),
                                              new XmlRootAttribute(transactorType.ToString())); // Can present the xmlRoot as an enum.

                ITransactor[] debtors = (Transactor[])xmlSerializer.Deserialize(new StringReader(xmlText));

                foreach (var debtor in debtors)
                {
                    people.Add(debtor);
                }
            }

            return people;
        }

        private static bool IsValid(object dto)
        {
            var validationContext = new ValidationContext(dto);
            var validationResult = new List<ValidationResult>();

            return Validator.TryValidateObject(dto, validationContext, validationResult, true);
        }

    }
}
