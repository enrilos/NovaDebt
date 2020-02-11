namespace NovaDebt
{
    partial class DetailsForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(DetailsForm));
            this.detailsBtnDelete = new System.Windows.Forms.Button();
            this.detailsBtnEdit = new System.Windows.Forms.Button();
            this.detailsNameLabel = new System.Windows.Forms.Label();
            this.detailsPhoneLabel = new System.Windows.Forms.Label();
            this.detailsEmailLabel = new System.Windows.Forms.Label();
            this.detailsFacebookLabel = new System.Windows.Forms.Label();
            this.detailsAmountLabel = new System.Windows.Forms.Label();
            this.detailsSinceLabel = new System.Windows.Forms.Label();
            this.detailsDueDateLabel = new System.Windows.Forms.Label();
            this.detailsTransactorTypeLabel = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // detailsBtnDelete
            // 
            this.detailsBtnDelete.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.detailsBtnDelete.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(208)))), ((int)(((byte)(255)))));
            this.detailsBtnDelete.FlatAppearance.MouseDownBackColor = System.Drawing.Color.White;
            this.detailsBtnDelete.FlatAppearance.MouseOverBackColor = System.Drawing.Color.White;
            this.detailsBtnDelete.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.detailsBtnDelete.Font = new System.Drawing.Font("Century Gothic", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.detailsBtnDelete.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(208)))), ((int)(((byte)(255)))));
            this.detailsBtnDelete.Location = new System.Drawing.Point(618, 373);
            this.detailsBtnDelete.Name = "detailsBtnDelete";
            this.detailsBtnDelete.Size = new System.Drawing.Size(170, 65);
            this.detailsBtnDelete.TabIndex = 8;
            this.detailsBtnDelete.Text = "Изтрий";
            this.detailsBtnDelete.UseVisualStyleBackColor = true;
            this.detailsBtnDelete.Click += new System.EventHandler(this.detailsBtnDelete_Click);
            // 
            // detailsBtnEdit
            // 
            this.detailsBtnEdit.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.detailsBtnEdit.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(208)))), ((int)(((byte)(255)))));
            this.detailsBtnEdit.FlatAppearance.MouseDownBackColor = System.Drawing.Color.White;
            this.detailsBtnEdit.FlatAppearance.MouseOverBackColor = System.Drawing.Color.White;
            this.detailsBtnEdit.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.detailsBtnEdit.Font = new System.Drawing.Font("Century Gothic", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.detailsBtnEdit.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(208)))), ((int)(((byte)(255)))));
            this.detailsBtnEdit.Location = new System.Drawing.Point(442, 373);
            this.detailsBtnEdit.Name = "detailsBtnEdit";
            this.detailsBtnEdit.Size = new System.Drawing.Size(170, 65);
            this.detailsBtnEdit.TabIndex = 9;
            this.detailsBtnEdit.Text = "Редактирай";
            this.detailsBtnEdit.UseVisualStyleBackColor = true;
            this.detailsBtnEdit.Click += new System.EventHandler(this.detailsBtnEdit_Click);
            // 
            // detailsNameLabel
            // 
            this.detailsNameLabel.AutoSize = true;
            this.detailsNameLabel.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.detailsNameLabel.Font = new System.Drawing.Font("Century Gothic", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.detailsNameLabel.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(208)))), ((int)(((byte)(255)))));
            this.detailsNameLabel.Location = new System.Drawing.Point(120, 40);
            this.detailsNameLabel.Name = "detailsNameLabel";
            this.detailsNameLabel.Size = new System.Drawing.Size(75, 30);
            this.detailsNameLabel.TabIndex = 10;
            this.detailsNameLabel.Text = "Име:";
            // 
            // detailsPhoneLabel
            // 
            this.detailsPhoneLabel.AutoSize = true;
            this.detailsPhoneLabel.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.detailsPhoneLabel.Font = new System.Drawing.Font("Century Gothic", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.detailsPhoneLabel.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(208)))), ((int)(((byte)(255)))));
            this.detailsPhoneLabel.Location = new System.Drawing.Point(102, 90);
            this.detailsPhoneLabel.Name = "detailsPhoneLabel";
            this.detailsPhoneLabel.Size = new System.Drawing.Size(93, 30);
            this.detailsPhoneLabel.TabIndex = 11;
            this.detailsPhoneLabel.Text = "Тел №:";
            // 
            // detailsEmailLabel
            // 
            this.detailsEmailLabel.AutoSize = true;
            this.detailsEmailLabel.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.detailsEmailLabel.Font = new System.Drawing.Font("Century Gothic", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.detailsEmailLabel.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(208)))), ((int)(((byte)(255)))));
            this.detailsEmailLabel.Location = new System.Drawing.Point(92, 140);
            this.detailsEmailLabel.Name = "detailsEmailLabel";
            this.detailsEmailLabel.Size = new System.Drawing.Size(103, 30);
            this.detailsEmailLabel.TabIndex = 12;
            this.detailsEmailLabel.Text = "Имейл:";
            // 
            // detailsFacebookLabel
            // 
            this.detailsFacebookLabel.AutoSize = true;
            this.detailsFacebookLabel.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.detailsFacebookLabel.Font = new System.Drawing.Font("Century Gothic", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.detailsFacebookLabel.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(208)))), ((int)(((byte)(255)))));
            this.detailsFacebookLabel.Location = new System.Drawing.Point(66, 190);
            this.detailsFacebookLabel.Name = "detailsFacebookLabel";
            this.detailsFacebookLabel.Size = new System.Drawing.Size(129, 30);
            this.detailsFacebookLabel.TabIndex = 13;
            this.detailsFacebookLabel.Text = "Фейсбук:";
            // 
            // detailsAmountLabel
            // 
            this.detailsAmountLabel.AutoSize = true;
            this.detailsAmountLabel.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.detailsAmountLabel.Font = new System.Drawing.Font("Century Gothic", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.detailsAmountLabel.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(208)))), ((int)(((byte)(255)))));
            this.detailsAmountLabel.Location = new System.Drawing.Point(38, 240);
            this.detailsAmountLabel.Name = "detailsAmountLabel";
            this.detailsAmountLabel.Size = new System.Drawing.Size(157, 30);
            this.detailsAmountLabel.TabIndex = 14;
            this.detailsAmountLabel.Text = "Количество:";
            // 
            // detailsSinceLabel
            // 
            this.detailsSinceLabel.AutoSize = true;
            this.detailsSinceLabel.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.detailsSinceLabel.Font = new System.Drawing.Font("Century Gothic", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.detailsSinceLabel.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(208)))), ((int)(((byte)(255)))));
            this.detailsSinceLabel.Location = new System.Drawing.Point(562, 40);
            this.detailsSinceLabel.Name = "detailsSinceLabel";
            this.detailsSinceLabel.Size = new System.Drawing.Size(50, 30);
            this.detailsSinceLabel.TabIndex = 15;
            this.detailsSinceLabel.Text = "От:";
            // 
            // detailsDueDateLabel
            // 
            this.detailsDueDateLabel.AutoSize = true;
            this.detailsDueDateLabel.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.detailsDueDateLabel.Font = new System.Drawing.Font("Century Gothic", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.detailsDueDateLabel.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(208)))), ((int)(((byte)(255)))));
            this.detailsDueDateLabel.Location = new System.Drawing.Point(562, 90);
            this.detailsDueDateLabel.Name = "detailsDueDateLabel";
            this.detailsDueDateLabel.Size = new System.Drawing.Size(54, 30);
            this.detailsDueDateLabel.TabIndex = 16;
            this.detailsDueDateLabel.Text = "До:";
            // 
            // detailsTransactorTypeLabel
            // 
            this.detailsTransactorTypeLabel.AutoSize = true;
            this.detailsTransactorTypeLabel.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.detailsTransactorTypeLabel.Font = new System.Drawing.Font("Century Gothic", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.detailsTransactorTypeLabel.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(208)))), ((int)(((byte)(255)))));
            this.detailsTransactorTypeLabel.Location = new System.Drawing.Point(135, 290);
            this.detailsTransactorTypeLabel.Name = "detailsTransactorTypeLabel";
            this.detailsTransactorTypeLabel.Size = new System.Drawing.Size(60, 30);
            this.detailsTransactorTypeLabel.TabIndex = 17;
            this.detailsTransactorTypeLabel.Text = "Тип:";
            // 
            // DetailsForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(40)))), ((int)(((byte)(40)))));
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.detailsTransactorTypeLabel);
            this.Controls.Add(this.detailsDueDateLabel);
            this.Controls.Add(this.detailsSinceLabel);
            this.Controls.Add(this.detailsAmountLabel);
            this.Controls.Add(this.detailsFacebookLabel);
            this.Controls.Add(this.detailsEmailLabel);
            this.Controls.Add(this.detailsPhoneLabel);
            this.Controls.Add(this.detailsNameLabel);
            this.Controls.Add(this.detailsBtnEdit);
            this.Controls.Add(this.detailsBtnDelete);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximumSize = new System.Drawing.Size(818, 497);
            this.MinimumSize = new System.Drawing.Size(818, 497);
            this.Name = "DetailsForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Детайли";
            this.Load += new System.EventHandler(this.DetailsForm_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button detailsBtnDelete;
        private System.Windows.Forms.Button detailsBtnEdit;
        private System.Windows.Forms.Label detailsNameLabel;
        private System.Windows.Forms.Label detailsPhoneLabel;
        private System.Windows.Forms.Label detailsEmailLabel;
        private System.Windows.Forms.Label detailsFacebookLabel;
        private System.Windows.Forms.Label detailsAmountLabel;
        private System.Windows.Forms.Label detailsSinceLabel;
        private System.Windows.Forms.Label detailsDueDateLabel;
        private System.Windows.Forms.Label detailsTransactorTypeLabel;
    }
}