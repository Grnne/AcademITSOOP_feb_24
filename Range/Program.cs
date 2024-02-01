namespace Range;

internal class Program
{
    static void Main(string[] args)
    {
        
        Range range0 = new Range(1,1);
        Range range1 = new Range();

        Console.WriteLine(range0.From);
        Console.WriteLine(range1.To);
    }
}
