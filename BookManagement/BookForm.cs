using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Serialization;

namespace BookManagement
{
    public partial class BookForm : Form
    {
        public enum FormMode
        {
            ADD,
            SELL
        }
        SeriesForm mSeriesForm;
        bool mDoSell;
        CBook mBook;
        public BookForm(SeriesForm seriesForm, CBook book, bool DoSell = false)
        {
            InitializeComponent();
            mSeriesForm = seriesForm;
            mDoSell = DoSell;
            mBook = book;
        }

        private void btnSave_Click(object sender, EventArgs e)
        {

            try
            {
                mBook = new CBook(
                    txtSeriesIndex.Text,
                    cbbEdition.SelectedIndex,
                    txtOriginalPrice.Text,
                    dtpBoughtDate.Text,
                    cbbOnBehalf.SelectedIndex,
                    txtFreight.Text,
                    mDoSell == true ? txtSoldPrice.Text : "",
                    mDoSell == true ? dtpSoldDate.Text : ""
                    );
            }
            catch (Exception ex)
            {
                MessageBox.Show($"{ex.Message}\n无法添加书目");
                return;
            }
            mSeriesForm.AddListView(mBook);
        }
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
            set { mSeriesIndex = value == string.Empty ? mSeriesIndex : value ; }
        }
        /// <summary>
        /// 版本类型
        /// </summary>
        string mEdition = string.Empty;
        [XmlElement("edition")]
        public int EditionIndex
        {
            get { return EditionKeyName[mEdition]; }
            set
            {
                mEdition = value == -1 ? throw new Exception("没有选择版本！") : EditionKeyIndex[value];
                UpdateData();
            }
        }
        /// <summary>
        /// 定价
        /// </summary>
        string mOriginalPrice = string.Empty;
        [XmlElement("original-price")]
        public string OriginalPrice
        {
            get { return mOriginalPrice; }
            set
            {
                mOriginalPrice = value == string.Empty ? throw new Exception("定价不能为空！") : value;
                UpdateData();
            }
        }
        /// <summary>
        /// 购买日期
        /// </summary>
        string mBoughtDate = string.Empty;
        [XmlElement("bought-time")]
        public string BoughtDate
        {
            get { return mOriginalPrice; }
            set
            {
                mBoughtDate = value;
                UpdateData();
            }
        }
        /// <summary>
        /// 代购索引
        /// </summary>
        string mOnBehalf = string.Empty;
        [XmlElement("on-behalf-index")]
        public int OnBehalfIndex
        {
            get { return OnBehalfKeyName[mOnBehalf]; }
            set
            {
                mOnBehalf = value == -1 ? throw new Exception("没有选择代购！") : OnBehalfKeyIndex[value];
                UpdateData();
            }
        }
        /// <summary>
        /// 邮费
        /// </summary>
        string mFreight = "0";
        [XmlElement("freight")]
        public string Freight
        {
            get { return mFreight; }
            set
            {
                mFreight = value == string.Empty ? mFreight : value;
                UpdateData();
            }
        }
        /// <summary>
        /// 出售价格
        /// </summary>
        string mSoldPrice = string.Empty;
        [XmlElement("sold-price")]
        public string SoldPrice
        {
            get { return mSoldPrice; }
            set
            {
                mSoldPrice = value == string.Empty ? throw new Exception("售价不能为空！") : value;
                UpdateData();
            }
        }
        /// <summary>
        /// 出售日期
        /// </summary>
        string mSoldDate = string.Empty;
        [XmlElement("sold-time")]
        public string SoldDate
        {
            get { return mSoldDate; }
            set
            {
                mSoldDate = value;
                UpdateData();
            }
        }

        public List<string> Data { get; private set; } = new List<string>();
        public CBook() { }
        public CBook(
            string seriesIndex,
            int editionIndex,
            string originalPrice,
            string boughtDate,
            int onBehalfIndex,
            string freight,
            string soldPrice,
            string soldDate
            )
        {
            SeriesIndex = seriesIndex.Trim();
            EditionIndex = editionIndex;
            OriginalPrice = originalPrice.Trim();
            BoughtDate = boughtDate.Trim();
            OnBehalfIndex = onBehalfIndex;
            Freight = freight.Trim();
            soldPrice = soldPrice.Trim();
            SoldDate = soldDate.Trim();
        }
        private void UpdateData()
        {
            Data = new List<string>()
            {
                mEdition,
                mOriginalPrice,
                mBoughtDate,
                mOnBehalf,
                mFreight,
                mSoldPrice,
                mSoldDate
            };
        }
        public static Dictionary<int, string> EditionKeyIndex = new Dictionary<int, string>
        {
            { 0, "首刷" },
            { 1, "首刷限定" },
            { 2, "首刷+书腰" },
            { 3, "再版" },
            { 4, "特别版" }
        };
        public static Dictionary<string, int> EditionKeyName = new Dictionary<string, int>
        {
            { "首刷", 0},
            { "首刷限定", 1},
            { "首刷+书腰", 2},
            { "再版", 3 },
            { "特别版", 4 }
        };
        public static Dictionary<int, string> OnBehalfKeyIndex = new Dictionary<int, string>
        {
            { 0, "代购一" },
            { 1, "代购二" },
            { 2, "代购三" }
        };
        public static Dictionary<string, int> OnBehalfKeyName = new Dictionary<string, int>
        {
            { "代购一", 0 },
            { "代购二", 1 },
            { "代购三", 2 }
        };
    }
}
