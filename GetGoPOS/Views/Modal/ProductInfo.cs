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
using GetGoPOS.Model.Global;
using GetGoPOS.Model;

namespace GetGoPOS.Views.Modal
{
    public partial class ProductInfo : Form
    {
        public bool newProduct = false;
        public bool forUpdate = false;
        public Product product { get; set; }
        public ProductInfo()
        {
            InitializeComponent();
        }

        private void ProductInfo_Load(object sender, EventArgs e)
        {
            this.KeyPreview = true;
            this.Text = string.Empty;
            this.ControlBox = false;
            this.DoubleBuffered = true;
            this.MaximizedBounds = Screen.FromHandle(this.Handle).WorkingArea;
            if(product != null && forUpdate)
            {
                tbProductName.Text = product.Name;
                tbPrice.Text = product.Price.ToString("N2");
                tbStockNo.Text = product.StockNo;
                lblBarcodeD.Text = product.Barcode;
                lblQtyD.Text = product.Qty.ToString("N2");
                btnAddProduct.IconChar = FontAwesome.Sharp.IconChar.Edit;
                cbProductStatus.Checked = (product.Show == 1);
            }

            if(!forUpdate)
            {
                lblBarcodeD.Text = DataHandler.GetNextBarcode();
                lblQty.Visible = false;
                lblQtyD.Visible = false;
                cbProductStatus.Enabled = false;
                cbProductStatus.Visible = false;
            }

        }

        private void ProductInfo_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
                this.Close();
        }
        private bool CheckFields()
        {
            decimal amt = FncFilter.GetDecimalValue(tbPrice.Text);
            if (amt == 0)
            {
                FncFilter.Alert(globalvariables.warning_invalid_amount);
                tbPrice.Focus();
                tbPrice.SelectAll();
                return false;
            }

            tbProductName.Text.Trim();
            if (tbProductName.Text == "")
            {
                FncFilter.Alert(globalvariables.warning_invalid_product);
                tbProductName.Focus();
                tbProductName.SelectAll();
                return false;
            }

            tbStockNo.Text.Trim();
            if (tbStockNo.Text == "")
            {
                FncFilter.Alert(globalvariables.warning_invalid_stockno);
                tbStockNo.Focus();
                tbStockNo.SelectAll();
                return false;
            }

            return true;
        }
        private void btnAddProduct_Click(object sender, EventArgs e)
        {
            if (!CheckFields())
                return;

            if (!forUpdate)
            {
                decimal price = FncFilter.GetDecimalValue(tbPrice.Text);
                string name = tbProductName.Text;
                string stockno = tbStockNo.Text;

                Product newproduct = new Product()
                {
                    Name = name,
                    StockNo = stockno,
                    Price = price
                };
                if (!DataHandler.SaveProduct(newproduct))
                {
                    FncFilter.Alert(globalvariables.saving_failed);
                    return;
                }
                else
                {
                    FncFilter.Alert(globalvariables.saving_success);
                    newProduct = true;
                    this.Close();
                }
            }
            else
            {
                decimal price = FncFilter.GetDecimalValue(tbPrice.Text);
                string name = tbProductName.Text;
                string stockno = tbStockNo.Text;

                product.Name = name;
                product.Price = price;
                product.StockNo = stockno;
                product.Show = cbProductStatus.Checked ? 1 : 0;

                if (!DataHandler.UpdateProduct(product))
                {
                    FncFilter.Alert(globalvariables.saving_failed);
                    return;
                }
                else
                {
                    FncFilter.Alert(globalvariables.saving_success);
                    newProduct = true;
                    this.Close();
                }
            }
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
