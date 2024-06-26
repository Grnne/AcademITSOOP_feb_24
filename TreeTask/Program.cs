﻿namespace TreeTask;

internal class Program
{
    static void Main(string[] args)
    {
        BinarySearchTree<int> tree = new();

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

        int index = 1;
        Console.WriteLine($"Проверим команду Contains(index): {tree.Contains(index)}");
        Console.WriteLine($"Проверим команду Remove(index): {tree.Remove(index)}; попробуем найти этот элемент: {tree.Contains(index)}");
        Console.WriteLine();

        Console.WriteLine("Проверим обходы");
        Console.WriteLine("В глубину:");
        tree.TraverseDepthFirst(PrintNode);
        Console.WriteLine();
        Console.WriteLine("В глубину рекурсивный:");
        tree.TraverseDepthFirstRecursive(PrintNode);
        Console.WriteLine();
        Console.WriteLine("В ширину:");
        tree.TraverseBreadthFirst(PrintNode);
    }

    static void PrintNode(int d) => Console.Write(d + " ");
}