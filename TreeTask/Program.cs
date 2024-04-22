namespace TreeTask;

internal class Program
{
    static void Main(string[] args)
    {
        // Надо переопределить тустринг через какой-то обход, чтоб сделать демонстрацию работы класса?
        BinarySearchTree<int> tree1 = new();

        tree1.Add(8);
        tree1.Add(4);
        tree1.Add(12);
        tree1.Add(2);
        tree1.Add(6);
        tree1.Add(10);
        tree1.Add(14);
        tree1.Add(1);
        tree1.Add(3);
        tree1.Add(5);
        tree1.Add(7);
        tree1.Add(9);
        tree1.Add(11);
        tree1.Add(13);
        tree1.Add(15);



        tree1.Remove(8);
    }
}