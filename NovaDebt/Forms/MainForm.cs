using AutoMapper;
using NovaDebt.Models;
using NovaDebt.Models.Enums;
using System;
using System.Collections.Generic;
using System.Data;
using System.Diagnostics;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Windows.Forms;
using System.Xml.Linq;

using static NovaDebt.DataSettings;

namespace NovaDebt.Forms
{
    public partial class MainForm : Form
    {
        private DataTable table;

        public MainForm()
        {
            // Checking if there is another thread of this application.
            Process[] processes = Process.GetProcessesByName(ApplicationName);

            if (processes.Length > 1)
            {
                Environment.Exit(0);
            }

            InitializeComponent();
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            Thread.CurrentThread.CurrentCulture = CultureInfo.InvariantCulture;

            // Static Mapper.
            // Initializing a profile class which contains mapping configurations inside.
            // Version of AutoMapper which is used: 7.0.1
            // NOTE: Newer versions of the AutoMapper don't use the static Mapper class.
            Mapper
                .Initialize(cfg => cfg.AddProfile<NovaDebtProfile>());

            this.table = new DataTable();
            this.InitializeDataTable(this.table);

            // Creating an uninstaller bat file
            if (!File.Exists(UninstallerFilePath))
            {
                using (FileStream fs = File.Create(UninstallerFilePath))
                {
                    byte[] bash = new UTF8Encoding(true).GetBytes(UninstallerSeed);
                    fs.Write(bash, 0, bash.Length);
                }
            }

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

            // Always writing the root element if the transactors file is empty or after creation just in case.
            // Otherwise xml doesn't like it and throws an exception ~ MissingRootElement.
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
            this.transactorsDataGrid.DataSource = table;
            // Data grid styling.
            this.transactorsDataGrid.AdvancedCellBorderStyle.All = DataGridViewAdvancedCellBorderStyle.None;

            // Customizing the columns/headers of the table
            // No Column
            DataGridViewColumn columnNo = this.transactorsDataGrid.Columns[0];
            columnNo.Width = 50;
            // Name Column
            DataGridViewColumn columnName = this.transactorsDataGrid.Columns[1];
            columnName.Width = 200;
            // Since Column
            DataGridViewColumn columnSince = this.transactorsDataGrid.Columns[2];
            columnSince.Width = 140;
            // Due Column
            DataGridViewColumn columnDueDate = this.transactorsDataGrid.Columns[3];
            columnDueDate.Width = 140;
            // Amount Column
            DataGridViewColumn columnAmount = this.transactorsDataGrid.Columns[4];
            columnAmount.Width = 190;

            // Button customizations are made both in code and the UI.
            // Font - Primary Buttons
            this.btnDebtors.Font = DefaultFontSixteen;
            this.btnCreditors.Font = DefaultFontSixteen;
            this.btnAdd.Font = DefaultFontSixteen;
            this.btnEdit.Font = DefaultFontSixteen;
            this.btnDetails.Font = DefaultFontSixteen;
            this.btnDelete.Font = DefaultFontSixteen;

            // BorderColor
            this.btnDebtors.FlatAppearance.BorderColor = DefaultButtonColor;
            this.btnCreditors.FlatAppearance.BorderColor = DefaultButtonColor;
            this.btnAdd.FlatAppearance.BorderColor = DefaultButtonColor;
            this.btnEdit.FlatAppearance.BorderColor = DefaultButtonColor;
            this.btnDetails.FlatAppearance.BorderColor = DefaultButtonColor;
            this.btnDelete.FlatAppearance.BorderColor = DefaultButtonColor;

            // Attaching an even which handles where the user has clicked.
            // If clicked outside the data grid view all selected rows are no longer selected and the focus is lost.
            this.novaDebtImage.MouseClick += new MouseEventHandler(RemoveDataGridSelection);
            this.mainPanel.MouseClick += new MouseEventHandler(RemoveDataGridSelection);
            this.menuPanel.MouseClick += new MouseEventHandler(RemoveDataGridSelection);
        }

