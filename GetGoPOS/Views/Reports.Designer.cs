
namespace GetGoPOS.Views
{
    partial class Reports
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
            this.components = new System.ComponentModel.Container();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Reports));
            this.dtpTo = new System.Windows.Forms.DateTimePicker();
            this.dtpFrom = new System.Windows.Forms.DateTimePicker();
            this.lblDateTo = new System.Windows.Forms.Label();
            this.lblDateFrom = new System.Windows.Forms.Label();
            this.dgvDates = new System.Windows.Forms.DataGridView();
            this.colDate = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colBeginOR = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colEndOR = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colOldGrandTotal = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colNewGrandTotal = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colNetSales = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colVat = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colTransCount = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.bgwSearchReports = new System.ComponentModel.BackgroundWorker();
            this.keyDownTimer = new System.Windows.Forms.Timer(this.components);
            this.pbLoad = new System.Windows.Forms.PictureBox();
            this.btnSearch = new FontAwesome.Sharp.IconButton();
            ((System.ComponentModel.ISupportInitialize)(this.dgvDates)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbLoad)).BeginInit();
            this.SuspendLayout();
            // 
            // dtpTo
            // 
            this.dtpTo.CustomFormat = "yyyy-MM-dd";
            this.dtpTo.Font = new System.Drawing.Font("Arial", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dtpTo.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpTo.Location = new System.Drawing.Point(422, 100);
            this.dtpTo.Name = "dtpTo";
            this.dtpTo.Size = new System.Drawing.Size(138, 29);
            this.dtpTo.TabIndex = 46;
            this.dtpTo.ValueChanged += new System.EventHandler(this.dtpTo_ValueChanged);
            // 
            // dtpFrom
            // 
            this.dtpFrom.CustomFormat = "yyyy-MM-dd";
            this.dtpFrom.Font = new System.Drawing.Font("Arial", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dtpFrom.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpFrom.Location = new System.Drawing.Point(158, 99);
            this.dtpFrom.Name = "dtpFrom";
            this.dtpFrom.Size = new System.Drawing.Size(138, 29);
            this.dtpFrom.TabIndex = 45;
            this.dtpFrom.ValueChanged += new System.EventHandler(this.dtpFrom_ValueChanged);
            // 
            // lblDateTo
            // 
            this.lblDateTo.AutoSize = true;
            this.lblDateTo.Font = new System.Drawing.Font("Arial", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblDateTo.ForeColor = System.Drawing.Color.Gainsboro;
            this.lblDateTo.Location = new System.Drawing.Point(314, 104);
            this.lblDateTo.Name = "lblDateTo";
            this.lblDateTo.Size = new System.Drawing.Size(102, 24);
            this.lblDateTo.TabIndex = 44;
            this.lblDateTo.Text = "DATE TO:";
            // 
            // lblDateFrom
            // 
            this.lblDateFrom.AutoSize = true;
            this.lblDateFrom.Font = new System.Drawing.Font("Arial", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblDateFrom.ForeColor = System.Drawing.Color.Gainsboro;
            this.lblDateFrom.Location = new System.Drawing.Point(17, 103);
            this.lblDateFrom.Name = "lblDateFrom";
            this.lblDateFrom.Size = new System.Drawing.Size(135, 24);
            this.lblDateFrom.TabIndex = 42;
            this.lblDateFrom.Text = "DATE FROM:";
            // 
            // dgvDates
            // 
            this.dgvDates.AllowUserToAddRows = false;
            this.dgvDates.AllowUserToDeleteRows = false;
            this.dgvDates.AllowUserToResizeColumns = false;
            this.dgvDates.AllowUserToResizeRows = false;
            this.dgvDates.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgvDates.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvDates.BackgroundColor = System.Drawing.Color.Gainsboro;
            this.dgvDates.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvDates.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.dgvDates.ColumnHeadersHeight = 30;
            this.dgvDates.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            this.dgvDates.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.colDate,
            this.colBeginOR,
            this.colEndOR,
            this.colOldGrandTotal,
            this.colNewGrandTotal,
            this.colNetSales,
            this.colVat,
            this.colTransCount});
            this.dgvDates.GridColor = System.Drawing.Color.Gainsboro;
            this.dgvDates.Location = new System.Drawing.Point(12, 144);
            this.dgvDates.Name = "dgvDates";
            this.dgvDates.ReadOnly = true;
            this.dgvDates.RowHeadersVisible = false;
            this.dgvDates.Size = new System.Drawing.Size(629, 349);
            this.dgvDates.TabIndex = 46;
            this.dgvDates.CellContentDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvDates_CellContentDoubleClick);
            // 
            // colDate
            // 
            this.colDate.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.colDate.FillWeight = 70.77962F;
            this.colDate.HeaderText = "Date";
            this.colDate.MinimumWidth = 80;
            this.colDate.Name = "colDate";
            this.colDate.ReadOnly = true;
            this.colDate.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // colBeginOR
            // 
            this.colBeginOR.HeaderText = "Start OR";
            this.colBeginOR.Name = "colBeginOR";
            this.colBeginOR.ReadOnly = true;
            // 
            // colEndOR
            // 
            this.colEndOR.HeaderText = "End OR";
            this.colEndOR.Name = "colEndOR";
            this.colEndOR.ReadOnly = true;
            // 
            // colOldGrandTotal
            // 
            this.colOldGrandTotal.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.colOldGrandTotal.FillWeight = 43.46766F;
            this.colOldGrandTotal.HeaderText = "Old Grand Total";
            this.colOldGrandTotal.MinimumWidth = 40;
            this.colOldGrandTotal.Name = "colOldGrandTotal";
            this.colOldGrandTotal.ReadOnly = true;
            this.colOldGrandTotal.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.colOldGrandTotal.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // colNewGrandTotal
            // 
            this.colNewGrandTotal.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.colNewGrandTotal.FillWeight = 42.48488F;
            this.colNewGrandTotal.HeaderText = "New Grand Total";
            this.colNewGrandTotal.MinimumWidth = 60;
            this.colNewGrandTotal.Name = "colNewGrandTotal";
            this.colNewGrandTotal.ReadOnly = true;
            this.colNewGrandTotal.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.colNewGrandTotal.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // colNetSales
            // 
            this.colNetSales.HeaderText = "Net Sales";
            this.colNetSales.Name = "colNetSales";
            this.colNetSales.ReadOnly = true;
            this.colNetSales.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.colNetSales.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // colVat
            // 
            this.colVat.HeaderText = "Vat Amount";
            this.colVat.Name = "colVat";
            this.colVat.ReadOnly = true;
            // 
            // colTransCount
            // 
            this.colTransCount.HeaderText = "No. Of Trans";
            this.colTransCount.Name = "colTransCount";
            this.colTransCount.ReadOnly = true;
            // 
            // bgwSearchReports
            // 
            this.bgwSearchReports.WorkerReportsProgress = true;
            this.bgwSearchReports.DoWork += new System.ComponentModel.DoWorkEventHandler(this.bgwSearchReports_DoWork);
            this.bgwSearchReports.ProgressChanged += new System.ComponentModel.ProgressChangedEventHandler(this.bgwSearchReports_ProgressChanged);
            this.bgwSearchReports.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.bgwSearchReports_RunWorkerCompleted);
            // 
            // keyDownTimer
            // 
            this.keyDownTimer.Interval = 400;
            this.keyDownTimer.Tick += new System.EventHandler(this.keyDownTimer_Tick);
            // 
            // pbLoad
            // 
            this.pbLoad.BackColor = System.Drawing.Color.Transparent;
            this.pbLoad.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.pbLoad.Image = ((System.Drawing.Image)(resources.GetObject("pbLoad.Image")));
            this.pbLoad.Location = new System.Drawing.Point(566, 99);
            this.pbLoad.Name = "pbLoad";
            this.pbLoad.Size = new System.Drawing.Size(29, 29);
            this.pbLoad.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pbLoad.TabIndex = 104;
            this.pbLoad.TabStop = false;
            this.pbLoad.Visible = false;
            // 
            // btnSearch
            // 
            this.btnSearch.FlatAppearance.BorderSize = 0;
            this.btnSearch.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSearch.IconChar = FontAwesome.Sharp.IconChar.Search;
            this.btnSearch.IconColor = System.Drawing.Color.Gainsboro;
            this.btnSearch.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.btnSearch.IconSize = 25;
            this.btnSearch.Location = new System.Drawing.Point(601, 98);
            this.btnSearch.Name = "btnSearch";
            this.btnSearch.Size = new System.Drawing.Size(40, 33);
            this.btnSearch.TabIndex = 47;
            this.btnSearch.UseVisualStyleBackColor = true;
            this.btnSearch.Click += new System.EventHandler(this.btnSearch_Click);
            // 
            // Reports
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(32)))), ((int)(((byte)(30)))), ((int)(((byte)(45)))));
            this.ClientSize = new System.Drawing.Size(653, 505);
            this.Controls.Add(this.pbLoad);
            this.Controls.Add(this.btnSearch);
            this.Controls.Add(this.dgvDates);
            this.Controls.Add(this.dtpTo);
            this.Controls.Add(this.dtpFrom);
            this.Controls.Add(this.lblDateFrom);
            this.Controls.Add(this.lblDateTo);
            this.Name = "Reports";
            this.Text = "REPORTS";
            this.Load += new System.EventHandler(this.Reports_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.Reports_KeyDown);
            ((System.ComponentModel.ISupportInitialize)(this.dgvDates)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbLoad)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.DateTimePicker dtpTo;
        private System.Windows.Forms.DateTimePicker dtpFrom;
        private System.Windows.Forms.Label lblDateTo;
        private System.Windows.Forms.Label lblDateFrom;
        private FontAwesome.Sharp.IconButton btnSearch;
        private System.Windows.Forms.DataGridView dgvDates;
        private System.Windows.Forms.PictureBox pbLoad;
        private System.ComponentModel.BackgroundWorker bgwSearchReports;
        private System.Windows.Forms.Timer keyDownTimer;
        private System.Windows.Forms.DataGridViewTextBoxColumn colDate;
        private System.Windows.Forms.DataGridViewTextBoxColumn colBeginOR;
        private System.Windows.Forms.DataGridViewTextBoxColumn colEndOR;
        private System.Windows.Forms.DataGridViewTextBoxColumn colOldGrandTotal;
        private System.Windows.Forms.DataGridViewTextBoxColumn colNewGrandTotal;
        private System.Windows.Forms.DataGridViewTextBoxColumn colNetSales;
        private System.Windows.Forms.DataGridViewTextBoxColumn colVat;
        private System.Windows.Forms.DataGridViewTextBoxColumn colTransCount;
    }
}