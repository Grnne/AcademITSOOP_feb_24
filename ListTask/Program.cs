namespace ListTask;

internal class Program
{
    // TODO Спросить, надо ли делать проверку методов в консоли, спросить про исключения, доделать нуллабле проверки 
    static void Main(string[] args)
    {
        
        SinglyLinkedList<int> list1 = new SinglyLinkedList<int>();
        list1.AddFirst(new Node<int>(0));
        list1.AddAt(1, new Node<int>(1));
        list1.AddAt(2, new Node<int>(2));
        list1.AddAt(3, new Node<int>(3));
        list1.AddAt(4, new Node<int>(4));

        list1.Reverse();
        var list2 = list1.Copy();

        Console.WriteLine(list2.GetValueAt(0));
        Console.WriteLine(list2.GetValueAt(1));
        Console.WriteLine(list2.GetValueAt(2));
        Console.WriteLine(list2.GetValueAt(3));
        Console.WriteLine(list2.GetValueAt(4));
    }
}
