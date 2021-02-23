
namespace GetGoPOS.Views
{
    partial class PointOfSales
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(PointOfSales));
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            this.panel1 = new System.Windows.Forms.Panel();
            this.btnZRead = new FontAwesome.Sharp.IconButton();
            this.btnXRead = new FontAwesome.Sharp.IconButton();
            this.btnOpenDrawer = new FontAwesome.Sharp.IconButton();
            this.btnVoid = new FontAwesome.Sharp.IconButton();
            this.btnReprint = new FontAwesome.Sharp.IconButton();
            this.btnAdd = new FontAwesome.Sharp.IconButton();
            this.dgvProduct = new System.Windows.Forms.DataGridView();
            this.colBarcode = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colProductName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colPrice = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colStockNo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.pbLoad = new System.Windows.Forms.PictureBox();
            this.txtKeyword = new System.Windows.Forms.TextBox();
            this.panel2 = new System.Windows.Forms.Panel();
            this.panel6 = new System.Windows.Forms.Panel();
            this.lblTotalQty = new System.Windows.Forms.Label();
            this.lblTotalQtyD = new System.Windows.Forms.Label();
            this.btnChangeQty = new FontAwesome.Sharp.IconButton();
            this.dgvTransactionProduct = new System.Windows.Forms.DataGridView();
            this.colTransBarcode = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colTransProductName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colTransPrice = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colTransQty = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.btnRemove = new FontAwesome.Sharp.IconButton();
            this.btnPayment = new FontAwesome.Sharp.IconButton();
            this.btnClear = new FontAwesome.Sharp.IconButton();
            this.panel5 = new System.Windows.Forms.Panel();
            this.label6 = new System.Windows.Forms.Label();
            this.lblORNumber = new System.Windows.Forms.Label();
            this.panel4 = new System.Windows.Forms.Panel();
            this.panel3 = new System.Windows.Forms.Panel();
            this.label2 = new System.Windows.Forms.Label();
            this.lblAmoundDueD = new System.Windows.Forms.Label();
            this.lblQtyD = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.bgwSearchProduct = new System.ComponentModel.BackgroundWorker();
            this.keyDownTimer = new System.Windows.Forms.Timer(this.components);
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvProduct)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbLoad)).BeginInit();
            this.panel2.SuspendLayout();
            this.panel6.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvTransactionProduct)).BeginInit();
            this.panel5.SuspendLayout();
            this.panel3.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panel1.Controls.Add(this.btnZRead);
            this.panel1.Controls.Add(this.btnXRead);
            this.panel1.Controls.Add(this.btnOpenDrawer);
            this.panel1.Controls.Add(this.btnVoid);
            this.panel1.Controls.Add(this.btnReprint);
            this.panel1.Controls.Add(this.btnAdd);
            this.panel1.Controls.Add(this.dgvProduct);
            this.panel1.Controls.Add(this.pbLoad);
            this.panel1.Controls.Add(this.txtKeyword);
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(347, 522);
            this.panel1.TabIndex = 20;
            // 
            // btnZRead
            // 
            this.btnZRead.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnZRead.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(32)))), ((int)(((byte)(30)))), ((int)(((byte)(45)))));
            this.btnZRead.FlatAppearance.BorderSize = 0;
            this.btnZRead.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnZRead.IconChar = FontAwesome.Sharp.IconChar.StoreAltSlash;
            this.btnZRead.IconColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(190)))), ((int)(((byte)(0)))));
            this.btnZRead.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.btnZRead.IconSize = 30;
            this.btnZRead.Location = new System.Drawing.Point(228, 471);
            this.btnZRead.Name = "btnZRead";
            this.btnZRead.Size = new System.Drawing.Size(48, 39);
            this.btnZRead.TabIndex = 111;
            this.btnZRead.UseVisualStyleBackColor = false;
            this.btnZRead.Click += new System.EventHandler(this.btnZRead_Click);
            // 
            // btnXRead
            // 
            this.btnXRead.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnXRead.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(32)))), ((int)(((byte)(30)))), ((int)(((byte)(45)))));
            this.btnXRead.FlatAppearance.BorderSize = 0;
            this.btnXRead.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnXRead.IconChar = FontAwesome.Sharp.IconChar.TimesCircle;
            this.btnXRead.IconColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(190)))), ((int)(((byte)(0)))));
            this.btnXRead.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.btnXRead.IconSize = 30;
            this.btnXRead.Location = new System.Drawing.Point(174, 471);
            this.btnXRead.Name = "btnXRead";
            this.btnXRead.Size = new System.Drawing.Size(48, 39);
            this.btnXRead.TabIndex = 110;
            this.btnXRead.UseVisualStyleBackColor = false;
            this.btnXRead.Click += new System.EventHandler(this.btnXRead_Click);
            // 
            // btnOpenDrawer
            // 
            this.btnOpenDrawer.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnOpenDrawer.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(32)))), ((int)(((byte)(30)))), ((int)(((byte)(45)))));
            this.btnOpenDrawer.FlatAppearance.BorderSize = 0;
            this.btnOpenDrawer.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnOpenDrawer.IconChar = FontAwesome.Sharp.IconChar.Codepen;
            this.btnOpenDrawer.IconColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(190)))), ((int)(((byte)(0)))));
            this.btnOpenDrawer.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.btnOpenDrawer.IconSize = 30;
            this.btnOpenDrawer.Location = new System.Drawing.Point(120, 471);
            this.btnOpenDrawer.Name = "btnOpenDrawer";
            this.btnOpenDrawer.Size = new System.Drawing.Size(48, 39);
            this.btnOpenDrawer.TabIndex = 109;
            this.btnOpenDrawer.UseVisualStyleBackColor = false;
            this.btnOpenDrawer.Click += new System.EventHandler(this.btnOpenDrawer_Click);
            // 
            // btnVoid
            // 
            this.btnVoid.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnVoid.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(32)))), ((int)(((byte)(30)))), ((int)(((byte)(45)))));
            this.btnVoid.FlatAppearance.BorderSize = 0;
            this.btnVoid.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnVoid.IconChar = FontAwesome.Sharp.IconChar.TrashAlt;
            this.btnVoid.IconColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(190)))), ((int)(((byte)(0)))));
            this.btnVoid.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.btnVoid.IconSize = 30;
            this.btnVoid.Location = new System.Drawing.Point(66, 471);
            this.btnVoid.Name = "btnVoid";
            this.btnVoid.Size = new System.Drawing.Size(48, 39);
            this.btnVoid.TabIndex = 108;
            this.btnVoid.UseVisualStyleBackColor = false;
            this.btnVoid.Click += new System.EventHandler(this.btnVoid_Click);
            // 
            // btnReprint
            // 
            this.btnReprint.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnReprint.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(32)))), ((int)(((byte)(30)))), ((int)(((byte)(45)))));
            this.btnReprint.FlatAppearance.BorderSize = 0;
            this.btnReprint.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnReprint.IconChar = FontAwesome.Sharp.IconChar.Print;
            this.btnReprint.IconColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(190)))), ((int)(((byte)(0)))));
            this.btnReprint.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.btnReprint.IconSize = 30;
            this.btnReprint.Location = new System.Drawing.Point(12, 471);
            this.btnReprint.Name = "btnReprint";
            this.btnReprint.Size = new System.Drawing.Size(48, 39);
            this.btnReprint.TabIndex = 107;
            this.btnReprint.UseVisualStyleBackColor = false;
            this.btnReprint.Click += new System.EventHandler(this.btnReprint_Click);
            // 
            // btnAdd
            // 
            this.btnAdd.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnAdd.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(32)))), ((int)(((byte)(30)))), ((int)(((byte)(45)))));
            this.btnAdd.FlatAppearance.BorderSize = 0;
            this.btnAdd.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnAdd.IconChar = FontAwesome.Sharp.IconChar.Plus;
            this.btnAdd.IconColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(190)))), ((int)(((byte)(0)))));
            this.btnAdd.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.btnAdd.IconSize = 30;
            this.btnAdd.Location = new System.Drawing.Point(287, 383);
            this.btnAdd.Name = "btnAdd";
            this.btnAdd.Size = new System.Drawing.Size(48, 39);
            this.btnAdd.TabIndex = 106;
            this.btnAdd.UseVisualStyleBackColor = false;
            this.btnAdd.Click += new System.EventHandler(this.btnAdd_Click);
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
            this.colStockNo});
            this.dgvProduct.GridColor = System.Drawing.Color.Gainsboro;
            this.dgvProduct.Location = new System.Drawing.Point(12, 114);
            this.dgvProduct.Name = "dgvProduct";
            this.dgvProduct.ReadOnly = true;
            this.dgvProduct.RowHeadersVisible = false;
            this.dgvProduct.Size = new System.Drawing.Size(323, 255);
            this.dgvProduct.TabIndex = 105;
            this.dgvProduct.CellContentDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvProduct_CellContentDoubleClick);
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
            // pbLoad
            // 
            this.pbLoad.BackColor = System.Drawing.Color.Transparent;
            this.pbLoad.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.pbLoad.Image = ((System.Drawing.Image)(resources.GetObject("pbLoad.Image")));
            this.pbLoad.Location = new System.Drawing.Point(306, 71);
            this.pbLoad.Name = "pbLoad";
            this.pbLoad.Size = new System.Drawing.Size(29, 29);
            this.pbLoad.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pbLoad.TabIndex = 104;
            this.pbLoad.TabStop = false;
            this.pbLoad.Visible = false;
            // 
            // txtKeyword
            // 
            this.txtKeyword.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtKeyword.Font = new System.Drawing.Font("Arial", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtKeyword.Location = new System.Drawing.Point(12, 65);
            this.txtKeyword.MaxLength = 10;
            this.txtKeyword.Name = "txtKeyword";
            this.txtKeyword.Size = new System.Drawing.Size(284, 39);
            this.txtKeyword.TabIndex = 14;
            this.txtKeyword.Tag = "num";
            this.txtKeyword.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.txtKeyword.TextChanged += new System.EventHandler(this.txtKeyword_TextChanged);
            this.txtKeyword.Leave += new System.EventHandler(this.txtKeyword_Leave);
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.panel6);
            this.panel2.Controls.Add(this.btnChangeQty);
            this.panel2.Controls.Add(this.dgvTransactionProduct);
            this.panel2.Controls.Add(this.btnRemove);
            this.panel2.Controls.Add(this.btnPayment);
            this.panel2.Controls.Add(this.btnClear);
            this.panel2.Controls.Add(this.panel5);
            this.panel2.Controls.Add(this.panel4);
            this.panel2.Controls.Add(this.panel3);
            this.panel2.Controls.Add(this.lblQtyD);
            this.panel2.Controls.Add(this.label3);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Right;
            this.panel2.Location = new System.Drawing.Point(353, 0);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(315, 522);
            this.panel2.TabIndex = 21;
            // 
            // panel6
            // 
            this.panel6.Controls.Add(this.lblTotalQty);
            this.panel6.Controls.Add(this.lblTotalQtyD);
            this.panel6.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel6.Location = new System.Drawing.Point(0, 422);
            this.panel6.Name = "panel6";
            this.panel6.Size = new System.Drawing.Size(315, 50);
            this.panel6.TabIndex = 108;
            // 
            // lblTotalQty
            // 
            this.lblTotalQty.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lblTotalQty.AutoSize = true;
            this.lblTotalQty.Font = new System.Drawing.Font("Arial", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTotalQty.ForeColor = System.Drawing.Color.Gainsboro;
            this.lblTotalQty.Location = new System.Drawing.Point(49, 6);
            this.lblTotalQty.Name = "lblTotalQty";
            this.lblTotalQty.Size = new System.Drawing.Size(131, 32);
            this.lblTotalQty.TabIndex = 18;
            this.lblTotalQty.Text = "Total Qty:";
            // 
            // lblTotalQtyD
            // 
            this.lblTotalQtyD.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lblTotalQtyD.AutoSize = true;
            this.lblTotalQtyD.Font = new System.Drawing.Font("Arial", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTotalQtyD.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(190)))), ((int)(((byte)(0)))));
            this.lblTotalQtyD.Location = new System.Drawing.Point(186, 6);
            this.lblTotalQtyD.Name = "lblTotalQtyD";
            this.lblTotalQtyD.Size = new System.Drawing.Size(30, 32);
            this.lblTotalQtyD.TabIndex = 19;
            this.lblTotalQtyD.Text = "0";
            this.lblTotalQtyD.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // btnChangeQty
            // 
            this.btnChangeQty.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnChangeQty.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(32)))), ((int)(((byte)(30)))), ((int)(((byte)(45)))));
            this.btnChangeQty.FlatAppearance.BorderSize = 0;
            this.btnChangeQty.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnChangeQty.IconChar = FontAwesome.Sharp.IconChar.ExchangeAlt;
            this.btnChangeQty.IconColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(190)))), ((int)(((byte)(0)))));
            this.btnChangeQty.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.btnChangeQty.IconSize = 30;
            this.btnChangeQty.Location = new System.Drawing.Point(248, 127);
            this.btnChangeQty.Name = "btnChangeQty";
            this.btnChangeQty.Size = new System.Drawing.Size(48, 39);
            this.btnChangeQty.TabIndex = 107;
            this.btnChangeQty.UseVisualStyleBackColor = false;
            this.btnChangeQty.Click += new System.EventHandler(this.btnChangeQty_Click);
            // 
            // dgvTransactionProduct
            // 
            this.dgvTransactionProduct.AllowUserToAddRows = false;
            this.dgvTransactionProduct.AllowUserToDeleteRows = false;
            this.dgvTransactionProduct.AllowUserToResizeColumns = false;
            this.dgvTransactionProduct.AllowUserToResizeRows = false;
            this.dgvTransactionProduct.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgvTransactionProduct.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvTransactionProduct.BackgroundColor = System.Drawing.Color.Gainsboro;
            this.dgvTransactionProduct.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvTransactionProduct.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle2;
            this.dgvTransactionProduct.ColumnHeadersHeight = 30;
            this.dgvTransactionProduct.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            this.dgvTransactionProduct.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.colTransBarcode,
            this.colTransProductName,
            this.colTransPrice,
            this.colTransQty});
            this.dgvTransactionProduct.GridColor = System.Drawing.Color.Gainsboro;
            this.dgvTransactionProduct.Location = new System.Drawing.Point(3, 172);
            this.dgvTransactionProduct.Name = "dgvTransactionProduct";
            this.dgvTransactionProduct.ReadOnly = true;
            this.dgvTransactionProduct.RowHeadersVisible = false;
            this.dgvTransactionProduct.Size = new System.Drawing.Size(303, 196);
            this.dgvTransactionProduct.TabIndex = 106;
            this.dgvTransactionProduct.SelectionChanged += new System.EventHandler(this.dgvTransactionProduct_SelectionChanged);
            // 
            // colTransBarcode
            // 
            this.colTransBarcode.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.colTransBarcode.FillWeight = 70.77962F;
            this.colTransBarcode.HeaderText = "Barcode";
            this.colTransBarcode.MinimumWidth = 80;
            this.colTransBarcode.Name = "colTransBarcode";
            this.colTransBarcode.ReadOnly = true;
            this.colTransBarcode.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // colTransProductName
            // 
            this.colTransProductName.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.colTransProductName.FillWeight = 43.46766F;
            this.colTransProductName.HeaderText = "Name";
            this.colTransProductName.MinimumWidth = 40;
            this.colTransProductName.Name = "colTransProductName";
            this.colTransProductName.ReadOnly = true;
            this.colTransProductName.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.colTransProductName.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // colTransPrice
            // 
            this.colTransPrice.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.colTransPrice.FillWeight = 42.48488F;
            this.colTransPrice.HeaderText = "Price";
            this.colTransPrice.MinimumWidth = 60;
            this.colTransPrice.Name = "colTransPrice";
            this.colTransPrice.ReadOnly = true;
            this.colTransPrice.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.colTransPrice.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // colTransQty
            // 
            this.colTransQty.HeaderText = "Qty";
            this.colTransQty.Name = "colTransQty";
            this.colTransQty.ReadOnly = true;
            this.colTransQty.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.colTransQty.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // btnRemove
            // 
            this.btnRemove.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnRemove.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(32)))), ((int)(((byte)(30)))), ((int)(((byte)(45)))));
            this.btnRemove.FlatAppearance.BorderSize = 0;
            this.btnRemove.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnRemove.IconChar = FontAwesome.Sharp.IconChar.Minus;
            this.btnRemove.IconColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(190)))), ((int)(((byte)(0)))));
            this.btnRemove.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.btnRemove.IconSize = 30;
            this.btnRemove.Location = new System.Drawing.Point(144, 377);
            this.btnRemove.Name = "btnRemove";
            this.btnRemove.Size = new System.Drawing.Size(51, 39);
            this.btnRemove.TabIndex = 25;
            this.btnRemove.UseVisualStyleBackColor = false;
            this.btnRemove.Click += new System.EventHandler(this.btnRemove_Click);
            // 
            // btnPayment
            // 
            this.btnPayment.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnPayment.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(32)))), ((int)(((byte)(30)))), ((int)(((byte)(45)))));
            this.btnPayment.FlatAppearance.BorderSize = 0;
            this.btnPayment.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnPayment.IconChar = FontAwesome.Sharp.IconChar.ShoppingCart;
            this.btnPayment.IconColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(190)))), ((int)(((byte)(0)))));
            this.btnPayment.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.btnPayment.IconSize = 30;
            this.btnPayment.Location = new System.Drawing.Point(248, 377);
            this.btnPayment.Name = "btnPayment";
            this.btnPayment.Size = new System.Drawing.Size(48, 39);
            this.btnPayment.TabIndex = 24;
            this.btnPayment.UseVisualStyleBackColor = false;
            this.btnPayment.Click += new System.EventHandler(this.btnPayment_Click);
            this.btnPayment.MouseHover += new System.EventHandler(this.btnPayment_MouseHover);
            // 
            // btnClear
            // 
            this.btnClear.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnClear.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(32)))), ((int)(((byte)(30)))), ((int)(((byte)(45)))));
            this.btnClear.FlatAppearance.BorderSize = 0;
            this.btnClear.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnClear.IconChar = FontAwesome.Sharp.IconChar.Broom;
            this.btnClear.IconColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(190)))), ((int)(((byte)(0)))));
            this.btnClear.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.btnClear.IconSize = 30;
            this.btnClear.Location = new System.Drawing.Point(199, 377);
            this.btnClear.Name = "btnClear";
            this.btnClear.Size = new System.Drawing.Size(48, 39);
            this.btnClear.TabIndex = 23;
            this.btnClear.UseVisualStyleBackColor = false;
            this.btnClear.Click += new System.EventHandler(this.btnClear_Click);
            // 
            // panel5
            // 
            this.panel5.Controls.Add(this.label6);
            this.panel5.Controls.Add(this.lblORNumber);
            this.panel5.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel5.Location = new System.Drawing.Point(0, 63);
            this.panel5.Name = "panel5";
            this.panel5.Size = new System.Drawing.Size(315, 50);
            this.panel5.TabIndex = 22;
            // 
            // label6
            // 
            this.label6.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Arial", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.ForeColor = System.Drawing.Color.Gainsboro;
            this.label6.Location = new System.Drawing.Point(5, 9);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(185, 32);
            this.label6.TabIndex = 18;
            this.label6.Text = "Sales Invoice:";
            // 
            // lblORNumber
            // 
            this.lblORNumber.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lblORNumber.AutoSize = true;
            this.lblORNumber.Font = new System.Drawing.Font("Arial", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblORNumber.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(190)))), ((int)(((byte)(0)))));
            this.lblORNumber.Location = new System.Drawing.Point(186, 9);
            this.lblORNumber.Name = "lblORNumber";
            this.lblORNumber.Size = new System.Drawing.Size(90, 32);
            this.lblORNumber.TabIndex = 19;
            this.lblORNumber.Text = "00000";
            this.lblORNumber.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // panel4
            // 
            this.panel4.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel4.Location = new System.Drawing.Point(0, 0);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(315, 63);
            this.panel4.TabIndex = 21;
            // 
            // panel3
            // 
            this.panel3.Controls.Add(this.label2);
            this.panel3.Controls.Add(this.lblAmoundDueD);
            this.panel3.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel3.Location = new System.Drawing.Point(0, 472);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(315, 50);
            this.panel3.TabIndex = 20;
            // 
            // label2
            // 
            this.label2.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Arial", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.Gainsboro;
            this.label2.Location = new System.Drawing.Point(16, 6);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(174, 32);
            this.label2.TabIndex = 18;
            this.label2.Text = "Amount Due:";
            // 
            // lblAmoundDueD
            // 
            this.lblAmoundDueD.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lblAmoundDueD.AutoSize = true;
            this.lblAmoundDueD.Font = new System.Drawing.Font("Arial", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblAmoundDueD.ForeColor = System.Drawing.Color.Red;
            this.lblAmoundDueD.Location = new System.Drawing.Point(186, 6);
            this.lblAmoundDueD.Name = "lblAmoundDueD";
            this.lblAmoundDueD.Size = new System.Drawing.Size(68, 32);
            this.lblAmoundDueD.TabIndex = 19;
            this.lblAmoundDueD.Text = "0.00";
            this.lblAmoundDueD.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // lblQtyD
            // 
            this.lblQtyD.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lblQtyD.Font = new System.Drawing.Font("Arial", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblQtyD.Location = new System.Drawing.Point(180, 129);
            this.lblQtyD.MaxLength = 10;
            this.lblQtyD.Name = "lblQtyD";
            this.lblQtyD.Size = new System.Drawing.Size(64, 39);
            this.lblQtyD.TabIndex = 15;
            this.lblQtyD.Tag = "num";
            this.lblQtyD.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // label3
            // 
            this.label3.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Arial", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.Color.Gainsboro;
            this.label3.Location = new System.Drawing.Point(49, 129);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(125, 32);
            this.label3.TabIndex = 17;
            this.label3.Text = "Quantity:";
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
            // PointOfSales
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(32)))), ((int)(((byte)(30)))), ((int)(((byte)(45)))));
            this.ClientSize = new System.Drawing.Size(668, 522);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.Name = "PointOfSales";
            this.Text = "POINT OF SALES";
            this.Load += new System.EventHandler(this.PointOfSales_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvProduct)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbLoad)).EndInit();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.panel6.ResumeLayout(false);
            this.panel6.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvTransactionProduct)).EndInit();
            this.panel5.ResumeLayout(false);
            this.panel5.PerformLayout();
            this.panel3.ResumeLayout(false);
            this.panel3.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Label lblAmoundDueD;
        public System.Windows.Forms.TextBox txtKeyword;
        private System.Windows.Forms.Label label2;
        public System.Windows.Forms.TextBox lblQtyD;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Panel panel5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label lblORNumber;
        private System.Windows.Forms.Panel panel4;
        private FontAwesome.Sharp.IconButton btnRemove;
        private FontAwesome.Sharp.IconButton btnPayment;
        private FontAwesome.Sharp.IconButton btnClear;
        private System.Windows.Forms.PictureBox pbLoad;
        private System.ComponentModel.BackgroundWorker bgwSearchProduct;
        private System.Windows.Forms.Timer keyDownTimer;
        private System.Windows.Forms.DataGridView dgvProduct;
        private System.Windows.Forms.DataGridViewTextBoxColumn colBarcode;
        private System.Windows.Forms.DataGridViewTextBoxColumn colProductName;
        private System.Windows.Forms.DataGridViewTextBoxColumn colPrice;
        private System.Windows.Forms.DataGridViewTextBoxColumn colStockNo;
        private System.Windows.Forms.DataGridView dgvTransactionProduct;
        private System.Windows.Forms.DataGridViewTextBoxColumn colTransBarcode;
        private System.Windows.Forms.DataGridViewTextBoxColumn colTransProductName;
        private System.Windows.Forms.DataGridViewTextBoxColumn colTransPrice;
        private System.Windows.Forms.DataGridViewTextBoxColumn colTransQty;
        private FontAwesome.Sharp.IconButton btnChangeQty;
        private FontAwesome.Sharp.IconButton btnAdd;
        private FontAwesome.Sharp.IconButton btnOpenDrawer;
        private FontAwesome.Sharp.IconButton btnVoid;
        private FontAwesome.Sharp.IconButton btnReprint;
        private System.Windows.Forms.Panel panel6;
        private System.Windows.Forms.Label lblTotalQty;
        private System.Windows.Forms.Label lblTotalQtyD;
        private FontAwesome.Sharp.IconButton btnZRead;
        private FontAwesome.Sharp.IconButton btnXRead;
    }
}