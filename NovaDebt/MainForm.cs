using AutoMapper;
using NovaDebt.Models;
using NovaDebt.Models.Enums;
using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Windows.Forms;
using System.Xml.Linq;
using static NovaDebt.DataSettings;

namespace NovaDebt
{
    public partial class MainForm : Form
    {
        private DataTable table;

        public MainForm()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            Thread.CurrentThread.CurrentCulture = CultureInfo.InvariantCulture;
            // I should consider preventing the user to start the application more than once.

            // Static Mapper.
            // Initializing a profile class which contains mapping configurations inside.
            // Version of AutoMapper which is used: 7.0.1
            // NOTE: Newer versions of the AutoMapper don't use the static Mapper class.
            Mapper
                .Initialize(cfg => cfg.AddProfile<NovaDebtProfile>());

            this.table = new DataTable();
            this.InitializeDataTable(this.table);

            // Making a separate file which keeps track of the id
            // Overwriting it always when adding a new record - incrementing with +1.
            // Thus I guarantee that no duplicate records will be sent to the transactors file.
            if (!File.Exists(IdCounterFilePath))
            {
                using (FileStream fs = File.Create(IdCounterFilePath))
                {
                    byte[] counterText = new UTF8Encoding(true).GetBytes(IdCounterSeed);
                    fs.Write(counterText, 0, counterText.Length);
                }
            }

            // Always writing the root element if the file is empty or after creation
            // Otherwise xml doesn't like it and throws exceptions.
            // So when the form loads I initialize the file within the directory with "Transactors" root el. as required.
            if (!File.Exists(TransactorsFilePath))
            {
                using (FileStream fs = File.Create(TransactorsFilePath))
                {
                    byte[] xmlRoot = new UTF8Encoding(true).GetBytes(XmlRootOpenClose);
                    fs.Write(xmlRoot, 0, xmlRoot.Length);
                }
            }

            // Setting the source of the DataGridView.
            this.debtorsDataGrid.DataSource = table;
            // Data grid styling.
            this.debtorsDataGrid.AdvancedCellBorderStyle.All = DataGridViewAdvancedCellBorderStyle.None;

            // Customizing the columns/headers of the table
            // No Column
            DataGridViewColumn columnNo = this.debtorsDataGrid.Columns[0];
            columnNo.Width = 50;
            // Name Column
            DataGridViewColumn columnName = this.debtorsDataGrid.Columns[1];
            columnName.Width = 200;
            // Since Column
            DataGridViewColumn columnSince = this.debtorsDataGrid.Columns[2];
            columnSince.Width = 140;
            // Due Column
            DataGridViewColumn columnDueDate = this.debtorsDataGrid.Columns[3];
            columnDueDate.Width = 140;
            // Amount Column
            DataGridViewColumn columnAmount = this.debtorsDataGrid.Columns[4];
            columnAmount.Width = 188;

            // Button customizations are made both in code and the UI.
            this.btnDebtors.FlatAppearance.BorderColor = Color.FromArgb(0, 208, 255);
            this.btnCreditors.FlatAppearance.BorderColor = Color.FromArgb(0, 208, 255);
            this.btnAdd.FlatAppearance.BorderColor = Color.FromArgb(0, 208, 255);
            this.btnEdit.FlatAppearance.BorderColor = Color.FromArgb(0, 208, 255);
            this.btnDetails.FlatAppearance.BorderColor = Color.FromArgb(0, 208, 255);
            this.btnDelete.FlatAppearance.BorderColor = Color.FromArgb(0, 208, 255);

            // Attaching an even which handles where the user has clicked.
            // If clicked outside the data grid view all selected rows are no longer selected and the focus is lost.
            this.mainPanel.MouseClick += new MouseEventHandler(RemoveDataGridSelection);
            this.menuPanel.MouseClick += new MouseEventHandler(RemoveDataGridSelection);
        }

        private void btnDebtors_Click(object sender, EventArgs e)
        {
            this.btnDebtors.Enabled = false;
            this.btnCreditors.Enabled = true;
            this.table.Rows.Clear();
            this.FillDataTable(TransactorsFilePath, TransactorType.Debtor);
            this.debtorsDataGrid.ClearSelection();
        }

        private void btnCreditors_Click(object sender, EventArgs e)
        {
            this.btnDebtors.Enabled = true;
            this.btnCreditors.Enabled = false;
            this.table.Rows.Clear();
            this.FillDataTable(TransactorsFilePath, TransactorType.Creditor);
            this.debtorsDataGrid.ClearSelection();
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            AddTransactorForm addTransactorForm = new AddTransactorForm();
            addTransactorForm.Show();

            // Disabling the main form while a subform is open.
            this.Enabled = false;

            // Event handler which will enable the main form if the add form is closed.
            addTransactorForm.FormClosed += new FormClosedEventHandler(FormClosed);
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            // TODO
            // I should create a separate form for this one.
        }

