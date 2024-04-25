namespace ArrayListHome;

internal class Program
{
    static void Main(string[] args)
    {
        try
        {
            string filePath = "..\\..\\..\\input.txt";
            List<string> fileLines = GetFileLines(filePath);

            foreach (string line in fileLines)
            {
                Console.WriteLine(line);
            }
        }
        catch (Exception e)
        {
            Console.WriteLine("Error: " + e.Message);
        }

        Console.WriteLine();

        List<int> numbers1 = new() { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 9, 9, 9, 9 };
        Console.WriteLine("Made new numbers list: " + string.Join(", ", numbers1));
        RemoveEvenNumbers(numbers1);
        Console.WriteLine("Removed even numbers from list: " + string.Join(", ", numbers1) + Environment.NewLine);

        List<int> numbers2 = new() { 3, 3, 3, 3, 3, 3, 34, 4, 4, 5, 6, 6, 6, 6 };
        Console.WriteLine("Made another numbers list: " + string.Join(", ", numbers2));
        List<int> distinctNumbers = GetDistinctItems(numbers2);
        Console.WriteLine("Got distinct numbers from list: " + string.Join(", ", distinctNumbers));
    }

    public static List<string> GetFileLines(string filePath)
    {
        using StreamReader streamReader = new(filePath);
        List<string> fileLines = new();
        string? currentLine;

        while ((currentLine = streamReader.ReadLine()) != null)
        {
            fileLines.Add(currentLine);
        }

        return fileLines;
    }

    public static void RemoveEvenNumbers(List<int> numbers)
    {
        for (int i = numbers.Count - 1; i >= 0; i--)
        {
            if (numbers[i] % 2 == 0)
            {
                numbers.RemoveAt(i);
            }
        }
    }

    public static List<T> GetDistinctItems<T>(List<T> list)
    {
        List<T> distinctItemsList = new(list.Count);

        foreach (T item in list)
        {
            if (!distinctItemsList.Contains(item))
            {
                distinctItemsList.Add(item);
            }
        }

        return distinctItemsList;
    }
}