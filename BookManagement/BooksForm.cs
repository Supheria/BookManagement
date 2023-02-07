using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml;
using System.Xml.Serialization;

namespace BookManagement
{
    public partial class BooksForm : Form
    {
        public BooksForm()
        {
            InitializeComponent();
        }
        public void InitializeList(CBookStorage storage)
        {
            lstvSeriesList.Items.Clear();
            foreach(var series in storage._seriesList)
            {
                ListViewItem item = new ListViewItem();
                // 设置行标题
                item.Text = series._seriesName;
                // 特定版本的数量
                item.SubItems.Add(string.Format($"全部版本：{series._booklist.Count}本"));
                lstvSeriesList.Items.Add(item);
            }
        }
    }

    public class CSeries
    {
        /// <summary>
        /// 套装名称
        /// </summary>
        string mSeriesName;
        [XmlElement("series-name")]
        public string _seriesName
        {
            get { return mSeriesName; }
            set { mSeriesName = value; }
        }
        /// <summary>
        /// 书单
        /// </summary>
        List<CBook> mBooklist = new List<CBook>();
        [XmlElement("book-info")]
        public List<CBook> _booklist
        {
            get { return mBooklist; }
            set { mBooklist = value; }
        }
        public CSeries() { }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="seriesName">套装名称</param>
        /// <param name="book"></param>
        public CSeries(string seriesName, params CBook[] book)
        {
            mSeriesName = seriesName;
            foreach(var bk in book)
            {
                mBooklist.Add(bk);
            }
        }

        public void Add(params CBook[] book)
        {
            foreach (var bk in book)
            {
                mBooklist.Add(bk);
            }
        }
    }

    [XmlRoot("book-storage")]
    public class CBookStorage
    {
        /// <summary>
        /// 套装列表
        /// </summary>
        List<CSeries> mSeriesList = new List<CSeries>();
        [XmlElement("series")]
        public List<CSeries> _seriesList
        {
            get
            {
                return mSeriesList;
            }
            set
            {
                mSeriesList = value;
            }
        }
        public CBookStorage() { }
        public CBookStorage(params CSeries[] series)
        {
            foreach(var sr in series)
            {
                mSeriesList.Add(sr);
            }
        }
        public void Add(params CSeries[] series)
        {
            foreach (var sr in series)
            {
                if (mSeriesList.FindIndex(x => x._seriesName == sr._seriesName) != -1)
                    throw new Exception($"无法添加已存在的同名套装");
                mSeriesList.Add(sr);
            }
        }
    }
}
