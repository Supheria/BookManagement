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
using static System.Windows.Forms.VisualStyles.VisualStyleElement.TextBox;

namespace BookManagement
{
    public partial class SeriesForm : Form
    {
        public CSeries mSeries = new CSeries();
        public SeriesForm()
        {
            InitializeComponent();
            this.lstvBooks.AutoResizeColumns(ColumnHeaderAutoResizeStyle.HeaderSize);
            SetTag(this);
        }
        private void SetTag(Control parent)
        {
            parent.Tag = parent.Width + " " + parent.Height + " " + parent.Left + " " + parent.Top + " " + parent.Font.Size;
            foreach (Control child in parent.Controls)
            {
                child.Tag = child.Width + " " + child.Height + " " + child.Left + " " + child.Top + " " + child.Font.Size;
                if (child.Controls.Count > 0)
                {
                    SetTag(child);
                }
            }
        }
        private void ResizeControls(float newWidth, float newHeight, Control parent)
        {
            foreach(Control child in parent.Controls)
            {
                if (child.Tag != null)
                {
                    string[] tagContent = child.Tag.ToString().Split(" ");
                    child.Width = (int)(float.Parse(tagContent[0]) * newWidth);
                    child.Height = (int)(float.Parse(tagContent[1]) * newHeight);
                    child.Left = (int)(float.Parse(tagContent[2]) * newWidth);
                    child.Top = (int)(float.Parse(tagContent[3]) * newHeight);
                    var fontSize = float.Parse(tagContent[4]) * newHeight;
                    child.Font = new Font(child.Font.Name, fontSize, child.Font.Style, child.Font.Unit);
                    if (child.Controls.Count > 0)
                    {
                        ResizeControls(newWidth, newHeight, child);
                    }
                }
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
            for (int i = 0; i < width.Length; i++)
            {
                lstvBooks.AutoResizeColumns(ColumnHeaderAutoResizeStyle.HeaderSize);
                width[i] = width[i] > lstvBooks.Columns[i].Width ? width[i] : lstvBooks.Columns[i].Width;
                lstvBooks.Columns[i].Width = width[i];
            }
            lstvBooks.Update();
        }

        public CBook ReadListView()
        {
            var item = lstvBooks.FocusedItem;
            var subItems = item.SubItems;
            CBook book = new CBook(
                subItems[0].Text,
                subItems[1].Text,
                subItems[2].Text,
                subItems[3].Text,
                subItems[4].Text,
                subItems[5].Text,
                subItems[6].Text,
                subItems[7].Text);
            return book;
        }

        private void btnAddRow_Click(object sender, EventArgs e)
        {
            BookForm form = new BookForm(this, new CBook());
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
            BookForm form = new BookForm(this, ReadListView());
            form.Show();
        }

        private void SeriesForm_SizeChanged(object sender, EventArgs e)
        {
            if (Tag != null)
            {
                string[] tagContent = Tag.ToString().Split(" ");
                float newWidth = this.Width / float.Parse(tagContent[0]);
                float newHeight = this.Height / float.Parse(tagContent[1]);
                ResizeControls(newWidth, newHeight, this);
                lstvBooks.AutoResizeColumns(ColumnHeaderAutoResizeStyle.HeaderSize);
                this.Invalidate();
            }
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
