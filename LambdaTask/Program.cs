namespace LambdaTask;

internal class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("Создадим список людей содержащий поля \"Имя\" и \"Возраст\"");

        var persons = new List<Person>
        {
            new Person("Алексей", 25),
            new Person("Александр", 21),
            new Person("Яна", 16),
            new Person("Евгений", 27),
            new Person("Яна", 17),
            new Person("Андрей", 22),
            new Person("Даниял", 29),
            new Person("Илья", 9),
            new Person("Василий", 24),
        };

        Console.WriteLine(string.Join(", ", persons));
        Console.WriteLine();

        Console.WriteLine("Список с уникальными именами: ");
        Console.WriteLine(string.Join(", ", persons.Select(x => x.Name).Distinct()) + ".");
        Console.WriteLine();

        Console.WriteLine("Люди моложе 18:");
        var persons2 = new List<Person>(persons.Select(x => x).Where(y => y.Age < 18));
        Console.WriteLine(string.Join(", ", persons2) + ".");

        Console.WriteLine($"И их средний возраст: {persons2.Average(x => x.Age)}");
        Console.WriteLine();

        Dictionary<string, double> personsByAge = persons
            .GroupBy(x => x.Name)
            .ToDictionary(x => x.Key, x => x.Average(x => x.Age));
        Console.WriteLine($"Средний возраст людей по имени: {string.Join(Environment.NewLine, personsByAge)}");
        Console.WriteLine();

        Console.WriteLine("Люди с возрастом от 20 до 45, отсортированные по убыванию возраста: ");
        var persons3 = new List<Person>(persons
            .Where(x => x.Age >= 20 && x.Age <= 45)
            .OrderByDescending(x => x.Age));
        Console.WriteLine(string.Join(Environment.NewLine, persons3));
        Console.WriteLine();

        // Задача 2
        Console.Write("Нажмите любую кнопку, чтобы очистить консоль");
        Console.ReadKey();
        Console.Clear();

        Console.Write("Введите количество чисел для вычисления квадратного корня: ");
        var limit = Convert.ToInt32(Console.ReadLine());

        foreach (var root in GetSquareRoots(limit))
        {
            Console.WriteLine(root);
        }

        Console.WriteLine();
        Console.Write("Нажмите любую клавишу, чтобы отобразить ряд Фибоначчи: ");
        Console.ReadKey();
        
        foreach (var number in GetFibbonacciNumbers())
        {
            Console.WriteLine(number);
        }
    }

    public static IEnumerable<double> GetSquareRoots(int limit)
    {
        var i = 0;

        while (i <= limit)
        {
            yield return Math.Sqrt(i);

            ++i;
        }
    }

    public static IEnumerable<Int128> GetFibbonacciNumbers()
    {
        Int128 j = 1;

        for (Int128 i = 1; ; i += j)
        {
            yield return i;

            j = i - j;
        }
    }
}