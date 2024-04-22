namespace TreeTask;

internal class Program
{
    static void Main(string[] args)
    {
        BinarySearchTree<int> tree = new();

        tree.Add(8);
        tree.Add(4);
        tree.Add(12);
        tree.Add(2);
        tree.Add(6);
        tree.Add(10);
        tree.Add(14);
        tree.Add(1);
        tree.Add(3);
        tree.Add(5);
        tree.Add(7);
        tree.Add(9);
        tree.Add(11);
        tree.Add(13);
        tree.Add(15);

        Console.WriteLine("Заполним и выведем наше дерево");
        Console.WriteLine(tree);
        
        Console.WriteLine($"Проверим команду Contains(1): {tree.Contains(1)}");
        Console.WriteLine($"Проверим команду Remove(1): {tree.Remove(1)}; попробуем найти этот элемент: {tree.Contains(1)}");
        Console.WriteLine();

        Console.WriteLine("Проверим обходы");
        Console.WriteLine("В ширину:");
        tree.TraverseDepthFirst(Console.WriteLine);
        Console.WriteLine();
        Console.WriteLine("В ширину рекурсивный:");
        tree.TraverseDepthFirstRecursive(Console.WriteLine);
        Console.WriteLine();
        Console.WriteLine("В глубину:");
        tree.TraverseBreadthFirst(Console.WriteLine);
    }
}