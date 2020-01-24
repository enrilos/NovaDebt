using NovaDebt.Models;
using NovaDebt.Models.Contracts;
using NovaDebt.Models.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Data;
using System.Drawing;
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
            table = new DataTable();

            table.Columns.Add("№", typeof(int)); // Id
            table.Columns.Add("Име", typeof(string)); // Name
            table.Columns.Add("Тел №", typeof(string)); // Phone Number
            table.Columns.Add("Имейл", typeof(string)); // Email
            table.Columns.Add("Фейсбук", typeof(string)); // Facebook
            table.Columns.Add("Количество", typeof(string)); // Amount. (Actual Amount type is decimal.)

            debtorsDataGrid.DataSource = table;

            DataGridViewColumn column = debtorsDataGrid.Columns[0];
            column.Width = 50;
            
            // Some of the button customizations are here.
            btnDebtors.TabStop = false;
            btnDebtors.FlatStyle = FlatStyle.Flat;
            btnDebtors.FlatAppearance.BorderSize = 1;
            btnDebtors.FlatAppearance.BorderColor = Color.FromArgb(0, 208, 255);

            btnCreditors.TabStop = false;
            btnCreditors.FlatStyle = FlatStyle.Flat;
            btnCreditors.FlatAppearance.BorderSize = 1;
            btnCreditors.FlatAppearance.BorderColor = Color.FromArgb(0, 208, 255);

            btnAdd.TabStop = false;
            btnAdd.FlatStyle = FlatStyle.Flat;
            btnAdd.FlatAppearance.BorderSize = 1;
            btnAdd.FlatAppearance.BorderColor = Color.FromArgb(0, 208, 255);

            btnEdit.TabStop = false;
            btnEdit.FlatStyle = FlatStyle.Flat;
            btnEdit.FlatAppearance.BorderSize = 1;
            btnEdit.FlatAppearance.BorderColor = Color.FromArgb(0, 208, 255);

            btnDelete.TabStop = false;
            btnDelete.FlatStyle = FlatStyle.Flat;
            btnDelete.FlatAppearance.BorderSize = 1;
            btnDelete.FlatAppearance.BorderColor = Color.FromArgb(0, 208, 255);
        }

        private void btnDebtors_Click(object sender, EventArgs e)
        {
            btnDebtors.Enabled = false;
            btnCreditors.Enabled = true;

            table.Rows.Clear();

            string path = Environment.GetFolderPath(Environment.SpecialFolder.Desktop) + "\\debtors.xml";

            this.debtorsDataGrid.AdvancedCellBorderStyle.All = DataGridViewAdvancedCellBorderStyle.None;

            InitializeDataGridView(path, TransactorType.Debtors);

            debtorsDataGrid.ClearSelection();
        }

        private void btnCreditors_Click(object sender, EventArgs e)
        {
            btnDebtors.Enabled = true;
            btnCreditors.Enabled = false;

            table.Rows.Clear();

            string path = Environment.GetFolderPath(Environment.SpecialFolder.Desktop) + "\\creditors.xml";

            this.debtorsDataGrid.AdvancedCellBorderStyle.All = DataGridViewAdvancedCellBorderStyle.None;

            InitializeDataGridView(path, TransactorType.Creditors);

            debtorsDataGrid.ClearSelection();
        }

        private void InitializeDataGridView(string path, TransactorType transactorType)
        {
            IEnumerable<object> people = DeserializeXml(path, transactorType).ToHashSet();

            foreach (var person in people)
            {
                // I should make validating methods for properties like Email manually
                // Sometimes the user won't know the person's email
                // And if left null the whole object is considered invalid and doesn't go in.
                if (IsValid(person))
                {
                    ITransactor creditor = ((Transactor)person);

                    table.Rows.Add(
                        creditor.Id,
                        creditor.Name,
                        creditor.PhoneNumber,
                        creditor.Email,
                        creditor.Facebook,
                        creditor.Amount + " лв.");
                }
            }
        }

        private IEnumerable<object> DeserializeXml(string path, TransactorType transactorType)
        {
            string xmlText = File.ReadAllText(path);

            ICollection<object> people = new List<object>();

            if (transactorType == TransactorType.Debtors)
            {
                XmlSerializer xmlSerializer = new XmlSerializer(typeof(DebtorDTO[]),
                                              new XmlRootAttribute(transactorType.ToString()));

                ITransactor[] debtors = (Transactor[])xmlSerializer.Deserialize(new StringReader(xmlText));

                foreach (var debtor in debtors)
                {
                    people.Add(debtor);
                }
            }
            else
            {
                XmlSerializer xmlSerializer = new XmlSerializer(typeof(CreditorDTO[]),
                                              new XmlRootAttribute(transactorType.ToString()));

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

        private void btnAdd_Click(object sender, EventArgs e)
        {
            frmAddTransactor frmAddTransactor = new frmAddTransactor();
            frmAddTransactor.Show();

            // Found a way to disable the button if the corresponding form is open.
            foreach (Form form in Application.OpenForms)
            {
                if (form.Name == "frmAddTransactor")
                {
                    btnAdd.Enabled = false;
                }
            }
            
            // Business logic should be implemented below.

            // Event handler which will enable the button back if the corresponding form is closed.
            frmAddTransactor.FormClosed += new FormClosedEventHandler(FormClosed);
        }

        private void FormClosed(object sender, FormClosedEventArgs e)
        {
            btnAdd.Enabled = true;
        }
    }
}
