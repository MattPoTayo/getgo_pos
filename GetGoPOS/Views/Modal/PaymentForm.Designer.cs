
namespace GetGoPOS.Views.Modal
{
    partial class PaymentForm
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
            this.label2 = new System.Windows.Forms.Label();
            this.iconPictureBox1 = new FontAwesome.Sharp.IconPictureBox();
            this.lblQtyD = new System.Windows.Forms.Label();
            this.lblQty = new System.Windows.Forms.Label();
            this.lblInvoiceD = new System.Windows.Forms.Label();
            this.lblInvoice = new System.Windows.Forms.Label();
            this.tbPrice = new System.Windows.Forms.TextBox();
            this.lblCash = new System.Windows.Forms.Label();
            this.btnPayment = new FontAwesome.Sharp.IconButton();
            this.btnClose = new FontAwesome.Sharp.IconButton();
            this.lblDueAmount = new System.Windows.Forms.Label();
            this.btnExactAmount = new FontAwesome.Sharp.IconButton();
            ((System.ComponentModel.ISupportInitialize)(this.iconPictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // label2
            // 
            this.label2.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Arial", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.Gainsboro;
            this.label2.Location = new System.Drawing.Point(122, 39);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(59, 24);
            this.label2.TabIndex = 47;
            this.label2.Text = "DUE:";
            // 
            // iconPictureBox1
            // 
            this.iconPictureBox1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(32)))), ((int)(((byte)(30)))), ((int)(((byte)(45)))));
            this.iconPictureBox1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(190)))), ((int)(((byte)(0)))));
            this.iconPictureBox1.IconChar = FontAwesome.Sharp.IconChar.MoneyBillAlt;
            this.iconPictureBox1.IconColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(190)))), ((int)(((byte)(0)))));
            this.iconPictureBox1.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.iconPictureBox1.IconSize = 62;
            this.iconPictureBox1.Location = new System.Drawing.Point(63, 24);
            this.iconPictureBox1.Name = "iconPictureBox1";
            this.iconPictureBox1.Size = new System.Drawing.Size(76, 62);
            this.iconPictureBox1.TabIndex = 48;
            this.iconPictureBox1.TabStop = false;
            // 
            // lblQtyD
            // 
            this.lblQtyD.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.lblQtyD.AutoSize = true;
            this.lblQtyD.Font = new System.Drawing.Font("Arial", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblQtyD.ForeColor = System.Drawing.Color.Gainsboro;
            this.lblQtyD.Location = new System.Drawing.Point(161, 134);
            this.lblQtyD.Name = "lblQtyD";
            this.lblQtyD.Size = new System.Drawing.Size(22, 24);
            this.lblQtyD.TabIndex = 58;
            this.lblQtyD.Text = "_";
            // 
            // lblQty
            // 
            this.lblQty.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.lblQty.AutoSize = true;
            this.lblQty.Font = new System.Drawing.Font("Arial", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblQty.ForeColor = System.Drawing.Color.Gainsboro;
            this.lblQty.Location = new System.Drawing.Point(38, 134);
            this.lblQty.Name = "lblQty";
            this.lblQty.Size = new System.Drawing.Size(117, 24);
            this.lblQty.TabIndex = 57;
            this.lblQty.Text = "Item Count:";
            // 
            // lblInvoiceD
            // 
            this.lblInvoiceD.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.lblInvoiceD.AutoSize = true;
            this.lblInvoiceD.Font = new System.Drawing.Font("Arial", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblInvoiceD.ForeColor = System.Drawing.Color.Gainsboro;
            this.lblInvoiceD.Location = new System.Drawing.Point(161, 99);
            this.lblInvoiceD.Name = "lblInvoiceD";
            this.lblInvoiceD.Size = new System.Drawing.Size(22, 24);
            this.lblInvoiceD.TabIndex = 56;
            this.lblInvoiceD.Text = "_";
            // 
            // lblInvoice
            // 
            this.lblInvoice.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.lblInvoice.AutoSize = true;
            this.lblInvoice.Font = new System.Drawing.Font("Arial", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblInvoice.ForeColor = System.Drawing.Color.Gainsboro;
            this.lblInvoice.Location = new System.Drawing.Point(12, 99);
            this.lblInvoice.Name = "lblInvoice";
            this.lblInvoice.Size = new System.Drawing.Size(143, 24);
            this.lblInvoice.TabIndex = 55;
            this.lblInvoice.Text = "Sales Invoice:";
            // 
            // tbPrice
            // 
            this.tbPrice.Font = new System.Drawing.Font("Arial", 20.25F);
            this.tbPrice.Location = new System.Drawing.Point(165, 162);
            this.tbPrice.MaxLength = 20;
            this.tbPrice.Name = "tbPrice";
            this.tbPrice.Size = new System.Drawing.Size(142, 39);
            this.tbPrice.TabIndex = 60;
            this.tbPrice.Tag = "num";
            this.tbPrice.Text = "0.00";
            this.tbPrice.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // lblCash
            // 
            this.lblCash.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.lblCash.AutoSize = true;
            this.lblCash.Font = new System.Drawing.Font("Arial", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCash.ForeColor = System.Drawing.Color.Gainsboro;
            this.lblCash.Location = new System.Drawing.Point(57, 172);
            this.lblCash.Name = "lblCash";
            this.lblCash.Size = new System.Drawing.Size(98, 24);
            this.lblCash.TabIndex = 59;
            this.lblCash.Text = "Payment:";
            // 
            // btnPayment
            // 
            this.btnPayment.FlatAppearance.BorderSize = 0;
            this.btnPayment.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnPayment.IconChar = FontAwesome.Sharp.IconChar.FileInvoice;
            this.btnPayment.IconColor = System.Drawing.Color.Gainsboro;
            this.btnPayment.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.btnPayment.IconSize = 30;
            this.btnPayment.Location = new System.Drawing.Point(259, 216);
            this.btnPayment.Name = "btnPayment";
            this.btnPayment.Size = new System.Drawing.Size(48, 39);
            this.btnPayment.TabIndex = 61;
            this.btnPayment.UseVisualStyleBackColor = true;
            this.btnPayment.Click += new System.EventHandler(this.btnPayment_Click);
            // 
            // btnClose
            // 
            this.btnClose.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnClose.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnClose.IconChar = FontAwesome.Sharp.IconChar.Times;
            this.btnClose.IconColor = System.Drawing.Color.Gainsboro;
            this.btnClose.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.btnClose.IconSize = 15;
            this.btnClose.Location = new System.Drawing.Point(298, 0);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(35, 20);
            this.btnClose.TabIndex = 108;
            this.btnClose.UseVisualStyleBackColor = true;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // lblDueAmount
            // 
            this.lblDueAmount.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.lblDueAmount.AutoSize = true;
            this.lblDueAmount.Font = new System.Drawing.Font("Arial", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblDueAmount.ForeColor = System.Drawing.Color.Gainsboro;
            this.lblDueAmount.Location = new System.Drawing.Point(177, 39);
            this.lblDueAmount.Name = "lblDueAmount";
            this.lblDueAmount.Size = new System.Drawing.Size(52, 24);
            this.lblDueAmount.TabIndex = 109;
            this.lblDueAmount.Text = "0.00";
            // 
            // btnExactAmount
            // 
            this.btnExactAmount.FlatAppearance.BorderSize = 0;
            this.btnExactAmount.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnExactAmount.IconChar = FontAwesome.Sharp.IconChar.Equals;
            this.btnExactAmount.IconColor = System.Drawing.Color.Gainsboro;
            this.btnExactAmount.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.btnExactAmount.IconSize = 30;
            this.btnExactAmount.Location = new System.Drawing.Point(205, 216);
            this.btnExactAmount.Name = "btnExactAmount";
            this.btnExactAmount.Size = new System.Drawing.Size(48, 39);
            this.btnExactAmount.TabIndex = 110;
            this.btnExactAmount.UseVisualStyleBackColor = true;
            this.btnExactAmount.Click += new System.EventHandler(this.btnExactAmount_Click);
            // 
            // PaymentForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(32)))), ((int)(((byte)(30)))), ((int)(((byte)(45)))));
            this.ClientSize = new System.Drawing.Size(332, 275);
            this.Controls.Add(this.btnExactAmount);
            this.Controls.Add(this.lblDueAmount);
            this.Controls.Add(this.btnClose);
            this.Controls.Add(this.btnPayment);
            this.Controls.Add(this.tbPrice);
            this.Controls.Add(this.lblCash);
            this.Controls.Add(this.lblQtyD);
            this.Controls.Add(this.lblQty);
            this.Controls.Add(this.lblInvoiceD);
            this.Controls.Add(this.lblInvoice);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.iconPictureBox1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Name = "PaymentForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "PaymentForm";
            this.Load += new System.EventHandler(this.PaymentForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.iconPictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private FontAwesome.Sharp.IconPictureBox iconPictureBox1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label lblQtyD;
        private System.Windows.Forms.Label lblQty;
        private System.Windows.Forms.Label lblInvoiceD;
        private System.Windows.Forms.Label lblInvoice;
        private System.Windows.Forms.TextBox tbPrice;
        private System.Windows.Forms.Label lblCash;
        private FontAwesome.Sharp.IconButton btnPayment;
        private FontAwesome.Sharp.IconButton btnClose;
        private System.Windows.Forms.Label lblDueAmount;
        private FontAwesome.Sharp.IconButton btnExactAmount;
    }
}