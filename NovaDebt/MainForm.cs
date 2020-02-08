using AutoMapper;
using NovaDebt.Models;
using NovaDebt.Models.Contracts;
using NovaDebt.Models.Enums;
using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
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
            // Overwriting it always by incrementing with +1.
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
                    byte[] xmlRoot = new UTF8Encoding(true).GetBytes(DefaultXmlRootOpenClose);
                    fs.Write(xmlRoot, 0, xmlRoot.Length);
                }
            }

            // I should think about when the file exits but doesn't contain the xmlRoot itself inside it.
            // Or the QA guy will scream as always.
            // That is a problem which must be fixed or xml won't be able to find the root element.

            // Setting the source of the DataGridView.
            this.debtorsDataGrid.DataSource = table;
            // Data grid styling.
            this.debtorsDataGrid.AdvancedCellBorderStyle.All = DataGridViewAdvancedCellBorderStyle.None;

            // Customizing the columns/headers of the table
            // No Column
            DataGridViewColumn columnNo = debtorsDataGrid.Columns[0];
            columnNo.Width = 50;
            // Amount Column
            DataGridViewColumn columnAmount = debtorsDataGrid.Columns[5];
            columnAmount.Width = 120;

            // Button customizations are made both in code and the UI.
            this.btnDebtors.FlatAppearance.BorderColor = Color.FromArgb(0, 208, 255);
            this.btnCreditors.FlatAppearance.BorderColor = Color.FromArgb(0, 208, 255);
            this.btnAdd.FlatAppearance.BorderColor = Color.FromArgb(0, 208, 255);
            this.btnEdit.FlatAppearance.BorderColor = Color.FromArgb(0, 208, 255);
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
            AddTransactorForm frmAddTransactor = new AddTransactorForm();
            frmAddTransactor.Show();

            // Disabling the main form while a subform is open.
            this.Enabled = false;

            // Event handler which will enable the main form if the add form is closed.
            frmAddTransactor.FormClosed += new FormClosedEventHandler(FormClosed);
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            // TODO
            // I should create a separate form for this one.
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

                    // OLD
                    //DataGridViewSelectedRowCollection selectedRows = this.debtorsDataGrid.SelectedRows;
                    //List<int> nosList = new List<int>();

                    //for (int i = 0; i < selectedRows.Count; i++)
                    //{
                    //    object no = selectedRows[i].Cells[TableColumn.No].Value;
                    //    // Parsing the element since the no is object type
                    //    nosList.Add(int.Parse(no.ToString()));
                    //}

                    //nosList = nosList.OrderBy(x => x).ToList();

                    //// I should filter a new collection again depending on the seleted debtors/creditors button from the xml.
                    //// Then overwrite the file without the deleted data and refresh the data grid view.
                    //// Thus the data which the user has selected will be deleted and removed from the file.

                    //IEnumerable<Transactor> transactors = XmlProcess.DeserializeXml(TransactorsFilePath);
                    //List<Transactor> newTransactors = new List<Transactor>();

                    //if (!this.btnDebtors.Enabled)
                    //{
                    //    // User has the Debtors button as the selected button.
                    //    foreach (var transactor in transactors)
                    //    {
                    //        if (!nosList.Any(x => x == transactor.No)
                    //            && transactor.TransactorType == TransactorType.Debtor.ToString())
                    //        {
                    //            transactor.No = newTransactors.Count + 1;
                    //            newTransactors.Add(transactor);
                    //        }
                    //    }

                    //    // Adding all the creditors after the filtration of debtors so we don't have missing records.
                    //    newTransactors.AddRange(transactors.Where(t => t.TransactorType == TransactorType.Creditor.ToString()));
                    //}
                    //else if (!this.btnCreditors.Enabled)
                    //{
                    //    // User has the Creditors button as the selected button.
                    //    foreach (var transactor in transactors)
                    //    {
                    //        if (!nosList.Any(x => x == transactor.No)
                    //            && transactor.TransactorType == TransactorType.Creditor.ToString())
                    //        {
                    //            transactor.No = newTransactors.Count + 1;
                    //            newTransactors.Add(transactor);
                    //        }
                    //    }

                    //    // Adding all the debtors after the filtration of creditors so we don't have missing records.
                    //    newTransactors.AddRange(transactors.Where(t => t.TransactorType == TransactorType.Debtor.ToString()));
                    //}

                    //// Overwriting the transactors.xml file.
                    //// Overwriting the whole file here is needed since the debtors/creditors are being changed.
                    //XmlProcess.SerializeXmlWithTransactors(TransactorsFilePath, newTransactors);

                    //// Refreshing the grid.
                    //this.table.Rows.Clear();

                    //if (!this.btnDebtors.Enabled)
                    //{
                    //    this.FillDataTable(TransactorsFilePath, TransactorType.Debtor);

                    //}
                    //else if (!this.btnCreditors.Enabled)
                    //{
                    //    this.FillDataTable(TransactorsFilePath, TransactorType.Creditor);
                    //}

                    //this.debtorsDataGrid.DataSource = table;
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
                    transactor.PhoneNumber,
                    transactor.Email,
                    transactor.Facebook,
                    transactor.Amount + DefaultCurrencySymbol);
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
            this.table.Columns.Add(TableColumn.PhoneNumber, typeof(string)); // PhoneNumber
            this.table.Columns.Add(TableColumn.Email, typeof(string)); // Email
            this.table.Columns.Add(TableColumn.Facebook, typeof(string)); // Facebook
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
