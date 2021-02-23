using GetGoPOS.Enums;
using GetGoPOS.Model;
using GetGoPOS.Model.Global;
using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Drawing.Printing;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace GetGoPOS.Helpers
{
    class HardwareHelper
    {
        public static Font font_Title = new Font("Consolas", 14.25F, FontStyle.Bold);
        public static Font font_Price = new Font("Consolas", 9.25F, FontStyle.Bold);
        public static Font font_Content = new Font("Consolas", 8.25F, FontStyle.Regular, GraphicsUnit.Point, (byte)0);
        public static Font font_Change = new Font("Consolas", 12, FontStyle.Bold);
        public static SolidBrush brush_Black = new SolidBrush(Color.Black);
        public static int getpbheight;
        public static void PrintPageReceipt(Transaction tran, bool isVoid, Bitmap bmp)
        {
            PrintReceipt(null, null, bmp, tran, isVoid, true, false); // tran.getsenior().get_fullname() != "");
        }
        public static void Print(Transaction tran, bool isReprint, bool isVoid, PrintingType ej = PrintingType.NormalPrinting)
        {
            
            if (ej == PrintingType.NormalPrinting)
                RawPrinterHelper.OpenCashDrawer(true);
            
            PrintReceipt(null, null, null, tran, isVoid, isReprint, false, ej);
        }
        public static Graphics PrintReceipt(object sender, PrintPageEventArgs e, Bitmap bmp, Transaction tran, bool isvoid, bool isreprint, bool customercopy, PrintingType ej = PrintingType.NormalPrinting)
        {
            // This actually doesnt use Graphics
            DataTable tempDataTable;
            int value = 64;
            if (globalvariables.PrintReceiptFormat == PrintFormat.Custom_76mm_journal)
                value = 40;
            else if (globalvariables.PrintReceiptFormat == PrintFormat.Custom_JNF_57mm)
                value = 42;
            ReceiptPrinterHelper printer = new ReceiptPrinterHelper(value);
            if (globalvariables.PrintReceiptBuffer != 0)
                printer.StringBufferWidth = globalvariables.PrintReceiptBuffer;
            if (globalvariables.PrintReceiptActual != 0)
                printer.StringFullWidth = globalvariables.PrintReceiptActual;
            if (globalvariables.PrintReceiptLimit != 0)
                printer.StringWidth = globalvariables.PrintReceiptLimit;
            if (globalvariables.PrintReceiptLinespacing != 0)
                printer.LineSpacing = globalvariables.PrintReceiptLinespacing;

            // Header
            printer.LargeFont();
            printer.CPI12();
            if (globalvariables.BusinessName != "")
                printer.WriteLines(globalvariables.BusinessName);
            printer.NormalFont();
            printer.CPI12();
            if (globalvariables.Owner != "")
                printer.WriteLines(globalvariables.Owner);
            printer.WriteLines(((globalvariables.IsVatable) ?
                "VAT REG. " : "NON VAT REG. ") + globalvariables.TIN);
            if (globalvariables.MIN != "")
                printer.WriteLines(globalvariables.MIN);
            if (globalvariables.Serial != "")
                printer.WriteLines(globalvariables.Serial);
            if (globalvariables.Address != "")
                printer.WriteLines(globalvariables.Address);
            if (globalvariables.TelNo != "")
                printer.WriteLines("Tel.#: " + globalvariables.TelNo);
            if (customercopy)
                printer.WriteLines("Customer's Copy");

            // Transaction Info
            tempDataTable = new DataTable();
            tempDataTable.Columns.Add();
            tempDataTable.Columns.Add();
            tempDataTable.Rows.Add("TERMINAL#: " + globalvariables.Terminal, "REF#:" + tran.ID.ToString());
            tempDataTable.Rows.Add("SI#: " + tran.InvoiceNumber, "TRAN#: " + tran.TransactionNo);
            tempDataTable.Rows.Add("DATE: " + tran.Date.ToShortDateString(), "TIME: " + tran.Date.ToLongTimeString());

            printer.WriteRepeatingCharacterLine('=');
            printer.WriteTable(
                tempDataTable,
                new StringAlignment[] { StringAlignment.Near, StringAlignment.Near },
                new int[] { printer.StringWidth / 2, printer.StringWidth / 2 }
            );
            
            tempDataTable = new DataTable();
            tempDataTable.Columns.Add();
            tempDataTable.Columns.Add();
            tempDataTable.Columns.Add();
            tempDataTable.Columns.Add();
            tempDataTable.Rows.Add("QTY", "", "DESCRIPTION", "AMOUNT");
            foreach (Product prod in tran.productlist)
            {
                string proddesc = prod.Name;
                tempDataTable.Rows.Add(prod.Qty.ToString("0.####"), "", proddesc, prod.Price.ToString("N2"));
            }
            printer.WriteRepeatingCharacterLine('=');
            printer.WriteTable(
                tempDataTable,
                new StringAlignment[] { StringAlignment.Far, StringAlignment.Far, StringAlignment.Near, StringAlignment.Far },
                new int[] { (int)(printer.StringWidth * 0.15), 1, (int)(printer.StringWidth * 0.6), (int)(printer.StringWidth * 0.25) }
            );

            printer.WriteRepeatingCharacterLine('=');
            // Discount Breakdown
            decimal total_sale = tran.GetTotalAmountDue();
            decimal total_gross = tran.GetTotalAmountDue();

            // Sub-Total Info
            tempDataTable = new DataTable();
            tempDataTable.Columns.Add();
            tempDataTable.Columns.Add();
            decimal totalQuantity = tran.GetTotalQty();
            //totalQuantity -= tran.get_gcexcessamt() > 0 ? 1 : 0;
            tempDataTable.Rows.Add("Total QTY:", totalQuantity.ToString("0.####"));
            printer.WriteTable(
                tempDataTable,
                new StringAlignment[] { StringAlignment.Near, StringAlignment.Far },
                new int[] { printer.StringWidth / 2, printer.StringWidth / 2 }
            );
            printer.LargeFont();
            printer.CPI12();
            printer.WriteRow(
               new string[] { "AMOUNT DUE:", total_sale.ToString("N2") },
               new StringAlignment[] { StringAlignment.Near, StringAlignment.Far },
               new int[] { printer.StringWidth / 2, printer.StringWidth / 2 }
           );
            printer.NormalFont();
            printer.CPI12();

            // Payment
            decimal tendered_cash = tran.TenderAmount;
            decimal tendered_change = tran.GetChange();
            tempDataTable = new DataTable();
            tempDataTable.Columns.Add(); tempDataTable.Columns.Add();
            int cnt_item_t = 0;

            //totalAmountDue -= gcexcessamt > 0 ? gcexcessamt : 0; 
            printer.NormalFont();
            printer.CPI12();

            if (tendered_cash != 0)
                tempDataTable.Rows.Add("Cash:", tendered_cash.ToString("N2")); cnt_item_t++;
            

            tempDataTable.Rows.Add("Change:", tendered_change.ToString("N2"));


            printer.WriteTable(
                tempDataTable,
                new StringAlignment[] { StringAlignment.Near, StringAlignment.Far },
                new int[] { printer.StringWidth / 2, printer.StringWidth / 2 }
            );

            // Sub-Total Info
            tempDataTable = new DataTable();
            tempDataTable.Columns.Add();
            tempDataTable.Columns.Add();
            if (globalvariables.IsVatable)
            {
                decimal vat = (total_sale / 1.12M) * 0.12M;
                decimal vatable = total_sale / 1.12M;
                tempDataTable.Rows.Add("VATABLE SALE:", vatable.ToString("N2"));
                printer.WriteRepeatingCharacterLine('=');
                // VAT
                tempDataTable.Rows.Add("VAT AMOUNT:", vat.ToString("N2"));
            }
            //gcexcess value is 0 if transaction is vatable for vat exempt breakdown
            printer.WriteTable(
                tempDataTable,
                new StringAlignment[] { StringAlignment.Near, StringAlignment.Far },
                new int[] { printer.StringWidth / 2, printer.StringWidth / 2 }
            );
            // POS Provider Info
            // Based on BIR Revenue Regulations No. 10-2015
            printer.WriteRepeatingCharacterLine('=');
            if (globalvariables.PosProviderName != "")
                printer.WriteLines(globalvariables.PosProviderName);
            if (globalvariables.PosProviderAddress != "")
                printer.WriteLines(globalvariables.PosProviderAddress);
            if (globalvariables.PosProviderTIN != "")
                printer.WriteLines(globalvariables.PosProviderTIN);
            if (globalvariables.Acc != "")
                printer.WriteLines(globalvariables.Acc);
            if (globalvariables.AccDate != "")
            {
                string validUntil = GetValidUntilDate(true);
                printer.WriteLines(globalvariables.AccDate);
                if (validUntil != "")
                    printer.WriteLines("Valid Until: " + validUntil);
            }
            if (globalvariables.PermitNo != "")
                printer.WriteLines(globalvariables.PermitNo);
            if (globalvariables.ApprovalDate != "")
            {
                string validUntil = GetValidUntilDate(false);
                printer.WriteLines("Date Issued: " + globalvariables.ApprovalDate);
                if (validUntil != "")
                    printer.WriteLines("Valid Until: " + validUntil);
            }
            printer.WriteLines("THIS INVOICE/RECEIPT SHALL BE VALID FOR FIVE(5) YEARS FROM THE DATE OF THE PERMIT TO USE.");

            // Footers
            printer.WriteRepeatingCharacterLine('=');
            if (globalvariables.OrFooter1 != "")
                printer.WriteLines(globalvariables.OrFooter1);
            if (globalvariables.OrFooter2 != "")
                printer.WriteLines(globalvariables.OrFooter2);
            if (globalvariables.OrFooter3 != "")
                printer.WriteLines(globalvariables.OrFooter3);
            if (globalvariables.OrFooter4 != "")
                printer.WriteLines(globalvariables.OrFooter4);

            // Based on BIR Revenue Regulations No. 10-2015
            printer.LargeFont();
            printer.CPI12();
            if (!globalvariables.IsVatable)
                printer.WriteLines("THIS DOCUMENT IS NOT VALID FOR CLAIM OF INPUT TAX.");
            printer.NormalFont();
            printer.CPI12();

            // Reprint/Voided Tag
            if (isvoid)
                printer.WriteLines("VOIDED RECEIPT!");
            if (isreprint)
            {
                printer.WriteLines("REPRINTED RECEIPT!");
            }
            else
            {
                DateTime now = DateTime.Now;
                printer.WriteLines("PRINTED: " + now.ToShortDateString() + " " + now.ToLongTimeString());
            }

            if (bmp == null)
            {
                printer.Print();
                if (ej == PrintingType.EJournalHardCopy || ej == PrintingType.NormalPrinting)
                    printer.ActivateCutter();
            }
            else
                printer.PreviewOR(e, bmp);

            return null;
        }

        public static string GetValidUntilDate(bool isAccDate)
        {
            //1 = acc_date; 0 = approvaldate
            DateTime validUntilDate;
            try
            {
                if (isAccDate)
                    validUntilDate = GetValidDate(globalvariables.AccDate);
                else
                    validUntilDate = GetValidDate(globalvariables.ApprovalDate);

                if (validUntilDate <= globalvariables.birUntilDate)
                    validUntilDate = globalvariables.birUntilDate.AddYears(5).AddDays(-1);
                else
                    validUntilDate = validUntilDate.AddYears(5).AddDays(-1);

                return validUntilDate.ToString("MMMM dd, yyyy");
            }
            catch { return ""; }
        }
        public static DateTime GetValidDate(string value)
        {
            DateTime validDate;
            Regex regex = new Regex(@"(\d+)[-.\/](\d+)[-.\/](\d+)");
            Match match = regex.Match(value);
            if (match.Success)
            {
                string dateString = match.Value;
                validDate = DateTime.Parse(dateString, System.Globalization.DateTimeFormatInfo.InvariantInfo);
            }
            else
            {
                validDate = DateTime.Now.AddMonths(1);
            }
            return validDate;
        }

        public static void PrintReport(object sender, PrintPageEventArgs e, Bitmap bmp, Report report)
        {
            PrintReading(e, bmp, report);
        }
        public static Graphics PrintReading(PrintPageEventArgs e, Bitmap bmp, Report report)
        {
            //DateTime mindate = Convert.ToDateTime(dr_summary["mindate"]);
            //DateTime maxdate = Convert.ToDateTime(dr_summary["maxdate"]);


            bool isPosVatable = globalvariables.IsVatable;
            string resetCounter = "0";
            string readcount = report.ReadCount.ToString();
            string ornumber_begin = report.MinOR;
            string ornumber_end = report.MaxOR;
            decimal new_grand = report.OldGrandTotal;
            decimal old_grand = report.NewGrandTotal;

            string terminalNo = globalvariables.Terminal;

            int nY = 0;
            int nX = 0;
            int[] column2format = new int[] { 160, 120 };
            int[] column4_rect_header2 = new int[] { 70, 70, 70, 70 };
            int maxwidth = 280;
            if (globalvariables.PrintReceiptFormat == PrintFormat.Custom_76mm)
            {
                column4_rect_header2 = new int[] { 44, 70, 44, 70 };
                column2format = new int[] { 120, 120 };
                maxwidth = 240;
            }
            else if (globalvariables.PrintReceiptFormat == PrintFormat.Custom_57mm)
            {
                column2format = new int[] { 95, 85 };
                maxwidth = 180;
            }
            else if (globalvariables.PrintReceiptFormat == PrintFormat.Custom_76mm_journal)
            {
                column4_rect_header2 = new int[] { 56, 70, 56, 70 };
                column2format = new int[] { 133, 120 };
                maxwidth = 253;
            }

            int value = 64;
            if (globalvariables.PrintReceiptFormat == PrintFormat.Custom_76mm_journal)
                value = 40;
            else if (globalvariables.PrintReceiptFormat == PrintFormat.Custom_JNF_57mm)
                value = 42;

            ReceiptPrinterHelper printer = new ReceiptPrinterHelper(value);
            if (globalvariables.PrintReceiptBuffer != 0)
                printer.StringBufferWidth = globalvariables.PrintReceiptBuffer;
            if (globalvariables.PrintReceiptActual != 0)
                printer.StringFullWidth = globalvariables.PrintReceiptActual;
            if (globalvariables.PrintReceiptLimit != 0)
                printer.StringWidth = globalvariables.PrintReceiptLimit;
            if (globalvariables.PrintReceiptLinespacing != 0)
                printer.LineSpacing = globalvariables.PrintReceiptLinespacing;

            //business Title     
            printer.LargeFont();
            printer.CPI12();
            printer.WriteLines(globalvariables.BusinessName);

            printer.NormalFont();
            printer.CPI12();

            //header 1
            DataTable dt_header1 = GetHeader(1, report.ActualDate);
            printer.WriteTable(
                dt_header1,
                new StringAlignment[] { StringAlignment.Center },
                new int[] { printer.StringWidth }
            );

            printer.LargeFont();
            printer.CPI12();
           
            string letter = (report.Type == 1) ? "X" : "Z";
            printer.WriteLines("Terminal Report " + letter + @"-Read");
            printer.NormalFont();
            printer.CPI12();
            DataTable dt_tblCounter = new DataTable();
            dt_tblCounter.Columns.Add(); dt_tblCounter.Columns.Add();
            dt_tblCounter.Rows.Add("Reading Counter: " + readcount, "Reset Counter: " + resetCounter);
            printer.WriteTable(
                dt_tblCounter,
                new StringAlignment[] { StringAlignment.Near, StringAlignment.Far },
                new int[] { printer.StringWidth / 2, printer.StringWidth / 2 }
            );

            //header 2
            string cdate = report.ActualDate.ToString("MM/dd/yyyy");
            string ctime = report.ActualDate.ToString("HH:mm:ss");
            DataTable dt_header2 = new DataTable();

            if (globalvariables.PrintReceiptFormat == PrintFormat.Custom_57mm)
            {
                dt_header2.Columns.Add(); dt_header2.Columns.Add();
                dt_header2.Rows.Add("Date:", cdate);
                dt_header2.Rows.Add("Time:", report.ActualDate.ToString("HH:mm:ss"));
                printer.WriteTable(
                dt_header2,
                new StringAlignment[] { StringAlignment.Near, StringAlignment.Far },
                new int[] { printer.StringWidth / 2, printer.StringWidth / 2 }
                );
            }
            else
            {
                dt_header2.Columns.Add(); dt_header2.Columns.Add(); dt_header2.Columns.Add(); dt_header2.Columns.Add();
                dt_header2.Rows.Add("Date:", cdate + " ", " Time:", report.ActualDate.ToString("HH:mm:ss"));

                printer.WriteTable(
                    dt_header2,
                    new StringAlignment[] { StringAlignment.Near, StringAlignment.Far, StringAlignment.Near, StringAlignment.Far },
                    new int[] { printer.StringWidth / 4, printer.StringWidth / 4, printer.StringWidth / 4, printer.StringWidth / 4 }
                );
            }

            //space
            nY += 10;

            //table header
            DataTable dt_tblheader = new DataTable();
            dt_tblheader.Columns.Add(); dt_tblheader.Columns.Add();
            dt_tblheader.Rows.Add("Description", "QTY / AMOUNT");
            printer.WriteTable(
                dt_tblheader,
                new StringAlignment[] { StringAlignment.Near, StringAlignment.Far },
                new int[] { printer.StringWidth / 2, printer.StringWidth / 2 }
                );
            if (report.Type == 1)
            {
                //-----------line-------------
                printer.WriteRepeatingCharacterLine('-');
            }
            else if (report.Type == 3)
            {
                //space
                //nY += 10;
                //-----------line-------------
                //nY += 5;
                printer.WriteRepeatingCharacterLine('-');
                printer.WriteLines("*** Z-READING SUMMARY ***");
                //-----------line-------------
                //nY += 5;
                printer.WriteRepeatingCharacterLine('-');
                //space
                //nY += 10;
            }
           
            printer.NormalFont();
            printer.CPI12();
            //summaries
            DataTable dt_salessummary1 = new DataTable();
            dt_salessummary1.Columns.Add(); dt_salessummary1.Columns.Add();

            dt_salessummary1.Rows.Add("TERMINAL", terminalNo);
            dt_salessummary1.Rows.Add("BEGIN OR#", ornumber_begin);
            dt_salessummary1.Rows.Add("END OR#", ornumber_end);
            dt_salessummary1.Rows.Add("  ", "  ");

            decimal all_vatable_sale = report.VatableSales;
            decimal all_total_qty = report.SalesItemQty + report.VoidItemQty;
            decimal all_total_return_qty = report.VoidItemQty;


            dt_salessummary1.Rows.Add("GROSS SALES", report.GrossAmount.ToString("N2"));
            dt_salessummary1.Rows.Add("TOTAL VOID", report.VoidAmount.ToString("N2"));
            dt_salessummary1.Rows.Add("NET SALES", report.VatableSales.ToString("N2"));

            dt_salessummary1.Rows.Add("CASH SALES", report.VatableSales.ToString("N2"));
            
            DataTable dt_salessummary2 = new DataTable();
            dt_salessummary2.Columns.Add(); dt_salessummary2.Columns.Add();

            dt_salessummary2.Rows.Add("  ", "  ");
            dt_salessummary2.Rows.Add("VATABLE SALES", (report.VatableSales / 1.12M).ToString("N2"));
            dt_salessummary2.Rows.Add("12% VAT AMT", report.Vat.ToString("N2"));


            dt_salessummary2.Rows.Add("  ", "  ");
            dt_salessummary2.Rows.Add("TOTAL QTY SOLD", report.SalesItemQty.ToString("N2"));
            dt_salessummary2.Rows.Add("ITEM VOID CNT", report.VoidItemQty.ToString("N2"));
            dt_salessummary2.Rows.Add("TRANS VOID AMT", report.VoidAmount.ToString("N2"));
            dt_salessummary2.Rows.Add("TRANS VOID CNT", report.VoidTransCount.ToString("N2"));
            dt_salessummary2.Rows.Add("SUCCESS TRANS CNT", report.SalesTransCount.ToString("N2"));
            dt_salessummary2.Rows.Add("TOTAL TRANS CNT", report.TransCount.ToString("N2"));

            if (report.Type == 3)
            {
                dt_salessummary2.Rows.Add("  ", "  ");
                dt_salessummary2.Rows.Add("NEW GRAND TOTAL", new_grand.ToString("N2"));
                dt_salessummary2.Rows.Add("OLD GRAND TOTAL", old_grand.ToString("N2"));
            }

            printer.WriteTable(
                dt_salessummary1,
                new StringAlignment[] { StringAlignment.Near, StringAlignment.Far },
                new int[] { printer.StringWidth / 2, printer.StringWidth / 2 }
                );

            printer.WriteTable(
                dt_salessummary2,
                new StringAlignment[] { StringAlignment.Near, StringAlignment.Far },
                new int[] { printer.StringWidth / 2, printer.StringWidth / 2 }
                );

            printer.Print();
            if (globalvariables.PrintReceiptFormat != PrintFormat.Custom_LQ310)
                printer.ActivateCutter();
            return null;
        }

        public static DataTable GetHeader(int type, DateTime dateTime)
        {
            bool isPosVatable = globalvariables.IsVatable;
            
            string sOwner = globalvariables.Owner;
            string sAddress = globalvariables.Address;
            string sTIN = ((isPosVatable) ? "VAT REG. " : "NON VAT REG. ") + globalvariables.TIN;
            string sACC = globalvariables.Acc;
            string sPermitNo = globalvariables.PermitNo;
            string sMIN = globalvariables.MIN;
            string sSerial = globalvariables.Serial;

            DataTable dt_header1 = new DataTable();
            dt_header1.Columns.Add();
            dt_header1.Rows.Add(sOwner);
            dt_header1.Rows.Add(sAddress);
            dt_header1.Rows.Add(sTIN);
            if (type == 1)
            {
                dt_header1.Rows.Add(sACC);
                dt_header1.Rows.Add(sPermitNo);
                dt_header1.Rows.Add(sSerial);
                dt_header1.Rows.Add(sMIN);
            }
            return dt_header1;
        }
    }
}
