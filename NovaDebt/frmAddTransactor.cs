using System;
using System.Drawing;
using System.Windows.Forms;

namespace NovaDebt
{
    public partial class frmAddTransactor : Form
    {
        public frmAddTransactor()
        {
            InitializeComponent();

            btnAddConfirm.TabStop = false;
            btnAddConfirm.FlatStyle = FlatStyle.Flat;
            btnAddConfirm.FlatAppearance.BorderSize = 1;
            btnAddConfirm.FlatAppearance.BorderColor = Color.FromArgb(0, 208, 255);

            btnAddCancel.TabStop = false;
            btnAddCancel.FlatStyle = FlatStyle.Flat;
            btnAddCancel.FlatAppearance.BorderSize = 1;
            btnAddCancel.FlatAppearance.BorderColor = Color.FromArgb(0, 208, 255);
        }

        private void btnAddConfirm_Click(object sender, EventArgs e)
        {
        }

        private void btnAddCancel_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show($"Данните няма да бъдат запазени.{Environment.NewLine}Наистина ли искате да излезете?",
                "Изход",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question) == DialogResult.Yes)
            {
                this.Close();
            }
        }
    }
}
