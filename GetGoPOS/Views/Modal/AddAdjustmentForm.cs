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
    public partial class AddAdjustmentForm : Form
    {
        private List<Product> products = new List<Product>();
        private List<Inventory> adjustments { get; set; } = new List<Inventory>();
        private int beginColumn = 0;
        private Product longestProductName = null;
        private bool isCheckSize = false;
        public AddAdjustmentForm()
        {
            InitializeComponent();

            this.KeyPreview = true;
            this.Text = string.Empty;
            this.ControlBox = false;
            this.DoubleBuffered = true;
            this.MaximizedBounds = Screen.FromHandle(this.Handle).WorkingArea;
        }

        private void AddAdjustmentForm_Load(object sender, EventArgs e)
        {
            FncFilter.set_dgv_controls(dgvProduct);
            FncFilter.set_dgv_controls(dgvAdjustments);
            foreach (DataGridViewColumn col in dgvProduct.Columns)
            {
                col.SortMode = DataGridViewColumnSortMode.NotSortable;
            }
            dgvProduct.VirtualMode = true;
            dgvProduct.CellValueNeeded += new DataGridViewCellValueEventHandler(dgvProduct_CellValueNeeded);
            dgvAdjustments.VirtualMode = true;
            dgvAdjustments.CellValueNeeded += new DataGridViewCellValueEventHandler(dgvAdjustments_CellValueNeeded);
            RefreshDetails();
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
        private void dgvAdjustments_CellValueNeeded(object sender, DataGridViewCellValueEventArgs e)
        {
            if (adjustments.Count == 0 || e.RowIndex >= adjustments.Count || !this.dgvAdjustments.Columns[e.ColumnIndex].Visible ||
                (isCheckSize && longestProductName == null))
                return;

            Inventory inventory = null;
            inventory = adjustments[e.RowIndex];
            switch (this.dgvAdjustments.Columns[e.ColumnIndex].Name)
            {
                case "colAdjProductName":
                    e.Value = inventory.ProductInfo.Name;
                    break;
                case "colQty":
                    e.Value = inventory.Quantity;
                    break;
            }
            RefreshDetails();
        }
        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
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

        private void btnAdd_Click(object sender, EventArgs e)
        {
            AddAdjustment();
        }
        private void AddAdjustment()
        {
            if (dgvProduct.SelectedRows.Count <= 0)
                return;

            Product product = products[dgvProduct.SelectedRows[0].Index];
            product.Qty = 1;
            try
            {
                bool alreadyExists = adjustments.Any(x => x.ProductInfo.ID == product.ID);
                if (alreadyExists)
                {
                    int index = adjustments.FindIndex(a => a.ProductInfo.ID == product.ID);
                    adjustments[index].Quantity += product.Qty;
                }
                else
                {
                    adjustments.Add(new Inventory() 
                    { 
                        ProductID = product.ID,
                        ProductInfo = product,
                        HeadID = 0,
                        Manual = true,
                        Quantity = 1,
                    }
                    );
                }
                dgvAdjustments.RowCount = adjustments.Count;
                dgvAdjustments.Refresh();
                //RefreshTransactionDetails();
            }
            catch { }
        }

        private void RefreshDetails()
        {

            if (dgvAdjustments.Rows.Count <= 0 && dgvAdjustments.SelectedRows.Count <= 0)
            {
                lblQtyD.Text = "0";
                lblQtyD.Enabled = false;
                btnChangeQty.Enabled = false;
            }
            else
            {
                try
                {
                    lblQtyD.Text = String.Format("{0:0.##}", adjustments[dgvAdjustments.SelectedRows[0].Index].Quantity);
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

        private void dgvAdjustments_SelectionChanged(object sender, EventArgs e)
        {
            RefreshDetails();
        }

        private void iconButton1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnChangeQty_Click(object sender, EventArgs e)
        {
            if (dgvAdjustments.SelectedRows.Count <= 0)
                return;

            int index = dgvAdjustments.SelectedRows[0].Index;
            decimal qty = FncFilter.GetDecimalValue(lblQtyD.Text);
            adjustments[index].Quantity = qty;

            dgvAdjustments.Refresh();
            RefreshDetails();
        }

        private void btnRemove_Click(object sender, EventArgs e)
        {
            if (dgvAdjustments.SelectedRows.Count <= 0)
                return;

            int index = dgvAdjustments.SelectedRows[0].Index;
            adjustments.RemoveAt(index);

            if (adjustments.Count <= 0)
            {
                dgvAdjustments.RowCount = 0;
            }
            else
                dgvAdjustments.RowCount = adjustments.Count;

            dgvAdjustments.Refresh();
            RefreshDetails();
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            dgvAdjustments.RowCount = 0;
            adjustments.Clear();
            RefreshDetails();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if(DataHandler.SaveAdjustments(adjustments))
            {
                FncFilter.Alert(globalvariables.saving_success);
                this.Close();
            }
            else
            {
                FncFilter.Alert(globalvariables.saving_failed);
                return;
            }
        }
    }
}
