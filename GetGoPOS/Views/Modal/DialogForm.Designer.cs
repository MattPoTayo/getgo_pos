namespace GetGoPOS.Views.Modal
{
    partial class DialogForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.MessageLabel = new System.Windows.Forms.Label();
            this.flowLPDialogFormbtns = new System.Windows.Forms.FlowLayoutPanel();
            this.YesButton = new System.Windows.Forms.Button();
            this.NoButton = new System.Windows.Forms.Button();
            this.tableLPHostforflowLP = new System.Windows.Forms.TableLayoutPanel();
            this.btnClose = new FontAwesome.Sharp.IconButton();
            this.btnYesIcon = new FontAwesome.Sharp.IconButton();
            this.btnNoIcon = new FontAwesome.Sharp.IconButton();
            this.flowLPDialogFormbtns.SuspendLayout();
            this.tableLPHostforflowLP.SuspendLayout();
            this.SuspendLayout();
            // 
            // MessageLabel
            // 
            this.MessageLabel.AutoSize = true;
            this.MessageLabel.Font = new System.Drawing.Font("Arial", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.MessageLabel.ForeColor = System.Drawing.Color.Gainsboro;
            this.MessageLabel.Location = new System.Drawing.Point(12, 25);
            this.MessageLabel.Name = "MessageLabel";
            this.MessageLabel.Size = new System.Drawing.Size(141, 32);
            this.MessageLabel.TabIndex = 21;
            this.MessageLabel.Text = "Message?";
            this.MessageLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // flowLPDialogFormbtns
            // 
            this.flowLPDialogFormbtns.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)));
            this.flowLPDialogFormbtns.AutoSize = true;
            this.flowLPDialogFormbtns.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.flowLPDialogFormbtns.Controls.Add(this.YesButton);
            this.flowLPDialogFormbtns.Controls.Add(this.NoButton);
            this.flowLPDialogFormbtns.Location = new System.Drawing.Point(80, 3);
            this.flowLPDialogFormbtns.Name = "flowLPDialogFormbtns";
            this.flowLPDialogFormbtns.Size = new System.Drawing.Size(290, 44);
            this.flowLPDialogFormbtns.TabIndex = 37;
            // 
            // YesButton
            // 
            this.YesButton.AutoSize = true;
            this.YesButton.Font = new System.Drawing.Font("Arial", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.YesButton.Location = new System.Drawing.Point(3, 3);
            this.YesButton.Name = "YesButton";
            this.YesButton.Size = new System.Drawing.Size(139, 38);
            this.YesButton.TabIndex = 35;
            this.YesButton.Text = "Yes (F1)";
            this.YesButton.UseVisualStyleBackColor = false;
            this.YesButton.Click += new System.EventHandler(this.YesButton_Click);
            // 
            // NoButton
            // 
            this.NoButton.AutoSize = true;
            this.NoButton.Font = new System.Drawing.Font("Arial", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.NoButton.Location = new System.Drawing.Point(148, 3);
            this.NoButton.Name = "NoButton";
            this.NoButton.Size = new System.Drawing.Size(139, 38);
            this.NoButton.TabIndex = 36;
            this.NoButton.Text = "No (F2)";
            this.NoButton.UseVisualStyleBackColor = false;
            this.NoButton.Click += new System.EventHandler(this.NoButton_Click);
            // 
            // tableLPHostforflowLP
            // 
            this.tableLPHostforflowLP.AutoSize = true;
            this.tableLPHostforflowLP.ColumnCount = 1;
            this.tableLPHostforflowLP.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLPHostforflowLP.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLPHostforflowLP.Controls.Add(this.flowLPDialogFormbtns, 0, 0);
            this.tableLPHostforflowLP.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.tableLPHostforflowLP.Location = new System.Drawing.Point(0, 221);
            this.tableLPHostforflowLP.Name = "tableLPHostforflowLP";
            this.tableLPHostforflowLP.RowCount = 1;
            this.tableLPHostforflowLP.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLPHostforflowLP.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLPHostforflowLP.Size = new System.Drawing.Size(451, 50);
            this.tableLPHostforflowLP.TabIndex = 38;
            this.tableLPHostforflowLP.Visible = false;
            // 
            // btnClose
            // 
            this.btnClose.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnClose.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnClose.IconChar = FontAwesome.Sharp.IconChar.Times;
            this.btnClose.IconColor = System.Drawing.Color.Gainsboro;
            this.btnClose.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.btnClose.IconSize = 15;
            this.btnClose.Location = new System.Drawing.Point(416, -1);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(35, 20);
            this.btnClose.TabIndex = 39;
            this.btnClose.UseVisualStyleBackColor = true;
            // 
            // btnYesIcon
            // 
            this.btnYesIcon.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnYesIcon.FlatAppearance.BorderSize = 0;
            this.btnYesIcon.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnYesIcon.IconChar = FontAwesome.Sharp.IconChar.Check;
            this.btnYesIcon.IconColor = System.Drawing.Color.Green;
            this.btnYesIcon.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.btnYesIcon.IconSize = 30;
            this.btnYesIcon.Location = new System.Drawing.Point(131, 182);
            this.btnYesIcon.Name = "btnYesIcon";
            this.btnYesIcon.Size = new System.Drawing.Size(91, 39);
            this.btnYesIcon.TabIndex = 40;
            this.btnYesIcon.UseVisualStyleBackColor = true;
            this.btnYesIcon.Click += new System.EventHandler(this.btnYesIcon_Click);
            // 
            // btnNoIcon
            // 
            this.btnNoIcon.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnNoIcon.FlatAppearance.BorderSize = 0;
            this.btnNoIcon.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnNoIcon.IconChar = FontAwesome.Sharp.IconChar.Times;
            this.btnNoIcon.IconColor = System.Drawing.Color.Red;
            this.btnNoIcon.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.btnNoIcon.IconSize = 30;
            this.btnNoIcon.Location = new System.Drawing.Point(228, 182);
            this.btnNoIcon.Name = "btnNoIcon";
            this.btnNoIcon.Size = new System.Drawing.Size(101, 39);
            this.btnNoIcon.TabIndex = 41;
            this.btnNoIcon.UseVisualStyleBackColor = true;
            this.btnNoIcon.Click += new System.EventHandler(this.btnNoIcon_Click);
            // 
            // DialogForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(32)))), ((int)(((byte)(30)))), ((int)(((byte)(45)))));
            this.ClientSize = new System.Drawing.Size(451, 271);
            this.Controls.Add(this.btnNoIcon);
            this.Controls.Add(this.btnYesIcon);
            this.Controls.Add(this.btnClose);
            this.Controls.Add(this.tableLPHostforflowLP);
            this.Controls.Add(this.MessageLabel);
            this.DoubleBuffered = true;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.KeyPreview = true;
            this.MaximizeBox = false;
            this.Name = "DialogForm";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Tag = "main";
            this.Text = "Question";
            this.Load += new System.EventHandler(this.DialogForm_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.DialogForm_KeyDown);
            this.flowLPDialogFormbtns.ResumeLayout(false);
            this.flowLPDialogFormbtns.PerformLayout();
            this.tableLPHostforflowLP.ResumeLayout(false);
            this.tableLPHostforflowLP.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label MessageLabel;
        private System.Windows.Forms.FlowLayoutPanel flowLPDialogFormbtns;
        private System.Windows.Forms.TableLayoutPanel tableLPHostforflowLP;
        private System.Windows.Forms.Button YesButton;
        private System.Windows.Forms.Button NoButton;
        private FontAwesome.Sharp.IconButton btnClose;
        private FontAwesome.Sharp.IconButton btnYesIcon;
        private FontAwesome.Sharp.IconButton btnNoIcon;
    }
}