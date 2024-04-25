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

        Console.WriteLine("Список с уникальными именами:");
        var uniqueNames = persons
            .Select(p => p.Name)
            .Distinct()
            .ToList();
        Console.WriteLine("Имена: " + string.Join(", ", uniqueNames));
        Console.WriteLine();

        Console.WriteLine("Люди моложе 18:");
        var teenagers = persons
            .Where(p => p.Age < 18)
            .ToList();
        Console.WriteLine("Имя, возраст: " + string.Join(", ", teenagers) + ".");
        Console.WriteLine($"И их средний возраст: {teenagers.Average(t => t.Age)}");
        Console.WriteLine();

        var averageAgesByNames = persons
            .GroupBy(p => p.Name)
            .ToDictionary(g => g.Key, g => g.Average(p => p.Age));
        Console.WriteLine($"Средний возраст людей по имени:{Environment.NewLine}{string.Join(Environment.NewLine, averageAgesByNames)}");
        Console.WriteLine();

        Console.WriteLine("Люди с возрастом от 20 до 45, отсортированные по убыванию возраста:");
        var middleAgedPersons = persons
            .Where(x => x.Age >= 20 && x.Age <= 45)
            .OrderByDescending(x => x.Age)
            .ToList();
        Console.WriteLine(string.Join(Environment.NewLine, middleAgedPersons.Select(x => x.Name)));
        Console.WriteLine();

        // Задача 2
        Console.Write("Нажмите любую кнопку, чтобы очистить консоль");
        Console.ReadKey();
        Console.Clear();

        Console.Write("Введите количество чисел для вычисления квадратного корня: ");
        var squareRootNumbersAmount = Convert.ToInt32(Console.ReadLine());

        foreach (var root in GetSquareRoots().Take(squareRootNumbersAmount))
        {
            Console.WriteLine(root);
        }

        Console.WriteLine();
        Console.Write("Введите количество чисел ряда Фибоначчи: ");
        var fibonacciNumbersAmount = Convert.ToInt32(Console.ReadLine());

        foreach (var fibonacciNumber in GetFibonacciNumbers().Take(fibonacciNumbersAmount))
        {
            Console.WriteLine(fibonacciNumber);
        }
    }

    public static IEnumerable<double> GetSquareRoots()
    {
        var i = 0;

        while (true)
        {
            yield return Math.Sqrt(i);

            ++i;
        }
    }

    public static IEnumerable<Int128> GetFibonacciNumbers()
    {
        yield return 0;
        yield return 1;

        Int128 previousFibonacciNumber = 0;
        Int128 currentFibonacciNumber = 1;

        while (true)
        {
            var nextFibonacciNumber = previousFibonacciNumber + currentFibonacciNumber;
            previousFibonacciNumber = currentFibonacciNumber;
            currentFibonacciNumber = nextFibonacciNumber;

            yield return nextFibonacciNumber;
        }
    }
}