        private void btnDetails_Click(object sender, EventArgs e)
        {
            // TODO
            // And also a separate form for this which has labels with data
            // It also must have an edit button and delete button below.
            if (this.debtorsDataGrid.SelectedRows.Count == 1)
            {
                DetailsForm detailsForm = new DetailsForm();
                detailsForm.Show();

                this.Enabled = false;

                detailsForm.FormClosed += new FormClosedEventHandler(FormClosed);
            }
            else
            {
                // TODO
                // msg box show: it can only show 1 record at a time.
            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (this.debtorsDataGrid.SelectedRows.Count > 0)
            {
                DialogResult dialog = MessageBox.Show(MessageBoxText.DeleteConfirmation,
                   MessageBoxCaption.Confirm,
                   MessageBoxButtons.YesNo,
                   MessageBoxIcon.Question);

                if (dialog == DialogResult.Yes)
                {
                    // When doing the delete think
                    // I should change the No of all the remaining others in the same category.
                    // NEW

                    XDocument xmlDocument = XDocument.Load(TransactorsFilePath);
                    IEnumerable<XElement> debtors = xmlDocument.Element("Transactors")
                                                               .Elements("Transactor");
                    DataGridViewSelectedRowCollection selectedRows = this.debtorsDataGrid.SelectedRows;

                    if (!this.btnDebtors.Enabled)
                    {
                        // The user has the Debtors button as the selected button.
                        debtors = debtors.Where(x => x.Element("TransactorType").Value == "Debtor");

                        for (int i = 0; i < selectedRows.Count; i++)
                        {
                            string no = selectedRows[i].Cells[TableColumn.No].Value.ToString();
                            xmlDocument.Root.Elements().FirstOrDefault(x => x.Attribute("no").Value == no
                                                                       && x.Element("TransactorType").Value == "Debtor")
                                .Remove();
                        }
                    }
                    else if (!this.btnCreditors.Enabled)
                    {
                        // The user has the Creditors button as the selected button.
                        debtors = debtors.Where(x => x.Element("TransactorType").Value == "Creditor");

                        for (int i = 0; i < selectedRows.Count; i++)
                        {
                            string no = selectedRows[i].Cells[TableColumn.No].Value.ToString();
                            xmlDocument.Root.Elements().FirstOrDefault(x => x.Attribute("no").Value == no
                                                                       && x.Element("TransactorType").Value == "Creditor")
                                .Remove();
                        }
                    }

                    int noCounter = 1;

                    foreach (XElement debtor in debtors)
                    {
                        debtor.SetAttributeValue("no", noCounter++);
                    }

                    xmlDocument.Save(TransactorsFilePath);

                    // Refreshing the grid upon deletion.
                    this.table.Rows.Clear();

                    if (!this.btnDebtors.Enabled)
                    {
                        this.FillDataTable(TransactorsFilePath, TransactorType.Debtor);
                    }
                    else if (!this.btnCreditors.Enabled)
                    {
                        this.FillDataTable(TransactorsFilePath, TransactorType.Creditor);
                    }

                    this.debtorsDataGrid.DataSource = table;
                }
            }
        }

        private void FillDataTable(string path, TransactorType transactorType)
        {
            if (path == null)
            {
                throw new ArgumentNullException(ErrorMessage.PathCannotBeNull);
            }
            else if (!File.Exists(path))
            {
                throw new InvalidOperationException(ErrorMessage.FileDoesntExist);
            }

            IEnumerable<Transactor> transactors = XmlProcess.DeserializeXmlWithTransactorType(path, transactorType);

            foreach (Transactor transactor in transactors)
            {
                this.table.Rows.Add(
                    transactor.No,
                    transactor.Name,
                    transactor.Since,
                    transactor.DueDate,
                    $"{transactor.Amount:f2}");
            }
        }

        private void InitializeDataTable(DataTable table)
        {
            if (table == null)
            {
                throw new ArgumentNullException(ErrorMessage.DataTableCannotBeNull);
            }

            this.table.Columns.Add(TableColumn.No, typeof(int)); // No
            this.table.Columns.Add(TableColumn.Name, typeof(string)); // Name
            this.table.Columns.Add(TableColumn.Since, typeof(string)); // Since
            this.table.Columns.Add(TableColumn.DueDate, typeof(string)); // DueDate
            this.table.Columns.Add(TableColumn.Amount, typeof(string)); // Amount. (Actual Amount type is decimal.)
            // For the case of concating a currency symbol later on, the amount in the grid is of type string.
        }

        private void FormClosed(object sender, FormClosedEventArgs e)
        {
            // Enabling the main form and refreshing the Data Grid View.
            this.Enabled = true;
            this.table.Rows.Clear();

            if (!this.btnDebtors.Enabled)
            {
                // Problem: The scroll should stay in it's last position.
                // Thinking about how to fix it...
                this.FillDataTable(TransactorsFilePath, TransactorType.Debtor);

            }
            else if (!this.btnCreditors.Enabled)
            {
                this.FillDataTable(TransactorsFilePath, TransactorType.Creditor);
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
