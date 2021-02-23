using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using GetGoPOS.Helpers;

namespace GetGoPOS.Views.Modal
{
    public enum ErrorFormButtonType
    {
        Escape,
        OK,
        Proceed
    }
    public partial class ErrorForm : BaseForm
    {
        public string errormessage;
        public ErrorFormButtonType ErrorFormButtonType { private get; set; } = ErrorFormButtonType.Escape;
        public ErrorForm()
        {
            InitializeComponent();
            errormessage = "";
        }

        private void ErrorForm_Load(object sender, EventArgs e)
        {
            this.KeyPreview = true;
            this.Text = string.Empty;
            this.ControlBox = false;
            this.DoubleBuffered = true;
            this.MaximizedBounds = Screen.FromHandle(this.Handle).WorkingArea;

            if (errormessage == "")
                errormessage = " ";
            this.lblError.Text = this.errormessage;
            GlobalFunc.CenterControlInParent(lblError, 38);

        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void ErrorForm_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
                btnClose.PerformClick();
        }
    }
}