        private void btnDebtors_Click(object sender, EventArgs e)
        {
            this.btnDebtors.Enabled = false;
            this.btnCreditors.Enabled = true;
            this.table.Rows.Clear();
            this.FillDataTable(TransactorsFilePath, TransactorType.Debtor);
            this.transactorsDataGrid.ClearSelection();
        }

        private void btnCreditors_Click(object sender, EventArgs e)
        {
            this.btnDebtors.Enabled = true;
            this.btnCreditors.Enabled = false;
            this.table.Rows.Clear();
            this.FillDataTable(TransactorsFilePath, TransactorType.Creditor);
            this.transactorsDataGrid.ClearSelection();
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            AddTransactorForm addTransactorForm = new AddTransactorForm();
            addTransactorForm.Show();

            // Disabling the main form while a subform is open.
            this.Enabled = false;

            // Event handler which will enable the main form if the add form is closed.
            addTransactorForm.FormClosed += new FormClosedEventHandler(FormClosedAction);
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            if (this.transactorsDataGrid.SelectedRows.Count == 1)
            {
                XDocument xmlDocument = XDocument.Load(TransactorsFilePath);
                IEnumerable<XElement> transactors = xmlDocument.Element(XmlRoot)
                                                           .Elements(XmlElement);

                DataGridViewSelectedRowCollection selectedRows = this.transactorsDataGrid.SelectedRows;
                string no = selectedRows[0].Cells[TableColumn.No].Value.ToString();

                XElement transactor = null;

                if (!this.btnDebtors.Enabled)
                {
                    // The user has the Debtors button as the selected button.
                    transactor = transactors.Where(x => x.Attribute("no").Value == no
                                            && x.Element("TransactorType").Value == "Debtor")
                        .FirstOrDefault();
                }
                else if (!this.btnCreditors.Enabled)
                {
                    // The user has the Creditors button as the selected button.
                    transactor = transactors.Where(x => x.Attribute("no").Value == no
                                            && x.Element("TransactorType").Value == "Creditor")
                        .FirstOrDefault();
                }

                EditTransactorForm editTransactorForm = new EditTransactorForm(
                    this,
                    int.Parse(transactor.Attribute("no").Value),
                    transactor.Element("Name").Value,
                    transactor.Element("Since").Value,
                    transactor.Element("DueDate").Value,
                    transactor.Element("PhoneNumber").Value,
                    transactor.Element("Email").Value,
                    transactor.Element("Facebook").Value,
                    decimal.Parse(transactor.Element("Amount").Value),
                    transactor.Element("TransactorType").Value);

                editTransactorForm.Show();
                this.Enabled = false;
                editTransactorForm.FormClosed += new FormClosedEventHandler(FormClosedAction);
            }
            else
            {
                MessageBox.Show(ErrorMessage.EditOverOneSelectedRecords,
                    MessageBoxCaption.Error,
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);

                return;
            }
        }

