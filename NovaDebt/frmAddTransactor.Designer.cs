namespace NovaDebt
{
    partial class frmAddTransactor
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmAddTransactor));
            this.btnAddConfirm = new System.Windows.Forms.Button();
            this.btnAddCancel = new System.Windows.Forms.Button();
            this.addNameLabel = new System.Windows.Forms.Label();
            this.addPhoneLabel = new System.Windows.Forms.Label();
            this.addEmailLabel = new System.Windows.Forms.Label();
            this.addFacebookLabel = new System.Windows.Forms.Label();
            this.addAmountLabel = new System.Windows.Forms.Label();
            this.addNameTextBox = new System.Windows.Forms.TextBox();
            this.addPhoneTextBox = new System.Windows.Forms.TextBox();
            this.addEmailTextBox = new System.Windows.Forms.TextBox();
            this.addFacebookTextBox = new System.Windows.Forms.TextBox();
            this.addAmountTextBox = new System.Windows.Forms.TextBox();
            this.btnAddDebtor = new System.Windows.Forms.Button();
            this.btnAddCreditor = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // btnAddConfirm
            // 
            this.btnAddConfirm.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.btnAddConfirm.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(208)))), ((int)(((byte)(255)))));
            this.btnAddConfirm.FlatAppearance.MouseDownBackColor = System.Drawing.Color.White;
            this.btnAddConfirm.FlatAppearance.MouseOverBackColor = System.Drawing.Color.White;
            this.btnAddConfirm.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnAddConfirm.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.btnAddConfirm.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(208)))), ((int)(((byte)(255)))));
            this.btnAddConfirm.Location = new System.Drawing.Point(612, 386);
            this.btnAddConfirm.Name = "btnAddConfirm";
            this.btnAddConfirm.Size = new System.Drawing.Size(176, 52);
            this.btnAddConfirm.TabIndex = 8;
            this.btnAddConfirm.Text = "Добави";
            this.btnAddConfirm.UseVisualStyleBackColor = true;
            this.btnAddConfirm.Click += new System.EventHandler(this.btnAddConfirm_Click);
            // 
            // btnAddCancel
            // 
            this.btnAddCancel.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.btnAddCancel.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(208)))), ((int)(((byte)(255)))));
            this.btnAddCancel.FlatAppearance.MouseDownBackColor = System.Drawing.Color.White;
            this.btnAddCancel.FlatAppearance.MouseOverBackColor = System.Drawing.Color.White;
            this.btnAddCancel.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnAddCancel.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.btnAddCancel.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(208)))), ((int)(((byte)(255)))));
            this.btnAddCancel.Location = new System.Drawing.Point(430, 386);
            this.btnAddCancel.Name = "btnAddCancel";
            this.btnAddCancel.Size = new System.Drawing.Size(176, 52);
            this.btnAddCancel.TabIndex = 7;
            this.btnAddCancel.Text = "Отказ";
            this.btnAddCancel.UseVisualStyleBackColor = true;
            this.btnAddCancel.Click += new System.EventHandler(this.btnAddCancel_Click);
            // 
            // addNameLabel
            // 
            this.addNameLabel.AutoSize = true;
            this.addNameLabel.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.addNameLabel.Font = new System.Drawing.Font("Century Gothic", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.addNameLabel.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(208)))), ((int)(((byte)(255)))));
            this.addNameLabel.Location = new System.Drawing.Point(192, 30);
            this.addNameLabel.Name = "addNameLabel";
            this.addNameLabel.Size = new System.Drawing.Size(68, 30);
            this.addNameLabel.TabIndex = 7;
            this.addNameLabel.Text = "Име";
            // 
            // addPhoneLabel
            // 
            this.addPhoneLabel.AutoSize = true;
            this.addPhoneLabel.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.addPhoneLabel.Font = new System.Drawing.Font("Century Gothic", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.addPhoneLabel.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(208)))), ((int)(((byte)(255)))));
            this.addPhoneLabel.Location = new System.Drawing.Point(174, 80);
            this.addPhoneLabel.Name = "addPhoneLabel";
            this.addPhoneLabel.Size = new System.Drawing.Size(86, 30);
            this.addPhoneLabel.TabIndex = 8;
            this.addPhoneLabel.Text = "Тел №";
            // 
            // addEmailLabel
            // 
            this.addEmailLabel.AutoSize = true;
            this.addEmailLabel.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.addEmailLabel.Font = new System.Drawing.Font("Century Gothic", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.addEmailLabel.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(208)))), ((int)(((byte)(255)))));
            this.addEmailLabel.Location = new System.Drawing.Point(164, 130);
            this.addEmailLabel.Name = "addEmailLabel";
            this.addEmailLabel.Size = new System.Drawing.Size(96, 30);
            this.addEmailLabel.TabIndex = 9;
            this.addEmailLabel.Text = "Имейл";
            // 
            // addFacebookLabel
            // 
            this.addFacebookLabel.AutoSize = true;
            this.addFacebookLabel.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.addFacebookLabel.Font = new System.Drawing.Font("Century Gothic", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.addFacebookLabel.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(208)))), ((int)(((byte)(255)))));
            this.addFacebookLabel.Location = new System.Drawing.Point(138, 180);
            this.addFacebookLabel.Name = "addFacebookLabel";
            this.addFacebookLabel.Size = new System.Drawing.Size(122, 30);
            this.addFacebookLabel.TabIndex = 10;
            this.addFacebookLabel.Text = "Фейсбук";
            // 
            // addAmountLabel
            // 
            this.addAmountLabel.AutoSize = true;
            this.addAmountLabel.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.addAmountLabel.Font = new System.Drawing.Font("Century Gothic", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.addAmountLabel.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(208)))), ((int)(((byte)(255)))));
            this.addAmountLabel.Location = new System.Drawing.Point(110, 230);
            this.addAmountLabel.Name = "addAmountLabel";
            this.addAmountLabel.Size = new System.Drawing.Size(150, 30);
            this.addAmountLabel.TabIndex = 11;
            this.addAmountLabel.Text = "Количество";
            // 
            // addNameTextBox
            // 
            this.addNameTextBox.BackColor = System.Drawing.Color.White;
            this.addNameTextBox.Font = new System.Drawing.Font("Calibri", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.addNameTextBox.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(50)))), ((int)(((byte)(50)))), ((int)(((byte)(50)))));
            this.addNameTextBox.Location = new System.Drawing.Point(266, 28);
            this.addNameTextBox.MaxLength = 70;
            this.addNameTextBox.Name = "addNameTextBox";
            this.addNameTextBox.Size = new System.Drawing.Size(390, 36);
            this.addNameTextBox.TabIndex = 0;
            // 
            // addPhoneTextBox
            // 
            this.addPhoneTextBox.BackColor = System.Drawing.Color.White;
            this.addPhoneTextBox.Font = new System.Drawing.Font("Calibri", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.addPhoneTextBox.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(50)))), ((int)(((byte)(50)))), ((int)(((byte)(50)))));
            this.addPhoneTextBox.Location = new System.Drawing.Point(266, 78);
            this.addPhoneTextBox.MaxLength = 50;
            this.addPhoneTextBox.Name = "addPhoneTextBox";
            this.addPhoneTextBox.Size = new System.Drawing.Size(390, 36);
            this.addPhoneTextBox.TabIndex = 1;
            // 
            // addEmailTextBox
            // 
            this.addEmailTextBox.BackColor = System.Drawing.Color.White;
            this.addEmailTextBox.Font = new System.Drawing.Font("Calibri", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.addEmailTextBox.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(50)))), ((int)(((byte)(50)))), ((int)(((byte)(50)))));
            this.addEmailTextBox.Location = new System.Drawing.Point(266, 128);
            this.addEmailTextBox.MaxLength = 100;
            this.addEmailTextBox.Name = "addEmailTextBox";
            this.addEmailTextBox.Size = new System.Drawing.Size(390, 36);
            this.addEmailTextBox.TabIndex = 2;
            // 
            // addFacebookTextBox
            // 
            this.addFacebookTextBox.BackColor = System.Drawing.Color.White;
            this.addFacebookTextBox.Font = new System.Drawing.Font("Calibri", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.addFacebookTextBox.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(50)))), ((int)(((byte)(50)))), ((int)(((byte)(50)))));
            this.addFacebookTextBox.Location = new System.Drawing.Point(266, 178);
            this.addFacebookTextBox.MaxLength = 100;
            this.addFacebookTextBox.Name = "addFacebookTextBox";
            this.addFacebookTextBox.Size = new System.Drawing.Size(390, 36);
            this.addFacebookTextBox.TabIndex = 3;
            // 
            // addAmountTextBox
            // 
            this.addAmountTextBox.BackColor = System.Drawing.Color.White;
            this.addAmountTextBox.Font = new System.Drawing.Font("Calibri", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.addAmountTextBox.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(50)))), ((int)(((byte)(50)))), ((int)(((byte)(50)))));
            this.addAmountTextBox.Location = new System.Drawing.Point(266, 228);
            this.addAmountTextBox.MaxLength = 10;
            this.addAmountTextBox.Name = "addAmountTextBox";
            this.addAmountTextBox.Size = new System.Drawing.Size(390, 36);
            this.addAmountTextBox.TabIndex = 4;
            // 
            // btnAddDebtor
            // 
            this.btnAddDebtor.FlatAppearance.BorderColor = System.Drawing.Color.WhiteSmoke;
            this.btnAddDebtor.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnAddDebtor.Font = new System.Drawing.Font("Century Gothic", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.btnAddDebtor.ForeColor = System.Drawing.Color.WhiteSmoke;
            this.btnAddDebtor.Location = new System.Drawing.Point(64, 293);
            this.btnAddDebtor.Name = "btnAddDebtor";
            this.btnAddDebtor.Size = new System.Drawing.Size(335, 53);
            this.btnAddDebtor.TabIndex = 5;
            this.btnAddDebtor.Text = "Дебитор";
            this.btnAddDebtor.UseVisualStyleBackColor = true;
            this.btnAddDebtor.Click += new System.EventHandler(this.btnAddDebtor_Click);
            // 
            // btnAddCreditor
            // 
            this.btnAddCreditor.FlatAppearance.BorderColor = System.Drawing.Color.WhiteSmoke;
            this.btnAddCreditor.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnAddCreditor.Font = new System.Drawing.Font("Century Gothic", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.btnAddCreditor.ForeColor = System.Drawing.Color.WhiteSmoke;
            this.btnAddCreditor.Location = new System.Drawing.Point(405, 293);
            this.btnAddCreditor.Name = "btnAddCreditor";
            this.btnAddCreditor.Size = new System.Drawing.Size(335, 53);
            this.btnAddCreditor.TabIndex = 6;
            this.btnAddCreditor.Text = "Кредитор";
            this.btnAddCreditor.UseVisualStyleBackColor = true;
            this.btnAddCreditor.Click += new System.EventHandler(this.btnAddCreditor_Click);
            // 
            // frmAddTransactor
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(50)))), ((int)(((byte)(50)))), ((int)(((byte)(50)))));
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.btnAddCreditor);
            this.Controls.Add(this.btnAddDebtor);
            this.Controls.Add(this.addAmountTextBox);
            this.Controls.Add(this.addFacebookTextBox);
            this.Controls.Add(this.addEmailTextBox);
            this.Controls.Add(this.addPhoneTextBox);
            this.Controls.Add(this.addNameTextBox);
            this.Controls.Add(this.addAmountLabel);
            this.Controls.Add(this.addFacebookLabel);
            this.Controls.Add(this.addEmailLabel);
            this.Controls.Add(this.addPhoneLabel);
            this.Controls.Add(this.addNameLabel);
            this.Controls.Add(this.btnAddCancel);
            this.Controls.Add(this.btnAddConfirm);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "frmAddTransactor";
            this.Text = "Добави";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Button btnAddConfirm;
        private System.Windows.Forms.Button btnAddCancel;
        private System.Windows.Forms.Label addNameLabel;
        private System.Windows.Forms.Label addPhoneLabel;
        private System.Windows.Forms.Label addEmailLabel;
        private System.Windows.Forms.Label addFacebookLabel;
        private System.Windows.Forms.Label addAmountLabel;
        private System.Windows.Forms.TextBox addNameTextBox;
        private System.Windows.Forms.TextBox addPhoneTextBox;
        private System.Windows.Forms.TextBox addEmailTextBox;
        private System.Windows.Forms.TextBox addFacebookTextBox;
        private System.Windows.Forms.TextBox addAmountTextBox;
        private System.Windows.Forms.Button btnAddDebtor;
        private System.Windows.Forms.Button btnAddCreditor;
    }
}