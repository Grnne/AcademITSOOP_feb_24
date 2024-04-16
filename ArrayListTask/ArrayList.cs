using System;
using System.Collections;
using System.Text;

namespace ArrayListTask;

public class ArrayList<T> : IList<T>
{
    private const int DefaultCapacity = 6;

    private T[] _items;

    private int _version;

    public int Capacity
    {
        get => _items.Length;

        set
        {
            if (value < Count)
            {
                throw new ArgumentOutOfRangeException(nameof(value), $"Capacity is less than the current items count. Capacity: {value}; Count: {Count}");
            }

            if (value == _items.Length)
            {
                return;
            }

            if (value > 0)
            {
                Array.Resize(ref _items, value);
            }
            else
            {
                _items = Array.Empty<T>();
            }
        }
    }

    public bool IsReadOnly => false;

    public int Count { get; private set; }

    public T this[int index]
    {
        get
        {
            CheckIndex(index);

            return _items[index];
        }

        set
        {
            CheckIndex(index);
            _items[index] = value;
            _version++;
        }
    }

    public ArrayList()
    {
        _items = new T[DefaultCapacity];
    }

    public ArrayList(int capacity)
    {
        if (capacity < 0)
        {
            throw new ArgumentOutOfRangeException(nameof(capacity), $"Capacity must be greater than zero, capacity: {capacity}");
        }

        if (capacity == 0)
        {
            _items = Array.Empty<T>();
        }
        else
        {
            _items = new T[capacity];
        }
    }

    public void Add(T item)
    {
        Insert(Count, item);
    }

    public void Insert(int index, T item)
    {
        if (index < 0 || index > Count)
        {
            throw new ArgumentOutOfRangeException(nameof(index), $"Argument is out of range. Must be in range from 0 to {Count}. Index: {index}");
        }

        if (Count == _items.Length)
        {
            IncreaseCapacity();
        }

        if (index < Count)
        {
            Array.Copy(_items, index, _items, index + 1, Count - index);
        }

        _items[index] = item;
        Count++;
        _version++;
    }

    public int IndexOf(T item)
    {
        for (int i = 0; i < Count; i++)
        {
            if (Equals(_items[i], item))
            {
                return i;
            }
        }

        return -1;
    }

    public bool Contains(T item)
    {
        return IndexOf(item) >= 0;
    }

    public void CopyTo(T[] array, int arrayIndex)
    {
        if (array is null)
        {
            throw new ArgumentNullException(nameof(array), "Destination array cant be null.");
        }

        if (array.Length < Count + arrayIndex)
        {
            throw new ArgumentException($"Destination array was not long enough. Destination array length: {array.Length}, source length + destination index = {Count + arrayIndex}", nameof(array));
        }

        if (array.Length <= arrayIndex)
        {
            throw new ArgumentOutOfRangeException(nameof(arrayIndex), $"Destination index is out of range. Must be in range from 0 to {array.Length - 1}. Index: {arrayIndex}");
        }
        Array.Copy(_items, 0, array, arrayIndex, Count);
    }

    public bool Remove(T item)
    {
        int index = IndexOf(item);

        if (index < 0)
        {
            return false;
        }

        RemoveAt(index);

        return true;
    }

    public void RemoveAt(int index)
    {
        CheckIndex(index);
        Count--;

        if (index < Count)
        {
            Array.Copy(_items, index + 1, _items, index, Count - index);
        }

        _items[Count] = default!;
        _version++;
    }

    public void Clear()
    {
        if (Count == 0)
        {
            return;
        }

        Array.Clear(_items, 0, Count);
        Count = 0;
        _version++;
    }

    public IEnumerator<T> GetEnumerator()
    {
        int version = _version;

        for (int i = 0; i < Count; ++i)
        {
            if (version != _version)
            {
                throw new InvalidOperationException("Collection was modified");
            }

            yield return _items[i];
        }
    }

    IEnumerator IEnumerable.GetEnumerator()
    {
        return GetEnumerator();
    }

    private void CheckIndex(int index)
    {
        if (index < 0 || index >= Count)
        {
            throw new ArgumentOutOfRangeException(nameof(index), $"Argument is out of range. Must be in range from 0 to {Count - 1}. Index: {index}");
        }
    }

    private void IncreaseCapacity()
    {
        Capacity = _items.Length == 0 ? DefaultCapacity : 2 * _items.Length;
    }

    public void TrimExcess()
    {
        if (Count < Capacity * 0.9)
        {
            Capacity = Count;
        }
    }

    public override string ToString()
    {
        StringBuilder stringBuilder = new();

        stringBuilder.Append('[');
        stringBuilder.AppendJoin(", ", this);
        stringBuilder.Append(']');

        return stringBuilder.ToString();
    }
}