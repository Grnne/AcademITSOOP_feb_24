using System.Collections;
using System.Diagnostics.CodeAnalysis;
using System.Text;

namespace ListTask;

public class SinglyLinkedList<T> : IEnumerable<T>
{
    private Node<T>? _head;

    public int Count { get; private set; }

    public T this[int index]
    {
        get
        {
            CheckIndex(index);

            return GetNode(index)!.Data;
        }

        set
        {
            CheckIndex(index);

            Node<T> node = GetNode(index);
            node.Data = value;
        }
    }

    public T GetFirst()
    {
        CheckIsListEmpty();

        return _head.Data;
    }

    public void AddFirst(T data)
    {
        _head = new Node<T>(data, _head!);
        Count++;
    }

    public void Add(T data)
    {
        Add(Count, data);
    }

    public void Add(int index, T data)
    {
        if (index < 0 || index > Count)
        {
            throw new ArgumentOutOfRangeException(nameof(index), $"Index {index} is out of range. Possible index range: from 0 to {Count}");
        }

        if (index == 0)
        {
            AddFirst(data);

            return;
        }

        Node<T> previousNode = GetNode(index - 1);
        previousNode.Next = new Node<T>(data, previousNode.Next);
        Count++;
    }

    public T RemoveFirst()
    {
        CheckIsListEmpty();

        T removedData = _head.Data;
        _head = _head.Next;
        Count--;

        return removedData;
    }

    public T RemoveAt(int index)
    {
        CheckIndex(index);

        if (index == 0)
        {
            return RemoveFirst();
        }

        Node<T> previousNode = GetNode(index - 1);
        T removedData = previousNode.Next!.Data;
        previousNode.Next = previousNode.Next.Next;
        Count--;

        return removedData;
    }

    public bool Remove(T data)
    {
        if (_head == null)
        {
            return false;
        }

        if (Equals(_head.Data, data))
        {
            RemoveFirst();

            return true;
        }

        Node<T> previousNode = _head;

        while (previousNode.Next != null)
        {
            if (Equals(previousNode.Next.Data, data))
            {
                previousNode.Next = previousNode.Next.Next;
                Count--;
                return true;
            }

            previousNode = previousNode.Next;
        }

        return false;
    }

    public void Reverse()
    {
        if (Count <= 1)
        {
            return;
        }

        Node<T>? currentNode = _head;
        Node<T>? previousNode = null;

        while (currentNode != null)
        {
            Node<T>? nextNode = currentNode.Next;
            currentNode.Next = previousNode;

            previousNode = currentNode;
            currentNode = nextNode;
        }

        _head = previousNode;
    }

    public SinglyLinkedList<T> Copy()
    {
        SinglyLinkedList<T> listCopy = new();

        if (_head is null)
        {
            return listCopy;
        }

        listCopy._head = new Node<T>(_head.Data);
        listCopy.Count = Count;

        Node<T> copyNode = listCopy._head;
        Node<T>? sourceNode = _head.Next;

        while (sourceNode is not null)
        {
            copyNode.Next = new Node<T>(sourceNode.Data);

            copyNode = copyNode.Next;
            sourceNode = sourceNode.Next;
        }

        return listCopy;
    }

    private void CheckIndex(int index)
    {
        if (index < 0 || index >= Count)
        {
            throw new ArgumentOutOfRangeException(nameof(index), $"Index {index} is out of range. Possible index range: from 0 to {Count - 1}");
        }
    }

    [MemberNotNull(nameof(_head))]
    private void CheckIsListEmpty()
    {
        if (_head is null)
        {
            throw new InvalidOperationException("List is empty");
        }
    }

    private Node<T> GetNode(int index)
    {
        Node<T> node = _head!;

        for (int i = 0; i < index; i++)
        {
            node = node.Next!;
        }

        return node;
    }

    public IEnumerator<T> GetEnumerator()
    {
        Node<T>? currentNode = _head;

        while (currentNode != null)
        {
            yield return currentNode.Data;

            currentNode = currentNode.Next;
        }
    }

    IEnumerator IEnumerable.GetEnumerator()
    {
        return GetEnumerator();
    }

    public override string ToString()
    {
        if (_head is null)
        {
            return "[]";
        }

        StringBuilder stringBuilder = new StringBuilder();

        stringBuilder.Append('[');
        stringBuilder.AppendJoin(", ", this);
        stringBuilder.Append(']');

        return stringBuilder.ToString();
    }
}