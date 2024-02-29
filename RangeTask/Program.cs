namespace RangeTask;

internal class Program
{
    static void Main(string[] args)
    {

        RangeTask range0 = new(1, 10);
        RangeTask range1 = new(11, 1000);
        RangeTask range2 = new(5, 12);
        RangeTask range3 = new();
        RangeTask[] range4 = new RangeTask[0];

        Console.WriteLine($"Длина диапазона: {range0.GetLength()}");
        Console.WriteLine($"Находится ли число внутри диапазона: {range0.IsInside(5)}");

        range3 = range0.IsIntersect(range2);
        Console.WriteLine($"Интервал пересечения диапазонов {range3.From}, {range3.To}");
        // Ругается на налл и падает, если метод IsIntersect вернул налл.

        range4 = range0.GetSum(range1);
        Console.WriteLine("Результат объединения двух диапазонов, если их можно объединить, или два диапазона, если нельзя.");

        foreach (RangeTask range in range4)
        {
            Console.WriteLine($"{range.From}, {range.To}");
        }

        range4 = range0.GetDifference(range2);
        Console.WriteLine("Результат разности двух диапазонов, если их можно вычесть, или два диапазона, если нельзя.");

        foreach (RangeTask range in range4)
        {
            Console.WriteLine($"{range.From}, {range.To}");
        }
    }
}