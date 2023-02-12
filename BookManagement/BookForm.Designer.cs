namespace BookManagement
{
    partial class BookForm
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
            this.lbeSeriesIndex = new System.Windows.Forms.Label();
            this.txtSeriesIndex = new System.Windows.Forms.TextBox();
            this.lbeEdition = new System.Windows.Forms.Label();
            this.lbeOriginalPrice = new System.Windows.Forms.Label();
            this.txtOriginalPrice = new System.Windows.Forms.TextBox();
            this.lbeOnBehalf = new System.Windows.Forms.Label();
            this.cbbOnBehalf = new System.Windows.Forms.ComboBox();
            this.btnSave = new System.Windows.Forms.Button();
            this.lbeSoldPrice = new System.Windows.Forms.Label();
            this.txtSoldPrice = new System.Windows.Forms.TextBox();
            this.cbbEdition = new System.Windows.Forms.ComboBox();
            this.txtFreight = new System.Windows.Forms.TextBox();
            this.lbeFreight = new System.Windows.Forms.Label();
            this.lbeBoughtDate = new System.Windows.Forms.Label();
            this.dtpBoughtDate = new System.Windows.Forms.DateTimePicker();
            this.dtpSoldDate = new System.Windows.Forms.DateTimePicker();
            this.lbeSoldDate = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // lbeSeriesIndex
            // 
            this.lbeSeriesIndex.AutoSize = true;
            this.lbeSeriesIndex.Location = new System.Drawing.Point(28, 12);
            this.lbeSeriesIndex.Name = "lbeSeriesIndex";
            this.lbeSeriesIndex.Size = new System.Drawing.Size(32, 17);
            this.lbeSeriesIndex.TabIndex = 0;
            this.lbeSeriesIndex.Text = "序号";
            // 
            // txtSeriesIndex
            // 
            this.txtSeriesIndex.Location = new System.Drawing.Point(66, 12);
            this.txtSeriesIndex.Name = "txtSeriesIndex";
            this.txtSeriesIndex.Size = new System.Drawing.Size(110, 23);
            this.txtSeriesIndex.TabIndex = 1;
            this.txtSeriesIndex.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtSeriesIndex_KeyPress);
            // 
            // lbeEdition
            // 
            this.lbeEdition.AutoSize = true;
            this.lbeEdition.Location = new System.Drawing.Point(28, 41);
            this.lbeEdition.Name = "lbeEdition";
            this.lbeEdition.Size = new System.Drawing.Size(32, 17);
            this.lbeEdition.TabIndex = 2;
            this.lbeEdition.Text = "版本";
            // 
            // lbeOriginalPrice
            // 
            this.lbeOriginalPrice.AutoSize = true;
            this.lbeOriginalPrice.Location = new System.Drawing.Point(28, 103);
            this.lbeOriginalPrice.Name = "lbeOriginalPrice";
            this.lbeOriginalPrice.Size = new System.Drawing.Size(32, 17);
            this.lbeOriginalPrice.TabIndex = 4;
            this.lbeOriginalPrice.Text = "定价";
            // 
            // txtOriginalPrice
            // 
            this.txtOriginalPrice.Location = new System.Drawing.Point(66, 103);
            this.txtOriginalPrice.Name = "txtOriginalPrice";
            this.txtOriginalPrice.Size = new System.Drawing.Size(110, 23);
            this.txtOriginalPrice.TabIndex = 5;
            this.txtOriginalPrice.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtOriginalPrice_KeyPress);
            // 
            // lbeOnBehalf
            // 
            this.lbeOnBehalf.AutoSize = true;
            this.lbeOnBehalf.Location = new System.Drawing.Point(28, 72);
            this.lbeOnBehalf.Name = "lbeOnBehalf";
            this.lbeOnBehalf.Size = new System.Drawing.Size(32, 17);
            this.lbeOnBehalf.TabIndex = 6;
            this.lbeOnBehalf.Text = "代购";
            // 
            // cbbOnBehalf
            // 
            this.cbbOnBehalf.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbbOnBehalf.FormattingEnabled = true;
            this.cbbOnBehalf.Location = new System.Drawing.Point(66, 72);
            this.cbbOnBehalf.Name = "cbbOnBehalf";
            this.cbbOnBehalf.Size = new System.Drawing.Size(110, 25);
            this.cbbOnBehalf.TabIndex = 7;
            // 
            // btnSave
            // 
            this.btnSave.Location = new System.Drawing.Point(55, 261);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(75, 23);
            this.btnSave.TabIndex = 8;
            this.btnSave.Text = "保存";
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // lbeSoldPrice
            // 
            this.lbeSoldPrice.AutoSize = true;
            this.lbeSoldPrice.Location = new System.Drawing.Point(28, 190);
            this.lbeSoldPrice.Name = "lbeSoldPrice";
            this.lbeSoldPrice.Size = new System.Drawing.Size(32, 17);
            this.lbeSoldPrice.TabIndex = 9;
            this.lbeSoldPrice.Text = "售价";
            // 
            // txtSoldPrice
            // 
            this.txtSoldPrice.Location = new System.Drawing.Point(66, 190);
            this.txtSoldPrice.Name = "txtSoldPrice";
            this.txtSoldPrice.Size = new System.Drawing.Size(110, 23);
            this.txtSoldPrice.TabIndex = 10;
            this.txtSoldPrice.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtSoldPrice_KeyPress);
            // 
            // cbbEdition
            // 
            this.cbbEdition.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbbEdition.FormattingEnabled = true;
            this.cbbEdition.Location = new System.Drawing.Point(66, 41);
            this.cbbEdition.Name = "cbbEdition";
            this.cbbEdition.Size = new System.Drawing.Size(110, 25);
            this.cbbEdition.TabIndex = 11;
            // 
            // txtFreight
            // 
            this.txtFreight.Location = new System.Drawing.Point(66, 161);
            this.txtFreight.Name = "txtFreight";
            this.txtFreight.Size = new System.Drawing.Size(110, 23);
            this.txtFreight.TabIndex = 12;
            this.txtFreight.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtFreight_KeyPress);
            // 
            // lbeFreight
            // 
            this.lbeFreight.AutoSize = true;
            this.lbeFreight.Location = new System.Drawing.Point(28, 161);
            this.lbeFreight.Name = "lbeFreight";
            this.lbeFreight.Size = new System.Drawing.Size(32, 17);
            this.lbeFreight.TabIndex = 13;
            this.lbeFreight.Text = "运费";
            // 
            // lbeBoughtDate
            // 
            this.lbeBoughtDate.AutoSize = true;
            this.lbeBoughtDate.Location = new System.Drawing.Point(4, 132);
            this.lbeBoughtDate.Name = "lbeBoughtDate";
            this.lbeBoughtDate.Size = new System.Drawing.Size(56, 17);
            this.lbeBoughtDate.TabIndex = 14;
            this.lbeBoughtDate.Text = "购买日期";
            // 
            // dtpBoughtDate
            // 
            this.dtpBoughtDate.Location = new System.Drawing.Point(66, 132);
            this.dtpBoughtDate.Name = "dtpBoughtDate";
            this.dtpBoughtDate.Size = new System.Drawing.Size(110, 23);
            this.dtpBoughtDate.TabIndex = 16;
            // 
            // dtpSoldDate
            // 
            this.dtpSoldDate.Location = new System.Drawing.Point(66, 219);
            this.dtpSoldDate.Name = "dtpSoldDate";
            this.dtpSoldDate.Size = new System.Drawing.Size(110, 23);
            this.dtpSoldDate.TabIndex = 17;
            // 
            // lbeSoldDate
            // 
            this.lbeSoldDate.AutoSize = true;
            this.lbeSoldDate.Location = new System.Drawing.Point(4, 219);
            this.lbeSoldDate.Name = "lbeSoldDate";
            this.lbeSoldDate.Size = new System.Drawing.Size(56, 17);
            this.lbeSoldDate.TabIndex = 18;
            this.lbeSoldDate.Text = "售出日期";
            // 
            // BookForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 17F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(192, 296);
            this.Controls.Add(this.lbeSoldDate);
            this.Controls.Add(this.dtpSoldDate);
            this.Controls.Add(this.dtpBoughtDate);
            this.Controls.Add(this.lbeBoughtDate);
            this.Controls.Add(this.lbeFreight);
            this.Controls.Add(this.txtFreight);
            this.Controls.Add(this.cbbEdition);
            this.Controls.Add(this.txtSoldPrice);
            this.Controls.Add(this.lbeSoldPrice);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.cbbOnBehalf);
            this.Controls.Add(this.lbeOnBehalf);
            this.Controls.Add(this.txtOriginalPrice);
            this.Controls.Add(this.lbeOriginalPrice);
            this.Controls.Add(this.lbeEdition);
            this.Controls.Add(this.txtSeriesIndex);
            this.Controls.Add(this.lbeSeriesIndex);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "BookForm";
            this.Text = "BookForm";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        public Label lbeSeriesIndex;
        public TextBox txtSeriesIndex;
        public Label lbeEdition;
        public Label lbeOriginalPrice;
        public TextBox txtOriginalPrice;
        public Label lbeOnBehalf;
        public ComboBox cbbOnBehalf;
        public Button btnSave;
        public Label lbeSoldPrice;
        public TextBox txtSoldPrice;
        public ComboBox cbbEdition;
        public TextBox txtFreight;
        public Label lbeFreight;
        public Label lbeBoughtDate;
        public DateTimePicker dtpBoughtDate;
        public DateTimePicker dtpSoldDate;
        public Label lbeSoldDate;
    }
}