
namespace GetGoPOS.Views.Modal
{
    partial class ChooseReportType
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
            this.lblDate = new System.Windows.Forms.Label();
            this.btnClose = new FontAwesome.Sharp.IconButton();
            this.btnZRead = new FontAwesome.Sharp.IconButton();
            this.iconPictureBox1 = new FontAwesome.Sharp.IconPictureBox();
            this.btnXRead = new FontAwesome.Sharp.IconButton();
            ((System.ComponentModel.ISupportInitialize)(this.iconPictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // lblDate
            // 
            this.lblDate.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.lblDate.AutoSize = true;
            this.lblDate.Font = new System.Drawing.Font("Arial", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblDate.ForeColor = System.Drawing.Color.Gainsboro;
            this.lblDate.Location = new System.Drawing.Point(117, 40);
            this.lblDate.Name = "lblDate";
            this.lblDate.Size = new System.Drawing.Size(22, 24);
            this.lblDate.TabIndex = 46;
            this.lblDate.Text = "_";
            // 
            // btnClose
            // 
            this.btnClose.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnClose.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnClose.IconChar = FontAwesome.Sharp.IconChar.Times;
            this.btnClose.IconColor = System.Drawing.Color.Gainsboro;
            this.btnClose.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.btnClose.IconSize = 15;
            this.btnClose.Location = new System.Drawing.Point(257, -1);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(35, 20);
            this.btnClose.TabIndex = 49;
            this.btnClose.UseVisualStyleBackColor = true;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // btnZRead
            // 
            this.btnZRead.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnZRead.FlatAppearance.BorderSize = 0;
            this.btnZRead.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnZRead.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnZRead.ForeColor = System.Drawing.Color.Gainsboro;
            this.btnZRead.IconChar = FontAwesome.Sharp.IconChar.Book;
            this.btnZRead.IconColor = System.Drawing.Color.Red;
            this.btnZRead.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.btnZRead.IconSize = 30;
            this.btnZRead.Location = new System.Drawing.Point(164, 98);
            this.btnZRead.Name = "btnZRead";
            this.btnZRead.Size = new System.Drawing.Size(119, 39);
            this.btnZRead.TabIndex = 48;
            this.btnZRead.Text = "Z-Read";
            this.btnZRead.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnZRead.UseVisualStyleBackColor = true;
            this.btnZRead.Click += new System.EventHandler(this.btnZRead_Click);
            // 
            // iconPictureBox1
            // 
            this.iconPictureBox1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(32)))), ((int)(((byte)(30)))), ((int)(((byte)(45)))));
            this.iconPictureBox1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(190)))), ((int)(((byte)(0)))));
            this.iconPictureBox1.IconChar = FontAwesome.Sharp.IconChar.CalendarAlt;
            this.iconPictureBox1.IconColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(190)))), ((int)(((byte)(0)))));
            this.iconPictureBox1.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.iconPictureBox1.IconSize = 47;
            this.iconPictureBox1.Location = new System.Drawing.Point(64, 29);
            this.iconPictureBox1.Name = "iconPictureBox1";
            this.iconPictureBox1.Size = new System.Drawing.Size(47, 47);
            this.iconPictureBox1.TabIndex = 47;
            this.iconPictureBox1.TabStop = false;
            // 
            // btnXRead
            // 
            this.btnXRead.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnXRead.FlatAppearance.BorderSize = 0;
            this.btnXRead.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnXRead.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnXRead.ForeColor = System.Drawing.Color.Gainsboro;
            this.btnXRead.IconChar = FontAwesome.Sharp.IconChar.BookOpen;
            this.btnXRead.IconColor = System.Drawing.Color.Green;
            this.btnXRead.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.btnXRead.IconSize = 30;
            this.btnXRead.Location = new System.Drawing.Point(12, 98);
            this.btnXRead.Name = "btnXRead";
            this.btnXRead.Size = new System.Drawing.Size(119, 39);
            this.btnXRead.TabIndex = 42;
            this.btnXRead.Text = "X-Read";
            this.btnXRead.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnXRead.UseVisualStyleBackColor = true;
            this.btnXRead.Click += new System.EventHandler(this.btnXRead_Click);
            // 
            // ChooseReportType
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(32)))), ((int)(((byte)(30)))), ((int)(((byte)(45)))));
            this.ClientSize = new System.Drawing.Size(293, 149);
            this.Controls.Add(this.btnClose);
            this.Controls.Add(this.btnZRead);
            this.Controls.Add(this.iconPictureBox1);
            this.Controls.Add(this.lblDate);
            this.Controls.Add(this.btnXRead);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Name = "ChooseReportType";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "ChooseReportType";
            this.Load += new System.EventHandler(this.ChooseReportType_Load);
            ((System.ComponentModel.ISupportInitialize)(this.iconPictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private FontAwesome.Sharp.IconButton btnXRead;
        private System.Windows.Forms.Label lblDate;
        private FontAwesome.Sharp.IconPictureBox iconPictureBox1;
        private FontAwesome.Sharp.IconButton btnZRead;
        private FontAwesome.Sharp.IconButton btnClose;
    }
}