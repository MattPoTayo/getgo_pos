using GetGoPOS.Helpers;
using GetGoPOS.Model;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GetGoPOS.Views.Modal
{
    public partial class ReprintVoidForm : Form
    {
        public bool IsReprint { get; set; } = false;
        public ReprintVoidForm()
        {
            InitializeComponent();
        }

        private void ReprintVoidForm_Load(object sender, EventArgs e)
        {
            this.KeyPreview = true;
            this.Text = string.Empty;
            this.ControlBox = false;
            this.DoubleBuffered = true;
            this.MaximizedBounds = Screen.FromHandle(this.Handle).WorkingArea;
            txtInvoice.Text = DataHandler.GetCurrentInvoice();
            txtInvoice.Focus();

            if (!IsReprint)
            {
                lblTitle.Text = "Void Transaction";
                iconPictureBox1.IconChar = FontAwesome.Sharp.IconChar.TrashAlt;
            }
        }

        private void ReprintVoidForm_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
                btnClose.PerformClick();
            else if (e.KeyCode == Keys.Enter)
                btnOkay.PerformClick();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void txtInvoice_Leave(object sender, EventArgs e)
        {
            txtInvoice.Focus();
        }

        private void txtInvoice_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) &&
            (e.KeyChar != '.'))
            {
                e.Handled = true;
            }

            //// only allow one decimal point
            //if ((e.KeyChar == '.') && ((sender as TextBox).Text.IndexOf('.') > -1))
            //{
            //    e.Handled = true;
            //}
        }

        private void btnOkay_Click(object sender, EventArgs e)
        {
            txtInvoice.Text.Trim();
            if (txtInvoice.Text.Length == 0)
                return;
            string invoicenumber = txtInvoice.Text;
            Transaction trans = DataHandler.GetTransactionByInvoice(invoicenumber);
            if (trans == null)
                FncFilter.Alert("Invalid Invoice Number.");
            else
            {
                if (IsReprint)
                {
                    HardwareHelper.Print(trans, true, false);
                    this.Close();
                }
                else
                {
                    DataHandler.VoidTransaction(trans);
                    HardwareHelper.Print(trans, false, true);
                    this.Close();
                }
            }
        }
    }
}
