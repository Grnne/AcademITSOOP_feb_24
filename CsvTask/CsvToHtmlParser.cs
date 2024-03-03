namespace CsvTask;

internal class CsvToHtmlParser
{
    static void Main(string[] args)
    {
        Console.WriteLine("Hello, World!");








    }

    public static void SetHeadTags()
    { }

    public static void SetBottomTags()
    { }

    public static string GetHtmlSymbolCodes(char literal) => literal switch
    {
        '<' => "&lt;",
        '>' => "&gt;",
        '&' => "&amp;",
        _ => string.Concat(literal)
    };
}