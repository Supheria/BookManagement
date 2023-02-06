using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BookManagement
{
    public partial class BooksForm : Form
    {
        public BooksForm()
        {
            InitializeComponent();
        }
        public void InitializeList(List<List<CBook>> seriesList)
        {
            lstvSeriesList.Items.Clear();
            for (int i = 0; i < seriesList.Count; i++)
            {
                var series = seriesList[i];
                ListViewItem item = new ListViewItem();
                // 行序号
                item.Text = string.Format($"{i}");
                // 设置行标题
                item.SubItems.Add(series[0].mName);
                // 特定版本的数量
                item.SubItems.Add(string.Format($"全部版本：{series.Count}本"));
                lstvSeriesList.Items.Add(item);
            }
        }
    }

    public class CBookSeries
    {
        /// <summary>
        /// 系列
        /// </summary>
        public List<CBook> mSeries;
        /// <summary>
        /// 系列名
        /// </summary>
        public string mTitle;
        /// <summary>
        /// 创建时间
        /// </summary>
        public string mCreatTime;
        public CBookSeries(List<CBook> bookSeries)
        {
            mSeries = bookSeries;
        }
        public string GetTitle()
        {
            return mSeries[0].mName;
        }
    }
}
