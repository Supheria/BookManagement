using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookManagement
{
    /// <summary>
    /// 图书类
    /// </summary>
    public class CBook
    {
        /// <summary>
        /// 书名
        /// </summary>
        public string mName { get; private set; }
        /// <summary>
        /// 版本类型
        /// </summary>
        public eEdition mEdit { get; private set; }
        /// <summary>
        /// 定价
        /// </summary>
        public int mOriginalPrice { get; private set; }
        /// <summary>
        /// 入库时间
        /// </summary>
        public string mAddTime { get; private set; }
        /// <summary>
        /// 出库时间
        /// </summary>
        public string? mSellTime { get; private set; }
        /// <summary>
        /// 代购索引
        /// </summary>
        public int mIndexOfOnBehalf { get; private set; }
        /// <summary>
        /// 系列索引
        /// </summary>
        public int mIndexInSeries { get; private set; }
        public CBook(
            string name,
            eEdition edit,
            int originalPrice,
            string addTime,
            int indexOfOnBehalf, 
            int indexInSeries = 0)
        {
            mName = name;
            mEdit = edit;
            mOriginalPrice = originalPrice;
            mAddTime = addTime;
            mSellTime = null;
            mIndexOfOnBehalf = indexOfOnBehalf;
            mIndexInSeries = indexInSeries;
        }
    }
    /// <summary>
    /// 版本
    /// </summary>
    public enum eEdition
    {
        REPRT = 0b0000, // 再版
        FIRST = 0b0001, // 首刷
        LIMIT = 0b0010, // 限定
        WAIST = 0b0100, // 书腰
        ESPEC = 0b1000, // 特别版
    }
}
