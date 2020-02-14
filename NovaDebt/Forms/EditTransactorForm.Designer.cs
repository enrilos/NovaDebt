namespace NovaDebt.Forms
{
    partial class EditTransactorForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(EditTransactorForm));
            this.nameLabel = new System.Windows.Forms.Label();
            this.phoneLabel = new System.Windows.Forms.Label();
            this.emailLabel = new System.Windows.Forms.Label();
            this.facebookLabel = new System.Windows.Forms.Label();
            this.amountLabel = new System.Windows.Forms.Label();
            this.interestCheckBox = new System.Windows.Forms.CheckBox();
            this.nameTextBox = new System.Windows.Forms.TextBox();
            this.phoneTextBox = new System.Windows.Forms.TextBox();
            this.emailTextBox = new System.Windows.Forms.TextBox();
            this.facebookTextBox = new System.Windows.Forms.TextBox();
            this.amountTextBox = new System.Windows.Forms.TextBox();
            this.btnDebtor = new System.Windows.Forms.Button();
            this.btnCreditor = new System.Windows.Forms.Button();
            this.interestsSeparator = new System.Windows.Forms.Panel();
            this.interestWithCurrencyTextBox = new System.Windows.Forms.TextBox();
            this.interestWithPercentageTextBox = new System.Windows.Forms.TextBox();
            this.interestWithCurrencyLabel = new System.Windows.Forms.Label();
            this.interestWithPercentageLabel = new System.Windows.Forms.Label();
            this.sinceLabel = new System.Windows.Forms.Label();
            this.dueDateLabel = new System.Windows.Forms.Label();
            this.sinceDatePicker = new System.Windows.Forms.DateTimePicker();
            this.dueDatePicker = new System.Windows.Forms.DateTimePicker();
            this.btnCancel = new System.Windows.Forms.Button();
            this.btnConfirm = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // nameLabel
            // 
            this.nameLabel.AutoSize = true;
            this.nameLabel.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.nameLabel.Font = new System.Drawing.Font("Century Gothic", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.nameLabel.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(208)))), ((int)(((byte)(255)))));
            this.nameLabel.Location = new System.Drawing.Point(97, 30);
            this.nameLabel.Name = "nameLabel";
            this.nameLabel.Size = new System.Drawing.Size(68, 30);
            this.nameLabel.TabIndex = 8;
            this.nameLabel.Text = "Име";
            // 
            // phoneLabel
            // 
            this.phoneLabel.AutoSize = true;
            this.phoneLabel.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.phoneLabel.Font = new System.Drawing.Font("Century Gothic", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.phoneLabel.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(208)))), ((int)(((byte)(255)))));
            this.phoneLabel.Location = new System.Drawing.Point(79, 80);
            this.phoneLabel.Name = "phoneLabel";
            this.phoneLabel.Size = new System.Drawing.Size(86, 30);
            this.phoneLabel.TabIndex = 9;
            this.phoneLabel.Text = "Тел №";
            // 
            // emailLabel
            // 
            this.emailLabel.AutoSize = true;
            this.emailLabel.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.emailLabel.Font = new System.Drawing.Font("Century Gothic", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.emailLabel.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(208)))), ((int)(((byte)(255)))));
            this.emailLabel.Location = new System.Drawing.Point(69, 130);
            this.emailLabel.Name = "emailLabel";
            this.emailLabel.Size = new System.Drawing.Size(96, 30);
            this.emailLabel.TabIndex = 10;
            this.emailLabel.Text = "Имейл";
            // 
            // facebookLabel
            // 
            this.facebookLabel.AutoSize = true;
            this.facebookLabel.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.facebookLabel.Font = new System.Drawing.Font("Century Gothic", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.facebookLabel.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(208)))), ((int)(((byte)(255)))));
            this.facebookLabel.Location = new System.Drawing.Point(43, 180);
            this.facebookLabel.Name = "facebookLabel";
            this.facebookLabel.Size = new System.Drawing.Size(122, 30);
            this.facebookLabel.TabIndex = 11;
            this.facebookLabel.Text = "Фейсбук";
            // 
            // amountLabel
            // 
            this.amountLabel.AutoSize = true;
            this.amountLabel.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.amountLabel.Font = new System.Drawing.Font("Century Gothic", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.amountLabel.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(208)))), ((int)(((byte)(255)))));
            this.amountLabel.Location = new System.Drawing.Point(15, 230);
            this.amountLabel.Name = "amountLabel";
            this.amountLabel.Size = new System.Drawing.Size(150, 30);
            this.amountLabel.TabIndex = 12;
            this.amountLabel.Text = "Количество";
            // 
            // interestCheckBox
            // 
            this.interestCheckBox.AutoSize = true;
            this.interestCheckBox.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.interestCheckBox.ForeColor = System.Drawing.Color.WhiteSmoke;
            this.interestCheckBox.Location = new System.Drawing.Point(552, 233);
            this.interestCheckBox.Name = "interestCheckBox";
            this.interestCheckBox.Size = new System.Drawing.Size(110, 27);
            this.interestCheckBox.TabIndex = 17;
            this.interestCheckBox.Text = "С лихва";
            this.interestCheckBox.UseVisualStyleBackColor = true;
            this.interestCheckBox.CheckedChanged += new System.EventHandler(this.interestCheckBox_CheckedChanged);
            // 
            // nameTextBox
            // 
            this.nameTextBox.BackColor = System.Drawing.Color.White;
            this.nameTextBox.Font = new System.Drawing.Font("Calibri", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.nameTextBox.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(50)))), ((int)(((byte)(50)))), ((int)(((byte)(50)))));
            this.nameTextBox.Location = new System.Drawing.Point(171, 28);
            this.nameTextBox.MaxLength = 30;
            this.nameTextBox.Name = "nameTextBox";
            this.nameTextBox.Size = new System.Drawing.Size(375, 36);
            this.nameTextBox.TabIndex = 18;
            // 
            // phoneTextBox
            // 
            this.phoneTextBox.BackColor = System.Drawing.Color.White;
            this.phoneTextBox.Font = new System.Drawing.Font("Calibri", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.phoneTextBox.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(50)))), ((int)(((byte)(50)))), ((int)(((byte)(50)))));
            this.phoneTextBox.Location = new System.Drawing.Point(171, 78);
            this.phoneTextBox.MaxLength = 20;
            this.phoneTextBox.Name = "phoneTextBox";
            this.phoneTextBox.Size = new System.Drawing.Size(375, 36);
            this.phoneTextBox.TabIndex = 19;
            // 
            // emailTextBox
            // 
            this.emailTextBox.BackColor = System.Drawing.Color.White;
            this.emailTextBox.Font = new System.Drawing.Font("Calibri", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.emailTextBox.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(50)))), ((int)(((byte)(50)))), ((int)(((byte)(50)))));
            this.emailTextBox.Location = new System.Drawing.Point(171, 128);
            this.emailTextBox.MaxLength = 40;
            this.emailTextBox.Name = "emailTextBox";
            this.emailTextBox.Size = new System.Drawing.Size(375, 36);
            this.emailTextBox.TabIndex = 20;
            // 
            // facebookTextBox
            // 
            this.facebookTextBox.BackColor = System.Drawing.Color.White;
            this.facebookTextBox.Font = new System.Drawing.Font("Calibri", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.facebookTextBox.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(50)))), ((int)(((byte)(50)))), ((int)(((byte)(50)))));
            this.facebookTextBox.Location = new System.Drawing.Point(171, 178);
            this.facebookTextBox.MaxLength = 30;
            this.facebookTextBox.Name = "facebookTextBox";
            this.facebookTextBox.Size = new System.Drawing.Size(375, 36);
            this.facebookTextBox.TabIndex = 21;
            // 
            // amountTextBox
            // 
            this.amountTextBox.BackColor = System.Drawing.Color.White;
            this.amountTextBox.Font = new System.Drawing.Font("Calibri", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.amountTextBox.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(50)))), ((int)(((byte)(50)))), ((int)(((byte)(50)))));
            this.amountTextBox.Location = new System.Drawing.Point(171, 228);
            this.amountTextBox.MaxLength = 15;
            this.amountTextBox.Name = "amountTextBox";
            this.amountTextBox.Size = new System.Drawing.Size(375, 36);
            this.amountTextBox.TabIndex = 22;
            // 
            // btnDebtor
            // 
            this.btnDebtor.FlatAppearance.BorderColor = System.Drawing.Color.WhiteSmoke;
            this.btnDebtor.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnDebtor.Font = new System.Drawing.Font("Century Gothic", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.btnDebtor.ForeColor = System.Drawing.Color.WhiteSmoke;
            this.btnDebtor.Location = new System.Drawing.Point(20, 286);
            this.btnDebtor.Name = "btnDebtor";
            this.btnDebtor.Size = new System.Drawing.Size(260, 53);
            this.btnDebtor.TabIndex = 23;
            this.btnDebtor.Text = "Дебитор";
            this.btnDebtor.UseVisualStyleBackColor = true;
            this.btnDebtor.Click += new System.EventHandler(this.btnDebtor_Click);
            // 
            // btnCreditor
            // 
            this.btnCreditor.FlatAppearance.BorderColor = System.Drawing.Color.WhiteSmoke;
            this.btnCreditor.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCreditor.Font = new System.Drawing.Font("Century Gothic", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.btnCreditor.ForeColor = System.Drawing.Color.WhiteSmoke;
            this.btnCreditor.Location = new System.Drawing.Point(286, 286);
            this.btnCreditor.Name = "btnCreditor";
            this.btnCreditor.Size = new System.Drawing.Size(260, 53);
            this.btnCreditor.TabIndex = 24;
            this.btnCreditor.Text = "Кредитор";
            this.btnCreditor.UseVisualStyleBackColor = true;
            this.btnCreditor.Click += new System.EventHandler(this.btnCreditor_Click);
            // 
            // interestsSeparator
            // 
            this.interestsSeparator.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(208)))), ((int)(((byte)(255)))));
            this.interestsSeparator.Location = new System.Drawing.Point(705, 217);
            this.interestsSeparator.Name = "interestsSeparator";
            this.interestsSeparator.Size = new System.Drawing.Size(198, 1);
            this.interestsSeparator.TabIndex = 25;
            this.interestsSeparator.Visible = false;
            // 
            // interestWithCurrencyTextBox
            // 
            this.interestWithCurrencyTextBox.BackColor = System.Drawing.Color.White;
            this.interestWithCurrencyTextBox.Font = new System.Drawing.Font("Calibri", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.interestWithCurrencyTextBox.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(50)))), ((int)(((byte)(50)))), ((int)(((byte)(50)))));
            this.interestWithCurrencyTextBox.Location = new System.Drawing.Point(705, 174);
            this.interestWithCurrencyTextBox.MaxLength = 15;
            this.interestWithCurrencyTextBox.Name = "interestWithCurrencyTextBox";
            this.interestWithCurrencyTextBox.Size = new System.Drawing.Size(198, 36);
            this.interestWithCurrencyTextBox.TabIndex = 26;
            this.interestWithCurrencyTextBox.Text = "0";
            this.interestWithCurrencyTextBox.Visible = false;
            this.interestWithCurrencyTextBox.WordWrap = false;
            // 
            // interestWithPercentageTextBox
            // 
            this.interestWithPercentageTextBox.BackColor = System.Drawing.Color.White;
            this.interestWithPercentageTextBox.Font = new System.Drawing.Font("Calibri", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.interestWithPercentageTextBox.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(50)))), ((int)(((byte)(50)))), ((int)(((byte)(50)))));
            this.interestWithPercentageTextBox.Location = new System.Drawing.Point(705, 224);
            this.interestWithPercentageTextBox.MaxLength = 7;
            this.interestWithPercentageTextBox.Name = "interestWithPercentageTextBox";
            this.interestWithPercentageTextBox.Size = new System.Drawing.Size(198, 36);
            this.interestWithPercentageTextBox.TabIndex = 27;
            this.interestWithPercentageTextBox.Text = "0";
            this.interestWithPercentageTextBox.Visible = false;
            this.interestWithPercentageTextBox.WordWrap = false;
            // 
            // interestWithCurrencyLabel
            // 
            this.interestWithCurrencyLabel.AutoSize = true;
            this.interestWithCurrencyLabel.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.interestWithCurrencyLabel.Font = new System.Drawing.Font("Century Gothic", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.interestWithCurrencyLabel.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(208)))), ((int)(((byte)(255)))));
            this.interestWithCurrencyLabel.Location = new System.Drawing.Point(909, 176);
            this.interestWithCurrencyLabel.Name = "interestWithCurrencyLabel";
            this.interestWithCurrencyLabel.Size = new System.Drawing.Size(44, 30);
            this.interestWithCurrencyLabel.TabIndex = 28;
            this.interestWithCurrencyLabel.Text = "лв.";
            this.interestWithCurrencyLabel.Visible = false;
            // 
            // interestWithPercentageLabel
            // 
            this.interestWithPercentageLabel.AutoSize = true;
            this.interestWithPercentageLabel.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.interestWithPercentageLabel.Font = new System.Drawing.Font("Century Gothic", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.interestWithPercentageLabel.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(208)))), ((int)(((byte)(255)))));
            this.interestWithPercentageLabel.Location = new System.Drawing.Point(909, 226);
            this.interestWithPercentageLabel.Name = "interestWithPercentageLabel";
            this.interestWithPercentageLabel.Size = new System.Drawing.Size(32, 30);
            this.interestWithPercentageLabel.TabIndex = 29;
            this.interestWithPercentageLabel.Text = "%";
            this.interestWithPercentageLabel.Visible = false;
            // 
            // sinceLabel
            // 
            this.sinceLabel.AutoSize = true;
            this.sinceLabel.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.sinceLabel.Font = new System.Drawing.Font("Century Gothic", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.sinceLabel.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(208)))), ((int)(((byte)(255)))));
            this.sinceLabel.Location = new System.Drawing.Point(656, 30);
            this.sinceLabel.Name = "sinceLabel";
            this.sinceLabel.Size = new System.Drawing.Size(43, 30);
            this.sinceLabel.TabIndex = 30;
            this.sinceLabel.Text = "От";
            // 
            // dueDateLabel
            // 
            this.dueDateLabel.AutoSize = true;
            this.dueDateLabel.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.dueDateLabel.Font = new System.Drawing.Font("Century Gothic", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.dueDateLabel.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(208)))), ((int)(((byte)(255)))));
            this.dueDateLabel.Location = new System.Drawing.Point(652, 80);
            this.dueDateLabel.Name = "dueDateLabel";
            this.dueDateLabel.Size = new System.Drawing.Size(47, 30);
            this.dueDateLabel.TabIndex = 31;
            this.dueDateLabel.Text = "До";
            // 
            // sinceDatePicker
            // 
            this.sinceDatePicker.Font = new System.Drawing.Font("Microsoft Sans Serif", 16.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.sinceDatePicker.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.sinceDatePicker.Location = new System.Drawing.Point(705, 26);
            this.sinceDatePicker.MaxDate = new System.DateTime(3020, 12, 31, 0, 0, 0, 0);
            this.sinceDatePicker.Name = "sinceDatePicker";
            this.sinceDatePicker.Size = new System.Drawing.Size(198, 38);
            this.sinceDatePicker.TabIndex = 32;
            this.sinceDatePicker.Value = new System.DateTime(2020, 2, 9, 0, 0, 0, 0);
            // 
            // dueDatePicker
            // 
            this.dueDatePicker.Font = new System.Drawing.Font("Microsoft Sans Serif", 16.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.dueDatePicker.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dueDatePicker.Location = new System.Drawing.Point(705, 76);
            this.dueDatePicker.MaxDate = new System.DateTime(2099, 12, 31, 0, 0, 0, 0);
            this.dueDatePicker.Name = "dueDatePicker";
            this.dueDatePicker.Size = new System.Drawing.Size(198, 38);
            this.dueDatePicker.TabIndex = 33;
            this.dueDatePicker.Value = new System.DateTime(2020, 2, 9, 0, 0, 0, 0);
            // 
            // btnCancel
            // 
            this.btnCancel.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.btnCancel.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(208)))), ((int)(((byte)(255)))));
            this.btnCancel.FlatAppearance.MouseDownBackColor = System.Drawing.Color.White;
            this.btnCancel.FlatAppearance.MouseOverBackColor = System.Drawing.Color.White;
            this.btnCancel.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCancel.Font = new System.Drawing.Font("Century Gothic", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.btnCancel.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(208)))), ((int)(((byte)(255)))));
            this.btnCancel.Location = new System.Drawing.Point(564, 281);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(200, 65);
            this.btnCancel.TabIndex = 34;
            this.btnCancel.Text = "Отказ";
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // btnConfirm
            // 
            this.btnConfirm.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.btnConfirm.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(208)))), ((int)(((byte)(255)))));
            this.btnConfirm.FlatAppearance.MouseDownBackColor = System.Drawing.Color.White;
            this.btnConfirm.FlatAppearance.MouseOverBackColor = System.Drawing.Color.White;
            this.btnConfirm.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnConfirm.Font = new System.Drawing.Font("Century Gothic", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.btnConfirm.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(208)))), ((int)(((byte)(255)))));
            this.btnConfirm.Location = new System.Drawing.Point(770, 281);
            this.btnConfirm.Name = "btnConfirm";
            this.btnConfirm.Size = new System.Drawing.Size(200, 65);
            this.btnConfirm.TabIndex = 35;
            this.btnConfirm.Text = "Запиши";
            this.btnConfirm.UseVisualStyleBackColor = true;
            this.btnConfirm.Click += new System.EventHandler(this.btnConfirm_Click);
            // 
            // EditTransactorForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(40)))), ((int)(((byte)(40)))));
            this.ClientSize = new System.Drawing.Size(982, 358);
            this.Controls.Add(this.btnConfirm);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.dueDatePicker);
            this.Controls.Add(this.sinceDatePicker);
            this.Controls.Add(this.dueDateLabel);
            this.Controls.Add(this.sinceLabel);
            this.Controls.Add(this.interestWithPercentageLabel);
            this.Controls.Add(this.interestWithCurrencyLabel);
            this.Controls.Add(this.interestWithPercentageTextBox);
            this.Controls.Add(this.interestWithCurrencyTextBox);
            this.Controls.Add(this.interestsSeparator);
            this.Controls.Add(this.btnCreditor);
            this.Controls.Add(this.btnDebtor);
            this.Controls.Add(this.amountTextBox);
            this.Controls.Add(this.facebookTextBox);
            this.Controls.Add(this.emailTextBox);
            this.Controls.Add(this.phoneTextBox);
            this.Controls.Add(this.nameTextBox);
            this.Controls.Add(this.interestCheckBox);
            this.Controls.Add(this.amountLabel);
            this.Controls.Add(this.facebookLabel);
            this.Controls.Add(this.emailLabel);
            this.Controls.Add(this.phoneLabel);
            this.Controls.Add(this.nameLabel);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximumSize = new System.Drawing.Size(1000, 405);
            this.MinimumSize = new System.Drawing.Size(1000, 405);
            this.Name = "EditTransactorForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Редактирай";
            this.Load += new System.EventHandler(this.EditTransactorForm_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label nameLabel;
        private System.Windows.Forms.Label phoneLabel;
        private System.Windows.Forms.Label emailLabel;
        private System.Windows.Forms.Label facebookLabel;
        private System.Windows.Forms.Label amountLabel;
        private System.Windows.Forms.CheckBox interestCheckBox;
        private System.Windows.Forms.TextBox nameTextBox;
        private System.Windows.Forms.TextBox phoneTextBox;
        private System.Windows.Forms.TextBox emailTextBox;
        private System.Windows.Forms.TextBox facebookTextBox;
        private System.Windows.Forms.TextBox amountTextBox;
        private System.Windows.Forms.Button btnDebtor;
        private System.Windows.Forms.Button btnCreditor;
        private System.Windows.Forms.Panel interestsSeparator;
        private System.Windows.Forms.TextBox interestWithCurrencyTextBox;
        private System.Windows.Forms.TextBox interestWithPercentageTextBox;
        private System.Windows.Forms.Label interestWithCurrencyLabel;
        private System.Windows.Forms.Label interestWithPercentageLabel;
        private System.Windows.Forms.Label sinceLabel;
        private System.Windows.Forms.Label dueDateLabel;
        private System.Windows.Forms.DateTimePicker sinceDatePicker;
        private System.Windows.Forms.DateTimePicker dueDatePicker;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.Button btnConfirm;
    }
}