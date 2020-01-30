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

            this.table = new DataTable();

            this.table.Columns.Add("№", typeof(int)); // Id
            this.table.Columns.Add("Име", typeof(string)); // Name
            this.table.Columns.Add("Тел №", typeof(string)); // Phone Number
            this.table.Columns.Add("Имейл", typeof(string)); // Email
            this.table.Columns.Add("Фейсбук", typeof(string)); // Facebook
            this.table.Columns.Add("Количество", typeof(string)); // Amount. (Actual Amount type is decimal.)

            // Setting the source of the DataGridView.
            this.debtorsDataGrid.DataSource = table;
            // Data grid styling.
            this.debtorsDataGrid.AdvancedCellBorderStyle.All = DataGridViewAdvancedCellBorderStyle.None;

            // Customizing the columns/headers of the table
            DataGridViewColumn column = debtorsDataGrid.Columns[0];
            column.Width = 50;

            // Button customizations are made both in code and the UI.
            this.btnDebtors.FlatAppearance.BorderColor = Color.FromArgb(0, 208, 255);
            this.btnCreditors.FlatAppearance.BorderColor = Color.FromArgb(0, 208, 255);
            this.btnAdd.FlatAppearance.BorderColor = Color.FromArgb(0, 208, 255);
            this.btnEdit.FlatAppearance.BorderColor = Color.FromArgb(0, 208, 255);
            this.btnDelete.FlatAppearance.BorderColor = Color.FromArgb(0, 208, 255);

        }

        private void btnDebtors_Click(object sender, EventArgs e)
        {
            this.btnDebtors.Enabled = false;
            this.btnCreditors.Enabled = true;

            this.table.Rows.Clear();

            string path = Environment.GetFolderPath(Environment.SpecialFolder.Desktop) + "\\transactors.xml";

            this.FillDataGridView(path, TransactorType.Debtor);

            this.debtorsDataGrid.ClearSelection();
        }

        private void btnCreditors_Click(object sender, EventArgs e)
        {
            this.btnDebtors.Enabled = true;
            this.btnCreditors.Enabled = false;

            this.table.Rows.Clear();

            string path = Environment.GetFolderPath(Environment.SpecialFolder.Desktop) + "\\transactors.xml";

            this.FillDataGridView(path, TransactorType.Creditor);
            
            this.debtorsDataGrid.ClearSelection();
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

        private void btnEdit_Click(object sender, EventArgs e)
        {
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
        }

        private void FillDataGridView(string path, TransactorType transactorType)
        {
            IEnumerable<ITransactor> transactors = XmlProcess.DeserializeXmlWithTransactorType(path, transactorType);

            foreach (ITransactor transactor in transactors)
            {
                this.table.Rows.Add(
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
            // Here I should refresh the dataGridView
            if (this.btnDebtors.Enabled == false)
            {

            }
            else if (this.btnCreditors.Enabled == false)
            {

            }
        }
    }
}
