using System;
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
        public CBook mBook;
        public BookForm()
        {
            InitializeComponent();
        }
    }
    /// <summary>
    /// 图书类
    /// </summary>
    public class CBook
    {
        /// <summary>
        /// 在套装中的序号
        /// </summary>
        int mIndexInSeries = 0;
        [XmlElement("series-index")]
        public int IndexInSeries
        {
            get { return mIndexInSeries; }
            set { mIndexInSeries = value; }
        }
        /// <summary>
        /// 版本类型
        /// </summary>
        eEdition mEdition;
        [XmlElement("edition")]
        public eEdition Edition
        {
            get { return mEdition; }
            set { mEdition = value; }
        }
        /// <summary>
        /// 定价
        /// </summary>
        int mOriginalPrice;
        [XmlElement("original-price")]
        public int OriginalPrice
        {
            get { return mOriginalPrice; }
            set { mOriginalPrice = value; }
        }
        /// <summary>
        /// 购买日期
        /// </summary>
        string mBoughtDate;
        [XmlElement("add-time")]
        public string BoughtDate
        {
            get { return mBoughtDate; }
            set { mBoughtDate = value; }
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
        /// 出售价格
        /// </summary>
        double mSoldPrice = -1f;
        [XmlElement("sold-price")]
        public double SoldPrice
        {
            get { return mSoldPrice; }
            set { mSoldPrice = value; }
        }
        /// <summary>
        /// 代购索引
        /// </summary>
        int mIndexOfOnBehalf;
        [XmlElement("behalf-index")]
        public int IndexOfOnBehalf
        {
            get { return mIndexOfOnBehalf; }
            set { mIndexOfOnBehalf = value; }
        }
        /// <summary>
        /// 运费
        /// </summary>
        int mFreight;
        public int Freight
        {
            get { return mFreight; }
            set { mFreight = value; }
        }
        public CBook() { }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="edition">版本类型</param>
        /// <param name="originalPrice">定价</param>
        /// <param name="boughtDate">添加时间</param>
        /// <param name="indexOfOnBehalf">代购索引</param>
        /// <param name="indexInSeries">在套装中的序号，默认为0</param>
        public CBook(
            eEdition edition,
            int originalPrice,
            string boughtDate,
            int indexOfOnBehalf,
            int indexInSeries = 0
            )
        {
            mEdition = edition;
            mOriginalPrice = originalPrice;
            mBoughtDate = boughtDate;
            mIndexOfOnBehalf = indexOfOnBehalf;
            mIndexInSeries = indexInSeries;
        }
    }
    /// <summary>
    /// 版本
    /// </summary>
    public enum eEdition
    {
        REPRT, // 再版
        FIRST, // 首刷
        FIRST_LIMIT, // 首刷限定
        FIRST_WAIST, // 手刷书腰
        ESPEC, // 特别版
    }
}
