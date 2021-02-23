using System;
using System.ComponentModel;
using System.Reflection;

namespace GetGoPOS.Enums
{
    public enum PrintFormat
    {
        [Description("None")]
        None = 0,
        [Description("76mm_journal")]
        Custom_76mm_journal = 1,
        [Description("JNF_57mm")]
        Custom_JNF_57mm = 2,
        [Description("76mm")]
        Custom_76mm = 3,
        [Description("57mm")]
        Custom_57mm = 4,
        [Description("LQ310")]
        Custom_LQ310 = 5,
    }

    public static class PrintFormatHelper
    {
        public static PrintFormat getDescription(string printReceiptFormat)
        {
            Object[] attribute;
            foreach (PrintFormat printFormat in Enum.GetValues(typeof(PrintFormat)))
            {
                attribute = printFormat.GetType()
                            .GetField(printFormat.ToString())
                            .GetCustomAttributes(typeof(DescriptionAttribute), false);

                if (attribute.Length > 0)
                    if ((attribute[0] as DescriptionAttribute).Description == printReceiptFormat)
                        return printFormat;
            }
            return PrintFormat.None;
        }
    }
}
