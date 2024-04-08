using System.Collections;
using System.Diagnostics.CodeAnalysis;
using System.Text;

namespace HashTableTask;

internal class SimpleHashTable<T> : ICollection<T>
{
    private const int DefaultCapacity = 50;

    private readonly List<T?>?[] _lists;

    private int _version;

    public bool IsReadOnly => false;

    public int Count { get; private set; }

    public SimpleHashTable()
    {
        _lists = new List<T?>[DefaultCapacity];
    }

    public SimpleHashTable(int capacity)
    {
        if (capacity < 0)
        {
            throw new ArgumentOutOfRangeException(nameof(capacity), "List size must be greater than 0");
        }

        _lists = new List<T?>[capacity];
    }

    public void Add(T item)
    {
        int index = GetIndex(item);

        if (_lists[index] is null)
        {
            _lists[index] = [];
        }

        _lists[index]!.Add(item);
        Count++;
        _version++;
    }

    public bool Remove(T item)
    {
        int index = GetIndex(item);

        if (_lists[index] is null)
        {
            return false;
        }

        if (_lists[index]!.Remove(item))
        {
            Count--;
            _version++;

            return true;
        }

        return false;
    }

    public void Clear()
    {
        if (Count == 0)
        {
            return;
        }

        foreach (List<T?>? list in _lists)
        {
            list?.Clear();
        }

        _version++;
        Count = 0;
    }

    public bool Contains(T? item)
    {
        int index = GetIndex(item);

        return _lists[index] != null && _lists[index]!.Contains(item);
    }

    public void CopyTo(T?[] array, int arrayIndex)
    {
        if (array == null)
        {
            throw new ArgumentNullException(nameof(array), "Array is null");
        }

        if (arrayIndex < 0)
        {
            throw new ArgumentOutOfRangeException(nameof(arrayIndex), "Index must be greater than 0");
        }

        if (array.Length < arrayIndex + Count)
        {
            throw new ArgumentException($"Destination array was not long enough. Destination array length: {array.Length}, source length + destination index = {Count + arrayIndex}", nameof(array));
        }

        int i = arrayIndex;

        foreach (T item in this)
        {
            array[i] = item;
            i++;
        }
    }

    public IEnumerator<T> GetEnumerator()
    {
        int version = _version;

        foreach (List<T?>? list in _lists)
        {
            if (list is not null)
            {
                foreach (T? item in list)
                {
                    if (version != _version)
                    {
                        throw new InvalidOperationException("Collection was modified");
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

    private int GetIndex(T? item) => (item is null) ? 0 : Math.Abs(item.GetHashCode() % _lists.Length);

    public override string ToString()
    {
        if (Count == 0)
        {
            return "[]";
        }

        StringBuilder stringBuilder = new();

        stringBuilder.Append('[');

        foreach (T? item in this)
        {
            if (item is null)
            {
                stringBuilder.Append("null, ");
            }
            else
            {
                stringBuilder.Append(item).Append(", ");
            }
        }

        stringBuilder.Remove(stringBuilder.Length - 2, 2);
        stringBuilder.Append(']');

        return stringBuilder.ToString();
    }
}