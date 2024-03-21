namespace CsvTask;

// TODO убрать целл, добавить метод для кавычки в конце строки
internal class Program
{
    static void Main(string[] args)
    {
        if (args.Length != 2)
        {
            Console.WriteLine("Enter input and output file paths, input must be .csv and output - .html");
            Console.ReadKey();
            return;
        }
        
        string input = args[0];
        string output = args[1];

        CsvToHtmlParser.ParseCsvToHtml(input, output);
    }
}