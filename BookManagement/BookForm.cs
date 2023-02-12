using System.Xml.Serialization;

namespace BookManagement
{
    public partial class BookForm : Form
    {
        SeriesForm mSeriesForm;
        ListViewItem mItem;
        public BookForm(SeriesForm seriesForm, ListViewItem item)
        {
            InitializeComponent();
            foreach (var keyIndex in EditionKeyIndex)
            {
                cbbEdition.Items.Add(keyIndex.Value);
            }
            foreach (var keyIndex in OnBehalfKeyIndex)
            {
                cbbOnBehalf.Items.Add(keyIndex.Value);
            }
            mSeriesForm = seriesForm;
            if (item.Index == -1)
            {
                this.Text = "新增...";
                mItem = new ListViewItem();
                txtSoldPrice.Visible = false; lbeSoldPrice.Visible = false;
                dtpSoldDate.Visible = false; lbeSoldDate.Visible = false;
                btnSave.Location = new Point(btnSave.Location.X, btnSave.Location.Y - (dtpSoldDate.Bottom - txtFreight.Bottom));
                this.Height = this.Height - (dtpSoldDate.Bottom - txtFreight.Bottom);
            }
            else
            {
                this.Text = $"{(seriesForm.Text == string.Empty ? "?" : seriesForm.Text)} - 第 {item.Text} 册";
                mItem = item;
                LoadItem();
            }
        }

        public void LoadItem()
        {
            var subItems = mItem.SubItems;
            #region ==== item读入控件 ====
            txtSeriesIndex.Text = subItems[0].Text;
            cbbEdition.SelectedIndex = EditionKeyName[subItems[1].Text];
            cbbOnBehalf.SelectedIndex = OnBehalfKeyName[subItems[2].Text];
            txtOriginalPrice.Text = subItems[3].Text;
            dtpBoughtDate.Value = DateTime.Parse(subItems[4].Text);
            txtFreight.Text = subItems[5].Text;
            txtSoldPrice.Text = subItems[6].Text;
            dtpSoldDate.Value = subItems[7].Text == string.Empty ? dtpSoldDate.Value : DateTime.Parse(subItems[7].Text);
            #endregion
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (mItem.Index != -1)
            {
                #region ==== 修改item ====
                mItem.SubItems[0].Text = txtSeriesIndex.Text == string.Empty ? "1" : txtSeriesIndex.Text;
                mItem.SubItems[1].Text = (cbbEdition.SelectedIndex == -1 ? throw new Exception("没有选择版本！") : EditionKeyIndex[cbbEdition.SelectedIndex]);
                mItem.SubItems[2].Text = (cbbOnBehalf.SelectedIndex == -1 ? throw new Exception("没有选择代购！") : OnBehalfKeyIndex[cbbOnBehalf.SelectedIndex]);
                mItem.SubItems[3].Text = (txtOriginalPrice.Text == string.Empty ? throw new Exception("定价不能为空！") : txtOriginalPrice.Text);
                mItem.SubItems[4].Text = (dtpBoughtDate.Value.ToShortDateString());
                mItem.SubItems[5].Text = (txtFreight.Text == string.Empty ? "1" : txtFreight.Text);
                mItem.SubItems[6].Text = (txtSoldPrice.Text);
                mItem.SubItems[7].Text = (txtSoldPrice.Text == string.Empty ? string.Empty : dtpSoldDate.Value.ToShortDateString());
                mItem.SubItems[8].Text = SumTotalCost();
                #endregion
                mSeriesForm.UpdateListView();
                this.Close();
                return;
            }
            try
            {
                #region ==== 新item ====
                mItem.Text = txtSeriesIndex.Text == string.Empty ? "0" : txtSeriesIndex.Text;
                mItem.SubItems.Add(cbbEdition.SelectedIndex == -1 ? throw new Exception("没有选择版本！") : EditionKeyIndex[cbbEdition.SelectedIndex]);
                mItem.SubItems.Add(cbbOnBehalf.SelectedIndex == -1 ? throw new Exception("没有选择代购！") : OnBehalfKeyIndex[cbbOnBehalf.SelectedIndex]);
                mItem.SubItems.Add(txtOriginalPrice.Text == string.Empty ? throw new Exception("定价不能为空！") : txtOriginalPrice.Text);
                mItem.SubItems.Add(dtpBoughtDate.Value.ToShortDateString());
                mItem.SubItems.Add(txtFreight.Text == string.Empty ? "1" : txtFreight.Text);
                mItem.SubItems.Add(string.Empty);
                mItem.SubItems.Add(string.Empty);
                mItem.SubItems.Add(SumTotalCost());
                #endregion
            }
            catch (Exception ex)
            {
                mItem = new ListViewItem();
                MessageBox.Show(ex.Message);
                return;
            }
            mSeriesForm.AddItem(mItem);
            mItem = new ListViewItem();
        }

