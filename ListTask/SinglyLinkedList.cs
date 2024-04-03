using System;
using System.Collections;
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
            CheckIsListEmpty();

            return GetNode(index)!.Item;
        }

        set
        {
            // А как мне в индексаторе вернуть прошлое значение?
            Node<T> node = GetNode(index)!;
            //T? oldItem = node.Item;
            node.Item = value;

            //return oldItem;
        }
    }

    public T GetFirst()
    {
        CheckIsListEmpty();

        return _head!.Item;
    }

    public void AddFirst(T item)
    {
        _head = new Node<T>(item, _head!);
        Count++;
    }

    public void Add(T item) // Добавил, чтоб получалось инициализировать список через new() {1, 3, 34}
    {
        Add(Count, item);
    }

    public void Add(int index, T item)
    {
        ValidateIndex(index);

        if (index == 0)
        {
            AddFirst(item);

            return;
        }

        Node<T> previousNode = GetNode(index - 1);
        previousNode.Next = new Node<T>(item, previousNode.Next!);
        Count++;
    }

    public T RemoveFirst()
    {
        CheckIsListEmpty();

        T deletedItem = _head!.Item;
        _head = _head.Next;
        Count--;

        return deletedItem;
    }

    public T RemoveAt(int index)
    {
        ValidateIndex(index);

        if (index == 0)
        {
            return RemoveFirst();
        }

        Node<T> previousNode = GetNode(index - 1)!;
        T deletedItem = previousNode.Next!.Item;
        previousNode.Next = previousNode.Next.Next;
        Count--;

        return deletedItem;

    }

    public bool Remove(T item)
    {
        if (_head == null)
        {
            return false;
        }

        if (Equals(_head.Item, item))
        {
            RemoveFirst();

            return true;
        }

        Node<T>? previousNode = _head;

        while (previousNode.Next != null)
        {
            if (Equals(previousNode.Next.Item, item))
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

        Node<T> currentNode = _head!;
        Node<T>? previousNode = null;

        for (int i = 0; i < Count; i++)
        {
            Node<T>? nextNode = currentNode.Next;
            currentNode.Next = previousNode;

            previousNode = currentNode;
            currentNode = nextNode!;
        }

        _head = previousNode;
    }

    public SinglyLinkedList<T> Copy()
    {
        SinglyLinkedList<T> copy = new();

        if (_head is null)
        {
            return copy;
        }

        copy._head = new Node<T>(_head.Item);
        copy.Count = Count;

        Node<T> currentNode = copy._head;
        Node<T> sourceNode = _head.Next!;

        while (sourceNode is not null)
        {
            currentNode.Next = new Node<T>(sourceNode.Item);

            currentNode = currentNode.Next;
            sourceNode = sourceNode.Next!;
        }

        return copy;
    }

    private void ValidateIndex(int index)
    {
        if (index < 0 || index > Count)
        {
            throw new ArgumentOutOfRangeException(nameof(index), $"Index {index} is out of range.");
        }
    }

    private void CheckIsListEmpty()
    {
        if (_head is null)
        {
            throw new InvalidOperationException("List is empty");
        }
    }

    private Node<T> GetNode(int index)
    {
        Node<T>? node = _head;

        for (int i = 0; i < index; i++)
        {
            node = node!.Next;
        }

        return node;
    }

    public IEnumerator<T> GetEnumerator()
    {
        var currentNode = _head;

        while (currentNode != null)
        {
            yield return currentNode.Item;

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
            return "null";
        }

        StringBuilder stringBuilder = new StringBuilder();

        stringBuilder.Append('[');

        foreach (T item in this)
        {
            stringBuilder.Append(item + ", ");
        }

        stringBuilder.Remove(stringBuilder.Length - 2, 2);
        stringBuilder.Append(']');

        return stringBuilder.ToString();
    }
}