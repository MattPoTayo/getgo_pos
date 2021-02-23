using System.ComponentModel;
using System.Windows.Forms;

namespace GetGoPOS
{
    public class BaseForm : Form
    {
        protected override CreateParams CreateParams
        {
            get
            {
                CreateParams cp = base.CreateParams;
                // Turn on WS_EX_COMPOSITED only during Runtime, causes problems during Designtime
                if (LicenseManager.UsageMode == LicenseUsageMode.Runtime)
                    cp.ExStyle |= 0x02000000;
                return cp;
            }
        }
    }
}
