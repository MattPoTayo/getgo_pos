using GetGoPOS.Helpers;
using GetGoPOS.Model;
using GetGoPOS.Model.Global;
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
    public partial class PaymentForm : Form
    {
        public Transaction transaction { get; set; }
        public bool transComplete = false;
        public PaymentForm()
        {
            InitializeComponent();
            transaction = new Transaction();

        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void PaymentForm_Load(object sender, EventArgs e)
        {
            this.KeyPreview = true;
            this.Text = string.Empty;
            this.ControlBox = false;
            this.DoubleBuffered = true;
            this.MaximizedBounds = Screen.FromHandle(this.Handle).WorkingArea;

            lblDueAmount.Text = transaction.GetTotalAmountDue().ToString("N2");
            lblInvoiceD.Text = transaction.InvoiceNumber;
            lblQtyD.Text = String.Format("{0:0.##}", transaction.GetTotalQty());
        }

        private void btnExactAmount_Click(object sender, EventArgs e)
        {
            decimal tendered = FncFilter.GetDecimalValue(lblDueAmount.Text);
            decimal amountdue = FncFilter.GetDecimalValue(lblDueAmount.Text);
            SaveTransaction(amountdue, tendered);
        }

        private void btnPayment_Click(object sender, EventArgs e)
        {
            decimal tendered = FncFilter.GetDecimalValue(tbPrice.Text);
            decimal amountdue = FncFilter.GetDecimalValue(lblDueAmount.Text);
            SaveTransaction(amountdue, tendered);
        }
        private void SaveTransaction(decimal amt, decimal tnd)
        {
            if (tnd < amt)
                return;
            try
            {
                transaction.TenderAmount = tnd;
                if (!DataHandler.SaveTransaction(transaction))
                {
                    FncFilter.Alert(globalvariables.saving_failed);
                    return;
                }
                else
                {
                    HardwareHelper.Print(transaction, false, false);
                    FncFilter.Alert(globalvariables.saving_success);
                    transComplete = true;
                    this.Close();
                }
            }
            catch
            {
                FncFilter.Alert(globalvariables.saving_failed);
                return;
            }
        }
    }
}
