namespace ListTask;

 internal class Node<T>
{
    public T Data { get; set; }

    public Node<T>? Next { get; set; }

    public Node(T data)
    {
        Data = data;
    }

    public Node(T Data, Node<T>? next)
    {
        this.Data = Data;
        Next = next;
    }
}