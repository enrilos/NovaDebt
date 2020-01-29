using AutoMapper;
using NovaDebt.Models.Contracts;
using NovaDebt.Models.Enums;
using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Windows.Forms;

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
            // static Mapper
            // Initializing a profile class which contains mapping configurations inside it.
            // Version which is used: 7.0.1
            // NOTE: Newer versions of the AutoMapper don't use the static Mapper class.
            Mapper
                .Initialize(cfg => cfg.AddProfile<NovaDebtProfile>());

            // DataTable
            table = new DataTable();

            table.Columns.Add("№", typeof(int)); // Id
            table.Columns.Add("Име", typeof(string)); // Name
            table.Columns.Add("Тел №", typeof(string)); // Phone Number
            table.Columns.Add("Имейл", typeof(string)); // Email
            table.Columns.Add("Фейсбук", typeof(string)); // Facebook
            table.Columns.Add("Количество", typeof(string)); // Amount. (Actual Amount type is decimal.)

            // Setting the source of the DataGridView.
            debtorsDataGrid.DataSource = table;

            // Customizing the columns/headers of the table
            DataGridViewColumn column = debtorsDataGrid.Columns[0];
            column.Width = 50;

            // Button customizations are made both in code and the UI.
            btnDebtors.FlatAppearance.BorderColor = Color.FromArgb(0, 208, 255);
            btnCreditors.FlatAppearance.BorderColor = Color.FromArgb(0, 208, 255);
            btnAdd.FlatAppearance.BorderColor = Color.FromArgb(0, 208, 255);
            btnEdit.FlatAppearance.BorderColor = Color.FromArgb(0, 208, 255);
            btnDelete.FlatAppearance.BorderColor = Color.FromArgb(0, 208, 255);
        }

        private void btnDebtors_Click(object sender, EventArgs e)
        {
            btnDebtors.Enabled = false;
            btnCreditors.Enabled = true;

            table.Rows.Clear();

            string path = Environment.GetFolderPath(Environment.SpecialFolder.Desktop) + "\\transactors.xml";

            this.debtorsDataGrid.AdvancedCellBorderStyle.All = DataGridViewAdvancedCellBorderStyle.None;

            FillDataGridView(path, TransactorType.Debtor);

            debtorsDataGrid.ClearSelection();
        }

        private void btnCreditors_Click(object sender, EventArgs e)
        {
            btnDebtors.Enabled = true;
            btnCreditors.Enabled = false;

            table.Rows.Clear();

            string path = Environment.GetFolderPath(Environment.SpecialFolder.Desktop) + "\\transactors.xml";

            this.debtorsDataGrid.AdvancedCellBorderStyle.All = DataGridViewAdvancedCellBorderStyle.None;

            FillDataGridView(path, TransactorType.Creditor);

            debtorsDataGrid.ClearSelection();
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            frmAddTransactor frmAddTransactor = new frmAddTransactor();
            frmAddTransactor.Show();

            // Disabling the main form while a subform is open.
            this.Enabled = false;

            // Event handler which will enable the main form if the add form is closed.
            frmAddTransactor.FormClosed += new FormClosedEventHandler(FormClosed);
        }

        private void FillDataGridView(string path, TransactorType transactorType)
        {
            IEnumerable<ITransactor> transactors = XmlProcess.DeserializeXml(path, transactorType);

            foreach (ITransactor transactor in transactors)
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

        private void FormClosed(object sender, FormClosedEventArgs e)
        {
            // Enabling the main form.
            this.Enabled = true;
        }
    }
}
