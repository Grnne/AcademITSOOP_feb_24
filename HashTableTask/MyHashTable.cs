using System.Collections;
using System.Text;

namespace HashTableTask;

internal class MyHashTable<T> : ICollection<T>
{
    private int _defaultCapacity = 50;

    private List<T>[] _lists = new List<T>[] { };

    public int Count { get; private set; }

    public bool IsReadOnly => false;

    private int _version = 0;

    public MyHashTable()
    {
        _lists = new List<T>[_defaultCapacity];
    }

    public MyHashTable(int capacity)
    {
        if (capacity < 0)
        {
            throw new ArgumentOutOfRangeException(nameof(capacity), "List size must be greater than 0");
        }

        _lists = new List<T>[capacity];
    }

    public void Add(T item)
    {
        int index = GetHash(item);

        if (_lists[index] is null)
        {
            _lists[index] = new List<T>();
        }

        _lists[index].Add(item);
        Count++;
        _version++;
    }

    public bool Remove(T item)
    {
        int index = GetHash(item);

        if (_lists[index] is null)
        {
            return false;
        }

        if (_lists[index].Remove(item))
        {
            Count--;
            _version++;

            return true;
        }

        return false;
    }

    public void Clear() // Прошлые листы сборщик мусора соберет сам?
    {
        _lists = new List<T>[0];
        _version++;
        Count = 0;
    }

    public bool Contains(T item)
    {
        int index = GetHash(item);

        if (_lists[index] is not null)
        {
            return _lists[index].Contains(item);
        }

        return false;
    }

    public void CopyTo(T[] array, int arrayIndex)
    {
        if (array == null)
        {
            throw new ArgumentNullException(nameof(array), "Array is empty");
        }

        if (arrayIndex < 0)
        {
            throw new IndexOutOfRangeException("Index must be greater than 0");
        }

        if (array.Length < arrayIndex + Count)
        {
            throw new InvalidOperationException("Initial collection cant be greater than target array");

        }

        foreach (T item in this)
        {
            array[arrayIndex] = item;
            arrayIndex++;
        }
    }

    public IEnumerator<T> GetEnumerator()
    {
        int version = _version;

        foreach (List<T> list in _lists)
        {
            if (list is not null)
            {
                foreach (T item in list)
                {
                    if (version != _version)
                    {
                        throw new InvalidOperationException("Collection were modified");
                    }

                    yield return item;
                }
            }
        }
    }

    IEnumerator IEnumerable.GetEnumerator()
    {
        return GetEnumerator();
    }

    private int GetHash(T item) => Math.Abs((item is null) ? 0 : item.GetHashCode() % _lists.Length);

    public override string ToString()
    {
        StringBuilder stringBuilder = new StringBuilder();

        stringBuilder.Append("[");

        foreach (T item in this)
        {
            stringBuilder.Append(item + ", ");
        }

        if (stringBuilder.Length > 1)
        {
            stringBuilder.Remove(stringBuilder.Length - 2, 2); 
        }

        stringBuilder.Append("]");

        return stringBuilder.ToString();
    }
}