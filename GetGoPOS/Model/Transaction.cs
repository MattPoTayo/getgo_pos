using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GetGoPOS.Model
{
    public class Transaction
    {
        public long ID { get; set; } = 0;
        public List<Product> productlist { get; set; } = new List<Product>();
        public string TransactionNo { get; set; } = "";
        public string InvoiceNumber { get; set; } = "";
        public DateTime Date { get; set; } = DateTime.Now;
        public decimal TenderAmount { get; set; } = 0;
        public bool Sales { get; set; } = true;
        public Transaction()
        {
            productlist = new List<Product>();
        }

        public decimal GetTotalAmountDue()
        {
            return productlist.Sum(x => x.Price * x.Qty);
        }
        public decimal GetTotalQty()
        {
            return productlist.Sum(x => x.Qty);        
        }
        public decimal GetChange()
        {
            decimal amountDue = GetTotalAmountDue();
            return TenderAmount >= amountDue ? TenderAmount - amountDue : 0;
        }
        public void SetTransactionByID(long ID)
        {

        }
    }
}
