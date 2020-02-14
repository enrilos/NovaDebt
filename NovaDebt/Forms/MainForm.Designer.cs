using System.Windows.Forms;

namespace NovaDebt.Forms
{
    partial class MainForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            this.btnDebtors = new System.Windows.Forms.Button();
            this.btnCreditors = new System.Windows.Forms.Button();
            this.menuPanel = new System.Windows.Forms.Panel();
            this.novaDebtImage = new System.Windows.Forms.PictureBox();
            this.transactorsDataGrid = new System.Windows.Forms.DataGridView();
            this.btnAdd = new System.Windows.Forms.Button();
            this.btnEdit = new System.Windows.Forms.Button();
            this.btnDelete = new System.Windows.Forms.Button();
            this.mainPanel = new System.Windows.Forms.Panel();
            this.btnDetails = new System.Windows.Forms.Button();
            this.menuPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.novaDebtImage)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.transactorsDataGrid)).BeginInit();
            this.mainPanel.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnDebtors
            // 
            this.btnDebtors.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(50)))), ((int)(((byte)(50)))), ((int)(((byte)(50)))));
            this.btnDebtors.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(208)))), ((int)(((byte)(255)))));
            this.btnDebtors.FlatAppearance.MouseDownBackColor = System.Drawing.Color.White;
            this.btnDebtors.FlatAppearance.MouseOverBackColor = System.Drawing.Color.White;
            this.btnDebtors.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnDebtors.Font = new System.Drawing.Font("Century Gothic", 16.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnDebtors.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(208)))), ((int)(((byte)(255)))));
            this.btnDebtors.Location = new System.Drawing.Point(0, 144);
            this.btnDebtors.Name = "btnDebtors";
            this.btnDebtors.Size = new System.Drawing.Size(212, 90);
            this.btnDebtors.TabIndex = 0;
            this.btnDebtors.TabStop = false;
            this.btnDebtors.Text = "Дебитори";
            this.btnDebtors.UseVisualStyleBackColor = false;
            this.btnDebtors.Click += new System.EventHandler(this.btnDebtors_Click);
            // 
            // btnCreditors
            // 
            this.btnCreditors.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(50)))), ((int)(((byte)(50)))), ((int)(((byte)(50)))));
            this.btnCreditors.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(208)))), ((int)(((byte)(255)))));
            this.btnCreditors.FlatAppearance.MouseDownBackColor = System.Drawing.Color.White;
            this.btnCreditors.FlatAppearance.MouseOverBackColor = System.Drawing.Color.White;
            this.btnCreditors.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCreditors.Font = new System.Drawing.Font("Century Gothic", 16.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.btnCreditors.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(208)))), ((int)(((byte)(255)))));
            this.btnCreditors.Location = new System.Drawing.Point(0, 240);
            this.btnCreditors.Name = "btnCreditors";
            this.btnCreditors.Size = new System.Drawing.Size(212, 90);
            this.btnCreditors.TabIndex = 0;
            this.btnCreditors.TabStop = false;
            this.btnCreditors.Text = "Кредитори";
            this.btnCreditors.UseVisualStyleBackColor = false;
            this.btnCreditors.Click += new System.EventHandler(this.btnCreditors_Click);
            // 
            // menuPanel
            // 
            this.menuPanel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(50)))), ((int)(((byte)(50)))), ((int)(((byte)(50)))));
            this.menuPanel.Controls.Add(this.novaDebtImage);
            this.menuPanel.Controls.Add(this.btnDebtors);
            this.menuPanel.Controls.Add(this.btnCreditors);
            this.menuPanel.Dock = System.Windows.Forms.DockStyle.Left;
            this.menuPanel.Location = new System.Drawing.Point(0, 0);
            this.menuPanel.Name = "menuPanel";
            this.menuPanel.Size = new System.Drawing.Size(214, 528);
            this.menuPanel.TabIndex = 2;
            // 
            // novaDebtImage
            // 
            this.novaDebtImage.Image = ((System.Drawing.Image)(resources.GetObject("novaDebtImage.Image")));
            this.novaDebtImage.Location = new System.Drawing.Point(6, 9);
            this.novaDebtImage.Name = "novaDebtImage";
            this.novaDebtImage.Size = new System.Drawing.Size(200, 90);
            this.novaDebtImage.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.novaDebtImage.TabIndex = 3;
            this.novaDebtImage.TabStop = false;
            // 
            // transactorsDataGrid
            // 
            this.transactorsDataGrid.AllowUserToAddRows = false;
            this.transactorsDataGrid.AllowUserToDeleteRows = false;
            this.transactorsDataGrid.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.transactorsDataGrid.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(40)))), ((int)(((byte)(40)))));
            this.transactorsDataGrid.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.transactorsDataGrid.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.None;
            this.transactorsDataGrid.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(40)))), ((int)(((byte)(40)))));
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(208)))), ((int)(((byte)(255)))));
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(40)))), ((int)(((byte)(40)))));
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(208)))), ((int)(((byte)(255)))));
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.transactorsDataGrid.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.transactorsDataGrid.ColumnHeadersHeight = 50;
            this.transactorsDataGrid.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            this.transactorsDataGrid.EnableHeadersVisualStyles = false;
            this.transactorsDataGrid.Location = new System.Drawing.Point(12, 9);
            this.transactorsDataGrid.Name = "transactorsDataGrid";
            this.transactorsDataGrid.ReadOnly = true;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(40)))), ((int)(((byte)(40)))));
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.Color.WhiteSmoke;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(40)))), ((int)(((byte)(40)))));
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.Color.WhiteSmoke;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.transactorsDataGrid.RowHeadersDefaultCellStyle = dataGridViewCellStyle2;
            this.transactorsDataGrid.RowHeadersVisible = false;
            this.transactorsDataGrid.RowHeadersWidth = 51;
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(40)))), ((int)(((byte)(40)))));
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle3.ForeColor = System.Drawing.Color.WhiteSmoke;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(208)))), ((int)(((byte)(255)))));
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(47)))), ((int)(((byte)(47)))), ((int)(((byte)(47)))));
            this.transactorsDataGrid.RowsDefaultCellStyle = dataGridViewCellStyle3;
            this.transactorsDataGrid.RowTemplate.Height = 50;
            this.transactorsDataGrid.RowTemplate.ReadOnly = true;
            this.transactorsDataGrid.RowTemplate.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.transactorsDataGrid.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.transactorsDataGrid.Size = new System.Drawing.Size(828, 400);
            this.transactorsDataGrid.TabIndex = 0;
            this.transactorsDataGrid.TabStop = false;
            // 
            // btnAdd
            // 
            this.btnAdd.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.btnAdd.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(208)))), ((int)(((byte)(255)))));
            this.btnAdd.FlatAppearance.MouseDownBackColor = System.Drawing.Color.White;
            this.btnAdd.FlatAppearance.MouseOverBackColor = System.Drawing.Color.White;
            this.btnAdd.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnAdd.Font = new System.Drawing.Font("Century Gothic", 16.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.btnAdd.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(208)))), ((int)(((byte)(255)))));
            this.btnAdd.Location = new System.Drawing.Point(12, 426);
            this.btnAdd.Name = "btnAdd";
            this.btnAdd.Size = new System.Drawing.Size(203, 90);
            this.btnAdd.TabIndex = 0;
            this.btnAdd.TabStop = false;
            this.btnAdd.Text = "Добави";
            this.btnAdd.UseVisualStyleBackColor = true;
            this.btnAdd.Click += new System.EventHandler(this.btnAdd_Click);
            // 
            // btnEdit
            // 
            this.btnEdit.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.btnEdit.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(208)))), ((int)(((byte)(255)))));
            this.btnEdit.FlatAppearance.MouseDownBackColor = System.Drawing.Color.White;
            this.btnEdit.FlatAppearance.MouseOverBackColor = System.Drawing.Color.White;
            this.btnEdit.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnEdit.Font = new System.Drawing.Font("Century Gothic", 16.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.btnEdit.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(208)))), ((int)(((byte)(255)))));
            this.btnEdit.Location = new System.Drawing.Point(221, 426);
            this.btnEdit.Name = "btnEdit";
            this.btnEdit.Size = new System.Drawing.Size(202, 90);
            this.btnEdit.TabIndex = 0;
            this.btnEdit.TabStop = false;
            this.btnEdit.Text = "Редактирай";
            this.btnEdit.UseVisualStyleBackColor = true;
            this.btnEdit.Click += new System.EventHandler(this.btnEdit_Click);
            // 
            // btnDelete
            // 
            this.btnDelete.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.btnDelete.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(208)))), ((int)(((byte)(255)))));
            this.btnDelete.FlatAppearance.MouseDownBackColor = System.Drawing.Color.White;
            this.btnDelete.FlatAppearance.MouseOverBackColor = System.Drawing.Color.White;
            this.btnDelete.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnDelete.Font = new System.Drawing.Font("Century Gothic", 16.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.btnDelete.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(208)))), ((int)(((byte)(255)))));
            this.btnDelete.Location = new System.Drawing.Point(637, 426);
            this.btnDelete.Name = "btnDelete";
            this.btnDelete.Size = new System.Drawing.Size(203, 90);
            this.btnDelete.TabIndex = 0;
            this.btnDelete.TabStop = false;
            this.btnDelete.Text = "Изтрий";
            this.btnDelete.UseVisualStyleBackColor = true;
            this.btnDelete.Click += new System.EventHandler(this.btnDelete_Click);
            // 
            // mainPanel
            // 
            this.mainPanel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(29)))), ((int)(((byte)(29)))), ((int)(((byte)(29)))));
            this.mainPanel.Controls.Add(this.btnDetails);
            this.mainPanel.Controls.Add(this.btnDelete);
            this.mainPanel.Controls.Add(this.btnEdit);
            this.mainPanel.Controls.Add(this.btnAdd);
            this.mainPanel.Controls.Add(this.transactorsDataGrid);
            this.mainPanel.Location = new System.Drawing.Point(212, 0);
            this.mainPanel.Name = "mainPanel";
            this.mainPanel.Size = new System.Drawing.Size(851, 528);
            this.mainPanel.TabIndex = 3;
            // 
            // btnDetails
            // 
            this.btnDetails.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.btnDetails.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(208)))), ((int)(((byte)(255)))));
            this.btnDetails.FlatAppearance.MouseDownBackColor = System.Drawing.Color.White;
            this.btnDetails.FlatAppearance.MouseOverBackColor = System.Drawing.Color.White;
            this.btnDetails.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnDetails.Font = new System.Drawing.Font("Century Gothic", 16.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.btnDetails.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(208)))), ((int)(((byte)(255)))));
            this.btnDetails.Location = new System.Drawing.Point(429, 426);
            this.btnDetails.Name = "btnDetails";
            this.btnDetails.Size = new System.Drawing.Size(202, 90);
            this.btnDetails.TabIndex = 1;
            this.btnDetails.TabStop = false;
            this.btnDetails.Text = "Детайли";
            this.btnDetails.UseVisualStyleBackColor = true;
            this.btnDetails.Click += new System.EventHandler(this.btnDetails_Click);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(1063, 528);
            this.Controls.Add(this.mainPanel);
            this.Controls.Add(this.menuPanel);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximumSize = new System.Drawing.Size(1081, 575);
            this.MinimumSize = new System.Drawing.Size(1081, 575);
            this.Name = "MainForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "NovaDebt";
            this.Load += new System.EventHandler(this.MainForm_Load);
            this.menuPanel.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.novaDebtImage)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.transactorsDataGrid)).EndInit();
            this.mainPanel.ResumeLayout(false);
            this.ResumeLayout(false);

        }


        #endregion

        private System.Windows.Forms.Button btnDebtors;
        private System.Windows.Forms.Button btnCreditors;
        private System.Windows.Forms.Panel menuPanel;
        private PictureBox novaDebtImage;
        private DataGridView transactorsDataGrid;
        private Button btnAdd;
        private Button btnEdit;
        private Button btnDelete;
        private Panel mainPanel;
        private Button btnDetails;
    }
}

