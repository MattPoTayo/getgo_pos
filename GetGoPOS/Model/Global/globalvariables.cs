using GetGoPOS.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GetGoPOS.Model.Global
{
    public static class globalvariables
    {

        public static string settingspath = Application.StartupPath + "/resources/config.txt";

        public static string warning_invalid_amount = "Invalid Amount.";
        public static string warning_invalid_product = "Invalid Product Name.";
        public static string warning_invalid_stockno = "Invalid Stock No.";

        public static string saving_failed = "Failed Saving Data.";
        public static string saving_success = "Success Saving Data.";

        public static string confirm_lock_pos = "Generating current day Z-Read will lock your POS for the day.\n\r Are you sure?";
        public static DateTime birUntilDate = new DateTime(2020, 8, 1);
        public static PrintFormat PrintReceiptFormat { get; set; } = PrintFormat.Custom_76mm;
        public static string PrinterODByte { get; set; } = "27,112,0,25,250";
        public static int PrintReceiptBuffer { get; set; } = 0;
        public static int PrintReceiptActual { get; set; } = 0;
        public static int PrintReceiptLimit { get; set; } = 0;
        public static int PrintReceiptLinespacing { get; set; } = 0;
        public static bool PrintReceiptDisableBypass { get; set; } = false;
        public static bool PrintChineseCharacters { get; set; } = false;

        //Header
        public static string BusinessName { get; set; } = "Store Name";
        public static string Owner { get; set; } = "Owned By: Owner Name";
        public static bool IsVatable { get; set; } = true;
        public static string TIN { get; set; } = "1234-1234-1234-1234";
        public static string MIN { get; set; } = "12345678910";
        public static string Serial { get; set; } = "12345678910";
        public static string PermitNo { get; set; } = "123456789";
        public static string Acc { get; set; } = "123456789";


        public static string Address { get; set; } = "123 Sample St. Sample City Metro Manila";
        public static string TelNo { get; set; } = "(027)254-2544";
        public static string ApprovalDate { get; set; } = "02/10/2021";


        public static string OrFooter1 { get; set; } = "THIS SERVES AS AN OFFICIAL RECEIPT. BRING THIS RECEIPT IN CASE OF EXCHANGE OF MERCHANDISE WITHIN 2 DAYS";
        public static string OrFooter2 { get; set; } = "THANK YOU AND COME AGAIN!";
        public static string OrFooter3 { get; set; } = "";
        public static string OrFooter4 { get; set; } = "";


        //POS Provider
        public static string PosProviderName { get; set; } = "SLTE LTD Co.";
        public static string PosProviderAddress { get; set; } = "Sample St. Brgy 123 Sample City, Metro Manila";
        public static string PosProviderTIN { get; set; } = "1234-1234-1234-1234";
        public static string AccDate { get; set; } = "02/10/2021";



        //Terminal
        public static string Terminal { get; set; } = "1";

        public static bool LockedPOS { get; set; } = false;

    }
}
