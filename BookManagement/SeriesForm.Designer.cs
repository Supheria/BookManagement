namespace BookManagement
{
    partial class SeriesForm
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
            this.lstvBooks = new System.Windows.Forms.ListView();
            this.SeriesIndex = new System.Windows.Forms.ColumnHeader();
            this.edition = new System.Windows.Forms.ColumnHeader();
            this.originalPrice = new System.Windows.Forms.ColumnHeader();
            this.BoughtDate = new System.Windows.Forms.ColumnHeader();
            this.OnBehalf = new System.Windows.Forms.ColumnHeader();
            this.freight = new System.Windows.Forms.ColumnHeader();
            this.soldPrice = new System.Windows.Forms.ColumnHeader();
            this.SoldDate = new System.Windows.Forms.ColumnHeader();
            this.totalCost = new System.Windows.Forms.ColumnHeader();
            this.btnAddRow = new System.Windows.Forms.Button();
            this.txtSeriesName = new System.Windows.Forms.TextBox();
            this.btnDelete = new System.Windows.Forms.Button();
            this.btnSell = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // lstvBooks
            // 
            this.lstvBooks.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.SeriesIndex,
            this.edition,
            this.originalPrice,
            this.BoughtDate,
            this.OnBehalf,
            this.freight,
            this.soldPrice,
            this.SoldDate,
            this.totalCost});
            this.lstvBooks.FullRowSelect = true;
            this.lstvBooks.GridLines = true;
            this.lstvBooks.Location = new System.Drawing.Point(12, 47);
            this.lstvBooks.MultiSelect = false;
            this.lstvBooks.Name = "lstvBooks";
            this.lstvBooks.Size = new System.Drawing.Size(571, 237);
            this.lstvBooks.TabIndex = 0;
            this.lstvBooks.UseCompatibleStateImageBehavior = false;
            this.lstvBooks.View = System.Windows.Forms.View.Details;
            this.lstvBooks.DoubleClick += new System.EventHandler(this.lstvBooks_DoubleClick);
            // 
            // SeriesIndex
            // 
            this.SeriesIndex.Text = "系列序号";
            // 
            // edition
            // 
            this.edition.Text = "版本";
            // 
            // originalPrice
            // 
            this.originalPrice.Text = "定价";
            // 
            // BoughtDate
            // 
            this.BoughtDate.Text = "购买日期";
            // 
            // OnBehalf
            // 
            this.OnBehalf.Text = "代购";
            // 
            // freight
            // 
            this.freight.Text = "邮费";
            // 
            // soldPrice
            // 
            this.soldPrice.DisplayIndex = 7;
            this.soldPrice.Text = "出售价格";
            // 
            // SoldDate
            // 
            this.SoldDate.DisplayIndex = 8;
            this.SoldDate.Text = "出售日期";
            // 
            // totalCost
            // 
            this.totalCost.DisplayIndex = 6;
            this.totalCost.Text = "总成本";
            // 
            // btnAddRow
            // 
            this.btnAddRow.Location = new System.Drawing.Point(387, 12);
            this.btnAddRow.Name = "btnAddRow";
            this.btnAddRow.Size = new System.Drawing.Size(60, 23);
            this.btnAddRow.TabIndex = 1;
            this.btnAddRow.Text = "新增";
            this.btnAddRow.UseVisualStyleBackColor = true;
            this.btnAddRow.Click += new System.EventHandler(this.btnAddRow_Click);
            // 
            // txtSeriesName
            // 
            this.txtSeriesName.Location = new System.Drawing.Point(12, 12);
            this.txtSeriesName.Name = "txtSeriesName";
            this.txtSeriesName.Size = new System.Drawing.Size(309, 23);
            this.txtSeriesName.TabIndex = 2;
            // 
            // btnDelete
            // 
            this.btnDelete.Location = new System.Drawing.Point(453, 12);
            this.btnDelete.Name = "btnDelete";
            this.btnDelete.Size = new System.Drawing.Size(60, 23);
            this.btnDelete.TabIndex = 3;
            this.btnDelete.Text = "删除";
            this.btnDelete.UseVisualStyleBackColor = true;
            this.btnDelete.Click += new System.EventHandler(this.btnDelete_Click);
            // 
            // btnSell
            // 
            this.btnSell.Location = new System.Drawing.Point(527, 11);
            this.btnSell.Name = "btnSell";
            this.btnSell.Size = new System.Drawing.Size(60, 23);
            this.btnSell.TabIndex = 4;
            this.btnSell.Text = "出售";
            this.btnSell.UseVisualStyleBackColor = true;
            // 
            // SeriesForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 17F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(595, 296);
            this.Controls.Add(this.btnSell);
            this.Controls.Add(this.btnDelete);
            this.Controls.Add(this.txtSeriesName);
            this.Controls.Add(this.btnAddRow);
            this.Controls.Add(this.lstvBooks);
            this.Name = "SeriesForm";
            this.Text = "SeriesForm";
            this.SizeChanged += new System.EventHandler(this.SeriesForm_SizeChanged);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private ListView lstvBooks;
        private ColumnHeader SeriesIndex;
        private ColumnHeader edition;
        private ColumnHeader originalPrice;
        private ColumnHeader BoughtDate;
        private ColumnHeader OnBehalf;
        private ColumnHeader soldPrice;
        private ColumnHeader SoldDate;
        private Button btnAddRow;
        private ColumnHeader freight;
        private ColumnHeader totalCost;
        private TextBox txtSeriesName;
        private Button btnDelete;
        private Button btnSell;
    }
}