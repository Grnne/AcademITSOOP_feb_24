﻿namespace CsvTask;

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

        string inputCsvPath = args[0];
        string outputHtmlPath = args[1];

        try
        {
            CsvToHtmlConverter.Convert(inputCsvPath, outputHtmlPath);
            Console.WriteLine("Parsing is done");
            Console.ReadKey();
        }
        catch (FileNotFoundException)
        {
            Console.WriteLine("File not found. Enter input and output file paths, input must be .csv and output - .html");
        }
        catch (IOException e)
        {
            Console.WriteLine("I/O error: " + e.Message);
        }
    }
}