﻿using System;
using System.Windows.Forms;

namespace NovaDebt
{
    partial class Form1
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            this.btnDebtors = new System.Windows.Forms.Button();
            this.btnCreditors = new System.Windows.Forms.Button();
            this.menuPanel = new System.Windows.Forms.Panel();
            this.titleLabel = new System.Windows.Forms.Label();
            this.dataPanel = new System.Windows.Forms.Panel();
            this.debtorsDataGrid = new System.Windows.Forms.DataGridView();
            this.menuPanel.SuspendLayout();
            this.dataPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.debtorsDataGrid)).BeginInit();
            this.SuspendLayout();
            // 
            // btnDebtors
            // 
            this.btnDebtors.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(50)))), ((int)(((byte)(50)))), ((int)(((byte)(50)))));
            this.btnDebtors.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(208)))), ((int)(((byte)(255)))));
            this.btnDebtors.FlatAppearance.BorderSize = 0;
            this.btnDebtors.FlatAppearance.MouseDownBackColor = System.Drawing.Color.White;
            this.btnDebtors.FlatAppearance.MouseOverBackColor = System.Drawing.Color.White;
            this.btnDebtors.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnDebtors.Font = new System.Drawing.Font("Raleway Light", 16.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.btnDebtors.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(208)))), ((int)(((byte)(255)))));
            this.btnDebtors.Location = new System.Drawing.Point(0, 113);
            this.btnDebtors.Name = "btnDebtors";
            this.btnDebtors.Size = new System.Drawing.Size(218, 71);
            this.btnDebtors.TabIndex = 0;
            this.btnDebtors.Text = "Дебитори";
            this.btnDebtors.UseVisualStyleBackColor = false;
            this.btnDebtors.Click += new System.EventHandler(this.btnDebtors_Click);
            // 
            // btnCreditors
            // 
            this.btnCreditors.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(208)))), ((int)(((byte)(255)))));
            this.btnCreditors.FlatAppearance.BorderSize = 0;
            this.btnCreditors.FlatAppearance.MouseDownBackColor = System.Drawing.Color.White;
            this.btnCreditors.FlatAppearance.MouseOverBackColor = System.Drawing.Color.White;
            this.btnCreditors.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnCreditors.Font = new System.Drawing.Font("Raleway Light", 16.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCreditors.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(208)))), ((int)(((byte)(255)))));
            this.btnCreditors.Location = new System.Drawing.Point(0, 190);
            this.btnCreditors.Name = "btnCreditors";
            this.btnCreditors.Size = new System.Drawing.Size(218, 71);
            this.btnCreditors.TabIndex = 1;
            this.btnCreditors.Text = "Кредитори";
            this.btnCreditors.UseVisualStyleBackColor = false;
            this.btnCreditors.Click += new System.EventHandler(this.btnCreditors_Click);
            // 
            // menuPanel
            // 
            this.menuPanel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(50)))), ((int)(((byte)(50)))), ((int)(((byte)(50)))));
            this.menuPanel.Controls.Add(this.titleLabel);
            this.menuPanel.Controls.Add(this.btnDebtors);
            this.menuPanel.Controls.Add(this.btnCreditors);
            this.menuPanel.Dock = System.Windows.Forms.DockStyle.Left;
            this.menuPanel.Location = new System.Drawing.Point(0, 0);
            this.menuPanel.Name = "menuPanel";
            this.menuPanel.Size = new System.Drawing.Size(214, 528);
            this.menuPanel.TabIndex = 2;
            // 
            // titleLabel
            // 
            this.titleLabel.AutoSize = true;
            this.titleLabel.Font = new System.Drawing.Font("Raleway Light", 24.5F);
            this.titleLabel.ForeColor = System.Drawing.SystemColors.Window;
            this.titleLabel.Location = new System.Drawing.Point(3, 9);
            this.titleLabel.Name = "titleLabel";
            this.titleLabel.Size = new System.Drawing.Size(211, 49);
            this.titleLabel.TabIndex = 2;
            this.titleLabel.Text = "NovaDebt";
            // 
            // dataPanel
            // 
            this.dataPanel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(29)))), ((int)(((byte)(29)))), ((int)(((byte)(29)))));
            this.dataPanel.Controls.Add(this.debtorsDataGrid);
            this.dataPanel.Location = new System.Drawing.Point(212, 0);
            this.dataPanel.Name = "dataPanel";
            this.dataPanel.Size = new System.Drawing.Size(851, 528);
            this.dataPanel.TabIndex = 3;
            // 
            // debtorsDataGrid
            // 
            this.debtorsDataGrid.AllowUserToAddRows = false;
            this.debtorsDataGrid.AllowUserToDeleteRows = false;
            this.debtorsDataGrid.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.debtorsDataGrid.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(50)))), ((int)(((byte)(50)))), ((int)(((byte)(50)))));
            this.debtorsDataGrid.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.debtorsDataGrid.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.None;
            this.debtorsDataGrid.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(50)))), ((int)(((byte)(50)))), ((int)(((byte)(50)))));
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(208)))), ((int)(((byte)(255)))));
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(50)))), ((int)(((byte)(50)))), ((int)(((byte)(50)))));
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(208)))), ((int)(((byte)(255)))));
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.debtorsDataGrid.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.debtorsDataGrid.ColumnHeadersHeight = 50;
            this.debtorsDataGrid.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            this.debtorsDataGrid.EnableHeadersVisualStyles = false;
            this.debtorsDataGrid.Location = new System.Drawing.Point(12, 9);
            this.debtorsDataGrid.Name = "debtorsDataGrid";
            this.debtorsDataGrid.ReadOnly = true;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(50)))), ((int)(((byte)(50)))), ((int)(((byte)(50)))));
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.Color.WhiteSmoke;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(50)))), ((int)(((byte)(50)))), ((int)(((byte)(50)))));
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.Color.WhiteSmoke;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.debtorsDataGrid.RowHeadersDefaultCellStyle = dataGridViewCellStyle2;
            this.debtorsDataGrid.RowHeadersVisible = false;
            this.debtorsDataGrid.RowHeadersWidth = 51;
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(50)))), ((int)(((byte)(50)))), ((int)(((byte)(50)))));
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle3.ForeColor = System.Drawing.Color.WhiteSmoke;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(208)))), ((int)(((byte)(255)))));
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(47)))), ((int)(((byte)(47)))), ((int)(((byte)(47)))));
            this.debtorsDataGrid.RowsDefaultCellStyle = dataGridViewCellStyle3;
            this.debtorsDataGrid.RowTemplate.Height = 50;
            this.debtorsDataGrid.RowTemplate.ReadOnly = true;
            this.debtorsDataGrid.RowTemplate.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.debtorsDataGrid.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.debtorsDataGrid.Size = new System.Drawing.Size(828, 400);
            this.debtorsDataGrid.TabIndex = 0;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(1063, 528);
            this.Controls.Add(this.dataPanel);
            this.Controls.Add(this.menuPanel);
            this.MaximumSize = new System.Drawing.Size(1081, 575);
            this.MinimumSize = new System.Drawing.Size(1081, 575);
            this.Name = "Form1";
            this.Text = "NovaDebt";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.menuPanel.ResumeLayout(false);
            this.menuPanel.PerformLayout();
            this.dataPanel.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.debtorsDataGrid)).EndInit();
            this.ResumeLayout(false);

        }


        #endregion

        private System.Windows.Forms.Button btnDebtors;
        private System.Windows.Forms.Button btnCreditors;
        private System.Windows.Forms.Panel menuPanel;
        private System.Windows.Forms.Label titleLabel;
        private System.Windows.Forms.Panel dataPanel;
        private System.Windows.Forms.DataGridView debtorsDataGrid;
    }
}

