namespace CsvTask;

//TODO метод для обработки пустой строки и кавычки в конце, возможно кейс
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

        try
        {
            CsvToHtmlParser.ParseCsvToHtml(input, output);
        }
        catch (FileNotFoundException)
        {
            Console.WriteLine("File not found. Enter input and output file paths, input must be .csv and output - .html");
        }
    }
}