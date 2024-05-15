using System.Text;

namespace TreeTask;

public class BinarySearchTree<T>
{
    private Node<T>? _root;

    private readonly Comparer<T> _comparer;

    public int Count { get; private set; }

    public BinarySearchTree()
    {
        _comparer = Comparer<T>.Default;
    }

    public BinarySearchTree(Comparer<T>? comparer)
    {
        _comparer = comparer ?? Comparer<T>.Default;
    }

    public void TraverseDepthFirst(Action<T> action)
    {
        if (_root is null)
        {
            return;
        }

        Stack<Node<T>> stack = new();
        stack.Push(_root);

        while (stack.Count > 0)
        {
            Node<T> currentNode = stack.Pop();
            action.Invoke(currentNode.Data);

            if (currentNode.Right is not null)
            {
                stack.Push(currentNode.Right);
            }

            if (currentNode.Left is not null)
            {
                stack.Push(currentNode.Left);
            }
        }
    }

    public void TraverseBreadthFirst(Action<T> action)
    {
        if (_root is null)
        {
            return;
        }

        Queue<Node<T>> queue = new();
        queue.Enqueue(_root);

        while (queue.Count > 0)
        {
            Node<T> currentNode = queue.Dequeue();
            action.Invoke(currentNode.Data);

            if (currentNode.Left is not null)
            {
                queue.Enqueue(currentNode.Left);
            }

            if (currentNode.Right is not null)
            {
                queue.Enqueue(currentNode.Right);
            }
        }
    }

    public void TraverseDepthFirstRecursive(Action<T> action)
    {
        if (_root is null)
        {
            return;
        }

        TraverseDepthFirstRecursive(action, _root);
    }

    private static void TraverseDepthFirstRecursive(Action<T> action, Node<T> currentNode)
    {
        action.Invoke(currentNode.Data);

        if (currentNode.Left is not null)
        {
            TraverseDepthFirstRecursive(action, currentNode.Left);
        }

        if (currentNode.Right is not null)
        {
            TraverseDepthFirstRecursive(action, currentNode.Right);
        }
    }

    public void Add(T data)
    {
        if (_root is null)
        {
            _root = new Node<T>(data);
            Count++;

            return;
        }

        Node<T> currentNode = _root;

        while (true)
        {
            int comparisonResult = Compare(data, currentNode.Data);

            if (comparisonResult < 0)
            {
                if (currentNode.Left is null)
                {
                    currentNode.Left = new Node<T>(data);
                    Count++;

                    return;
                }

                currentNode = currentNode.Left;
            }
            else
            {
                if (currentNode.Right is null)
                {
                    currentNode.Right = new Node<T>(data);
                    Count++;

                    return;
                }

                currentNode = currentNode.Right;
            }
        }
    }

    public bool Contains(T data) => GetNodeAndParent(data).Node is not null;

    public bool Remove(T data)
    {
        if (_root is null)
        {
            return false;
        }

        (Node<T>? nodeToBeDeleted, Node<T>? parentNode) = GetNodeAndParent(data);

        if (nodeToBeDeleted is null)
        {
            return false;
        }

        if (nodeToBeDeleted.Left is null || nodeToBeDeleted.Right is null)
        {
            RemoveNodeWithZeroOrSingleChild(nodeToBeDeleted, parentNode);

            return true;
        }

        RemoveNodeWithTwoChildren(nodeToBeDeleted, parentNode);

        return true;
    }

    private void RemoveNodeWithZeroOrSingleChild(Node<T> nodeToBeDeleted, Node<T>? parentNode)
    {
        Node<T>? childNode = nodeToBeDeleted.Left ?? nodeToBeDeleted.Right;

        if (parentNode is null)
        {
            _root = childNode;
        }
        else if (parentNode.Left == nodeToBeDeleted)
        {
            parentNode.Left = childNode;
        }
        else
        {
            parentNode.Right = childNode;
        }

        Count--;
    }

    private void RemoveNodeWithTwoChildren(Node<T> nodeToBeDeleted, Node<T>? parentNode)
    {
        Node<T> leftmostChild = nodeToBeDeleted.Right!;
        Node<T> leftmostChildParent = nodeToBeDeleted;

        if (leftmostChild.Left is null)
        {
            if (parentNode is null)
            {
                _root = leftmostChild;
            }
            else if (parentNode.Left == nodeToBeDeleted)
            {
                parentNode.Left = leftmostChild;
            }
            else
            {
                parentNode.Right = leftmostChild;
            }

            leftmostChild.Left = nodeToBeDeleted.Left;

            Count--;

            return;
        }

        while (leftmostChild.Left is not null)
        {
            leftmostChildParent = leftmostChild;
            leftmostChild = leftmostChild.Left;
        }

        if (parentNode is null)
        {
            _root = leftmostChild;
        }
        else if (parentNode.Left == nodeToBeDeleted)
        {
            parentNode.Left = leftmostChild;
        }
        else
        {
            parentNode.Right = leftmostChild;
        }

        leftmostChildParent.Left = leftmostChild.Right;
        leftmostChild.Left = nodeToBeDeleted.Left;
        leftmostChild.Right = nodeToBeDeleted.Right;

        Count--;
    }

    private (Node<T>? Node, Node<T>? ParentNode) GetNodeAndParent(T data)
    {
        if (_root is null)
        {
            return (null, null);
        }

        Node<T>? currentNode = _root;
        Node<T>? parentNode = null;

        while (true)
        {
            int comparisonResult = Compare(data, currentNode.Data);

            if (comparisonResult == 0)
            {
                return (currentNode, parentNode);
            }

            if (comparisonResult < 0)
            {
                if (currentNode.Left is null)
                {
                    return (null, parentNode);
                }

                parentNode = currentNode;
                currentNode = currentNode.Left;
            }
            else
            {
                if (currentNode.Right is null)
                {
                    return (null, parentNode);
                }

                parentNode = currentNode;
                currentNode = currentNode.Right;
            }
        }
    }

    private int Compare(T data1, T data2)
    {
        return _comparer.Compare(data1, data2);
    }

    public override string ToString()
    {
        StringBuilder sb = new();

        sb.Append('[');
        TraverseBreadthFirst(d => sb.Append(d).Append(", "));
        sb.Remove(sb.Length - 2, 2);
        sb.Append(']');

        return sb.ToString();
    }
}