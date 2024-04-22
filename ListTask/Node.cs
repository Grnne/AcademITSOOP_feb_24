namespace ListTask;

internal class Node<T>
{
    public T Data { get; set; }

    public Node<T>? Next { get; set; }

    public Node(T data)
    {
        Data = data;
    }

    public Node(T data, Node<T>? next)
    {
        Data = data;
        Next = next;
    }
}