using System.Collections;

namespace HashTableTask;

internal class MyHashTable<T> : ICollection<T>
{
    private List<T>[] _items = new List<T>[] { };

    public int Count { get; private set; }

    public bool IsReadOnly => false;

    private int _version = 0;

    public int GetHash()
    { return 1; }

    public void Add(T item)
    {
        throw new NotImplementedException();
    }

    public void Clear()
    {
        throw new NotImplementedException();
    }

    public bool Contains(T item)
    {
        throw new NotImplementedException();
    }

    public void CopyTo(T[] array, int arrayIndex)
    {
        throw new NotImplementedException();
    }

    public IEnumerator<T> GetEnumerator()
    {
        throw new NotImplementedException();
    }

    public bool Remove(T item)
    {
        throw new NotImplementedException();
    }

    IEnumerator IEnumerable.GetEnumerator()
    {
        throw new NotImplementedException();
    }
}
