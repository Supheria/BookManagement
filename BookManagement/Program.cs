
using BookManagement;

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
        booksForm.InitializeList(allSeries);
        Application.Run(booksForm);
    }

    static List<CBook> series_1 = new List<CBook>
    {
        new CBook("书名1", eEdition.FIRST & eEdition.ESPEC, 100, "时间1", 2, 1),
        new CBook("书名2", eEdition.FIRST & eEdition.FIRST, 100, "时间2", 2, 1)
    };
    static List<CBook> series_2 = new List<CBook>
    {
        new CBook("书名3", eEdition.FIRST & eEdition.ESPEC, 100, "时间1", 2, 1),
    };
    static List<List<CBook>> allSeries = new List<List<CBook>>
    { 
        series_1, 
        series_2 
    };
}