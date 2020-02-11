﻿namespace NovaDebt
{
    partial class AddTransactorForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(AddTransactorForm));
            this.addBtnConfirm = new System.Windows.Forms.Button();
            this.addBtnCancel = new System.Windows.Forms.Button();
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
            this.addBtnDebtor = new System.Windows.Forms.Button();
            this.addBtnCreditor = new System.Windows.Forms.Button();
            this.addSinceLabel = new System.Windows.Forms.Label();
            this.addDueDateLabel = new System.Windows.Forms.Label();
            this.addDueDatePicker = new System.Windows.Forms.DateTimePicker();
            this.addSinceDatePicker = new System.Windows.Forms.DateTimePicker();
            this.addInterestCheckBox = new System.Windows.Forms.CheckBox();
            this.addInterestWithCurrencyTextBox = new System.Windows.Forms.TextBox();
            this.addInterestWithPercentageTextBox = new System.Windows.Forms.TextBox();
            this.addInterestWithCurrencyLabel = new System.Windows.Forms.Label();
            this.addInterestWithPercentageLabel = new System.Windows.Forms.Label();
            this.addInterestsSeparator = new System.Windows.Forms.Panel();
            this.SuspendLayout();
            // 
            // addBtnConfirm
            // 
            this.addBtnConfirm.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.addBtnConfirm.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(208)))), ((int)(((byte)(255)))));
            this.addBtnConfirm.FlatAppearance.MouseDownBackColor = System.Drawing.Color.White;
            this.addBtnConfirm.FlatAppearance.MouseOverBackColor = System.Drawing.Color.White;
            this.addBtnConfirm.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.addBtnConfirm.Font = new System.Drawing.Font("Century Gothic", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.addBtnConfirm.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(208)))), ((int)(((byte)(255)))));
            this.addBtnConfirm.Location = new System.Drawing.Point(770, 281);
            this.addBtnConfirm.Name = "addBtnConfirm";
            this.addBtnConfirm.Size = new System.Drawing.Size(200, 65);
            this.addBtnConfirm.TabIndex = 8;
            this.addBtnConfirm.Text = "Добави";
            this.addBtnConfirm.UseVisualStyleBackColor = true;
            this.addBtnConfirm.Click += new System.EventHandler(this.btnAddConfirm_Click);
            // 
            // addBtnCancel
            // 
            this.addBtnCancel.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.addBtnCancel.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(208)))), ((int)(((byte)(255)))));
            this.addBtnCancel.FlatAppearance.MouseDownBackColor = System.Drawing.Color.White;
            this.addBtnCancel.FlatAppearance.MouseOverBackColor = System.Drawing.Color.White;
            this.addBtnCancel.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.addBtnCancel.Font = new System.Drawing.Font("Century Gothic", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.addBtnCancel.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(208)))), ((int)(((byte)(255)))));
            this.addBtnCancel.Location = new System.Drawing.Point(564, 281);
            this.addBtnCancel.Name = "addBtnCancel";
            this.addBtnCancel.Size = new System.Drawing.Size(200, 65);
            this.addBtnCancel.TabIndex = 7;
            this.addBtnCancel.Text = "Отказ";
            this.addBtnCancel.UseVisualStyleBackColor = true;
            this.addBtnCancel.Click += new System.EventHandler(this.btnAddCancel_Click);
            // 
            // addNameLabel
            // 
            this.addNameLabel.AutoSize = true;
            this.addNameLabel.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.addNameLabel.Font = new System.Drawing.Font("Century Gothic", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.addNameLabel.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(208)))), ((int)(((byte)(255)))));
            this.addNameLabel.Location = new System.Drawing.Point(97, 30);
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
            this.addPhoneLabel.Location = new System.Drawing.Point(79, 80);
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
            this.addEmailLabel.Location = new System.Drawing.Point(69, 130);
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
            this.addFacebookLabel.Location = new System.Drawing.Point(43, 180);
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
            this.addAmountLabel.Location = new System.Drawing.Point(15, 230);
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
            this.addNameTextBox.Location = new System.Drawing.Point(171, 28);
            this.addNameTextBox.MaxLength = 30;
            this.addNameTextBox.Name = "addNameTextBox";
            this.addNameTextBox.Size = new System.Drawing.Size(375, 36);
            this.addNameTextBox.TabIndex = 0;
            // 
            // addPhoneTextBox
            // 
            this.addPhoneTextBox.BackColor = System.Drawing.Color.White;
            this.addPhoneTextBox.Font = new System.Drawing.Font("Calibri", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.addPhoneTextBox.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(50)))), ((int)(((byte)(50)))), ((int)(((byte)(50)))));
            this.addPhoneTextBox.Location = new System.Drawing.Point(171, 78);
            this.addPhoneTextBox.MaxLength = 20;
            this.addPhoneTextBox.Name = "addPhoneTextBox";
            this.addPhoneTextBox.Size = new System.Drawing.Size(375, 36);
            this.addPhoneTextBox.TabIndex = 1;
            // 
            // addEmailTextBox
            // 
            this.addEmailTextBox.BackColor = System.Drawing.Color.White;
            this.addEmailTextBox.Font = new System.Drawing.Font("Calibri", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.addEmailTextBox.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(50)))), ((int)(((byte)(50)))), ((int)(((byte)(50)))));
            this.addEmailTextBox.Location = new System.Drawing.Point(171, 128);
            this.addEmailTextBox.MaxLength = 40;
            this.addEmailTextBox.Name = "addEmailTextBox";
            this.addEmailTextBox.Size = new System.Drawing.Size(375, 36);
            this.addEmailTextBox.TabIndex = 2;
            // 
            // addFacebookTextBox
            // 
            this.addFacebookTextBox.BackColor = System.Drawing.Color.White;
            this.addFacebookTextBox.Font = new System.Drawing.Font("Calibri", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.addFacebookTextBox.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(50)))), ((int)(((byte)(50)))), ((int)(((byte)(50)))));
            this.addFacebookTextBox.Location = new System.Drawing.Point(171, 178);
            this.addFacebookTextBox.MaxLength = 30;
            this.addFacebookTextBox.Name = "addFacebookTextBox";
            this.addFacebookTextBox.Size = new System.Drawing.Size(375, 36);
            this.addFacebookTextBox.TabIndex = 3;
            // 
            // addAmountTextBox
            // 
            this.addAmountTextBox.BackColor = System.Drawing.Color.White;
            this.addAmountTextBox.Font = new System.Drawing.Font("Calibri", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.addAmountTextBox.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(50)))), ((int)(((byte)(50)))), ((int)(((byte)(50)))));
            this.addAmountTextBox.Location = new System.Drawing.Point(171, 228);
            this.addAmountTextBox.MaxLength = 15;
            this.addAmountTextBox.Name = "addAmountTextBox";
            this.addAmountTextBox.Size = new System.Drawing.Size(375, 36);
            this.addAmountTextBox.TabIndex = 4;
            // 
            // addBtnDebtor
            // 
            this.addBtnDebtor.FlatAppearance.BorderColor = System.Drawing.Color.WhiteSmoke;
            this.addBtnDebtor.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.addBtnDebtor.Font = new System.Drawing.Font("Century Gothic", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.addBtnDebtor.ForeColor = System.Drawing.Color.WhiteSmoke;
            this.addBtnDebtor.Location = new System.Drawing.Point(20, 286);
            this.addBtnDebtor.Name = "addBtnDebtor";
            this.addBtnDebtor.Size = new System.Drawing.Size(260, 53);
            this.addBtnDebtor.TabIndex = 5;
            this.addBtnDebtor.Text = "Дебитор";
            this.addBtnDebtor.UseVisualStyleBackColor = true;
            this.addBtnDebtor.Click += new System.EventHandler(this.btnAddDebtor_Click);
            // 
            // addBtnCreditor
            // 
            this.addBtnCreditor.FlatAppearance.BorderColor = System.Drawing.Color.WhiteSmoke;
            this.addBtnCreditor.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.addBtnCreditor.Font = new System.Drawing.Font("Century Gothic", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.addBtnCreditor.ForeColor = System.Drawing.Color.WhiteSmoke;
            this.addBtnCreditor.Location = new System.Drawing.Point(286, 286);
            this.addBtnCreditor.Name = "addBtnCreditor";
            this.addBtnCreditor.Size = new System.Drawing.Size(260, 53);
            this.addBtnCreditor.TabIndex = 6;
            this.addBtnCreditor.Text = "Кредитор";
            this.addBtnCreditor.UseVisualStyleBackColor = true;
            this.addBtnCreditor.Click += new System.EventHandler(this.btnAddCreditor_Click);
            // 
            // addSinceLabel
            // 
            this.addSinceLabel.AutoSize = true;
            this.addSinceLabel.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.addSinceLabel.Font = new System.Drawing.Font("Century Gothic", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.addSinceLabel.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(208)))), ((int)(((byte)(255)))));
            this.addSinceLabel.Location = new System.Drawing.Point(656, 30);
            this.addSinceLabel.Name = "addSinceLabel";
            this.addSinceLabel.Size = new System.Drawing.Size(43, 30);
            this.addSinceLabel.TabIndex = 12;
            this.addSinceLabel.Text = "От";
            // 
            // addDueDateLabel
            // 
            this.addDueDateLabel.AutoSize = true;
            this.addDueDateLabel.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.addDueDateLabel.Font = new System.Drawing.Font("Century Gothic", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.addDueDateLabel.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(208)))), ((int)(((byte)(255)))));
            this.addDueDateLabel.Location = new System.Drawing.Point(652, 80);
            this.addDueDateLabel.Name = "addDueDateLabel";
            this.addDueDateLabel.Size = new System.Drawing.Size(47, 30);
            this.addDueDateLabel.TabIndex = 13;
            this.addDueDateLabel.Text = "До";
            // 
            // addDueDatePicker
            // 
            this.addDueDatePicker.Font = new System.Drawing.Font("Microsoft Sans Serif", 16.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.addDueDatePicker.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.addDueDatePicker.Location = new System.Drawing.Point(705, 76);
            this.addDueDatePicker.MaxDate = new System.DateTime(2099, 12, 31, 0, 0, 0, 0);
            this.addDueDatePicker.Name = "addDueDatePicker";
            this.addDueDatePicker.Size = new System.Drawing.Size(198, 38);
            this.addDueDatePicker.TabIndex = 15;
            this.addDueDatePicker.Value = new System.DateTime(2020, 2, 9, 0, 0, 0, 0);
            // 
            // addSinceDatePicker
            // 
            this.addSinceDatePicker.Font = new System.Drawing.Font("Microsoft Sans Serif", 16.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.addSinceDatePicker.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.addSinceDatePicker.Location = new System.Drawing.Point(705, 26);
            this.addSinceDatePicker.MaxDate = new System.DateTime(3020, 12, 31, 0, 0, 0, 0);
            this.addSinceDatePicker.Name = "addSinceDatePicker";
            this.addSinceDatePicker.Size = new System.Drawing.Size(198, 38);
            this.addSinceDatePicker.TabIndex = 14;
            this.addSinceDatePicker.Value = new System.DateTime(2020, 2, 9, 0, 0, 0, 0);
            // 
            // addInterestCheckBox
            // 
            this.addInterestCheckBox.AutoSize = true;
            this.addInterestCheckBox.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.addInterestCheckBox.ForeColor = System.Drawing.Color.WhiteSmoke;
            this.addInterestCheckBox.Location = new System.Drawing.Point(552, 233);
            this.addInterestCheckBox.Name = "addInterestCheckBox";
            this.addInterestCheckBox.Size = new System.Drawing.Size(110, 27);
            this.addInterestCheckBox.TabIndex = 16;
            this.addInterestCheckBox.Text = "С лихва";
            this.addInterestCheckBox.UseVisualStyleBackColor = true;
            this.addInterestCheckBox.CheckedChanged += new System.EventHandler(this.addInterestCheckBox_CheckedChanged);
            // 
            // addInterestWithCurrencyTextBox
            // 
            this.addInterestWithCurrencyTextBox.BackColor = System.Drawing.Color.White;
            this.addInterestWithCurrencyTextBox.Font = new System.Drawing.Font("Calibri", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.addInterestWithCurrencyTextBox.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(50)))), ((int)(((byte)(50)))), ((int)(((byte)(50)))));
            this.addInterestWithCurrencyTextBox.Location = new System.Drawing.Point(705, 174);
            this.addInterestWithCurrencyTextBox.MaxLength = 15;
            this.addInterestWithCurrencyTextBox.Name = "addInterestWithCurrencyTextBox";
            this.addInterestWithCurrencyTextBox.Size = new System.Drawing.Size(198, 36);
            this.addInterestWithCurrencyTextBox.TabIndex = 17;
            this.addInterestWithCurrencyTextBox.Text = "0";
            this.addInterestWithCurrencyTextBox.Visible = false;
            this.addInterestWithCurrencyTextBox.WordWrap = false;
            // 
            // addInterestWithPercentageTextBox
            // 
            this.addInterestWithPercentageTextBox.BackColor = System.Drawing.Color.White;
            this.addInterestWithPercentageTextBox.Font = new System.Drawing.Font("Calibri", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.addInterestWithPercentageTextBox.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(50)))), ((int)(((byte)(50)))), ((int)(((byte)(50)))));
            this.addInterestWithPercentageTextBox.Location = new System.Drawing.Point(705, 224);
            this.addInterestWithPercentageTextBox.MaxLength = 7;
            this.addInterestWithPercentageTextBox.Name = "addInterestWithPercentageTextBox";
            this.addInterestWithPercentageTextBox.Size = new System.Drawing.Size(198, 36);
            this.addInterestWithPercentageTextBox.TabIndex = 18;
            this.addInterestWithPercentageTextBox.Text = "0";
            this.addInterestWithPercentageTextBox.Visible = false;
            this.addInterestWithPercentageTextBox.WordWrap = false;
            // 
            // addInterestWithCurrencyLabel
            // 
            this.addInterestWithCurrencyLabel.AutoSize = true;
            this.addInterestWithCurrencyLabel.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.addInterestWithCurrencyLabel.Font = new System.Drawing.Font("Century Gothic", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.addInterestWithCurrencyLabel.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(208)))), ((int)(((byte)(255)))));
            this.addInterestWithCurrencyLabel.Location = new System.Drawing.Point(909, 176);
            this.addInterestWithCurrencyLabel.Name = "addInterestWithCurrencyLabel";
            this.addInterestWithCurrencyLabel.Size = new System.Drawing.Size(44, 30);
            this.addInterestWithCurrencyLabel.TabIndex = 19;
            this.addInterestWithCurrencyLabel.Text = "лв.";
            this.addInterestWithCurrencyLabel.Visible = false;
            // 
            // addInterestWithPercentageLabel
            // 
            this.addInterestWithPercentageLabel.AutoSize = true;
            this.addInterestWithPercentageLabel.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.addInterestWithPercentageLabel.Font = new System.Drawing.Font("Century Gothic", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.addInterestWithPercentageLabel.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(208)))), ((int)(((byte)(255)))));
            this.addInterestWithPercentageLabel.Location = new System.Drawing.Point(909, 226);
            this.addInterestWithPercentageLabel.Name = "addInterestWithPercentageLabel";
            this.addInterestWithPercentageLabel.Size = new System.Drawing.Size(32, 30);
            this.addInterestWithPercentageLabel.TabIndex = 20;
            this.addInterestWithPercentageLabel.Text = "%";
            this.addInterestWithPercentageLabel.Visible = false;
            // 
            // addInterestsSeparator
            // 
            this.addInterestsSeparator.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(208)))), ((int)(((byte)(255)))));
            this.addInterestsSeparator.Location = new System.Drawing.Point(705, 217);
            this.addInterestsSeparator.Name = "addInterestsSeparator";
            this.addInterestsSeparator.Size = new System.Drawing.Size(198, 1);
            this.addInterestsSeparator.TabIndex = 21;
            this.addInterestsSeparator.Visible = false;
            // 
            // AddTransactorForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(40)))), ((int)(((byte)(40)))));
            this.ClientSize = new System.Drawing.Size(982, 358);
            this.Controls.Add(this.addInterestsSeparator);
            this.Controls.Add(this.addInterestWithPercentageLabel);
            this.Controls.Add(this.addInterestWithCurrencyLabel);
            this.Controls.Add(this.addInterestWithPercentageTextBox);
            this.Controls.Add(this.addInterestWithCurrencyTextBox);
            this.Controls.Add(this.addInterestCheckBox);
            this.Controls.Add(this.addSinceDatePicker);
            this.Controls.Add(this.addDueDatePicker);
            this.Controls.Add(this.addDueDateLabel);
            this.Controls.Add(this.addSinceLabel);
            this.Controls.Add(this.addBtnCreditor);
            this.Controls.Add(this.addBtnDebtor);
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
            this.Controls.Add(this.addBtnCancel);
            this.Controls.Add(this.addBtnConfirm);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "AddTransactorForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Добави";
            this.Load += new System.EventHandler(this.AddTransactorForm_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Button addBtnConfirm;
        private System.Windows.Forms.Button addBtnCancel;
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
        private System.Windows.Forms.Button addBtnDebtor;
        private System.Windows.Forms.Button addBtnCreditor;
        private System.Windows.Forms.Label addSinceLabel;
        private System.Windows.Forms.Label addDueDateLabel;
        private System.Windows.Forms.DateTimePicker addDueDatePicker;
        private System.Windows.Forms.DateTimePicker addSinceDatePicker;
        private System.Windows.Forms.CheckBox addInterestCheckBox;
        private System.Windows.Forms.TextBox addInterestWithCurrencyTextBox;
        private System.Windows.Forms.TextBox addInterestWithPercentageTextBox;
        private System.Windows.Forms.Label addInterestWithCurrencyLabel;
        private System.Windows.Forms.Label addInterestWithPercentageLabel;
        private System.Windows.Forms.Panel addInterestsSeparator;
    }
}