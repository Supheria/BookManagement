using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace BookManagement
{
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
        public int _indexInSeries
        {
            get { return mIndexInSeries; }
            set { mIndexInSeries = value; }
        }
        /// <summary>
        /// 版本类型
        /// </summary>
        eEdition mEdition;
        [XmlElement("edition")]
        public eEdition _edition
        {
            get { return mEdition; }
            set { mEdition = value; }
        }
        /// <summary>
        /// 定价
        /// </summary>
        int mOriginalPrice;
        [XmlElement("original-price")]
        public int _originalPrice
        {
            get { return mOriginalPrice; }
            set { mOriginalPrice = value; }
        }
        /// <summary>
        /// 入库时间
        /// </summary>
        string mAddTime;
        [XmlElement("add-time")]
        public string _addTime
        {
            get { return mAddTime; }
            set { mAddTime = value; }
        }
        /// <summary>
        /// 出库时间
        /// </summary>
        string mSoldTime = string.Empty;
        [XmlElement("sold-time")]
        public string _soldTime
        {
            get { return mSoldTime; }
            set { mSoldTime = value; }
        }
        /// <summary>
        /// 出售价格
        /// </summary>
        double mSoldPrice = -1f;
        [XmlElement("sold-price")]
        public double _soldPrice
        {
            get { return mSoldPrice; }
            set
            {
                mSoldPrice = value;
                mSoldTime = System.DateTime.Now.ToString("f");
            }
        }
        /// <summary>
        /// 代购索引
        /// </summary>
        int mIndexOfOnBehalf;
        [XmlElement("behalf-index")]
        public int _indexOfOnBehalf
        {
            get { return mIndexOfOnBehalf; }
            set
            {
                mIndexOfOnBehalf = value;
            }
        }
        public CBook() { }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="edition">版本类型</param>
        /// <param name="originalPrice">定价</param>
        /// <param name="addTime">入库时间</param>
        /// <param name="indexOfOnBehalf">代购索引</param>
        /// <param name="indexInSeries">在套装中的序号，默认为0</param>
        /// <param name="soldPrice">出售价格，默认为-1</param>
        public CBook(
            eEdition edition,
            int originalPrice,
            string addTime,
            int indexOfOnBehalf,
            int indexInSeries
            )
        {
            mEdition = edition;
            mOriginalPrice = originalPrice;
            mAddTime = addTime;
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
