using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GetGoPOS.Model
{
    public class Inventory
    {
        public long ID { get; set; } = 0;
        public long ProductID { get; set; } = 0;
        public Product ProductInfo { get; set; } = new Product();
        public decimal Quantity { get; set; } = 0;
        public long HeadID { get; set; } = 0;
        public bool Manual { get; set; } = false;
        public DateTime Date { get; set; } = DateTime.Now;
        public DateTime ActualDate { get; set; } = DateTime.Now;

        public Inventory()
        { 
        }
    }
}
