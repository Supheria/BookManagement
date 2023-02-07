
using BookManagement;
using System.Text;
using System.Xml;
using System.Xml.Serialization;
//using static System.Net.Mime.MediaTypeNames;

internal static class Program
{
    /// <summary>
    /// 应用程序的主入口点。
    /// </summary>
    [STAThread]
    static void Main()
    {
        Application.EnableVisualStyles();
        Application.SetCompatibleTextRenderingDefault(false);
        BooksForm booksForm = new BooksForm();
        test();
        booksForm.InitializeList(storage);
        Application.Run(booksForm);
        
    }

    static CBookStorage storage = new CBookStorage();
    static CSeries series_1 = new CSeries(
        "套装一",
        new CBook(eEdition.FIRST, 100, "时间1", 1, 0), 
        new CBook(eEdition.FIRST_WAIST, 100, "时间1", 2, 1)
            );
    static CSeries series_2 = new CSeries(
        "套装二",
        new CBook(eEdition.FIRST_WAIST, 100, "时间1", 2, 0)
        );

    public static void test()
    {
        //storage = new CBookStorage(series_1, series_2);
        //// 将对象序列化输出到文件
        //FileStream stream = new FileStream("hh.xml", FileMode.Create);
        //SerializeToXml(stream);
        //stream.Close();
        DeserializeFromXml();
    }
    public static void SerializeToXml(FileStream stream)
    {
        XmlSerializer serializer = new XmlSerializer(storage.GetType());
        XmlWriterSettings settings = new XmlWriterSettings();
        settings.Indent = true;
        settings.IndentChars = "    ";
        settings.NewLineChars = Environment.NewLine;
        settings.Encoding = Encoding.UTF8;
        //settings.OmitXmlDeclaration = true;  // 不生成声明头

        using (XmlWriter xmlWriter = XmlWriter.Create(stream, settings))
        {
            // 强制指定命名空间，覆盖默认的命名空间
            XmlSerializerNamespaces namespaces = new XmlSerializerNamespaces();
            namespaces.Add(string.Empty, string.Empty);
            serializer.Serialize(new XmlWriterForceFullEnd(xmlWriter), storage, namespaces);
            xmlWriter.Close();
        }
    }

    public static void DeserializeFromXml()
    {
        FileStream fs = File.Open("file.xml", FileMode.Open);
        using (StreamReader sr = new StreamReader(fs, Encoding.UTF8))
        {
            XmlSerializer xz = new XmlSerializer(typeof(CBookStorage));
            storage = (CBookStorage)xz.Deserialize(sr);
        }
    }

    public sealed class Utf8Writer : StringWriter
    {
        public override Encoding Encoding => Encoding.UTF8;
    }
}