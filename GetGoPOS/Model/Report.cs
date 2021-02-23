using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GetGoPOS.Model
{
    public class Report
    {
        public long ID { get; set; } = 0;
        public DateTime Date { get; set; } = DateTime.Now;
        public decimal OldGrandTotal { get; set; } = 0;
        public decimal NewGrandTotal { get; set; } = 0;
        public decimal VoidItemQty { get; set; } = 0;
        public decimal SalesItemQty { get; set; } = 0;
        public decimal GrossAmount { get; set; } = 0;
        public decimal SalesTransCount { get; set; } = 0;
        public decimal TransCount { get; set; } = 0;
        public decimal VoidTransCount { get; set; } = 0;
        public decimal VoidAmount { get; set; } = 0;
        public decimal Vat { get; set; } = 0;
        public decimal VatableSales { get; set; } = 0;
        public int Type { get; set; } = 0;
        public int ReadCount { get; set; } = 0;
        public string MinOR { get; set; } = "0";
        public string MaxOR { get; set; } = "0";
        public DateTime ActualDate { get; set; } = DateTime.Now;

        public Report()
        {

        }
    }
}
