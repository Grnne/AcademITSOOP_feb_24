namespace ArrayListHome;

internal class Program
{
    static void Main(string[] args)
    {
        string path = "..\\..\\..\\input.txt";

        List<string> list = ParseToList(path);

        foreach (var item in list)
        {
            Console.WriteLine(item);
        }

        Console.WriteLine();

        List<int> ints = new() { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 9, 9, 9, 9 };

        RemoveEvenNumbers(ints);
        Console.WriteLine("Removed even numbers from list. " + string.Join(", ", ints) + Environment.NewLine);

        ints = GetDistinctNumbers(ints);
        Console.WriteLine("Got distinct numbers from list. " + string.Join(", ", ints));
    }

    public static List<string> ParseToList(string path)
    {
        List<string> list = new();

        using StreamReader streamReader = new(path);

        string currentLine;

        while ((currentLine = streamReader.ReadLine()) != null)
        {
            list.Add(currentLine);
        }

        return list;
    }

    public static void RemoveEvenNumbers(List<int> list)
    {
        for (int i = list.Count - 1; i >= 0; i--)
        {
            if (list[i] % 2 == 0)
            {
                list.RemoveAt(i);
            }
        }
    }

    public static List<int> GetDistinctNumbers(List<int> list)
    {
        List<int> result = new();

        foreach (int i in list)
        {
            if (!result.Contains(i))
            {
                result.Add(i);
            }
        }

        return result;
    }
}