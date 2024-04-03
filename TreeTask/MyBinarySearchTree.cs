using System.Xml.Linq;

namespace TreeTask;

internal class MyBinarySearchTree<T>
{
    private Node<T>? _root;

    public int Count { get; private set; }

    public MyBinarySearchTree()
    {
    }

    public MyBinarySearchTree(T item)
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
            currentNode = currentNode.Left;
            queue.Enqueue(currentNode);

            currentNode = currentNode.Right;
            queue.Enqueue(currentNode);
        }
    }

    public void DepthFirstSearchRecursive(T item)
    {

    }

    public void DepthFirstSearch(T item)
    {

    }
}