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
using GetGoPOS.Views.Modal;

namespace GetGoPOS.Views
{
    public partial class ManageInventory : BaseForm
    {

        private List<Inventory> inventories = new List<Inventory>();
        private int beginColumn = 0;
        private Inventory longestProductName = null;
        private bool isCheckSize = false;
        public ManageInventory()
        {
            InitializeComponent();

            this.dgvInventory.AutoGenerateColumns = false;
            this.KeyPreview = true;
            this.beginColumn = 0;
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

        private void ManageInventory_Load(object sender, EventArgs e)
        {
            foreach (DataGridViewColumn col in dgvInventory.Columns)
            {
                col.SortMode = DataGridViewColumnSortMode.NotSortable;
                col.AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells;
            }
            FncFilter.set_dgv_controls(dgvInventory);
            dgvInventory.VirtualMode = true;
            dgvInventory.CellValueNeeded += new DataGridViewCellValueEventHandler(dgvInventory_CellValueNeeded);
        }
        private void dgvInventory_CellValueNeeded(object sender, DataGridViewCellValueEventArgs e)
        {
            if (inventories.Count == 0 || e.RowIndex >= inventories.Count || !this.dgvInventory.Columns[e.ColumnIndex].Visible ||
                (isCheckSize && longestProductName == null))
                return;

            Inventory invent = null;
            if (isCheckSize)
                invent = longestProductName;
            else
                invent = inventories[e.RowIndex];

            switch (this.dgvInventory.Columns[e.ColumnIndex].Name)
            {
                case "colID":
                    e.Value = invent.ID;
                    break;
                case "colProductName":
                    e.Value = invent.ProductInfo.Name;
                    break;
                case "colQuantity":
                    e.Value = invent.Quantity;
                    break;
                case "colDate":
                    e.Value = invent.Date;
                    break;
                case "colManual":
                    e.Value = invent.Manual;
                    break;
            }
        }
        private void txtKeyword_TextChanged(object sender, EventArgs e)
        {
            keyDownTimer.Stop();
            keyDownTimer.Start();
        }

        private void ManageInventory_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Down)
            {
                if (dgvInventory.RowCount != 0)
                {
                    int current_row = dgvInventory.CurrentCell.RowIndex;
                    int next_row = current_row + 1;
                    dgvInventory.MultiSelect = false;

                    if (next_row < dgvInventory.RowCount)
                    {
                        dgvInventory.Rows[next_row].Selected = true;
                        dgvInventory.CurrentCell = dgvInventory[beginColumn, next_row];
                    }
                    else
                        return;
                }
                else
                    return;
            }
            else if (e.KeyCode == Keys.Up)
            {
                if (dgvInventory.RowCount != 0)
                {
                    int current_row = dgvInventory.CurrentCell.RowIndex;
                    int next_row = current_row - 1;
                    dgvInventory.MultiSelect = false;

                    if (next_row > -1)
                    {
                        dgvInventory.Rows[next_row].Selected = true;
                        dgvInventory.CurrentCell = dgvInventory[beginColumn, next_row];
                    }
                    else
                        return;
                }
                else
                    return;
            }
            else if (e.KeyCode == Keys.Enter)
            {
                //ViewProduct();
            }
            else
                return;
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

        private void bgwSearchProduct_DoWork(object sender, DoWorkEventArgs e)
        {
            string SQLSearch = "";
            txtKeyword.Text.Trim();
            string filtermanual = "";
            if(rbManual.Checked)
            {
                filtermanual = @" AND IA.manual = 1";
            }
            else if(rbAuto.Checked)
            {
                filtermanual = @" AND TH.sales = 1 AND IA.manual = 0";
            }

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
                SQLSearch = string.Format(@"SELECT 
	                                            IA.*, 
	                                            P.productname, 
	                                            P.barcode, 
	                                            P.stockno 
                                            FROM InventoryAdjust IA
                                            LEFT JOIN Product P 
	                                            ON P.ID = IA.productid 
                                            LEFT JOIN TransactionHead TH
	                                            ON TH.ID = IA.headid
                                            WHERE (P.productname LIKE '{0}' 
	                                            OR P.barcode LIKE '{1}' 
	                                            OR P.stockno LIKE '{2}'){3} ORDER BY IA.id DESC", str_input, str_input, str_input, filtermanual);
            }
            else
            {
                SQLSearch = string.Format(@"SELECT 
	                                            IA.*, 
	                                            P.productname, 
	                                            P.barcode, 
	                                            P.stockno 
                                            FROM InventoryAdjust IA
                                            LEFT JOIN Product P 
	                                            ON P.ID = IA.productid 
                                            LEFT JOIN TransactionHead TH
	                                            ON TH.ID = IA.headid
                                            WHERE IA.id > 0{0} ORDER BY IA.id DESC", filtermanual);
            }


           DataTable inventoryDataTable = DataBaseHelper.GetDB(SQLSearch);
            inventories.Clear();
            this.bgwSearchProduct.ReportProgress(0);
            //dgvProduct.DataSource = result;
            foreach (DataRow inventoryDataRow in inventoryDataTable.Rows)
            {
                //decimal actualPrice = Convert.ToDecimal(inventoryDataRow["price"].ToString());
                long prodID = Convert.ToInt64(inventoryDataRow["productid"]);
                Product prod = new Product();
                prod.SetProductByID(prodID.ToString());
                inventories.Add(
                    new Inventory
                    {
                        ID = Convert.ToInt64(inventoryDataRow["id"]),
                        ProductID = prodID,
                        ProductInfo = prod,
                        Quantity = Convert.ToDecimal(inventoryDataRow["quantity"]),
                        HeadID = Convert.ToInt64(inventoryDataRow["headid"].ToString()),
                        Manual = Convert.ToInt32(inventoryDataRow["manual"]) == 1 ? true : false,
                        Date = Convert.ToDateTime(inventoryDataRow["transdate"].ToString()),
                        ActualDate = Convert.ToDateTime(inventoryDataRow["date"].ToString())
                    }
                );
            }
            longestProductName = null;
            List<string> productNames = new List<string>();
            if (inventories.Count != 0)
            {
                inventories.ForEach(x => productNames.AddRange(x.ProductInfo.Name.Split(' ')));
                int textLength = productNames.Max(s => s.Length);
                string productName = productNames.FirstOrDefault(s => s.Length == textLength);
                longestProductName = inventories.FirstOrDefault(s => s.ProductInfo.Name.Contains(productName));
            }
            this.bgwSearchProduct.ReportProgress(1);
        }

        private void bgwSearchProduct_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            //Un-comment to record speed in log.
            //DateTime startTime = DateTime.Now;
            if (e.ProgressPercentage == 0)
                dgvInventory.RowCount = 0;

            if (e.ProgressPercentage == 1 && inventories.Count != 0)
            {
                isCheckSize = false;
                dgvInventory.RowCount = inventories.Count;
            }
            // Un - comment to record speed in log.
            //LOGS.LOG_PRINT(string.Format("BG_PROGRESS, complete run in {0} ms", (DateTime.Now - startTime).TotalMilliseconds));
        }

