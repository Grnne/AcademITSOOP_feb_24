namespace TreeTask;

public class BinarySearchTree<T>
{
    private Node<T>? _root;

    private  readonly Comparer<T>? _comparer = Comparer<T>.Default;

    public int Count { get; private set; }

    public BinarySearchTree()
    {
    }

    public BinarySearchTree(T item)
    {
        _root = new Node<T>(item);
        Count++;
    }

    public BinarySearchTree(T item, Comparer<T> comparer)
    {
        if (comparer is null)
        {
            throw new ArgumentNullException(nameof(comparer), "Comparer can't be null");
        }

        _root = new Node<T>(item);
        _comparer = comparer;
        Count++;
    }

    public bool BreadthFirstSearch(T item)
    {
        if (_root == null)
        {
            return false;
        }

        Stack<Node<T>> stack = new();
        stack.Push(_root);

        while (stack.Count > 0)
        {
            Node<T> currentNode = stack.Pop();

            if (Compare(item, currentNode.Data) == 0)
            {
                return true;
            }

            if (currentNode.Left is not null)
            {
                currentNode = currentNode.Left;
                stack.Push(currentNode);
            }

            if (currentNode.Right is not null)
            {
                currentNode = currentNode.Right;
                stack.Push(currentNode);
            }
        }

        return false;
    }

    public bool DepthFirstSearch(T item)
    {
        if (_root == null)
        {
            return false;
        }

        Queue<Node<T>> queue = new();
        queue.Enqueue(_root);

        while (queue.Count > 0)
        {
            Node<T> currentNode = queue.Dequeue();

            if (Compare(item, currentNode.Data) == 0)
            {
                return true;
            }

            if (currentNode.Right is not null)
            {
                currentNode = currentNode.Right;
                queue.Enqueue(currentNode);
            }

            if (currentNode.Left is not null)
            {
                currentNode = currentNode.Left;
                queue.Enqueue(currentNode);
            }
        }

        return false;
    }

    public bool DepthFirstSearchRecursive(T item)
    {
        if (_root == null)
        {
            return false;
        }

        return DepthFirstWalkRecursive(item, _root);
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
            int comparisonResult = Compare(data);

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
                else
                {
                    currentNode = currentNode.Right;
                }
            }
        }
    }

    public bool Contains(T item)
    {
        if (Compare(SearchNodesFamily(item, out _).Data, item) == 0)
        {
            return true;
        }

        return false;
    }

    public bool Remove(T item)
    {
        if (_root is null)
        {
            return false;
        }

        Node<T>? parentNode;
        Node<T>? currentNode = SearchNodesFamily(item, out parentNode);

        if (currentNode is null)
        {
            return false;
        }

        if (currentNode.Left is null && currentNode.Right is null)
        {
            RemoveLeaf(currentNode, parentNode);

            return true;
        }

        if (currentNode.Left is null || currentNode.Right is null)
        {
            RemoveNodeWithZeroOrSingleChild(currentNode, parentNode);

            return true;
        }

        RemoveNodeWithTwoChildren(currentNode, parentNode);

        return true;
    }

    private void RemoveLeaf(Node<T> currentNode, Node<T>? parentNode)
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
    }

    private void RemoveNodeWithZeroOrSingleChild(Node<T> currentNode, Node<T>? parentNode)
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

    private void RemoveNodeWithTwoChildren(Node<T> currentNode, Node<T>? parentNode) // TODO перепроверить
    {
        Node<T> leftmostChild = currentNode.Right!;
        Node<T>? leftmostChildParent = currentNode;

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

    private static bool DepthFirstWalkRecursive(T item, Node<T> currentNode)
    {
        if (Compare(item, currentNode.Data) == 0)
        {
            return true;
        }

        if (currentNode.Left is null && currentNode.Right is null)
        {
            return false;
        }

        if (currentNode.Left is not null)
        {
            DepthFirstWalkRecursive(item, currentNode.Left);
        }

        if (currentNode.Right is not null)
        {
            DepthFirstWalkRecursive(item, currentNode.Right);
        }

        return false;
    }

    private Node<T>? SearchNodesFamily(T item, out Node<T>? parentNode) // Возможно, лучше кортеж возвращать?
    {
        if (item is null)
        {
            throw new ArgumentNullException(nameof(item), "Argument cant be null");
        }

        parentNode = null;

        if (_root == null)
        {
            return null;
        }

        if (item.Equals(_root.Data))
        {
            return _root;
        }

        Node<T>? currentNode = _root;

        while (0 == 0)
        {
            int comparisonResult = Compare(item, currentNode.Data);

            if (comparisonResult == 0)
            {
                return currentNode;
            }

            if (comparisonResult < 0)
            {
                if (currentNode.Left is null)
                {
                    return null;
                }

                parentNode = currentNode;
                currentNode = currentNode.Left;
            }
            else
            {
                if (currentNode.Right is null)
                {
                    return null;
                }

                parentNode = currentNode;
                currentNode = currentNode.Right;
            }
        }
    }

    private int Compare(T data1, T data2) // TODO Возможно надо сделать нормальный компаратор
    {
        return _comparer!.Compare(data1, data2);
    }
}