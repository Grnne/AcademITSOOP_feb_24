namespace TreeTask;

public class BinarySearchTree<T>
{
    private Node<T>? _root;

    private readonly Comparer<T>? _comparer = Comparer<T>.Default;

    public int Count { get; private set; }

    public BinarySearchTree(T data)
    {
        _root = new Node<T>(data);
        Count++;
    }

    public BinarySearchTree(T data, Comparer<T> comparer)
    {
        if (comparer is null)
        {
            throw new ArgumentNullException(nameof(comparer), "Comparer can't be null");
        }

        _root = new Node<T>(data);
        _comparer = comparer;
        Count++;
    }

    public void TraverseDepthFirst(Action<T> action)
    {
        if (_root == null)
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
        if (_root == null)
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
        if (_root == null)
        {
            return;
        }

        TraverseDepthFirstRecursive(action, _root);
    }

    private static void TraverseDepthFirstRecursive(Action<T> action, Node<T> currentNode)
    {
        action.Invoke(currentNode.Data);

        if (currentNode.Left is null && currentNode.Right is null)
        {
            return;
        }

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
        if (_root == null)
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

    public bool Contains(T data) => GetNodeAndParent(data).Node != null;

    public bool Remove(T data)
    {
        if (_root is null)
        {
            return false;
        }

        Node<T>? parentNode = GetNodeAndParent(data).ParentNode;
        Node<T>? currentNode = GetNodeAndParent(data).Node;

        if (currentNode is null)
        {
            return false;
        }

        if (currentNode.Left is null || currentNode.Right is null)
        {
            RemoveNodeWithZeroOrSingleChild(currentNode, parentNode);

            return true;
        }

        RemoveNodeWithTwoChildren(currentNode, parentNode);

        return true;
    }

    private void RemoveNodeWithZeroOrSingleChild(Node<T> currentNode, Node<T>? parentNode)
    {
        if (currentNode.Left is null && currentNode.Right is null)
        {
            if (parentNode is null)
            {
                _root = null;
            }
            else if (parentNode.Left == currentNode)
            {
                parentNode.Left = null;
            }
            else
            {
                parentNode.Right = null;
            }

            Count--;

            return;
        }

        if (currentNode.Left is null || currentNode.Right is null)
        {
            Node<T> childNode;

            if (currentNode.Left is null)
            {
                childNode = currentNode.Right!;
            }
            else
            {
                childNode = currentNode.Left;
            }

            if (parentNode is null)
            {
                _root = childNode;
            }
            else if (parentNode.Left == currentNode)
            {
                parentNode.Left = childNode;
            }
            else
            {
                parentNode.Right = childNode;
            }

            Count--;
        }
    }

    private void RemoveNodeWithTwoChildren(Node<T> currentNode, Node<T>? parentNode)
    {
        Node<T> leftmostChild = currentNode.Right!;
        Node<T> leftmostChildParent = currentNode;

        if (leftmostChild.Left is null)
        {
            if (parentNode is null)
            {
                _root = leftmostChild;
            }
            else if (parentNode.Left == currentNode)
            {
                parentNode.Left = leftmostChild;
            }
            else
            {
                parentNode.Right = leftmostChild;
            }

            leftmostChild.Left = currentNode.Left;

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
        else if (parentNode.Left == currentNode)
        {
            parentNode.Left = leftmostChild;
        }
        else
        {
            parentNode.Right = leftmostChild;
        }

        if (leftmostChild.Right is null)
        {
            leftmostChildParent.Left = null;
        }
        else
        {
            leftmostChildParent.Left = leftmostChild.Right;
        }

        leftmostChild.Left = currentNode.Left;
        leftmostChild.Right = currentNode.Right;

        Count--;
    }

    private (Node<T>? Node, Node<T>? ParentNode) GetNodeAndParent(T data)
    {
        if (_root == null)
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
        return _comparer!.Compare(data1, data2);
    }

    public override string ToString() // TODO в стрингбилдер, возможно, в виде дерева, узнать как лучше сделать
    {
        string result = string.Empty;
        void action(T i) => result += i + Environment.NewLine;
        TraverseBreadthFirst(action);
        return result;
    }
}