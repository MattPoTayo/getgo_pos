using GetGoPOS.Helpers;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;

namespace GetGoPOS.Views.Modal
{
    public partial class DialogForm : BaseForm
    {
        public string Title { get; set; }
        public string Message { get; set; }
        public string YesButtonLabel { get; set; }
        public string NoButtonLabel { get; set; }
        public string ReturnValue { get; set; }

        public DialogForm(string message, string title, string yesButtonLabel, string noButtonLabel)
        {
            InitializeComponent();
            this.Title = title;
            this.Message = message;
            this.YesButtonLabel = string.Format("{0} (F1)", yesButtonLabel);
            this.NoButtonLabel = string.Format("{0} (F2)", noButtonLabel);

            if (this.Title == "")
                Title = " ";
        }
        private void DialogForm_Load(object sender, EventArgs e)
        {
            this.Text = this.Title;
            this.MessageLabel.Text = this.Message;
            this.YesButton.Text = this.YesButtonLabel;
            this.NoButton.Text = this.NoButtonLabel;
            this.KeyPreview = true;
            this.Text = string.Empty;
            this.ControlBox = false;
            this.DoubleBuffered = true;
            this.MaximizedBounds = Screen.FromHandle(this.Handle).WorkingArea;

            int buttonTopPosition = GlobalFunc.CenterControlInParent(MessageLabel, YesButton.Height);
            if (buttonTopPosition != 0)
            {
                YesButton.Top = buttonTopPosition;
                NoButton.Top = buttonTopPosition;
            }
        }
        private void DialogForm_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
                NoButton.PerformClick();
            else if (e.KeyCode == Keys.F1)
                YesButton.PerformClick();
            else if (e.KeyCode == Keys.F2)
                NoButton.PerformClick();
            return;
        }

        protected override bool ProcessCmdKey(ref Message msg, Keys keyData)
        {
            if (keyData == Keys.F10)
                return true;
            return base.ProcessCmdKey(ref msg, keyData);
        }

        private void YesButton_Click(object sender, EventArgs e)
        {
            this.ReturnValue = YesButton.Text;
            this.Close();
        }

        private void NoButton_Click(object sender, EventArgs e)
        {
            this.ReturnValue = NoButton.Text;
            this.Close();
        }

        private void btnYesIcon_Click(object sender, EventArgs e)
        {
            this.ReturnValue = YesButton.Text;
            this.Close();
        }

        private void btnNoIcon_Click(object sender, EventArgs e)
        {
            this.ReturnValue = NoButton.Text;
            this.Close();
        }
    }
}