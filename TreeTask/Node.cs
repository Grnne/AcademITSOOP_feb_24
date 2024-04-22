namespace TreeTask;

internal class Node<T>(T item)
{
    public T Data { get; set; } = item;

    public Node<T>? Left { get; set; }

    public Node<T>? Right { get; set; }
}