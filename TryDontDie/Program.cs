using System;
using System.Collections;


int counter = 0;

ObjectPool<ClassicPullItem> pool = new();

List<ClassicPullItem> list = new List<ClassicPullItem>();
for (int i = 0; i < 10; i++)
{

    list.Add(pool.Get());
    list.Add(pool.Get());
    list.Add(pool.Get());

    foreach (var item in list)
    {
        item.Id = i;
        item.Run(CountToCount);
        Console.WriteLine(item.Id);
    }
    foreach (var item in list)
    {
        pool.Release(item);
    }
    list.Clear();
}
list.Add(pool.Get());
list.Add(pool.Get());
list.Add(pool.Get());
foreach (var item in list)
{
    item.Run(CountToCount);
}
foreach (var item in list)
{
    pool.Release(item);
}
list.Clear();
Console.ReadKey(false);
Console.WriteLine("End of programm");

void CountToCount()
{
    var id = Thread.CurrentThread.Name;
    counter++;

    Console.WriteLine($"{id} = {counter}");
}

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
public abstract class PullItem
{
    public int Id { get; set; }
    public Thread? _thread { get; set; }
    public abstract void Reset();
}
public sealed class ClassicPullItem : PullItem
{
    //public int Id { get; set; }
    public string Name { get; set; } = String.Empty;
    public Thread? _thread { get => base._thread; private set => base._thread = value; }
    public override void Reset()
    {
        Id = 0;
        //Name = string.Empty;
    }
    public Thread Run(Action act)
    {
        _thread = new Thread(new ThreadStart(act));
        _thread.Start();
        return _thread;
    }
}