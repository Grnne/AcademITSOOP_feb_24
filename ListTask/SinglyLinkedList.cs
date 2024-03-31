using System.Collections;

namespace ListTask;

public class SinglyLinkedList<T> : IEnumerable<T>
{
    private Node<T>? _head;

    public int Count { get; private set; }

    public T this[int index]
    {
        get
        {
            if (_head is null)
            {
                throw new NullReferenceException("Element is null");
            }

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
        if (_head is null)
        {
            throw new InvalidOperationException("List is empty");
        }

        return _head.Item;
    }

    public void AddFirst(T item)
    {
        if (_head is null)
        {
            _head =  new Node<T>(item);
        }
        else
        {
            _head.Next = _head;
            _head = new Node<T>(item);
        }

        Count++;
    }

    public void Add(int index, T item)
    {
        if (index < 0 || index > Count)
        {
            throw new ArgumentOutOfRangeException(nameof(index), $"Index {index} is out of range.");
        }

        if (index == 0)
        {
            AddFirst(item);
        }
        else
        {
            Node<T> prev = GetNode(index - 1)!;
            node.Next = prev.Next;
            prev.Next = new Node<T>(item);
            Count++;
        }
    }

    public T RemoveFirst()
    {
        if (_head is null)
        {
            throw new InvalidOperationException("List is empty");
        }

        T result = _head.Item;
        _head = _head.Next;
        Count--;

        return result;
    }

    public T RemoveAt(int index)
    {
        if (index == 0)
        {
            return RemoveFirst();
        }
        else
        {
            Node<T> previousNode = GetNode(index - 1)!;
            T result = previousNode.Next.Item;
            previousNode.Next = previousNode.Next.Next;
            Count--;

            return result;
        }
    }

    public bool Remove(T item)
    {
        Node<T> node = _head!;

        for (int i = 0; i < Count; i++)
        {
            if (node.Item.Equals(item))
            {
                RemoveAt(i);
                return true;
                Count--;
            }
        }

        return false;
    }

    public void Reverse()
    {
        if (Count == 1)
        {
            return;
        }

        if (Count == 2)
        {
            _head.Next.Next = _head;
            _head = _head.Next;

            return;
        }

        Node<T> node = _head.Next;
        Node<T> next;
        Node<T> prev = _head;

        for (int i = 0; i < Count - 1; i++)
        {
            next = node.Next; // следующая нода
            node.Next = prev; // меняем ссылку у текущей ноды
            prev = node; // предыдущая нода становится текущей
            node = next; // переход на следующую ноду
        }

        _head = prev;
    }

    public SinglyLinkedList<T> Copy()
    {
        SinglyLinkedList<T> copy = new SinglyLinkedList<T>();
        Node<T> node = _head;
        int i = 0;


        while (node != null)
        {
            copy.ADD(i, new Node<T>(node.Item));
            i++;
            node = node.Next;
        }

        return copy;
    }

    private Node<T> GetNode(int index)
    {
        if (index < 0 || index > Count)
        {
            throw new ArgumentOutOfRangeException(nameof(index), $"Index {index} is out of range.");
        }

        Node<T>? node = _head;

        for (int i = 0; i < index; i++)
        {
            node = node.Next;
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
        string result = string.Empty;

        if (_head is null)
        {
            return "null";
        }
        
        foreach (T node in this)
        {
            result += _head.Item;
        }

        return result;
    }
}