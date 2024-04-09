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
        var distinctNames = persons
            .Select(x => x.Name)
            .Distinct()
            .ToList();
        Console.WriteLine(string.Join(", ", distinctNames));
        Console.WriteLine();

        Console.WriteLine("Люди моложе 18:");
        var teenagers = persons
            .Where(y => y.Age < 18)
            .ToList();
        Console.WriteLine("Имена: " + string.Join(", ", teenagers) + ".");
        Console.WriteLine($"И их средний возраст: {teenagers.Average(x => x.Age)}");
        Console.WriteLine();

        var averageAgesByName = persons
            .GroupBy(x => x.Name)
            .ToDictionary(x => x.Key, x => x.Average(x => x.Age));
        Console.WriteLine($"Средний возраст людей по имени: {string.Join(Environment.NewLine, averageAgesByName)}");
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
        var numbersAmount = Convert.ToInt32(Console.ReadLine());

        foreach (var root in GetSquareRoots().Take(numbersAmount))
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

        Int128 fibonacciNumber1 = 0;
        Int128 fibonacciNumber2 = 1;
        Int128 fibonacciNumber3;

        while (true)
        {
            fibonacciNumber3 = fibonacciNumber1 + fibonacciNumber2;
            fibonacciNumber1 = fibonacciNumber2;
            fibonacciNumber2 = fibonacciNumber3;

            yield return fibonacciNumber3;
        }
    }
}