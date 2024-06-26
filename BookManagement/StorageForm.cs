﻿using System.Text;
using System.Text.RegularExpressions;
using System.Xml;
using System.Xml.Serialization;

namespace BookManagement
{
    public partial class StorageForm : Form
    {
        CBookStorage mStorage = new CBookStorage();

        public StorageForm()
        {
            InitializeComponent();
            ResizeForm.SetTag(this);
        }
        public void UpateListView()
        {
            lstvSeries.Items.Clear();
            foreach (var series in mStorage.SeriesList)
            {
                ListViewItem item = new ListViewItem();
                // 设置行标题
                item.Text = series.SeriesName;
                // 特定版本的数量
                item.SubItems.Add(string.Format($"全部版本：{series.Booklist.Count}本"));
                lstvSeries.Items.Add(item);
            }
            lstvSeries.AutoResizeColumns(ColumnHeaderAutoResizeStyle.HeaderSize);
            int[] width = new int[2];
            for (int i = 0; i < width.Length; i++)
            {
                width[i] = lstvSeries.Columns[i].Width;
            }
            foreach (var item in lstvSeries.Items)
            {
                for (int i = 0; i < width.Length; i++)
                {
                    width[i] = width[i] > lstvSeries.Columns[i].Width ? width[i] : lstvSeries.Columns[i].Width;
                    lstvSeries.Columns[i].Width = width[i];
                }
            }
            lstvSeries.Update();
        }
        #region ==== 文件处理 ====
        /// <summary>
        /// 序列化成XML
        /// </summary>
        /// <param name="fstream"></param>
        public void SerializeToXml(string path)
        {
            XmlSerializer serializer = new XmlSerializer(mStorage.GetType());
            XmlWriterSettings settings = new XmlWriterSettings();
            settings.Indent = true;
            settings.IndentChars = "\t";
            settings.NewLineChars = Environment.NewLine;
            settings.Encoding = Encoding.UTF8;
            //settings.OmitXmlDeclaration = true;  // 不生成声明头

            FileStream fileStream = new FileStream(path, FileMode.Create);
            XmlWriter xmlWriter = XmlWriter.Create(fileStream, settings);
            // 强制指定命名空间，覆盖默认的命名空间
            XmlSerializerNamespaces namespaces = new XmlSerializerNamespaces();
            namespaces.Add(string.Empty, string.Empty);
            serializer.Serialize(new XmlWriterForceFullEnd(xmlWriter), mStorage, namespaces);
            xmlWriter.Close();
            fileStream.Close();
        }
        /// <summary>
        /// 从XML反序列化
        /// </summary>
        /// <param name="fstream"></param>
        public void DeserializeFromXml(string path)
        {
            FileStream fileStream = new FileStream(path, FileMode.Open);
            StreamReader sr = new StreamReader(fileStream, Encoding.UTF8);
            XmlSerializer serializer = new XmlSerializer(mStorage.GetType());
            mStorage = (CBookStorage)serializer.Deserialize(sr);
            fileStream.Close();
        }
        #endregion
        private void btnLoad_Click(object sender, EventArgs e)
        {
            #region ==== 打开文件 ====
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = "XML文件(*.xml)|*.xml";
            if (openFileDialog.ShowDialog(this) == DialogResult.Cancel)
            {
                return;
            }
            #endregion
            string path = openFileDialog.FileName;
            Match match = Regex.Match(path, "_old\\.xml$");
            if (!match.Success)
            {
                Match mc = Regex.Match(path, "(.*)(\\.xml$)");
                FileInfo finfo = new FileInfo(path);
                string copyPath = mc.Groups[1].Value + "_old.xml";
                if (new FileInfo(copyPath).Exists)
                {
                    new FileInfo(copyPath).Delete();
                }
                finfo.CopyTo(copyPath);
            }
            try
            {
                DeserializeFromXml(path);
                UpateListView();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            #region ==== 选择保存路径 ====
            SaveFileDialog saveFileDialog = new SaveFileDialog();
            saveFileDialog.Title = "另存为：";
            // 设置文件类型
            saveFileDialog.Filter = "XML文件(*.xml)|*.xml";
            // 记忆上次打开的目录
            saveFileDialog.RestoreDirectory = true;
            //按下确定选择的按钮
            if (saveFileDialog.ShowDialog() == DialogResult.Cancel)
            {
                return;
            }
            #endregion
            try
            {
                SerializeToXml(saveFileDialog.FileName);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btnAddRow_Click(object sender, EventArgs e)
        {
            SeriesForm seriesForm = new SeriesForm(null);
            this.Hide();
            seriesForm.ShowDialog();
            this.Show();
            if (seriesForm.mSeries.Booklist.Count == 0)
            {
                return;
            }
            mStorage.Add(seriesForm.mSeries);
            UpateListView();
        }

        private void lstvSeries_DoubleClick(object sender, EventArgs e)
        {
            int index = lstvSeries.FocusedItem.Index;
            if (index == -1)
            {
                return;
            }
            SeriesForm seriesForm = new SeriesForm(mStorage.SeriesList[index]);
            this.Hide();
            seriesForm.ShowDialog();
            this.Show();
            mStorage.SeriesList[index] = seriesForm.mSeries;
            UpateListView();
        }

        private void StorageForm_SizeChanged(object sender, EventArgs e)
        {
            if (Tag != null)
            {
                string[] tagContent = Tag.ToString().Split(" ");
                float newWidth = this.Width / float.Parse(tagContent[0]);
                float newHeight = this.Height / float.Parse(tagContent[1]);
                ResizeForm.ResizeControls(newWidth, newHeight, this);
                lstvSeries.AutoResizeColumns(ColumnHeaderAutoResizeStyle.HeaderSize);
                this.Invalidate();
            }
        }
    }
    /// <summary>
    /// 书库类
    /// </summary>
    [XmlRoot("book-storage")]
    public class CBookStorage
    {
        /// <summary>
        /// 套装列表
        /// </summary>
        List<CSeries> mSeriesList = new List<CSeries>();
        [XmlElement("series")]
        public List<CSeries> SeriesList
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
            foreach (var sr in series)
            {
                mSeriesList.Add(sr);
            }
        }
        public void Add(params CSeries[] series)
        {
            foreach (var sr in series)
            {
                if (mSeriesList.FindIndex(x => x.SeriesName == sr.SeriesName) != -1)
                    throw new Exception($"无法添加已存在的同名套装");
                mSeriesList.Add(sr);
            }
        }
    }
}
