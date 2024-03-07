namespace RangeTask;

internal class Program
{
    static void Main(string[] args)
    {
        Range range1 = new Range(1, 10);

        Console.WriteLine($"Длина диапазона: {range1.GetLength()}");
        Console.WriteLine($"Находится ли число внутри диапазона: {range1.IsInside(5)}");

        Range range2 = new Range(5, 15);

        Console.WriteLine($"Интервал пересечения диапазонов: {range1.GetIntersection(range2)}");
        Console.WriteLine();

        Console.Write("Результат объединения двух диапазонов, если их можно объединить: ");
        Range[] ranges = range2.GetUnion(range1);
        Console.WriteLine("[" + string.Join<Range>(", ", ranges) + "]");

        ranges = range2.GetUnion(new Range(20, 30));
        Console.WriteLine($"и два диапазона, если нельзя: [{string.Join<Range>(", ", ranges)}]");
        Console.WriteLine();


        Console.WriteLine("Результаты разности двух диапазонов, если они:");
        ranges = range2.GetDifference(new Range(0, 3));
        Console.WriteLine($"не пересекаются: [{string.Join<Range>(", ", ranges)}]");

        ranges = range2.GetDifference(new Range(0, 50));
        Console.WriteLine($"второй полностью перекрывает первый: [{string.Join<Range>(", ", ranges)}]");

        ranges = range2.GetDifference(new Range(8, 10));
        Console.WriteLine($"второй лежит внутри первого: [{string.Join<Range>(", ", ranges)}]");

        ranges = range2.GetDifference(new Range(0, 8));
        Console.WriteLine($"второй частично перекрывает первый: [{string.Join<Range>(", ", ranges)}]");
    }
}