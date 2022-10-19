




class ConcurentList<T> /*: IEnumerable<T>*/ where T : struct
{
    object locker = new();
    private List<T> container { get; set; }
    public int Count { get => container.Count; }
    public ConcurentList(int counter = 0) => container = new List<T>(counter);

    public void Add(T item)
    {
        lock (locker)
        {
            container.Add(item);
        }
    }

    public void RemoveAt(int index)
    {
        lock (locker)
        {
            container.RemoveAt(index);
        }
    }

    public bool Remove(T item)
    {
        lock (locker)
        {
            return container.Remove(item);
        }
    }

    public IEnumerator<T> GetEnumerator() => container.GetEnumerator();
}