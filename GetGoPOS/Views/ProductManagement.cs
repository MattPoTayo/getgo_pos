using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using GetGoPOS.Helpers;
using GetGoPOS.Model;
using GetGoPOS.Views.Modal;

namespace GetGoPOS.Views
{
    public partial class ProductManagement : BaseForm
    {

        private List<Product> products = new List<Product>();
        private int beginColumn = 0;
        private Product longestProductName = null;
        private bool isCheckSize = false;
        public ProductManagement()
        {
            InitializeComponent();

            this.dgvProduct.AutoGenerateColumns = false;
            this.KeyPreview = true;
            this.beginColumn = 0;
        }

        private void btnAddProduct_Click(object sender, EventArgs e)
        {
            ProductInfo productInfo = new ProductInfo();
            productInfo.ShowDialog();

            if (productInfo.newProduct)
                btnSearchProduct.PerformClick();
        }

        private void txtKeyword_TextChanged(object sender, EventArgs e)
        {
            keyDownTimer.Stop();
            keyDownTimer.Start();
        }
        private void ProductManagement_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Down)
            {
                if (dgvProduct.RowCount != 0)
                {
                    int current_row = dgvProduct.CurrentCell.RowIndex;
                    int next_row = current_row + 1;
                    dgvProduct.MultiSelect = false;

                    if (next_row < dgvProduct.RowCount)
                    {
                        dgvProduct.Rows[next_row].Selected = true;
                        dgvProduct.CurrentCell = dgvProduct[beginColumn, next_row];
                    }
                    else
                        return;
                }
                else
                    return;
            }
            else if (e.KeyCode == Keys.Up)
            {
                if (dgvProduct.RowCount != 0)
                {
                    int current_row = dgvProduct.CurrentCell.RowIndex;
                    int next_row = current_row - 1;
                    dgvProduct.MultiSelect = false;

                    if (next_row > -1)
                    {
                        dgvProduct.Rows[next_row].Selected = true;
                        dgvProduct.CurrentCell = dgvProduct[beginColumn, next_row];
                    }
                    else
                        return;
                }
                else
                    return;
            }
            else if (e.KeyCode == Keys.Enter)
                ViewProduct();
            else
                return;
        }
        private void ViewProduct()
        {
            if (dgvProduct.SelectedRows.Count <= 0)
                return;
            Product product = products[dgvProduct.SelectedRows[0].Index];
            try
            {
                ProductInfo productInfo = new ProductInfo();
                productInfo.product = product;
                productInfo.forUpdate = true;
                productInfo.ShowDialog();

                if (productInfo.newProduct)
                    btnSearchProduct.PerformClick();
            }
            catch { }
        }
        protected override bool ProcessCmdKey(ref Message msg, Keys keyData)
        {
            if (keyData == Keys.F10) return true;
            return base.ProcessCmdKey(ref msg, keyData);
        }

        private void txtKeyword_Leave(object sender, EventArgs e)
        {
            this.txtKeyword.Focus();
        }
        private void ProductManagement_Load(object sender, EventArgs e)
        {
            foreach (DataGridViewColumn col in dgvProduct.Columns)
            {
                col.SortMode = DataGridViewColumnSortMode.NotSortable;
                col.AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells;
            }
            FncFilter.set_dgv_controls(dgvProduct);
            dgvProduct.VirtualMode = true;
            dgvProduct.CellValueNeeded += new DataGridViewCellValueEventHandler(dgvProduct_CellValueNeeded);
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
                case "colInventory":
                    e.Value = product.Qty.ToString("N2");
                    break;
            }
        }
        private void keyDownTimer_Tick(object sender, EventArgs e)
        {
            keyDownTimer.Stop();
            if (this.txtKeyword.Text.Trim().Length == 0)
            {
                pbLoad.Visible = true;
                bgwSearchProduct.RunWorkerAsync();
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
            txtKeyword.Text.Trim();
            int discountinued = cbShowDiscontinued.Checked ? 0 : 1;
            if (txtKeyword.Text != "")
            {
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
                                        stockno LIKE '{2}') AND discontinued = '{3}'", str_input, str_input, str_input, discountinued);
            }
            else
            {
                SQLSearch = string.Format(@"SELECT * 
                                    FROM Product WHERE discontinued = '{0}'", discountinued);
            }


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
                ) ;
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
        private void bgwSearchProduct_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            pbLoad.Visible = false;

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

        private void btnSearchProduct_Click(object sender, EventArgs e)
        {
            if(!bgwSearchProduct.IsBusy)
            {
                pbLoad.Visible = true;
                bgwSearchProduct.RunWorkerAsync();
            }
        }

        private void dgvProduct_CellContentDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            ViewProduct();
        }

        private void chShowDiscontinued_CheckedChanged(object sender, EventArgs e)
        {
            btnSearchProduct.PerformClick();
        }
    }
}
