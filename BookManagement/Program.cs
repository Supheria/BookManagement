
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
}