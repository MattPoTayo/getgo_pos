
namespace GetGoPOS.Views
{
    partial class ManageInventory
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ManageInventory));
            this.dgvInventory = new System.Windows.Forms.DataGridView();
            this.colID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colProductName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colQuantity = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colDate = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colManual = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.pbLoad = new System.Windows.Forms.PictureBox();
            this.btnSearchProduct = new FontAwesome.Sharp.IconButton();
            this.btnAddProduct = new FontAwesome.Sharp.IconButton();
            this.txtKeyword = new System.Windows.Forms.TextBox();
            this.btnRecompute = new FontAwesome.Sharp.IconButton();
            this.bgwSearchProduct = new System.ComponentModel.BackgroundWorker();
            this.keyDownTimer = new System.Windows.Forms.Timer(this.components);
            this.rbAll = new System.Windows.Forms.RadioButton();
            this.rbManual = new System.Windows.Forms.RadioButton();
            this.rbAuto = new System.Windows.Forms.RadioButton();
            this.bwRecompute = new System.ComponentModel.BackgroundWorker();
            ((System.ComponentModel.ISupportInitialize)(this.dgvInventory)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbLoad)).BeginInit();
            this.SuspendLayout();
            // 
            // dgvInventory
            // 
            this.dgvInventory.AllowUserToAddRows = false;
            this.dgvInventory.AllowUserToDeleteRows = false;
            this.dgvInventory.AllowUserToResizeColumns = false;
            this.dgvInventory.AllowUserToResizeRows = false;
            this.dgvInventory.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgvInventory.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvInventory.BackgroundColor = System.Drawing.Color.Gainsboro;
            this.dgvInventory.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvInventory.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle2;
            this.dgvInventory.ColumnHeadersHeight = 30;
            this.dgvInventory.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            this.dgvInventory.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.colID,
            this.colProductName,
            this.colQuantity,
            this.colDate,
            this.colManual});
            this.dgvInventory.GridColor = System.Drawing.Color.Gainsboro;
            this.dgvInventory.Location = new System.Drawing.Point(13, 149);
            this.dgvInventory.Name = "dgvInventory";
            this.dgvInventory.ReadOnly = true;
            this.dgvInventory.RowHeadersVisible = false;
            this.dgvInventory.Size = new System.Drawing.Size(644, 361);
            this.dgvInventory.TabIndex = 15;
            // 
            // colID
            // 
            this.colID.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.colID.FillWeight = 70.77962F;
            this.colID.HeaderText = "ID";
            this.colID.MinimumWidth = 80;
            this.colID.Name = "colID";
            this.colID.ReadOnly = true;
            this.colID.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // colProductName
            // 
            this.colProductName.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.colProductName.FillWeight = 43.46766F;
            this.colProductName.HeaderText = "Product Name";
            this.colProductName.MinimumWidth = 40;
            this.colProductName.Name = "colProductName";
            this.colProductName.ReadOnly = true;
            this.colProductName.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.colProductName.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // colQuantity
            // 
            this.colQuantity.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.colQuantity.FillWeight = 42.48488F;
            this.colQuantity.HeaderText = "Quantity";
            this.colQuantity.MinimumWidth = 60;
            this.colQuantity.Name = "colQuantity";
            this.colQuantity.ReadOnly = true;
            this.colQuantity.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.colQuantity.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // colDate
            // 
            this.colDate.HeaderText = "Date";
            this.colDate.Name = "colDate";
            this.colDate.ReadOnly = true;
            this.colDate.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.colDate.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // colManual
            // 
            this.colManual.HeaderText = "Manual";
            this.colManual.Name = "colManual";
            this.colManual.ReadOnly = true;
            // 
            // pbLoad
            // 
            this.pbLoad.BackColor = System.Drawing.Color.Transparent;
            this.pbLoad.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.pbLoad.Image = ((System.Drawing.Image)(resources.GetObject("pbLoad.Image")));
            this.pbLoad.Location = new System.Drawing.Point(618, 115);
            this.pbLoad.Name = "pbLoad";
            this.pbLoad.Size = new System.Drawing.Size(29, 29);
            this.pbLoad.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pbLoad.TabIndex = 109;
            this.pbLoad.TabStop = false;
            this.pbLoad.Visible = false;
            // 
            // btnSearchProduct
            // 
            this.btnSearchProduct.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnSearchProduct.FlatAppearance.BorderSize = 0;
            this.btnSearchProduct.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSearchProduct.IconChar = FontAwesome.Sharp.IconChar.Search;
            this.btnSearchProduct.IconColor = System.Drawing.Color.Gainsboro;
            this.btnSearchProduct.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.btnSearchProduct.IconSize = 30;
            this.btnSearchProduct.Location = new System.Drawing.Point(608, 70);
            this.btnSearchProduct.Name = "btnSearchProduct";
            this.btnSearchProduct.Size = new System.Drawing.Size(48, 39);
            this.btnSearchProduct.TabIndex = 108;
            this.btnSearchProduct.UseVisualStyleBackColor = true;
            this.btnSearchProduct.Click += new System.EventHandler(this.btnSearchProduct_Click);
            // 
            // btnAddProduct
            // 
            this.btnAddProduct.FlatAppearance.BorderSize = 0;
            this.btnAddProduct.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnAddProduct.IconChar = FontAwesome.Sharp.IconChar.Plus;
            this.btnAddProduct.IconColor = System.Drawing.Color.Gainsboro;
            this.btnAddProduct.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.btnAddProduct.IconSize = 30;
            this.btnAddProduct.Location = new System.Drawing.Point(13, 70);
            this.btnAddProduct.Name = "btnAddProduct";
            this.btnAddProduct.Size = new System.Drawing.Size(48, 39);
            this.btnAddProduct.TabIndex = 107;
            this.btnAddProduct.UseVisualStyleBackColor = true;
            this.btnAddProduct.Click += new System.EventHandler(this.btnAddProduct_Click);
            // 
            // txtKeyword
            // 
            this.txtKeyword.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtKeyword.Font = new System.Drawing.Font("Arial", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtKeyword.Location = new System.Drawing.Point(63, 70);
            this.txtKeyword.MaxLength = 10;
            this.txtKeyword.Name = "txtKeyword";
            this.txtKeyword.Size = new System.Drawing.Size(549, 39);
            this.txtKeyword.TabIndex = 106;
            this.txtKeyword.Tag = "num";
            this.txtKeyword.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.txtKeyword.TextChanged += new System.EventHandler(this.txtKeyword_TextChanged);
            this.txtKeyword.Leave += new System.EventHandler(this.txtKeyword_Leave);
            // 
            // btnRecompute
            // 
            this.btnRecompute.FlatAppearance.BorderSize = 0;
            this.btnRecompute.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnRecompute.IconChar = FontAwesome.Sharp.IconChar.Calculator;
            this.btnRecompute.IconColor = System.Drawing.Color.Gainsboro;
            this.btnRecompute.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.btnRecompute.IconSize = 30;
            this.btnRecompute.Location = new System.Drawing.Point(13, 115);
            this.btnRecompute.Name = "btnRecompute";
            this.btnRecompute.Size = new System.Drawing.Size(48, 33);
            this.btnRecompute.TabIndex = 112;
            this.btnRecompute.UseVisualStyleBackColor = true;
            this.btnRecompute.Click += new System.EventHandler(this.btnRecompute_Click);
            // 
            // bgwSearchProduct
            // 
            this.bgwSearchProduct.WorkerReportsProgress = true;
            this.bgwSearchProduct.DoWork += new System.ComponentModel.DoWorkEventHandler(this.bgwSearchProduct_DoWork);
            this.bgwSearchProduct.ProgressChanged += new System.ComponentModel.ProgressChangedEventHandler(this.bgwSearchProduct_ProgressChanged);
            this.bgwSearchProduct.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.bgwSearchProduct_RunWorkerCompleted);
            // 
            // keyDownTimer
            // 
            this.keyDownTimer.Interval = 400;
            this.keyDownTimer.Tick += new System.EventHandler(this.keyDownTimer_Tick);
            // 
            // rbAll
            // 
            this.rbAll.AutoSize = true;
            this.rbAll.Checked = true;
            this.rbAll.ForeColor = System.Drawing.Color.Gainsboro;
            this.rbAll.Location = new System.Drawing.Point(67, 123);
            this.rbAll.Name = "rbAll";
            this.rbAll.Size = new System.Drawing.Size(36, 17);
            this.rbAll.TabIndex = 113;
            this.rbAll.TabStop = true;
            this.rbAll.Text = "All";
            this.rbAll.UseVisualStyleBackColor = true;
            this.rbAll.CheckedChanged += new System.EventHandler(this.rbAll_CheckedChanged);
            // 
            // rbManual
            // 
            this.rbManual.AutoSize = true;
            this.rbManual.ForeColor = System.Drawing.Color.Gainsboro;
            this.rbManual.Location = new System.Drawing.Point(109, 123);
            this.rbManual.Name = "rbManual";
            this.rbManual.Size = new System.Drawing.Size(60, 17);
            this.rbManual.TabIndex = 114;
            this.rbManual.TabStop = true;
            this.rbManual.Text = "Manual";
            this.rbManual.UseVisualStyleBackColor = true;
            this.rbManual.CheckedChanged += new System.EventHandler(this.rbManual_CheckedChanged);
            // 
            // rbAuto
            // 
            this.rbAuto.AutoSize = true;
            this.rbAuto.ForeColor = System.Drawing.Color.Gainsboro;
            this.rbAuto.Location = new System.Drawing.Point(175, 123);
            this.rbAuto.Name = "rbAuto";
            this.rbAuto.Size = new System.Drawing.Size(81, 17);
            this.rbAuto.TabIndex = 115;
            this.rbAuto.TabStop = true;
            this.rbAuto.Text = "Transaction";
            this.rbAuto.UseVisualStyleBackColor = true;
            this.rbAuto.CheckedChanged += new System.EventHandler(this.rbAuto_CheckedChanged);
            // 
            // bwRecompute
            // 
            this.bwRecompute.DoWork += new System.ComponentModel.DoWorkEventHandler(this.bwRecompute_DoWork);
            this.bwRecompute.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.bwRecompute_RunWorkerCompleted);
            // 
            // ManageInventory
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(32)))), ((int)(((byte)(30)))), ((int)(((byte)(45)))));
            this.ClientSize = new System.Drawing.Size(668, 522);
            this.Controls.Add(this.rbAuto);
            this.Controls.Add(this.rbManual);
            this.Controls.Add(this.rbAll);
            this.Controls.Add(this.btnRecompute);
            this.Controls.Add(this.pbLoad);
            this.Controls.Add(this.btnSearchProduct);
            this.Controls.Add(this.btnAddProduct);
            this.Controls.Add(this.txtKeyword);
            this.Controls.Add(this.dgvInventory);
            this.Name = "ManageInventory";
            this.Text = "MANAGE INVENTORY";
            this.Load += new System.EventHandler(this.ManageInventory_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.ManageInventory_KeyDown);
            ((System.ComponentModel.ISupportInitialize)(this.dgvInventory)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbLoad)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dgvInventory;
        private System.Windows.Forms.PictureBox pbLoad;
        private FontAwesome.Sharp.IconButton btnSearchProduct;
        private FontAwesome.Sharp.IconButton btnAddProduct;
        public System.Windows.Forms.TextBox txtKeyword;
        private FontAwesome.Sharp.IconButton btnRecompute;
        private System.ComponentModel.BackgroundWorker bgwSearchProduct;
        private System.Windows.Forms.Timer keyDownTimer;
        private System.Windows.Forms.DataGridViewTextBoxColumn colID;
        private System.Windows.Forms.DataGridViewTextBoxColumn colProductName;
        private System.Windows.Forms.DataGridViewTextBoxColumn colQuantity;
        private System.Windows.Forms.DataGridViewTextBoxColumn colDate;
        private System.Windows.Forms.DataGridViewTextBoxColumn colManual;
        private System.Windows.Forms.RadioButton rbAll;
        private System.Windows.Forms.RadioButton rbManual;
        private System.Windows.Forms.RadioButton rbAuto;
        private System.ComponentModel.BackgroundWorker bwRecompute;
    }
}