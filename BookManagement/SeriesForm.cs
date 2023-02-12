using System.Xml.Serialization;

namespace BookManagement
{
    public partial class SeriesForm : Form
    {
        public CSeries mSeries = new CSeries();
        public SeriesForm(CSeries? series)
        {
            InitializeComponent();
            this.lstvBooks.AutoResizeColumns(ColumnHeaderAutoResizeStyle.HeaderSize);
            SetTag(this);
            if (series != null)
            {
                mSeries = series;
                LoadListView();
            }
            this.txtSeriesName.Text = this.Text = mSeries.SeriesName;
        }
        void LoadListView()
        {
            foreach (var book in mSeries.Booklist)
            {
                ListViewItem item = new ListViewItem();
                item.Text = book.SeriesIndex;
                item.SubItems.Add(book.Edition);
                item.SubItems.Add(book.OnBehalf);
                item.SubItems.Add(book.OriginalPrice);
                item.SubItems.Add(book.BoughtDate);
                item.SubItems.Add(book.Freight);
                item.SubItems.Add(book.SoldPrice);
                item.SubItems.Add(book.SoldDate);
                item.SubItems.Add(book.TotalCost);
                lstvBooks.Items.Add(item);
            }
            UpdateListView();
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
            foreach (Control child in parent.Controls)
            {
                if (child.Tag != null)
                {
                    string[] tagContent = child.Tag.ToString().Split(" ");
                    child.Width = (int)(float.Parse(tagContent[0]) * newWidth);
                    child.Height = (int)(float.Parse(tagContent[1]) * newHeight);
                    child.Left = (int)(float.Parse(tagContent[2]) * newWidth);
                    child.Top = (int)(float.Parse(tagContent[3]) * newHeight);
                    var fontSize = float.Parse(tagContent[4]) * newHeight * 0.8f;
                    child.Font = new Font(child.Font.Name, fontSize, child.Font.Style, child.Font.Unit);
                    if (child.Controls.Count > 0)
                    {
                        ResizeControls(newWidth, newHeight, child);
                    }
                }
            }
        }
        public void EditItem(ListViewItem item, int index)
        {
            try
            {
                this.lstvBooks.Items[index] = item;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"{ex.Message}/n无法编辑条目。");
            }
        }
        public void AddItem(ListViewItem item)
        {
            lstvBooks.Items.Add(item);
            UpdateListView();
        }
        public void UpdateListView()
        {
            lstvBooks.AutoResizeColumns(ColumnHeaderAutoResizeStyle.HeaderSize);
            int[] width = new int[9];
            for (int i = 0; i < width.Length; i++)
            {
                width[i] = lstvBooks.Columns[i].Width;
            }
            foreach (var item in lstvBooks.Items)
            {
                for (int i = 0; i < width.Length; i++)
                {
                    width[i] = width[i] > lstvBooks.Columns[i].Width ? width[i] : lstvBooks.Columns[i].Width;
                    lstvBooks.Columns[i].Width = width[i];
                }
            }
            lstvBooks.Update();
        }
        private void btnAddRow_Click(object sender, EventArgs e)
        {
            BookForm form = new BookForm(this, new ListViewItem());
            form.Show();
        }
        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (lstvBooks.SelectedItems.Count == 0)
            {
                return;
            }
            if (MessageBox.Show("确定删除所有选中项吗？", "提示", MessageBoxButtons.YesNo) == DialogResult.No)
            {
                return;
            }
            foreach (ListViewItem sel in lstvBooks.SelectedItems)
            {
                sel.Remove();
            }
            UpdateListView();
        }

        private void lstvBooks_DoubleClick(object sender, EventArgs e)
        {
            var item = lstvBooks.FocusedItem;
            if (item == null)
            {
                return;
            }
            BookForm form = new BookForm(this, item);
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

        private void SeriesForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (lstvBooks.Items.Count == 0)
            {
                return;
            }
            if (mSeries.SeriesName == string.Empty)
            {
                MessageBox.Show("还没有输入书名！");
                e.Cancel = true;
                return;
            }
            mSeries.Clear();
            foreach (ListViewItem item in lstvBooks.Items)
            {
                CBook book = new CBook();
                var subItems = item.SubItems;
                book.SeriesIndex = subItems[0].Text;
                book.Edition = subItems[1].Text;
                book.OnBehalf = subItems[2].Text;
                book.OriginalPrice = subItems[3].Text;
                book.BoughtDate = subItems[4].Text;
                book.Freight = subItems[5].Text;
                book.SoldPrice = subItems[6].Text;
                book.SoldDate = subItems[7].Text;
                book.TotalCost = subItems[8].Text;
                mSeries.Add(book);
            }
        }

        private void txtSeriesName_TextChanged(object sender, EventArgs e)
        {
            this.Text = mSeries.SeriesName = txtSeriesName.Text;
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
        string mSeriesName = string.Empty;
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
        public void Clear()
        {
            mBooklist = new List<CBook>();
        }
    }
}
