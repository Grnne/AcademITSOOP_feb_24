namespace ListTask;

public class SinglyLinkedList<T>
{
    public Node<T>? Head { get; set; }

    public int Count { get; set; } = 0;

    public T GetFirst()
    {
        if (Head is null)
        {
            throw new NullReferenceException("Element is null");
        }

        return Head.Item;
    }

    public T? GetValueAt(int index)
    {
        return GetElementAt(index)!.Item;
    }

    public T? SetValueAt(int index, T value)
    {
        Node<T> node = GetElementAt(index)!;
        T? oldValue = node.Item;
        node.Item = value;

        return oldValue;
    }

    public void AddFirst(Node<T> item)
    {
        Count++;

        if (Head is null)
        {
            Head = item;
        }
        else
        {
            item.Next = Head;
            Head = item;
        }
    }

    public void AddAt(int index, Node<T> item)
    {
        if (index > Count || index < 0)
        {
            throw new ArgumentOutOfRangeException($"Index {index} is out of range.");
        }

        if (index == 0)
        {
            AddFirst(item);
        }
        else
        {
            Node<T> prev = GetElementAt(index - 1)!;
            item.Next = prev.Next;
            prev.Next = item;
            Count++;
        }
    }

    public T RemoveFirst()
    {
        if (Head is null)
        {
            throw new NullReferenceException("Element is null");
        }

        T result = Head.Item;
        Head = Head.Next;
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
            Node<T> previousNode = GetElementAt(index - 1)!;
            T result = previousNode.Next.Item;
            previousNode.Next = previousNode.Next.Next;
            Count--;

            return result;
        }
    }

    public bool Remove(T value)
    {
        Node<T> node = Head!;

        for (int i = 0; i < Count; i++)
        {
            if (node.Item.Equals(value))
            {
                RemoveAt(i);
                return true;
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
            Head.Next.Next = Head;
            Head = Head.Next;

            return;
        }

        Node<T> node = Head.Next;
        Node<T> next;
        Node<T> prev = Head;

        for (int i = 0; i < Count - 1; i++)
        {
            next = node.Next; // следующая нода
            node.Next = prev; // меняем ссылку у текущей ноды
            prev = node; // предыдущая нода становится текущей
            node = next; // переход на следующую ноду
        }

        Head = prev;
    }

    public SinglyLinkedList<T> Copy()
    {
        SinglyLinkedList<T> copy = new SinglyLinkedList<T>();
        Node<T> node = Head;
        int i = 0;


        while (node != null)
        {
            copy.AddAt(i, new Node<T>(node.Item));
            i++;
            node = node.Next;
        }

        return copy;
    }

    public Node<T>? GetElementAt(int index)
    {
        if (index > Count || index < 0)
        {
            throw new ArgumentOutOfRangeException($"Index {index} is out of range.");
        }

        Node<T> node = Head!;

        for (int i = 0; i < index; i++)
        {
            node = node.Next!;
        }

        return node!;
    }
}