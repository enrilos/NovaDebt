using System;
using System.Windows.Forms;

namespace NovaDebt
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle13 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle14 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle15 = new System.Windows.Forms.DataGridViewCellStyle();
            this.btnDebtors = new System.Windows.Forms.Button();
            this.btnCreditors = new System.Windows.Forms.Button();
            this.menuPanel = new System.Windows.Forms.Panel();
            this.novaDebtImage = new System.Windows.Forms.PictureBox();
            this.debtorsDataGrid = new System.Windows.Forms.DataGridView();
            this.btnAdd = new System.Windows.Forms.Button();
            this.btnEdit = new System.Windows.Forms.Button();
            this.btnDelete = new System.Windows.Forms.Button();
            this.mainPanel = new System.Windows.Forms.Panel();
            this.menuPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.novaDebtImage)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.debtorsDataGrid)).BeginInit();
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
            // debtorsDataGrid
            // 
            this.debtorsDataGrid.AllowUserToAddRows = false;
            this.debtorsDataGrid.AllowUserToDeleteRows = false;
            this.debtorsDataGrid.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.debtorsDataGrid.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(40)))), ((int)(((byte)(40)))));
            this.debtorsDataGrid.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.debtorsDataGrid.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.None;
            this.debtorsDataGrid.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            dataGridViewCellStyle13.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle13.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(40)))), ((int)(((byte)(40)))));
            dataGridViewCellStyle13.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            dataGridViewCellStyle13.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(208)))), ((int)(((byte)(255)))));
            dataGridViewCellStyle13.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(40)))), ((int)(((byte)(40)))));
            dataGridViewCellStyle13.SelectionForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(208)))), ((int)(((byte)(255)))));
            dataGridViewCellStyle13.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.debtorsDataGrid.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle13;
            this.debtorsDataGrid.ColumnHeadersHeight = 50;
            this.debtorsDataGrid.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            this.debtorsDataGrid.EnableHeadersVisualStyles = false;
            this.debtorsDataGrid.Location = new System.Drawing.Point(12, 9);
            this.debtorsDataGrid.Name = "debtorsDataGrid";
            this.debtorsDataGrid.ReadOnly = true;
            dataGridViewCellStyle14.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle14.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(40)))), ((int)(((byte)(40)))));
            dataGridViewCellStyle14.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            dataGridViewCellStyle14.ForeColor = System.Drawing.Color.WhiteSmoke;
            dataGridViewCellStyle14.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(40)))), ((int)(((byte)(40)))));
            dataGridViewCellStyle14.SelectionForeColor = System.Drawing.Color.WhiteSmoke;
            dataGridViewCellStyle14.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.debtorsDataGrid.RowHeadersDefaultCellStyle = dataGridViewCellStyle14;
            this.debtorsDataGrid.RowHeadersVisible = false;
            this.debtorsDataGrid.RowHeadersWidth = 51;
            dataGridViewCellStyle15.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle15.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(40)))), ((int)(((byte)(40)))));
            dataGridViewCellStyle15.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle15.ForeColor = System.Drawing.Color.WhiteSmoke;
            dataGridViewCellStyle15.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(208)))), ((int)(((byte)(255)))));
            dataGridViewCellStyle15.SelectionForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(47)))), ((int)(((byte)(47)))), ((int)(((byte)(47)))));
            this.debtorsDataGrid.RowsDefaultCellStyle = dataGridViewCellStyle15;
            this.debtorsDataGrid.RowTemplate.Height = 50;
            this.debtorsDataGrid.RowTemplate.ReadOnly = true;
            this.debtorsDataGrid.RowTemplate.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.debtorsDataGrid.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.debtorsDataGrid.Size = new System.Drawing.Size(828, 400);
            this.debtorsDataGrid.TabIndex = 0;
            this.debtorsDataGrid.TabStop = false;
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
            this.btnAdd.Location = new System.Drawing.Point(12, 425);
            this.btnAdd.Name = "btnAdd";
            this.btnAdd.Size = new System.Drawing.Size(208, 90);
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
            this.btnEdit.Location = new System.Drawing.Point(226, 425);
            this.btnEdit.Name = "btnEdit";
            this.btnEdit.Size = new System.Drawing.Size(208, 90);
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
            this.btnDelete.Location = new System.Drawing.Point(632, 425);
            this.btnDelete.Name = "btnDelete";
            this.btnDelete.Size = new System.Drawing.Size(208, 90);
            this.btnDelete.TabIndex = 0;
            this.btnDelete.TabStop = false;
            this.btnDelete.Text = "Изтрий";
            this.btnDelete.UseVisualStyleBackColor = true;
            this.btnDelete.Click += new System.EventHandler(this.btnDelete_Click);
            // 
            // mainPanel
            // 
            this.mainPanel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(29)))), ((int)(((byte)(29)))), ((int)(((byte)(29)))));
            this.mainPanel.Controls.Add(this.btnDelete);
            this.mainPanel.Controls.Add(this.btnEdit);
            this.mainPanel.Controls.Add(this.btnAdd);
            this.mainPanel.Controls.Add(this.debtorsDataGrid);
            this.mainPanel.Location = new System.Drawing.Point(212, 0);
            this.mainPanel.Name = "mainPanel";
            this.mainPanel.Size = new System.Drawing.Size(851, 528);
            this.mainPanel.TabIndex = 3;
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
            this.Text = "NovaDebt";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.menuPanel.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.novaDebtImage)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.debtorsDataGrid)).EndInit();
            this.mainPanel.ResumeLayout(false);
            this.ResumeLayout(false);

        }


        #endregion

        private System.Windows.Forms.Button btnDebtors;
        private System.Windows.Forms.Button btnCreditors;
        private System.Windows.Forms.Panel menuPanel;
        private PictureBox novaDebtImage;
        private DataGridView debtorsDataGrid;
        private Button btnAdd;
        private Button btnEdit;
        private Button btnDelete;
        private Panel mainPanel;
    }
}

