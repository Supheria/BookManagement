namespace BookManagement
{
    partial class StorageForm
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
            this.lstvSeries = new System.Windows.Forms.ListView();
            this.seriesName = new System.Windows.Forms.ColumnHeader();
            this.editionNumber = new System.Windows.Forms.ColumnHeader();
            this.btnLoad = new System.Windows.Forms.Button();
            this.btnSave = new System.Windows.Forms.Button();
            this.btnAddRow = new System.Windows.Forms.Button();
            this.btnDeleteRaw = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // lstvSeries
            // 
            this.lstvSeries.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.seriesName,
            this.editionNumber});
            this.lstvSeries.FullRowSelect = true;
            this.lstvSeries.GridLines = true;
            this.lstvSeries.Location = new System.Drawing.Point(12, 51);
            this.lstvSeries.MultiSelect = false;
            this.lstvSeries.Name = "lstvSeries";
            this.lstvSeries.Size = new System.Drawing.Size(320, 249);
            this.lstvSeries.TabIndex = 0;
            this.lstvSeries.UseCompatibleStateImageBehavior = false;
            this.lstvSeries.View = System.Windows.Forms.View.Details;
            this.lstvSeries.DoubleClick += new System.EventHandler(this.lstvSeries_DoubleClick);
            // 
            // seriesName
            // 
            this.seriesName.Text = "套装名称";
            // 
            // editionNumber
            // 
            this.editionNumber.Text = "版本数量";
            this.editionNumber.Width = 256;
            // 
            // btnLoad
            // 
            this.btnLoad.Location = new System.Drawing.Point(12, 12);
            this.btnLoad.Name = "btnLoad";
            this.btnLoad.Size = new System.Drawing.Size(75, 23);
            this.btnLoad.TabIndex = 1;
            this.btnLoad.Text = "加载文件...";
            this.btnLoad.UseVisualStyleBackColor = true;
            this.btnLoad.Click += new System.EventHandler(this.btnLoad_Click);
            // 
            // btnSave
            // 
            this.btnSave.Location = new System.Drawing.Point(93, 12);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(75, 23);
            this.btnSave.TabIndex = 2;
            this.btnSave.Text = "另存为...";
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // btnAddRow
            // 
            this.btnAddRow.Location = new System.Drawing.Point(211, 12);
            this.btnAddRow.Name = "btnAddRow";
            this.btnAddRow.Size = new System.Drawing.Size(49, 23);
            this.btnAddRow.TabIndex = 3;
            this.btnAddRow.Text = "新增";
            this.btnAddRow.UseVisualStyleBackColor = true;
            this.btnAddRow.Click += new System.EventHandler(this.btnAddRow_Click);
            // 
            // btnDeleteRaw
            // 
            this.btnDeleteRaw.Location = new System.Drawing.Point(266, 12);
            this.btnDeleteRaw.Name = "btnDeleteRaw";
            this.btnDeleteRaw.Size = new System.Drawing.Size(49, 23);
            this.btnDeleteRaw.TabIndex = 4;
            this.btnDeleteRaw.Text = "删除";
            this.btnDeleteRaw.UseVisualStyleBackColor = true;
            // 
            // StorageForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 17F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(344, 312);
            this.Controls.Add(this.btnDeleteRaw);
            this.Controls.Add(this.btnAddRow);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.btnLoad);
            this.Controls.Add(this.lstvSeries);
            this.Name = "StorageForm";
            this.Text = "BooksForm";
            this.ResumeLayout(false);

        }

        #endregion

        private ListView lstvSeries;
        private ColumnHeader seriesName;
        private ColumnHeader editionNumber;
        private Button btnLoad;
        private Button btnSave;
        private Button btnAddRow;
        private Button btnDeleteRaw;
    }
}