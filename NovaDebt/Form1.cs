using AutoMapper;
using NovaDebt.Models.Contracts;
using NovaDebt.Models.Enums;
using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.IO;
using System.Text;
using System.Windows.Forms;

namespace NovaDebt
{
    public partial class Form1 : Form
    {
        private const string PathCannotBeNullErrorMessage = "Path cannot be null.";
        private const string FileDoesntExistErrorMessage = "File doesn't exist.";
        private const string DataTableCannotBeNullErrorMessage = "Data table cannot be null.";

        private DataTable table;
        string path;

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            // Static Mapper.
            // Initializing a profile class which contains mapping configurations inside.
            // Version of AutoMapper which is used: 7.0.1
            // NOTE: Newer versions of the AutoMapper don't use the static Mapper class.
            Mapper
                .Initialize(cfg => cfg.AddProfile<NovaDebtProfile>());

            this.table = new DataTable();
            this.InitializeDataTable(this.table);

            this.path = Environment.GetFolderPath(Environment.SpecialFolder.Desktop) + "\\transactors.xml";

            // Always writing the root element if the file is empty or after creation
            // Otherwise xml doesn't like it and throws exceptions.
            // So when the form loads I initialize the file within the directory with "Transactors" root el. as required.
            if (!File.Exists(path))
            {
                using (FileStream fs = File.Create(path))
                {
                    byte[] xmlRoot = new UTF8Encoding(true).GetBytes($"<Transactors>{Environment.NewLine}</Transactors>");
                    fs.Write(xmlRoot, 0, xmlRoot.Length);
                }
            }
            // I should think about when the file exits but doesn't contain the xmlRoot itself inside it.
            // That is a problem and xml won't be happy.

            // Setting the source of the DataGridView.
            this.debtorsDataGrid.DataSource = table;
            // Data grid styling.
            this.debtorsDataGrid.AdvancedCellBorderStyle.All = DataGridViewAdvancedCellBorderStyle.None;

            // Customizing the columns/headers of the table
            DataGridViewColumn columnNo = debtorsDataGrid.Columns[0];
            columnNo.Width = 50;
            DataGridViewColumn columnAmount = debtorsDataGrid.Columns[5];
            columnAmount.Width = 120;

            // Button customizations are made both in code and the UI.
            this.btnDebtors.FlatAppearance.BorderColor = Color.FromArgb(0, 208, 255);
            this.btnCreditors.FlatAppearance.BorderColor = Color.FromArgb(0, 208, 255);
            this.btnAdd.FlatAppearance.BorderColor = Color.FromArgb(0, 208, 255);
            this.btnEdit.FlatAppearance.BorderColor = Color.FromArgb(0, 208, 255);
            this.btnDelete.FlatAppearance.BorderColor = Color.FromArgb(0, 208, 255);

            // Attaching an even which handles where the user has clicked.
            // If clicked outside the data grid view all selected rows are no longer selected and lose focus.
            this.mainPanel.MouseClick += new MouseEventHandler(RemoveDataGridSelection);
            this.menuPanel.MouseClick += new MouseEventHandler(RemoveDataGridSelection);
        }

        private void btnDebtors_Click(object sender, EventArgs e)
        {
            this.btnDebtors.Enabled = false;
            this.btnCreditors.Enabled = true;

            this.table.Rows.Clear();

            this.FillDataTable(path, TransactorType.Debtor);

            this.debtorsDataGrid.ClearSelection();
        }

        private void btnCreditors_Click(object sender, EventArgs e)
        {
            this.btnDebtors.Enabled = true;
            this.btnCreditors.Enabled = false;

            this.table.Rows.Clear();

            this.FillDataTable(path, TransactorType.Creditor);

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
            // TODO
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            // When deleting one or more selected records I must override the original file.
            // I should consider adding a new property which is the No itself and stop messing with the Id.
            // The Id should stay static. It's unique identifier after all.
            // TODO
            // Fixed the problem.
            // Now the enumeration of each record and the Id are different.
            // It's time to implement the Delete function.
            //if (this.debtorsDataGrid.SelectedRows.Count > 0)
            //{
            //    var selectedRows = this.debtorsDataGrid.SelectedRows;
            //    var info = selectedRows[0].Cells["Име"].Value;
            //}
        }

        private void FillDataTable(string path, TransactorType transactorType)
        {
            if (path == null)
            {
                throw new ArgumentNullException(PathCannotBeNullErrorMessage);
            }
            else if (!File.Exists(path))
            {
                throw new InvalidOperationException(FileDoesntExistErrorMessage);
            }

            IEnumerable<ITransactor> transactors = XmlProcess.DeserializeXmlWithTransactorType(path, transactorType);

            foreach (ITransactor transactor in transactors)
            {
                this.table.Rows.Add(
                    transactor.No,
                    transactor.Name,
                    transactor.PhoneNumber,
                    transactor.Email,
                    transactor.Facebook,
                    transactor.Amount + " лв.");
            }
        }

        private void InitializeDataTable(DataTable table)
        {
            if (table == null)
            {
                throw new ArgumentNullException(DataTableCannotBeNullErrorMessage);
            }

            this.table.Columns.Add("№", typeof(int)); // No
            this.table.Columns.Add("Име", typeof(string)); // Name
            this.table.Columns.Add("Тел №", typeof(string)); // Phone Number
            this.table.Columns.Add("Имейл", typeof(string)); // Email
            this.table.Columns.Add("Фейсбук", typeof(string)); // Facebook
            this.table.Columns.Add("Количество", typeof(string)); // Amount. (Actual Amount type is decimal.)
        }

        private void FormClosed(object sender, FormClosedEventArgs e)
        {
            // Enabling the main form and refreshing the Data Grid View.
            this.Enabled = true;
            this.table.Rows.Clear();

            if (this.btnDebtors.Enabled == false)
            {
                // Problem: The scroll should stay in it's last position.
                // Thinking about how to fix it...
                this.FillDataTable(path, TransactorType.Debtor);
                
            }
            else if (this.btnCreditors.Enabled == false)
            {
                this.FillDataTable(path, TransactorType.Creditor);
            }

            this.debtorsDataGrid.DataSource = table;
            this.debtorsDataGrid.ClearSelection();
        }

        private void RemoveDataGridSelection(object sender, MouseEventArgs e)
        {
            this.debtorsDataGrid.ClearSelection();
        }

    }
}
