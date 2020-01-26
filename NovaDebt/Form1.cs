using AutoMapper;
using NovaDebt.Models;
using NovaDebt.Models.Contracts;
using NovaDebt.Models.DTOs;
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
using ValidationContext = System.ComponentModel.DataAnnotations.ValidationContext;

namespace NovaDebt
{
    public partial class Form1 : Form
    {
        private DataTable table;

        public Form1()
        {
            InitializeComponent();

            // Button customizations are made both in code and the UI.
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

        private void Form1_Load(object sender, EventArgs e)
        {
            // Initializing a profile class which contains mapping configurations inside it.
            // Current version: 7.0.1
            // NOTE: Newer versions of the AutoMapper don't use the static Mapper class.
            Mapper
                .Initialize(cfg => cfg.AddProfile<NovaDebtProfile>());

            table = new DataTable();

            table.Columns.Add("№", typeof(int)); // Id
            table.Columns.Add("Име", typeof(string)); // Name
            table.Columns.Add("Тел №", typeof(string)); // Phone Number
            table.Columns.Add("Имейл", typeof(string)); // Email
            table.Columns.Add("Фейсбук", typeof(string)); // Facebook
            table.Columns.Add("Количество", typeof(string)); // Amount. (Actual Amount type is decimal.)

            // Setting the source of the DataGridView.
            debtorsDataGrid.DataSource = table;

            DataGridViewColumn column = debtorsDataGrid.Columns[0];
            column.Width = 50;
        }

        private void btnDebtors_Click(object sender, EventArgs e)
        {
            btnDebtors.Enabled = false;
            btnCreditors.Enabled = true;

            table.Rows.Clear();

            string path = Environment.GetFolderPath(Environment.SpecialFolder.Desktop) + "\\transactors.xml";

            this.debtorsDataGrid.AdvancedCellBorderStyle.All = DataGridViewAdvancedCellBorderStyle.None;

            InitializeDataGridView(path, TransactorType.Debtor);

            debtorsDataGrid.ClearSelection();
        }

        private void btnCreditors_Click(object sender, EventArgs e)
        {
            btnDebtors.Enabled = true;
            btnCreditors.Enabled = false;

            table.Rows.Clear();

            string path = Environment.GetFolderPath(Environment.SpecialFolder.Desktop) + "\\transactors.xml";

            this.debtorsDataGrid.AdvancedCellBorderStyle.All = DataGridViewAdvancedCellBorderStyle.None;

            InitializeDataGridView(path, TransactorType.Creditor);

            debtorsDataGrid.ClearSelection();
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

            // Event handler which will enable the add button back if the corresponding form is closed.
            frmAddTransactor.FormClosed += new FormClosedEventHandler(FormClosed);
        }

        private void InitializeDataGridView(string path, TransactorType transactorType)
        {
            IEnumerable<ITransactor> transactors = DeserializeXml(path, transactorType);

            foreach (var transactor in transactors)
            {
                // I should make validating methods for properties like Email manually
                // Sometimes the user won't know the person's email
                // And if left null the whole object is considered invalid and doesn't go in (but it must).
                if (IsValid(transactor))
                {
                    table.Rows.Add(
                        transactor.Id,
                        transactor.Name,
                        transactor.PhoneNumber,
                        transactor.Email,
                        transactor.Facebook,
                        transactor.Amount + " лв.");
                }
            }
        }

        private IEnumerable<ITransactor> DeserializeXml(string path, TransactorType transactorType)
        {
            string xmlText = File.ReadAllText(path);

            XmlSerializer xmlSerializer = new XmlSerializer(typeof(TransactorDTO[]),
                                          new XmlRootAttribute("Transactors"));

            TransactorDTO[] transactorDTOs = (TransactorDTO[])xmlSerializer.Deserialize(new StringReader(xmlText));

            Transactor[] transactors = Mapper.Map<Transactor[]>(transactorDTOs)
                                       .Where(t => t.TransactorType == transactorType.ToString())
                                       .ToArray();

            for (int i = 0; i < transactors.Length; i++)
            {
                transactors[i].Id = i + 1;
            }

            return transactors;
        }

        private static bool IsValid(object dto)
        {
            ValidationContext validationContext = new ValidationContext(dto);
            List<ValidationResult> validationResult = new List<ValidationResult>();

            return Validator.TryValidateObject(dto, validationContext, validationResult, true);
        }

        private void FormClosed(object sender, FormClosedEventArgs e)
        {
            btnAdd.Enabled = true;
        }
    }
}
