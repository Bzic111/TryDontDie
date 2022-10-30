



public sealed class ObjectPool<TPullItem> where TPullItem : PullItem, new()
{
    private readonly Queue<TPullItem> _queue = new();
    public int PoolCount { get => _queue.Count; }
    public TPullItem Get()
    {
        return _queue.Count > 0 ? _queue.Dequeue() : new TPullItem();
    }

    public void Release(TPullItem item)
    {
        if (item is null)
            return;
        item.Reset();
        item.Id = item.Id == 0 ? _queue.Count + 1 : item.Id;

        _queue.Enqueue(item);
    }
}
