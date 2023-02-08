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
            this.indexInSeries = new System.Windows.Forms.ColumnHeader();
            this.edition = new System.Windows.Forms.ColumnHeader();
            this.originalPrice = new System.Windows.Forms.ColumnHeader();
            this.BoughtDate = new System.Windows.Forms.ColumnHeader();
            this.OnBehalf = new System.Windows.Forms.ColumnHeader();
            this.freight = new System.Windows.Forms.ColumnHeader();
            this.totalCost = new System.Windows.Forms.ColumnHeader();
            this.soldPrice = new System.Windows.Forms.ColumnHeader();
            this.SoldDate = new System.Windows.Forms.ColumnHeader();
            this.btnAddRow = new System.Windows.Forms.Button();
            this.txtSeriesName = new System.Windows.Forms.TextBox();
            this.btnDelete = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // lstvBooks
            // 
            this.lstvBooks.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.indexInSeries,
            this.edition,
            this.originalPrice,
            this.BoughtDate,
            this.OnBehalf,
            this.freight,
            this.totalCost,
            this.soldPrice,
            this.SoldDate});
            this.lstvBooks.FullRowSelect = true;
            this.lstvBooks.GridLines = true;
            this.lstvBooks.Location = new System.Drawing.Point(12, 54);
            this.lstvBooks.MultiSelect = false;
            this.lstvBooks.Name = "lstvBooks";
            this.lstvBooks.Size = new System.Drawing.Size(596, 249);
            this.lstvBooks.TabIndex = 0;
            this.lstvBooks.UseCompatibleStateImageBehavior = false;
            this.lstvBooks.View = System.Windows.Forms.View.Details;
            // 
            // indexInSeries
            // 
            this.indexInSeries.Text = "序号";
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
            // totalCost
            // 
            this.totalCost.Text = "总成本";
            // 
            // soldPrice
            // 
            this.soldPrice.Text = "出售价格";
            // 
            // SoldDate
            // 
            this.SoldDate.Text = "出售日期";
            // 
            // btnAddRow
            // 
            this.btnAddRow.Location = new System.Drawing.Point(432, 12);
            this.btnAddRow.Name = "btnAddRow";
            this.btnAddRow.Size = new System.Drawing.Size(75, 23);
            this.btnAddRow.TabIndex = 1;
            this.btnAddRow.Text = "新增";
            this.btnAddRow.UseVisualStyleBackColor = true;
            // 
            // txtSeriesName
            // 
            this.txtSeriesName.Location = new System.Drawing.Point(12, 12);
            this.txtSeriesName.Name = "txtSeriesName";
            this.txtSeriesName.Size = new System.Drawing.Size(329, 23);
            this.txtSeriesName.TabIndex = 2;
            // 
            // btnDelete
            // 
            this.btnDelete.Location = new System.Drawing.Point(513, 12);
            this.btnDelete.Name = "btnDelete";
            this.btnDelete.Size = new System.Drawing.Size(75, 23);
            this.btnDelete.TabIndex = 3;
            this.btnDelete.Text = "删除";
            this.btnDelete.UseVisualStyleBackColor = true;
            // 
            // SeriesForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 17F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(620, 315);
            this.Controls.Add(this.btnDelete);
            this.Controls.Add(this.txtSeriesName);
            this.Controls.Add(this.btnAddRow);
            this.Controls.Add(this.lstvBooks);
            this.Name = "SeriesForm";
            this.Text = "SeriesForm";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private ListView lstvBooks;
        private ColumnHeader indexInSeries;
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
    }
}