        private void bgwSearchProduct_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            pbLoad.Visible = false;
        }

        private void btnSearchProduct_Click(object sender, EventArgs e)
        {
            if (!bgwSearchProduct.IsBusy)
            {
                pbLoad.Visible = true;
                bgwSearchProduct.RunWorkerAsync();
            }
        }

        private void cbViewAll_CheckedChanged(object sender, EventArgs e)
        {
            if (!bgwSearchProduct.IsBusy)
            {
                pbLoad.Visible = true;
                bgwSearchProduct.RunWorkerAsync();
            }
        }

        private void btnAddProduct_Click(object sender, EventArgs e)
        {
            AddAdjustmentForm addAdjust = new AddAdjustmentForm();
            addAdjust.ShowDialog();
            if(!bgwSearchProduct.IsBusy)
            {
                pbLoad.Visible = true;
                bgwSearchProduct.RunWorkerAsync();
            }
        }

        private void rbAll_CheckedChanged(object sender, EventArgs e)
        {
            if (!bgwSearchProduct.IsBusy)
            {
                pbLoad.Visible = true;
                bgwSearchProduct.RunWorkerAsync();
            }
        }

        private void rbManual_CheckedChanged(object sender, EventArgs e)
        {
            if (!bgwSearchProduct.IsBusy)
            {
                pbLoad.Visible = true;
                bgwSearchProduct.RunWorkerAsync();
            }
        }

        private void rbAuto_CheckedChanged(object sender, EventArgs e)
        {
            if (!bgwSearchProduct.IsBusy)
            {
                pbLoad.Visible = true;
                bgwSearchProduct.RunWorkerAsync();
            }
        }

        private void btnRecompute_Click(object sender, EventArgs e)
        {
            if(!bwRecompute.IsBusy)
            {
                pbLoad.Visible = true;
                bwRecompute.RunWorkerAsync();
            }
        }

        private void bwRecompute_DoWork(object sender, DoWorkEventArgs e)
        {
            DataTable dbprod = DataBaseHelper.GetDB(@"SELECT * FROM Product WHERE discontinued = 1");
            List<Product> productlist = new List<Product>();

            if (dbprod.Rows.Count == 0)
                return;

            foreach(DataRow dr in dbprod.Rows)
            {
                Product prod = new Product();
                long ID = Convert.ToInt64(dr["id"]);
                prod.SetProductByID(ID.ToString());
                productlist.Add(prod);
            }    

            foreach(Product product in productlist)
            {
                decimal qty = 0;
                DataTable qtydt = DataBaseHelper.GetDB(string.Format(@"SELECT SUM(quantity) AS qty
                                                FROM InventoryAdjust WHERE productid = '{0}'", product.ID));
                if (qtydt.Rows.Count == 0 || qtydt == null)
                    qty = 0;
                else
                {
                    try
                    {
                        qty = Convert.ToDecimal(qtydt.Rows[0]["qty"]);
                    }
                    catch { qty = 0; }
                }

                DataBaseHelper.SetDB(string.Format(@"UPDATE Product
                                        SET inventory = '{0}'
                                        WHERE id = '{1}'", qty, product.ID));
            }
        }

        private void bwRecompute_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            pbLoad.Visible = false;
            FncFilter.Alert("Recompute Complete!");
        }
    }
}
