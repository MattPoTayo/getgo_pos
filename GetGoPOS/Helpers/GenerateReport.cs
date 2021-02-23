using GetGoPOS.Model;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GetGoPOS.Helpers
{
    public static class GenerateReport
    {
        public static bool XRead(DateTime date)
        {
            return Generate(1, date);
        }
        public static bool ZRead(DateTime date)
        {

            return Generate(3, date);
        }
        public static IEnumerable<DateTime> EachDay(DateTime from, DateTime thru)
        {
            if (from < thru)
                for (var day = from.Date; day.Date <= thru.Date; day = day.AddDays(1))
                    yield return day;
            else
                for (var day = from.Date; day.Date >= thru.Date; day = day.AddDays(-1))
                    yield return day;
        }
        public static bool GenerateUngeneratedReport()
        {
            try
            {
                DateTime minsalesdate = DataHandler.GetMinimumSaleDate();
                DateTime lastZread = DataHandler.GetLastZReadDate();

                if (lastZread.Date == DateTime.Now.Date)
                    return true;
                if (lastZread.Date == DateTime.Now.AddDays(-1).Date)
                    return true;
                else
                {
                    DataBaseHelper.SetDB(@"DELETE FROM Reports WHERE transdate >= '" + lastZread.Date.ToString("yyyy-MM-dd") + "'");
                    foreach (DateTime day in EachDay(lastZread, DateTime.Now.AddDays(-1)))
                    {
                        GenerateReport.XRead(day);
                        GenerateReport.ZRead(day);
                    }
                }
            
                return true;
            }
            catch
            {
                return false;
            }

        }
        private static bool Generate(int type, DateTime date)
        {
            try
            {
                Report report = new Report();
                report.Date = date;
                report.Type = type;

                report.MinOR = DataHandler.GetOR(true, date);
                report.MaxOR = DataHandler.GetOR(false, date);

                report.OldGrandTotal = DataHandler.GetOldGrandTotal(type);

                DataTable dt = DataBaseHelper.GetDB(string.Format(@"SELECT 
	                                                SUM(TD.price * TD.quantity) AS sales, 
	                                                COUNT(*) AS itemcount,
	                                                TH.transdate
                                                FROM TransactionHead TH
                                                LEFT JOIN TransactionDetail TD ON TD.headid = TH.id
                                                WHERE  
                                                    transdate = '{0}' 
                                                    AND sales = 1 GROUP By TH.transdate", date.ToString("yyyy-MM-dd")));
                DataTable dtvoid = DataBaseHelper.GetDB(string.Format(@"SELECT 
	                                                SUM(TD.price * TD.quantity) AS voidsales, 
	                                                COUNT(*) AS itemcount,
	                                                TH.transdate
                                                FROM TransactionHead TH
                                                LEFT JOIN TransactionDetail TD ON TD.headid = TH.id
                                                WHERE  
                                                    transdate = '{0}' 
                                                    AND sales = 0 GROUP By TH.transdate", date.ToString("yyyy-MM-dd")));
                if (dt.Rows.Count == 0)
                {
                    report.VatableSales = 0;
                    report.NewGrandTotal = report.OldGrandTotal;
                    report.Vat = 0;
                    report.TransCount = 0;
                    report.SalesTransCount = 0;
                    report.VatableSales = 0;
                    report.SalesItemQty = 0;
                }
                else
                {
                    report.VatableSales = Convert.ToDecimal(dt.Rows[0]["Sales"]);
                    report.NewGrandTotal = report.OldGrandTotal + report.VatableSales;
                    report.Vat = (report.VatableSales / 1.12M) * 0.12M;
                    report.TransCount = 0;
                    report.SalesItemQty = Convert.ToDecimal(dt.Rows[0]["itemcount"]);

                    DataTable dtcounts = DataBaseHelper.GetDB(string.Format(@"SELECT COUNT(*) AS cnt FROM TransactionHead WHERE sales = 1 and transdate = '{0}'", date.ToString("yyyy-MM-dd")));

                    report.SalesTransCount = Convert.ToDecimal(dtcounts.Rows[0]["cnt"]);
                }
                if (dtvoid.Rows.Count == 0)
                {
                    report.VoidAmount = 0;
                    report.VoidTransCount = 0;
                    report.VoidItemQty = 0;
                }
                else
                {
                    report.VoidAmount = Convert.ToDecimal(dtvoid.Rows[0]["voidsales"]);
                    report.VoidItemQty = Convert.ToDecimal(dtvoid.Rows[0]["itemcount"]);

                    DataTable dtcountsvoid = DataBaseHelper.GetDB(string.Format(@"SELECT COUNT(*) AS cnt FROM TransactionHead WHERE sales = 0 and transdate = '{0}'", date.ToString("yyyy-MM-dd")));
                    report.VoidTransCount = Convert.ToDecimal(dtcountsvoid.Rows[0]["cnt"]);
                }

                report.GrossAmount = report.VoidAmount + report.VatableSales;
                report.TransCount = report.SalesTransCount + report.VoidTransCount;
                DataBaseHelper.SetDB(@"DELETE FROM Reports WHERE readtype = '" + report.Type + "' AND transdate = '" + report.Date.ToString("yyyy-MM-dd") + "'");
                report.ReadCount = DataHandler.GetNextReadCount(report.Type);
                HardwareHelper.PrintReport(null, null, null, report);
                return DataHandler.SaveReport(report);
            }
            catch
            {
                return false;
            }
        }
    }
}
