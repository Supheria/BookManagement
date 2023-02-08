
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
        Application.Run(new StorageForm());
        
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
        //FileStream stream = File.Open("file.xml", FileMode.Open);
        //DeserializeFromXml(stream);
    }
}