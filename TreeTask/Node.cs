namespace TreeTask;

internal class Node<T>(T data)
{
    public T Data { get; set; } = data;

    public Node<T>? Left { get; set; }

    public Node<T>? Right { get; set; }
}