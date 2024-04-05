namespace ArrayListHome;

internal class Program
{
    static void Main(string[] args)
    {
        string path = "..\\..\\..\\input.txt";

        try
        {
            List<string> list = GetLinesFromFileToList(path);

            foreach (string line in list)
            {
                Console.WriteLine(line);
            }

        }
        catch (FileNotFoundException)
        {
            Console.WriteLine("File not found");
        }
        catch (Exception)
        {
            Console.WriteLine("Something gone wrong");
        }

        Console.WriteLine();

        List<int> numbers = new() { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 9, 9, 9, 9 };

        RemoveEvenNumbers(numbers);
        Console.WriteLine("Removed even numbers from list. " + string.Join(", ", numbers) + Environment.NewLine);

        List<int> numbers2 = new() { 3, 3, 3, 3, 3, 3, 34, 4, 4, 5, 6, 6, 6, 6 };
        numbers2 = GetDistinctItems(numbers2);
        Console.WriteLine("Got distinct numbers from list. " + string.Join(", ", numbers2));
    }

    public static List<string> GetLinesFromFileToList(string path)
    {
        using StreamReader streamReader = new(path);
        List<string> list = new();
        string currentLine;

        while ((currentLine = streamReader.ReadLine()) != null)
        {
            list.Add(currentLine);
        }

        return list;
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

    public static List<T> GetDistinctItems<T>(List<T> items)
    {
        List<T> distinctItems = new(items.Count);

        foreach (T number in items)
        {
            if (!distinctItems.Contains(number))
            {
                distinctItems.Add(number);
            }
        }

        return distinctItems;
    }
}