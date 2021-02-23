using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using GetGoPOS.Model;

namespace GetGoPOS.Helpers
{
    public static class DataHandler
    {

        public static bool UpdateProduct(Product prod)
        {
            try
            {
                DataBaseHelper.SetDB(string.Format(@"UPDATE Product
                                        SET productname = '{0}',
	                                        stockno ='{1}',
	                                        price = '{2}',
                                            discontinued = '{3}'
                                        WHERE id = '{4}'",  prod.Name, prod.StockNo, prod.Price, prod.Show, prod.ID));
                return true;
            }
            catch(Exception exe)
            {
                MessageBox.Show(exe.Message);
                return false;
            }
        }
        public static bool SaveProduct(Product prod)
        {
            try
            {
                string barcode = GetNextBarcode();

                DataBaseHelper.SetDB(string.Format(@"INSERT INTO Product(barcode, productname, stockno, price)
                    VALUES('{0}','{1}','{2}','{3}')", barcode, prod.Name, prod.StockNo, prod.Price));
                return true;
            }
            catch (Exception exe)
            {
                MessageBox.Show(exe.Message);
                return false;
            }

        }
        public static bool SaveTransaction(Transaction trans)
        {
            try
            {
                string transNo  = GetNextTransNumber();
                string idNo = GetNextID("TransactionHead");

                DataBaseHelper.SetDB(string.Format(@"INSERT INTO TransactionHead(transactionnumber, invoicenumber, transdate, sales, tenderamount, date)
                    VALUES('{0}','{1}','{2}', '{3}', '{4}', '{5}')", transNo, trans.InvoiceNumber, trans.Date.ToString("yyyy-MM-dd"), trans.Sales ? "1": "0", trans.TenderAmount, trans.Date));

                foreach(Product prod in trans.productlist)
                {
                    DataBaseHelper.SetDB(string.Format(@"INSERT INTO TransactionDetail(headid, productid, quantity, price)
                    VALUES('{0}','{1}','{2}', '{3}')", idNo, prod.ID, prod.Qty, prod.Price));
                    DataBaseHelper.SetDB(string.Format(@"INSERT INTO InventoryAdjust(productid, quantity, headid, date, transdate)
                    VALUES('{0}','{1}','{2}', '{3}', '{4}')", prod.ID, prod.Qty * -1, idNo, trans.Date, trans.Date.ToString("yyyy-MM-dd")));
                }
                return true;

            }
            catch 
            {
                return false;
            }
        }
        public static bool SaveAdjustments(List<Inventory> adjustments)
        {
            try
            {
                foreach (Inventory adj in adjustments)
                {
                    DataBaseHelper.SetDB(string.Format(@"INSERT INTO InventoryAdjust(productid, quantity, headid, date, transdate, manual)
                    VALUES('{0}','{1}','{2}', '{3}', '{4}', '{5}')", adj.ProductID, adj.Quantity, 0, adj.Date, adj.Date.ToString("yyyy-MM-dd"), "1"));
                }
                return true;
            }
            catch
            {
                return false;
            }
        }
        public static bool VoidTransaction(Transaction trans)
        {
            try
            {
                DataBaseHelper.SetDB(string.Format(@"UPDATE TransactionHead
                                        SET sales = '0',
                                            date = '{0}'
                                        WHERE id = '{1}'", DateTime.Now, trans.ID));
                return true;
            }
            catch (Exception exe)
            {
                MessageBox.Show(exe.Message);
                return false;
            }
        }
        public static string GetNextID(string table)
        {
            DataTable dt = DataBaseHelper.GetDB(string.Format(@"SELECT id FROM {0} ORDER BY id DESC LIMIT 1", table));
            if (dt.Rows.Count == 0)
                return "1";
            else
            {
                string test = dt.Rows[0]["id"].ToString();
                long idraw = Convert.ToInt64(test);
                return (idraw + 1).ToString();
            }
        }
        public static string GetNextBarcode()
        {
            DataTable dt = DataBaseHelper.GetDB("SELECT barcode FROM Product ORDER BY barcode DESC LIMIT 1");
            if (dt.Rows.Count == 0)
                return "100000000001";
            else
            {
                string test = dt.Rows[0]["barcode"].ToString();
                long barcoderaw = Convert.ToInt64(test);
                return (barcoderaw + 1).ToString();
            }
        }

        public static string GetNextORNumber()
        {
            DataTable dt = DataBaseHelper.GetDB("SELECT invoicenumber FROM TransactionHead ORDER BY invoicenumber DESC LIMIT 1");
            if (dt.Rows.Count == 0)
                return "1";
            else
            {
                string test = dt.Rows[0]["invoicenumber"].ToString();
                long ornumberraw = Convert.ToInt64(test);
                return (ornumberraw + 1).ToString();
            }
        }
        public static string GetNextTransNumber()
        {
            DataTable dt = DataBaseHelper.GetDB("SELECT transactionnumber FROM TransactionHead ORDER BY transactionnumber DESC LIMIT 1");
            if (dt.Rows.Count == 0)
                return "1";
            else
            {
                string test = dt.Rows[0]["transactionnumber"].ToString();
                long transnumbraw = Convert.ToInt64(test);
                return (transnumbraw + 1).ToString();
            }
        }
        public static string GetCurrentInvoice()
        {
            DataTable dt = DataBaseHelper.GetDB("SELECT invoicenumber FROM TransactionHead ORDER BY invoicenumber DESC LIMIT 1");
            if (dt.Rows.Count == 0)
                return "";
            else
            {
                return dt.Rows[0]["invoicenumber"].ToString();
            }
        }
        public static bool SaveReport(Report report)
        {
            try
            {
                DataBaseHelper.SetDB(@"DELETE FROM Reports WHERE readtype = '" + report.Type + "' AND transdate = '" + report.Date.ToString("yyyy-MM-dd") + "'");

                DataBaseHelper.SetDB(string.Format(@"INSERT INTO Reports(oldgrandtotal, newgrandtotal, date, readtype, readcount, transdate, voiditemqty, salesitemqty, grossamount, salescount, transcount, voidcount, voidamount, vat, vatablesales, minor, maxor)
                    VALUES('{0}','{1}','{2}', '{3}', '{4}', '{5}','{6}','{7}', '{8}', '{9}', '{10}','{11}','{12}', '{13}', '{14}', '{15}', '{16}')",
                        report.OldGrandTotal, report.NewGrandTotal, report.Date, report.Type, report.ReadCount, report.Date.ToString("yyyy-MM-dd"), report.VoidItemQty, report.SalesItemQty, report.GrossAmount, report.SalesTransCount, report.TransCount, report.VoidTransCount,
                        report.VoidAmount, report.Vat, report.VatableSales, report.MinOR, report.MaxOR));

                return true;
            }
            catch
            {
                return false;
            }
        }
        public static DateTime GetMinimumSaleDate()
        {
            DataTable dt = DataBaseHelper.GetDB(string.Format(@"SELECT MIN(date) as date FROM TransactionHead"));
            if (dt.Rows.Count == 0 || dt == null)
                return DateTime.Now;
            else
                try
                {
                    return Convert.ToDateTime(dt.Rows[0]["date"]);
                }
                catch { return DateTime.Now; }
        }

        public static DateTime GetLastZReadDate()
        {
            DataTable dt = DataBaseHelper.GetDB(string.Format(@"SELECT MIN(date) as date FROM Reports WHERE readtype = 3"));
            if (dt.Rows.Count == 0 || dt == null)
                return DataHandler.GetMinimumSaleDate();
            else
                try
                {
                    return Convert.ToDateTime(dt.Rows[0]["date"]);
                }
                catch { return DataHandler.GetMinimumSaleDate(); }
        }
        public static int GetNextReadCount(int type)
        {
            DataTable dt = DataBaseHelper.GetDB(string.Format(@"SELECT COALESCE(MAX(readcount),0) as rcount FROM Reports WHERE readtype = '{0}'", type));
            if (dt.Rows.Count == 0)
                return 0;
            else
                return Convert.ToInt32(dt.Rows[0]["rcount"]) + 1;
        }

        public static decimal GetOldGrandTotal(int type)
        {
            DataTable dt = DataBaseHelper.GetDB(string.Format(@"SELECT COALESCE(MAX(newgrandtotal),0) as oldt FROM Reports WHERE readtype = '{0}'", type));
            if (dt.Rows.Count == 0 || dt == null)
                return 0;
            else
                return Convert.ToDecimal(dt.Rows[0]["oldt"]);
        }
        public static string GetOR(bool min, DateTime date)
        {
            DataTable dt = DataBaseHelper.GetDB(string.Format(@"SELECT COALESCE({0}(invoicenumber),0) as InvNumber FROM TransactionHead WHERE transdate = '{1}'", min ? "MIN":"MAX", date.ToString("yyyy-MM-dd")));
            if (dt.Rows.Count == 0 || dt == null)
                return "0";
            else
                return dt.Rows[0]["InvNumber"].ToString();
        }

        public static bool CheckPOSIfLocked()
        {
            DataTable dt = DataBaseHelper.GetDB(string.Format(@"SELECT * FROM Reports WHERE transdate = '{0}' AND `readtype` = 3",  DateTime.Now.ToString("yyyy-MM-dd")));
            if (dt.Rows.Count > 0)
                return true;
            else
                return false;
        }

        public static Transaction GetTransactionByInvoice(string invoice)
        {
            Transaction trans = new Transaction();

            try
            {
                DataTable dt = DataBaseHelper.GetDB(string.Format(@"SELECT * FROM TransactionHead WHERE invoicenumber = '{0}' LIMIT 1", invoice));
                if (dt.Rows.Count == 0)
                    return null;
                else
                {
                    trans = new Transaction
                    {
                        ID = Convert.ToInt64(dt.Rows[0]["id"]),
                        InvoiceNumber = dt.Rows[0]["invoicenumber"].ToString(),
                        TransactionNo = dt.Rows[0]["transactionnumber"].ToString(),
                        Sales = Convert.ToInt32(dt.Rows[0]["sales"].ToString()) == 1 ? true : false,
                        Date = Convert.ToDateTime(dt.Rows[0]["date"].ToString()),
                        TenderAmount = Convert.ToDecimal(dt.Rows[0]["tenderamount"])
                    };

                    DataTable dtdetail = DataBaseHelper.GetDB(string.Format(@"SELECT * From TransactionDetail WHERE headid = '{0}'", trans.ID));

                    if (dt.Rows.Count == 0)
                        return null;
                    else
                    {
                        foreach(DataRow dr in dtdetail.Rows)
                        {
                            string prodid = dr["productid"].ToString();
                            decimal price = Convert.ToDecimal(dr["price"]);
                            decimal qty = Convert.ToDecimal(dr["quantity"]);

                            Product prod = new Product();
                            prod.SetProductByID(prodid);
                            prod.Qty = qty;
                            prod.Price = price;

                            trans.productlist.Add(prod);
                        }
                    }    
                }
            }
            catch { return null; }
            return trans;
        }
    }
}
