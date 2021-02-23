using GetGoPOS.Helpers;
using GetGoPOS.Model;
using GetGoPOS.Model.Global;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GetGoPOS.Views.Modal
{
    public partial class ChooseReportType : Form
    {
        public Report report { get; set; } = new Report();
        public ChooseReportType()
        {
            InitializeComponent();

            this.KeyPreview = true;
            this.Text = string.Empty;
            this.ControlBox = false;
            this.DoubleBuffered = true;
            this.MaximizedBounds = Screen.FromHandle(this.Handle).WorkingArea;
        }

        private void ChooseReportType_Load(object sender, EventArgs e)
        {
            lblDate.Text = report.Date.ToString("yyyy-MM-dd");
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnZRead_Click(object sender, EventArgs e)
        {
            if (report.Date == DateTime.Now.Date && !globalvariables.LockedPOS)
            {
                if (FncFilter.ConfirmYesNo(globalvariables.confirm_lock_pos))
                {
                    GenerateReport.ZRead(report.Date);
                }
            }
            else
            {
                report.Type = 3;
                HardwareHelper.PrintReport(null, null, null, report);
            }
            this.Close();

        }

        private void btnXRead_Click(object sender, EventArgs e)
        {
            HardwareHelper.PrintReport(null, null, null, report);
            this.Close();
        }
    }
}