        public string SumTotalCost()
        {
            int originalPrice = int.Parse(mItem.SubItems[3].Text);
            int index = OnBehalfKeyName[mItem.SubItems[2].Text];
            if(index >= OnBehalf.OnBehalfs.Length)
            {
                return string.Empty;
            }
            int freiht = int.Parse(mItem.SubItems[5].Text);
            int OnBehalfCost = OnBehalf.OnBehalfs[index](originalPrice);
            int totalCost = originalPrice + OnBehalfCost + freiht;
            return totalCost.ToString() + $"，含代购￥{OnBehalf.OnBehalfs[index](originalPrice)}";
        }
        #region ==== Dictionary ====
        public static Dictionary<int, string> EditionKeyIndex = new Dictionary<int, string>
        {
            { 0, "首刷" },
            { 1, "首刷限定" },
            { 2, "首刷+书腰" },
            { 3, "再版" },
            { 4, "特别版" },
            { 5, "？" }
        };
        public static Dictionary<string, int> EditionKeyName = new Dictionary<string, int>
        {
            { "首刷", 0},
            { "首刷限定", 1},
            { "首刷+书腰", 2},
            { "再版", 3 },
            { "特别版", 4 },
            { "？", 5 },
            { string.Empty, -1 }
        };
        public static Dictionary<int, string> OnBehalfKeyIndex = new Dictionary<int, string>
        {
            { 0, "代购一" },
            { 1, "代购二" },
            { 2, "代购三" },
            { 3, "自购" }
        };
        public static Dictionary<string, int> OnBehalfKeyName = new Dictionary<string, int>
        {
            { "代购一", 0 },
            { "代购二", 1 },
            { "代购三", 2 },
            { "自购", 3 },
            { string.Empty, -1 }
        };
        #endregion
        #region ==== 只允许输入数字
        private void txtSeriesIndex_KeyPress(object sender, KeyPressEventArgs e)
        {
            // e.KeyChar == (char)8 是退格键
            if (!(char.IsNumber(e.KeyChar) || e.KeyChar == (char)8 || e.KeyChar == '-' || e.KeyChar == ','))
            {
                e.Handled = true;
            }
        }

        private void txtOriginalPrice_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!(char.IsNumber(e.KeyChar) || e.KeyChar == (char)8))
            {
                e.Handled = true;
            }
        }

        private void txtFreight_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!(char.IsNumber(e.KeyChar) || e.KeyChar == (char)8))
            {
                e.Handled = true;
            }
        }

        private void txtSoldPrice_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!(char.IsNumber(e.KeyChar) || e.KeyChar == (char)8))
            {
                e.Handled = true;
            }
        }
        #endregion
    }
    /// <summary>
    /// 图书类
    /// </summary>
    public class CBook
    {
        /// <summary>
        /// 系列序号
        /// </summary>
        string mSeriesIndex = "0";
        [XmlElement("series-number")]
        public string SeriesIndex
        {
            get { return mSeriesIndex; }
            set { mSeriesIndex = value; }
        }
        /// <summary>
        /// 版本类型
        /// </summary>
        string mEdition = string.Empty;
        [XmlElement("edition")]
        public string Edition
        {
            get { return mEdition; }
            set { mEdition = value; }
        }
        /// <summary>
        /// 定价
        /// </summary>
        string mOriginalPrice = string.Empty;
        [XmlElement("original-price")]
        public string OriginalPrice
        {
            get { return mOriginalPrice; }
            set { mOriginalPrice = value; }
        }
        /// <summary>
        /// 购买日期
        /// </summary>
        string mBoughtDate = string.Empty;
        [XmlElement("bought-time")]
        public string BoughtDate
        {
            get { return mBoughtDate; }
            set { mBoughtDate = value; }
        }
        /// <summary>
        /// 代购
        /// </summary>
        string mOnBehalf = string.Empty;
        [XmlElement("on-behalf")]
        public string OnBehalf
        {
            get { return mOnBehalf; }
            set { mOnBehalf = value; }
        }
        /// <summary>
        /// 邮费
        /// </summary>
        string mFreight = "1";
        [XmlElement("freight")]
        public string Freight
        {
            get { return mFreight; }
            set { mFreight = value; }
        }
        /// <summary>
        /// 出售价格
        /// </summary>
        string mSoldPrice = string.Empty;
        [XmlElement("sold-price")]
        public string SoldPrice
        {
            get { return mSoldPrice; }
            set { mSoldPrice = value; }
        }
        /// <summary>
        /// 出售日期
        /// </summary>
        string mSoldDate = string.Empty;
        [XmlElement("sold-time")]
        public string SoldDate
        {
            get { return mSoldDate; }
            set { mSoldDate = value; }
        }
        /// <summary>
        /// 总成本
        /// </summary>
        string mTotalCost = string.Empty;
        [XmlElement("total-cost")]
        public string TotalCost
        {
            get { return mTotalCost; }
            set { mTotalCost = value; }
        }
        public CBook() { }
    }
}