        private void btnDetails_Click(object sender, EventArgs e)
        {
            if (this.transactorsDataGrid.SelectedRows.Count == 1)
            {
                XDocument xmlDocument = XDocument.Load(TransactorsFilePath);
                IEnumerable<XElement> transactors = xmlDocument.Element(XmlRoot)
                                                           .Elements(XmlElement);

                DataGridViewSelectedRowCollection selectedRows = this.transactorsDataGrid.SelectedRows;
                string no = selectedRows[0].Cells[TableColumn.No].Value.ToString();
                XElement transactor = null;

                if (!this.btnDebtors.Enabled)
                {
                    // The user has the Debtors button as the selected button.
                    transactor = transactors.Where(x => x.Attribute("no").Value == no
                                            && x.Element("TransactorType").Value == "Debtor")
                        .FirstOrDefault();
                }
                else if (!this.btnCreditors.Enabled)
                {
                    // The user has the Creditors button as the selected button.
                    transactor = transactors.Where(x => x.Attribute("no").Value == no
                                            && x.Element("TransactorType").Value == "Creditor")
                        .FirstOrDefault();
                }

                DetailsForm detailsForm = new DetailsForm(
                    this,
                    int.Parse(transactor.Attribute("no").Value),
                    transactor.Element("Name").Value,
                    transactor.Element("Since").Value,
                    transactor.Element("DueDate").Value,
                    transactor.Element("PhoneNumber").Value,
                    transactor.Element("Email").Value,
                    transactor.Element("Facebook").Value,
                    decimal.Parse(transactor.Element("Amount").Value),
                    transactor.Element("TransactorType").Value);

                detailsForm.Show();
                this.Enabled = false;
                detailsForm.FormClosed += new FormClosedEventHandler(FormClosedAction);
            }
            else
            {
                MessageBox.Show(ErrorMessage.DetailsOverOneSelectedRecords,
                    MessageBoxCaption.Error,
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);

                return;
            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (this.transactorsDataGrid.SelectedRows.Count > 0)
            {
                DialogResult dialog = MessageBox.Show(MessageBoxText.DeleteConfirmationPlural,
                   MessageBoxCaption.Confirm,
                   MessageBoxButtons.YesNo,
                   MessageBoxIcon.Question);

                if (dialog == DialogResult.Yes)
                {
                    XDocument xmlDocument = XDocument.Load(TransactorsFilePath);
                    IEnumerable<XElement> debtors = xmlDocument.Element(XmlRoot)
                                                               .Elements(XmlElement);
                    DataGridViewSelectedRowCollection selectedRows = this.transactorsDataGrid.SelectedRows;

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

                    // Setting the id -1 for each record in the selected transactors collection.
                    foreach (XElement debtor in debtors)
                    {
                        debtor.SetAttributeValue("no", noCounter++);
                    }

                    xmlDocument.Save(TransactorsFilePath, SaveOptions.DisableFormatting);

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

                    this.transactorsDataGrid.DataSource = table;
                }
            }
        }

        private void FillDataTable(string path, TransactorType transactorType)
        {
            if (path == null)
            {
                throw new NullReferenceException(ErrorMessage.PathCannotBeNull);
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
                throw new NullReferenceException(ErrorMessage.DataTableCannotBeNull);
            }

            this.table.Columns.Add(TableColumn.No, typeof(int)); // №
            this.table.Columns.Add(TableColumn.Name, typeof(string)); // Име
            this.table.Columns.Add(TableColumn.Since, typeof(string)); // От
            this.table.Columns.Add(TableColumn.DueDate, typeof(string)); // До
            this.table.Columns.Add(TableColumn.Amount, typeof(string)); // Количество в лв.
        }

        private void FormClosedAction(object sender, FormClosedEventArgs e)
        {
            // This check if necessary so when the user has clicked the edit button in the Details section
            // the main forms remains disabled.
            foreach (Form form in Application.OpenForms)
            {
                if (form.Name == "EditTransactorForm")
                {
                    return;
                }
            }

            this.EnableMainFormAndRefreshDataGrid(this);
        }

        private void RemoveDataGridSelection(object sender, MouseEventArgs e)
        {
            this.transactorsDataGrid.ClearSelection();
        }

        public void EnableMainFormAndRefreshDataGrid(MainForm mainForm)
        {
            mainForm.Enabled = true;
            mainForm.table.Rows.Clear();

            if (!mainForm.btnDebtors.Enabled)
            {
                mainForm.FillDataTable(TransactorsFilePath, TransactorType.Debtor);

            }
            else if (!mainForm.btnCreditors.Enabled)
            {
                mainForm.FillDataTable(TransactorsFilePath, TransactorType.Creditor);
            }

            mainForm.transactorsDataGrid.DataSource = table;
            mainForm.transactorsDataGrid.ClearSelection();
        }
    }
}
