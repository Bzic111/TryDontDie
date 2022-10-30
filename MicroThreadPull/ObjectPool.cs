public sealed class ObjectPool<TPullItem> where TPullItem : PullItem, new()
{
    private readonly Queue<TPullItem> _queue = new();
    public int PoolCount { get => _queue.Count; }
    public int MaxSize { get; private set; } = 0;
    public TPullItem Get()
    {
        return _queue.Count > 0 ? _queue.Dequeue() : new TPullItem();
    }
    public void SetMaxSize(int size) => MaxSize = size;
    public void Release(TPullItem item)
    {
        if (item is null)
            return;
        item.Reset();
        item.Id = item.Id == 0 ? _queue.Count + 1 : item.Id;
        if (MaxSize==0 || _queue.Count< MaxSize)
        {
            _queue.Enqueue(item);
        }
        else
        {
            throw new ArgumentOutOfRangeException("Reached maximum size of pool...");
        }
    }
}
