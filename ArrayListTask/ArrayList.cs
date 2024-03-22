using System.Collections;

namespace ArrayListTask;

public class ArrayList<T> : IList<T>
{
    private const int DefaultCapacity = 6;

#pragma warning disable CA1825 // не совсем понял зачем оно
    private static readonly T[] s_emptyArray = new T[0];
#pragma warning restore CA1825

    private T[] _items = new T[DefaultCapacity];

    private int _size;

    public int Count => _size;

    private int _version = 0;

    public int Capacity
    {
        get => _items.Length;
        set
        {
            if (value < _size)
            {
                throw new ArgumentOutOfRangeException(nameof(value), $"Capacity is less than the current array size. Capacity: {value} Size: {_size - 1}");
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
                _items = s_emptyArray;
            }


        }
    }

    public bool IsReadOnly => false;

    public T this[int index]
    {
        get
        {
            if ((index < 0) || (index >= _size))
            {
                throw new IndexOutOfRangeException($"Index is out of range. Must be in range from 0 to {_size - 1}");
            }

            return _items[index];
        }

        set
        {
            if ((index < 0) || (index >= _size))
            {
                throw new IndexOutOfRangeException($"Index is out of range. Must be in range from 0 to {_size - 1}");
            }

            _items[index] = value;
        }
    }

    public ArrayList()
    {
        _items = s_emptyArray;
    }

    public ArrayList(int capacity)
    {
        if (capacity < 0)
        {
            throw new ArgumentOutOfRangeException(nameof(capacity), $"Capacity must be more than zero, capacity: {capacity}!");
        }
        if (capacity == 0)
        {
            _items = s_emptyArray;
        }
        else
        {
            _items = new T[capacity];
        }
    }

    public void Add(T item)
    {
        Insert(_size, item);
    }

    public void Insert(int index, T item)
    {
        if (index < 0 || index > _size)
        {
            throw new ArgumentOutOfRangeException(nameof(index), $"Index is out of range. Must be in range from 0 to {_size - 1}");
        }

        if (_size == _items.Length)
        {
            Grow(_size + 1);
        }

        if (index < _size)
        {
            Array.Copy(_items, index, _items, index + 1, _size - index);
        }

        _items[index] = item;
        _size++;
        _version++;
    }

    public int IndexOf(T item)
    {
        for (int i = 0; i < _size; i++)
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
        if (IndexOf(item) >= 0)
        {
            return true;
        }

        return false;
    }

    public void CopyTo(T[] array, int arrayIndex)
    {
        if (array is null)
        {
            throw new ArgumentNullException(nameof(array), "Destination array cant be null.");
        }

        if (array.Length < _size + arrayIndex)
        {
            throw new ArgumentOutOfRangeException(nameof(array), "Destination array must be greater then source array + index.");
        }

        Array.Copy(_items, 0, array, arrayIndex, _items.Length);
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
        if (index < 0 || index > _size)
        {
            throw new ArgumentOutOfRangeException(nameof(index), $"Index is out of range. Must be in range from 0 to {_size - 1}");
        }

        if (index < _size - 1)
        {
            Array.Copy(_items, index + 1, _items, index, _size - index - 1);
        }

        _items[_size - 1] = default;
        _size--;
        _version++;
    }

    public void Clear()
    {
        if (Count == 0)
        {
            return;
        }

        Array.Clear(_items, 0, _items.Length);
        _size = 0;
        _version++;
    }

    public IEnumerator<T> GetEnumerator()
    {
        int version = _version;

        for (int i = 0; i < _size; ++i)
        {
            if (version != _version)
            {
                throw new InvalidOperationException("Collection were modified");
            }

            yield return _items[i];
        }
    }

    IEnumerator IEnumerable.GetEnumerator()
    {
        return GetEnumerator();
    }

    private void Grow(int capacity)
    {
        int newCapacity = _items.Length == 0 ? DefaultCapacity : 2 * _items.Length;

        if (newCapacity < capacity)
        {
            newCapacity = capacity;
        }

        Capacity = newCapacity;
    }

    public void TrimExcess()
    {
        if (_size < Capacity * 0.9)
        {
            Capacity = _size;
        }
    }

    public override string ToString()
    {
        return "[" + string.Join(", ", _items) + "]"; // Спросить почему и как исправить
    }
}