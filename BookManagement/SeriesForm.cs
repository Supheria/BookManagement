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
    public partial class SeriesForm : Form
    {
        public CSeries mSeries = new CSeries();
        public SeriesForm()
        {
            InitializeComponent();
        }
        private void setTag(Control parent)
        {
            foreach (Control child in parent.Controls)
            {
                child.Tag = child.Width + " " + child.Height + " " +
            }
        }

        public void AddListView(CBook book)
        {
            int[] width = new int[9];
            for (int i = 0; i < width.Length; i++)
            {
                width[i] = lstvBooks.Columns[i].Width;
            }
            ListViewItem item = new ListViewItem();
            // 设置行标题
            item.Text = book.SeriesIndex.ToString();
            // 特定版本的数量
            foreach (var data in book.Data)
            {
                item.SubItems.Add(data);
            }
            int totalCost = 999;
            item.SubItems.Add(totalCost.ToString());
            lstvBooks.Items.Add(item);

            lstvBooks.Update();
        }

        public CBook ReadListView()
        {
            var item = lstvBooks.SelectedItems;
            CBook book = new CBook();
            return book;
        }

        private void btnAddRow_Click(object sender, EventArgs e)
        {
            BookForm form = new BookForm(this, new CBook());
            form.txtSeriesIndex.Enabled = true;
            form.cbbEdition.Enabled = true;
            form.txtOriginalPrice.Enabled = true;
            form.dtpBoughtDate.Enabled = true;
            form.cbbOnBehalf.Enabled = true;
            form.txtFreight.Enabled = true;
            form.txtSoldPrice.Enabled = false;
            form.dtpSoldDate.Enabled = false;
            form.Show();
        }

        private void button1_Click(object sender, EventArgs e)
        {

        }

        private void btnDelete_Click(object sender, EventArgs e)
        {

        }

        private void lstvBooks_DoubleClick(object sender, EventArgs e)
        {

        }

        private void SeriesForm_SizeChanged(object sender, EventArgs e)
        {

            lstvBooks.Size = this.ClientSize;
            this.Invalidate();
        }
    }
    /// <summary>
    /// 套装类
    /// </summary>
    public class CSeries
    {
        /// <summary>
        /// 套装名称
        /// </summary>
        string mSeriesName;
        [XmlElement("series-name")]
        public string SeriesName
        {
            get { return mSeriesName; }
            set { mSeriesName = value; }
        }
        /// <summary>
        /// 书单
        /// </summary>
        List<CBook> mBooklist = new List<CBook>();
        [XmlElement("book-info")]
        public List<CBook> Booklist
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
            foreach (var bk in book)
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
}
