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

        Console.WriteLine("Зададим матрицу смежности как в лекции и сделаем обходы:");
        Console.WriteLine();

        Console.WriteLine("Обход в ширину:");
        graph.TraverseBreadthFirst(PrintVertex);
        Console.WriteLine();

        Console.WriteLine("Обход в глубину:");
        graph.TraverseDepthFirst(PrintVertex);
        Console.WriteLine();

        Console.WriteLine("Обход в глубину рекурсией:");
        graph.TraverseDepthFirstRecursive(PrintVertex);
        Console.WriteLine();
    }

    static void PrintVertex(int v) => Console.Write(v + " ");
}
