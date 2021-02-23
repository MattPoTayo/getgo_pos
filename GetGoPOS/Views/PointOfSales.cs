using GetGoPOS.Helpers;
using GetGoPOS.Model;
using GetGoPOS.Model.Global;
using GetGoPOS.Views.Modal;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace GetGoPOS.Views
{
    public partial class PointOfSales : BaseForm
    {
        private List<Product> products = new List<Product>();
        private Transaction transaction { get; set; } = new Transaction();
        private int beginColumn = 0;
        private Product longestProductName = null;
        private bool isCheckSize = false;
        public PointOfSales()
        {
            InitializeComponent();

            this.dgvProduct.AutoGenerateColumns = false;
            this.KeyPreview = true;
            this.beginColumn = 0;
            globalvariables.LockedPOS = DataHandler.CheckPOSIfLocked();
        }

        private void PointOfSales_Load(object sender, EventArgs e)
        {
            FncFilter.set_dgv_controls(dgvProduct);
            FncFilter.set_dgv_controls(dgvTransactionProduct);
            foreach (DataGridViewColumn col in dgvProduct.Columns)
            {
                col.SortMode = DataGridViewColumnSortMode.NotSortable;
            }
            dgvProduct.VirtualMode = true;
            dgvProduct.CellValueNeeded += new DataGridViewCellValueEventHandler(dgvProduct_CellValueNeeded);
            dgvTransactionProduct.VirtualMode = true;
            dgvTransactionProduct.CellValueNeeded += new DataGridViewCellValueEventHandler(dgvTransactionProduct_CellValueNeeded);
            InitializeTransaction();
        }
        private void dgvProduct_CellValueNeeded(object sender, DataGridViewCellValueEventArgs e)
        {
            if (products.Count == 0 || e.RowIndex >= products.Count || !this.dgvProduct.Columns[e.ColumnIndex].Visible ||
                (isCheckSize && longestProductName == null))
                return;

            Product product = null;
            if (isCheckSize)
                product = longestProductName;
            else
                product = products[e.RowIndex];

            switch (this.dgvProduct.Columns[e.ColumnIndex].Name)
            {
                case "colBarcode":
                    e.Value = product.Barcode;
                    break;
                case "colProductName":
                    e.Value = product.Name;
                    break;
                case "colStockNo":
                    e.Value = product.StockNo;
                    break;
                case "colPrice":
                    e.Value = product.Price.ToString("N2");
                    break;
            }
        }
        private void dgvTransactionProduct_CellValueNeeded(object sender, DataGridViewCellValueEventArgs e)
        {
            if (transaction.productlist.Count == 0 || e.RowIndex >= transaction.productlist.Count || !this.dgvTransactionProduct.Columns[e.ColumnIndex].Visible ||
                (isCheckSize && longestProductName == null))
                return;

            Product product = null;
            if (isCheckSize)
                product = longestProductName;
            else
                product = transaction.productlist[e.RowIndex];

            switch (this.dgvTransactionProduct.Columns[e.ColumnIndex].Name)
            {
                case "colTransBarcode":
                    e.Value = product.Barcode;
                    break;
                case "colTransProductName":
                    e.Value = product.Name;
                    break;
                case "colTransQty":
                    e.Value = product.Qty;
                    break;
                case "colTransPrice":
                    e.Value = product.Price.ToString("N2");
                    break;
            }
        }

        private void keyDownTimer_Tick(object sender, EventArgs e)
        {
            keyDownTimer.Stop();
            if (this.txtKeyword.Text.Trim().Length == 0)
            {
                this.dgvProduct.RowCount = 0;
                products.Clear();
                FncFilter.SetGridViewDisplay(this.dgvProduct, false);
                return;
            }
            if (!bgwSearchProduct.IsBusy)
            {
                pbLoad.Visible = true;
                bgwSearchProduct.RunWorkerAsync();
            }
        }

        private void bgwSearchProduct_DoWork(object sender, DoWorkEventArgs e)
        {
            string SQLSearch = "";
            e.Result = false;
            string str_input = "";
            string[] words = this.txtKeyword.Text.Split(' ');
            foreach (string word in words)
            {
                if (word.Length > 0)
                    str_input += "%" + word;
            }
            str_input += "%";
            SQLSearch = string.Format(@"SELECT * 
                                FROM Product 
                                WHERE (productname LIKE '{0}' OR
                                    barcode LIKE '{1}' OR
                                    stockno LIKE '{2}')", str_input, str_input, str_input);



            DataTable productDataTable = DataBaseHelper.GetDB(SQLSearch);
            products.Clear();
            this.bgwSearchProduct.ReportProgress(0);
            //dgvProduct.DataSource = result;
            foreach (DataRow productDataRow in productDataTable.Rows)
            {
                decimal actualPrice = Convert.ToDecimal(productDataRow["price"].ToString());
                products.Add(
                    new Product
                    {
                        ID = Convert.ToInt64(productDataRow["id"]),
                        Name = productDataRow["productname"].ToString(),
                        Barcode = productDataRow["barcode"].ToString(),
                        StockNo = productDataRow["stockno"].ToString(),
                        Price = actualPrice,
                        Qty = FncFilter.GetDecimalValue(productDataRow["inventory"].ToString()),
                        Show = Convert.ToInt32(productDataRow["discontinued"].ToString())
                    }
                );
            }
            longestProductName = null;
            List<string> productNames = new List<string>();
            if (products.Count != 0)
            {
                products.ForEach(x => productNames.AddRange(x.Name.Split(' ')));
                int textLength = productNames.Max(s => s.Length);
                string productName = productNames.FirstOrDefault(s => s.Length == textLength);
                longestProductName = products.FirstOrDefault(s => s.Name.Contains(productName));
            }
            this.bgwSearchProduct.ReportProgress(1);
        }

        private void txtKeyword_TextChanged(object sender, EventArgs e)
        {
            keyDownTimer.Stop();
            keyDownTimer.Start();
        }

        private void txtKeyword_Leave(object sender, EventArgs e)
        {
        }

        private void bgwSearchProduct_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            //Un-comment to record speed in log.
            //DateTime startTime = DateTime.Now;
            if (e.ProgressPercentage == 0)
                dgvProduct.RowCount = 0;

            if (e.ProgressPercentage == 1 && products.Count != 0)
            {
                isCheckSize = false;
                dgvProduct.RowCount = products.Count;
            }
            // Un - comment to record speed in log.
            //LOGS.LOG_PRINT(string.Format("BG_PROGRESS, complete run in {0} ms", (DateTime.Now - startTime).TotalMilliseconds));
        }

        private void bgwSearchProduct_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            pbLoad.Visible = false;
        }
        private void InitializeTransaction()
        {
            transaction = new Transaction();
            dgvTransactionProduct.RowCount = 0;
            transaction.InvoiceNumber = DataHandler.GetNextORNumber().PadLeft(7, '0');
            lblORNumber.Text = transaction.InvoiceNumber;

            RefreshTransactionDetails();
        }

        private void dgvProduct_CellContentDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            AddProduct();
        }

        private void AddProduct()
        {
            if(globalvariables.LockedPOS)
            {
                FncFilter.Alert("POS is Locked, Z-Read already generated");
                return;
            }

            if (dgvProduct.SelectedRows.Count <= 0)
                return;

            Product product = products[dgvProduct.SelectedRows[0].Index];
            try
            {
                bool alreadyExists = transaction.productlist.Any(x => x.ID == product.ID);
                if (alreadyExists)
                {
                    int index = transaction.productlist.FindIndex(a => a.ID == product.ID);
                    transaction.productlist[index].Qty = transaction.productlist[index].Qty + 1;

                }
                else
                {
                    product.Qty = 1;
                    transaction.productlist.Add(product);
                }
                dgvTransactionProduct.RowCount = transaction.productlist.Count;
                dgvTransactionProduct.Refresh();
                RefreshTransactionDetails();
            }
            catch { }
        }

        private void btnPayment_Click(object sender, EventArgs e)
        {
            if (transaction.productlist.Count == 0)
                return;
            PaymentForm payment = new PaymentForm();
            payment.transaction = transaction;
            payment.ShowDialog();
            if (payment.transComplete)
                InitializeTransaction();
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            dgvTransactionProduct.RowCount = 0;
            transaction.productlist.Clear();
            RefreshTransactionDetails();
        }

        private void RefreshTransactionDetails()
        {
            if (globalvariables.LockedPOS)
            {
                panel2.Enabled = false;
            }
            else
            {

                lblAmoundDueD.Text = transaction.GetTotalAmountDue().ToString("N2");
                lblTotalQtyD.Text = String.Format("{0:0.##}", transaction.GetTotalQty());

                if (dgvTransactionProduct.Rows.Count <= 0 && dgvTransactionProduct.SelectedRows.Count <= 0)
                {
                    lblQtyD.Text = "0";
                    lblQtyD.Enabled = false;
                    btnChangeQty.Enabled = false;
                }
                else
                {
                    try
                    {
                        lblQtyD.Text = String.Format("{0:0.##}", transaction.productlist[dgvTransactionProduct.SelectedRows[0].Index].Qty);
                        btnChangeQty.Enabled = true;
                        lblQtyD.Enabled = true;
                    }
                    catch
                    {
                        lblQtyD.Text = "0";
                        btnChangeQty.Enabled = false;
                        lblQtyD.Enabled = false;
                    }
                }
            }
        }

        private void btnRemove_Click(object sender, EventArgs e)
        {
            if (dgvTransactionProduct.SelectedRows.Count <= 0)
                return;

            int index = dgvTransactionProduct.SelectedRows[0].Index;
            transaction.productlist.RemoveAt(index);

            if (transaction.productlist.Count <= 0)
            {
                dgvTransactionProduct.RowCount = 0;
            }
            else
                dgvTransactionProduct.RowCount = transaction.productlist.Count;

            dgvTransactionProduct.Refresh();
            RefreshTransactionDetails();
        }

        private void dgvTransactionProduct_SelectionChanged(object sender, EventArgs e)
        {
            RefreshTransactionDetails();
        }

        private void btnChangeQty_Click(object sender, EventArgs e)
        {
            if (dgvTransactionProduct.SelectedRows.Count <= 0)
                return;

            int index = dgvTransactionProduct.SelectedRows[0].Index;
            decimal qty = FncFilter.GetDecimalValue(lblQtyD.Text);
            transaction.productlist[index].Qty = qty;

            dgvTransactionProduct.Refresh();
            RefreshTransactionDetails();
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            AddProduct();
        }

        private void btnReprint_Click(object sender, EventArgs e)
        {
            ReprintVoidForm reprintVoidForm = new ReprintVoidForm();
            reprintVoidForm.IsReprint = true;
            reprintVoidForm.ShowDialog();
        }

        private void btnVoid_Click(object sender, EventArgs e)
        {
            if (globalvariables.LockedPOS)
            {
                FncFilter.Alert("POS is Locked, Z-Read already generated");
                return;
            }
            ReprintVoidForm reprintVoidForm = new ReprintVoidForm();
            reprintVoidForm.IsReprint = false;
            reprintVoidForm.ShowDialog();
        }

        private void btnOpenDrawer_Click(object sender, EventArgs e)
        {
            RawPrinterHelper.OpenCashDrawer(false);
        }

        private void btnXRead_Click(object sender, EventArgs e)
        {
            if(GenerateReport.XRead(DateTime.Now))
            {
                FncFilter.Alert("X-Read Generation Success");
            }
        }

        private void btnZRead_Click(object sender, EventArgs e)
        {
            if (FncFilter.ConfirmYesNo(globalvariables.confirm_lock_pos))
            {
                GenerateReport.ZRead(DateTime.Now);
                globalvariables.LockedPOS = true;
                RefreshTransactionDetails();
            }
            else
                return;
        }

        private void btnPayment_MouseHover(object sender, EventArgs e)
        {
        }
    }
}
