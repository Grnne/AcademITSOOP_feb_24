namespace ListTask;

internal class Program
{
    // TODO Спросить, надо ли делать проверку методов в консоли, спросить про исключения, доделать нуллабле проверки 
    static void Main(string[] args)
    {
        
        SinglyLinkedList<int> list1 = new SinglyLinkedList<int>();
        list1.AddFirst(new Node<int>(0));
        list1.ADD(1, new Node<int>(1));
        list1.ADD(2, new Node<int>(2));
        list1.ADD(3, new Node<int>(3));
        list1.ADD(4, new Node<int>(4));

        list1._head = new Node<int>(0);

    }
}
