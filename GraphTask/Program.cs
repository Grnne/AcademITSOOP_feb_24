namespace GraphTask;

internal class Program
{
    static void Main(string[] args)
    {
        Graph graph = new(new[,]
        {
            { 0, 1, 0, 0, 0, 0, 0 },
            { 1, 0, 1, 1, 1, 1, 0 },
            { 0, 1, 0, 0, 0, 0, 1 },
            { 0, 1, 0, 0, 0, 0, 0 },
            { 0, 1, 0, 0, 0, 1, 0 },
            { 0, 1, 0, 0, 1, 0, 1 },
            { 0, 0, 1, 0, 0, 1, 0 }
        });

        graph.Data = new double[] { 1, 2, 3, 4, 5, 6, 7 };

        Console.WriteLine("Зададим матрицу смежности как в лекции и сделаем обходы:");
        Console.WriteLine();

        Console.WriteLine("Обход в ширину:");
        graph.TraverseBreadthFirst(Console.WriteLine);
        Console.WriteLine();

        Console.WriteLine("Обход в глубину:");
        graph.TraverseDepthFirst(Console.WriteLine);
        Console.WriteLine();

        Console.WriteLine("Обход в глубину рекурсией:");
        graph.TraverseDepthFirstRecursive(Console.WriteLine);
    }
}
