namespace TreeTask;

internal class BinarySearchTree<T>
{
    private Node<T>? _root;

    public int Count { get; private set; }

    public BinarySearchTree()
    {
    }

    public BinarySearchTree(T item)
    {
        _root = new Node<T>(item);
        Count++;
    }

    public void Add(T item)
    {
        if (_root == null)
        {
            _root = new Node<T>(item);
        }
        else
        {
            Node<T> currentNode = _root;

        }


    }

    public T Search(T item)
    {
        return _root.Item;
    }

    public void Remove(T item)
    {

    }

    public void BreadthFirstSearch(T item)
    {
        if (_root == null)
        {
            return;
        }

        Queue<Node<T>> queue = new();
        Node<T> currentNode = _root;

        while (queue.Count > 0)
        {
            queue.Dequeue();

            if (currentNode.Left is not null)
            {
                currentNode = currentNode.Left;
                queue.Enqueue(currentNode);
            }

            if (currentNode.Left is not null)
            {
                currentNode = currentNode.Right;
                queue.Enqueue(currentNode);
            }
        }
    }

    public void DepthFirstSearchRecursive(T item)
    {

    }

    public void DepthFirstSearch(T item)
    {

    }
}