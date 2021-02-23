using GetGoPOS.Helpers;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GetGoPOS.Model
{
    public class Product
    {
        public long ID { get; set; } = 0;
        public string Name { get; set; } = "";
        public string StockNo { get; set; } = "";
        public string Barcode { get; set; } = "";
        public decimal Price { get; set; } = 0;
        public decimal Qty { get; set; } = 0;
        public int Show { get; set; } = 1;
        public Product()
        {
        }
        public void SetProductByID(string id)
        {
            string getSQL = string.Format(@"SELECT * FROM Product WHERE id = '{0}'", id);

            DataTable dt = DataBaseHelper.GetDB(getSQL);

            ID = Convert.ToInt64(dt.Rows[0]["id"]);
            Name = dt.Rows[0]["productname"].ToString();
            StockNo = dt.Rows[0]["stockno"].ToString();
            Barcode = dt.Rows[0]["barcode"].ToString();
            Price = Convert.ToDecimal(dt.Rows[0]["price"]);
            Show = Convert.ToInt32(dt.Rows[0]["discontinued"]);
        }
    }
}
