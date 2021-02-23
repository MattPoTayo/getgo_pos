
namespace GetGoPOS.Views
{
    partial class ProductManagement
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ProductManagement));
            this.txtKeyword = new System.Windows.Forms.TextBox();
            this.dgvProduct = new System.Windows.Forms.DataGridView();
            this.btnAddProduct = new FontAwesome.Sharp.IconButton();
            this.btnSearchProduct = new FontAwesome.Sharp.IconButton();
            this.bgwSearchProduct = new System.ComponentModel.BackgroundWorker();
            this.keyDownTimer = new System.Windows.Forms.Timer(this.components);
            this.pbLoad = new System.Windows.Forms.PictureBox();
            this.cbShowDiscontinued = new System.Windows.Forms.CheckBox();
            this.colBarcode = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colProductName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colPrice = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colStockNo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colInventory = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.dgvProduct)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbLoad)).BeginInit();
            this.SuspendLayout();
            // 
            // txtKeyword
            // 
            this.txtKeyword.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtKeyword.Font = new System.Drawing.Font("Arial", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtKeyword.Location = new System.Drawing.Point(63, 74);
            this.txtKeyword.MaxLength = 10;
            this.txtKeyword.Name = "txtKeyword";
            this.txtKeyword.Size = new System.Drawing.Size(549, 39);
            this.txtKeyword.TabIndex = 7;
            this.txtKeyword.Tag = "num";
            this.txtKeyword.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.txtKeyword.TextChanged += new System.EventHandler(this.txtKeyword_TextChanged);
            this.txtKeyword.Leave += new System.EventHandler(this.txtKeyword_Leave);
            // 
            // dgvProduct
            // 
            this.dgvProduct.AllowUserToAddRows = false;
            this.dgvProduct.AllowUserToDeleteRows = false;
            this.dgvProduct.AllowUserToResizeColumns = false;
            this.dgvProduct.AllowUserToResizeRows = false;
            this.dgvProduct.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgvProduct.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvProduct.BackgroundColor = System.Drawing.Color.Gainsboro;
            this.dgvProduct.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvProduct.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.dgvProduct.ColumnHeadersHeight = 30;
            this.dgvProduct.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            this.dgvProduct.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.colBarcode,
            this.colProductName,
            this.colPrice,
            this.colStockNo,
            this.colInventory});
            this.dgvProduct.GridColor = System.Drawing.Color.Gainsboro;
            this.dgvProduct.Location = new System.Drawing.Point(12, 149);
            this.dgvProduct.Name = "dgvProduct";
            this.dgvProduct.ReadOnly = true;
            this.dgvProduct.RowHeadersVisible = false;
            this.dgvProduct.Size = new System.Drawing.Size(644, 361);
            this.dgvProduct.TabIndex = 12;
            this.dgvProduct.CellContentDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvProduct_CellContentDoubleClick);
            // 
            // btnAddProduct
            // 
            this.btnAddProduct.FlatAppearance.BorderSize = 0;
            this.btnAddProduct.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnAddProduct.IconChar = FontAwesome.Sharp.IconChar.Plus;
            this.btnAddProduct.IconColor = System.Drawing.Color.Gainsboro;
            this.btnAddProduct.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.btnAddProduct.IconSize = 30;
            this.btnAddProduct.Location = new System.Drawing.Point(13, 74);
            this.btnAddProduct.Name = "btnAddProduct";
            this.btnAddProduct.Size = new System.Drawing.Size(48, 39);
            this.btnAddProduct.TabIndex = 13;
            this.btnAddProduct.UseVisualStyleBackColor = true;
            this.btnAddProduct.Click += new System.EventHandler(this.btnAddProduct_Click);
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
            this.btnSearchProduct.Location = new System.Drawing.Point(608, 74);
            this.btnSearchProduct.Name = "btnSearchProduct";
            this.btnSearchProduct.Size = new System.Drawing.Size(48, 39);
            this.btnSearchProduct.TabIndex = 14;
            this.btnSearchProduct.UseVisualStyleBackColor = true;
            this.btnSearchProduct.Click += new System.EventHandler(this.btnSearchProduct_Click);
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
            // pbLoad
            // 
            this.pbLoad.BackColor = System.Drawing.Color.Transparent;
            this.pbLoad.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.pbLoad.Image = ((System.Drawing.Image)(resources.GetObject("pbLoad.Image")));
            this.pbLoad.Location = new System.Drawing.Point(583, 119);
            this.pbLoad.Name = "pbLoad";
            this.pbLoad.Size = new System.Drawing.Size(29, 29);
            this.pbLoad.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pbLoad.TabIndex = 103;
            this.pbLoad.TabStop = false;
            this.pbLoad.Visible = false;
            // 
            // cbShowDiscontinued
            // 
            this.cbShowDiscontinued.AutoSize = true;
            this.cbShowDiscontinued.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbShowDiscontinued.ForeColor = System.Drawing.Color.Gainsboro;
            this.cbShowDiscontinued.Location = new System.Drawing.Point(63, 119);
            this.cbShowDiscontinued.Name = "cbShowDiscontinued";
            this.cbShowDiscontinued.Size = new System.Drawing.Size(150, 24);
            this.cbShowDiscontinued.TabIndex = 105;
            this.cbShowDiscontinued.Text = "DISCONTINUED";
            this.cbShowDiscontinued.UseVisualStyleBackColor = true;
            this.cbShowDiscontinued.CheckedChanged += new System.EventHandler(this.chShowDiscontinued_CheckedChanged);
            // 
            // colBarcode
            // 
            this.colBarcode.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.colBarcode.FillWeight = 70.77962F;
            this.colBarcode.HeaderText = "Barcode";
            this.colBarcode.MinimumWidth = 80;
            this.colBarcode.Name = "colBarcode";
            this.colBarcode.ReadOnly = true;
            this.colBarcode.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // colProductName
            // 
            this.colProductName.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.colProductName.FillWeight = 43.46766F;
            this.colProductName.HeaderText = "Name";
            this.colProductName.MinimumWidth = 40;
            this.colProductName.Name = "colProductName";
            this.colProductName.ReadOnly = true;
            this.colProductName.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.colProductName.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // colPrice
            // 
            this.colPrice.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.colPrice.FillWeight = 42.48488F;
            this.colPrice.HeaderText = "Price";
            this.colPrice.MinimumWidth = 60;
            this.colPrice.Name = "colPrice";
            this.colPrice.ReadOnly = true;
            this.colPrice.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.colPrice.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // colStockNo
            // 
            this.colStockNo.HeaderText = "StockNo";
            this.colStockNo.Name = "colStockNo";
            this.colStockNo.ReadOnly = true;
            this.colStockNo.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.colStockNo.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // colInventory
            // 
            this.colInventory.HeaderText = "Inventory";
            this.colInventory.Name = "colInventory";
            this.colInventory.ReadOnly = true;
            // 
            // ProductManagement
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(32)))), ((int)(((byte)(30)))), ((int)(((byte)(45)))));
            this.ClientSize = new System.Drawing.Size(668, 522);
            this.Controls.Add(this.cbShowDiscontinued);
            this.Controls.Add(this.pbLoad);
            this.Controls.Add(this.btnSearchProduct);
            this.Controls.Add(this.btnAddProduct);
            this.Controls.Add(this.dgvProduct);
            this.Controls.Add(this.txtKeyword);
            this.Name = "ProductManagement";
            this.Text = "PRODUCT MANAGEMENT";
            this.Load += new System.EventHandler(this.ProductManagement_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.ProductManagement_KeyDown);
            ((System.ComponentModel.ISupportInitialize)(this.dgvProduct)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbLoad)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        public System.Windows.Forms.TextBox txtKeyword;
        private System.Windows.Forms.DataGridView dgvProduct;
        private FontAwesome.Sharp.IconButton btnAddProduct;
        private FontAwesome.Sharp.IconButton btnSearchProduct;
        private System.ComponentModel.BackgroundWorker bgwSearchProduct;
        private System.Windows.Forms.Timer keyDownTimer;
        private System.Windows.Forms.PictureBox pbLoad;
        private System.Windows.Forms.CheckBox cbShowDiscontinued;
        private System.Windows.Forms.DataGridViewTextBoxColumn colBarcode;
        private System.Windows.Forms.DataGridViewTextBoxColumn colProductName;
        private System.Windows.Forms.DataGridViewTextBoxColumn colPrice;
        private System.Windows.Forms.DataGridViewTextBoxColumn colStockNo;
        private System.Windows.Forms.DataGridViewTextBoxColumn colInventory;
    }
}