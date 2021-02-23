using GetGoPOS.Enums;
using GetGoPOS.Model.Global;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GetGoPOS.Helpers
{
    public static class ConfigGetter
    {
        public static bool GetConfigDetails()
        {
            try
            {
                string[] setting_lines = File.ReadAllLines(globalvariables.settingspath);
                IEnumerable<string[]> setting_enu = setting_lines.Select(l => l.Split(new[] { '=' }, 2));
                var dic = setting_enu.ToDictionary(s => s[0].ToLower().Trim(), s => s[1].Trim());

                //Terminal
                try { globalvariables.Terminal = dic["terminal"]; }
                catch { globalvariables.Terminal = "1"; }
                //BusinessName
                try { globalvariables.BusinessName = dic["businessname"]; }
                catch { globalvariables.BusinessName = "Store Name"; }
                //Owner
                try { globalvariables.Owner = dic["owner"]; }
                catch { globalvariables.Owner = "Owned By: Owner Name"; }
                //IsVat
                try { globalvariables.IsVatable = dic["isvat"].ToString() == "1" ? true: false; }
                catch { globalvariables.IsVatable = true; }
                //TIN
                try { globalvariables.TIN = dic["tin"]; }
                catch { globalvariables.TIN = "1234-1234-1234-1234"; }
                //MIN
                try { globalvariables.MIN = dic["min"]; }
                catch { globalvariables.MIN = "12345678910"; }
                //Serial
                try { globalvariables.Serial = dic["serial"]; }
                catch { globalvariables.Serial = "12345678910"; }
                //PermitNo
                try { globalvariables.PermitNo = dic["permitno"]; }
                catch { globalvariables.PermitNo = "123456789"; }
                //Acc
                try { globalvariables.Acc = dic["acc"]; }
                catch { globalvariables.Acc = "123456789"; }
                //Address
                try { globalvariables.Address = dic["address"]; }
                catch { globalvariables.Address = "123 Sample St. Sample City Metro Manila"; }
                //ApprovalDate
                try { globalvariables.ApprovalDate = dic["approvaldate"]; }
                catch { globalvariables.ApprovalDate = "02/10/2021"; }
                //PosProviderName
                try { globalvariables.PosProviderName = dic["posprovidername"]; }
                catch { globalvariables.PosProviderName = "SLTE LTD Co."; }
                //PosProviderAddress
                try { globalvariables.PosProviderAddress = dic["posprovideraddress"]; }
                catch { globalvariables.PosProviderAddress = "Sample St. Brgy 123 Sample City, Metro Manila"; }
                //PosProviderTIN
                try { globalvariables.PosProviderTIN = dic["posprovidertin"]; }
                catch { globalvariables.PosProviderTIN = "1234-1234-1234-1234"; }
                //AccDate
                try { globalvariables.AccDate = dic["accdate"]; }
                catch { globalvariables.AccDate = "02/10/2021"; }
                //OrFooter1
                try { globalvariables.OrFooter1 = dic["orfooter1"]; }
                catch { globalvariables.OrFooter1 = "THIS SERVES AS AN OFFICIAL RECEIPT. BRING THIS RECEIPT IN CASE OF EXCHANGE OF MERCHANDISE WITHIN 2 DAYS"; }
                //OrFooter2
                try { globalvariables.OrFooter2 = dic["orfooter2"]; }
                catch { globalvariables.OrFooter2 = "THANK YOU AND COME AGAIN!"; }
                //PrintReceiptFormat
                try { globalvariables.PrintReceiptFormat = (PrintFormat)Convert.ToInt16(dic["printreceiptformat"]); }
                catch { globalvariables.PrintReceiptFormat = PrintFormat.Custom_76mm_journal; }
                //PrintReceiptBuffer
                try { globalvariables.PrintReceiptBuffer = Convert.ToInt32(dic["printreceiptbuffer"]); }
                catch { globalvariables.PrintReceiptBuffer = 0; }
                //PrintReceiptActual
                try { globalvariables.PrintReceiptActual = Convert.ToInt32(dic["printreceiptactual"]); }
                catch { globalvariables.PrintReceiptActual = 0; }
                //PrintReceiptLimit
                try { globalvariables.PrintReceiptLimit = Convert.ToInt32(dic["printreceiptlimit"]); }
                catch { globalvariables.PrintReceiptLimit = 0; }
                //PrintReceiptLinespacing
                try { globalvariables.PrintReceiptLinespacing = Convert.ToInt32(dic["printreceiptlinespacing"]); }
                catch { globalvariables.PrintReceiptLinespacing = 0; }
                //PrintChineseCharacters
                try { globalvariables.PrintChineseCharacters =dic["printreceiptbuffer"] == "1" ? true : false; }
                catch { globalvariables.PrintChineseCharacters = false; }

                return true;
            }
            catch
            {
                return false;
            }
        }
    }
}
