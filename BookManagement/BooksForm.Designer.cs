namespace BookManagement
{
    partial class BooksForm
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
            this.lstvSeriesList = new System.Windows.Forms.ListView();
            this.index = new System.Windows.Forms.ColumnHeader();
            this.seriesName = new System.Windows.Forms.ColumnHeader();
            this.editionNumber = new System.Windows.Forms.ColumnHeader();
            this.SuspendLayout();
            // 
            // lstvSeriesList
            // 
            this.lstvSeriesList.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.index,
            this.seriesName,
            this.editionNumber});
            this.lstvSeriesList.GridLines = true;
            this.lstvSeriesList.Location = new System.Drawing.Point(0, 0);
            this.lstvSeriesList.Name = "lstvSeriesList";
            this.lstvSeriesList.Size = new System.Drawing.Size(546, 217);
            this.lstvSeriesList.TabIndex = 0;
            this.lstvSeriesList.UseCompatibleStateImageBehavior = false;
            this.lstvSeriesList.View = System.Windows.Forms.View.Details;
            // 
            // index
            // 
            this.index.Text = "序号";
            // 
            // seriesName
            // 
            this.seriesName.Text = "系列名";
            // 
            // editionNumber
            // 
            this.editionNumber.Text = "版本数量";
            // 
            // BooksForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 17F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.lstvSeriesList);
            this.Name = "BooksForm";
            this.Text = "BooksForm";
            this.ResumeLayout(false);

        }

        #endregion

        private ListView lstvSeriesList;
        private ColumnHeader index;
        private ColumnHeader seriesName;
        private ColumnHeader editionNumber;
    }
}