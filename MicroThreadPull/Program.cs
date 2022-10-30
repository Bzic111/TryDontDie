
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
    item.Run(CountToCount);

foreach (var item in list)
    pool.Release(item);

list.Clear();
Console.ReadKey(false);
Console.WriteLine("End of programm");

void CountToCount()
{
    var id = Thread.CurrentThread.Name;
    counter++;

    Console.WriteLine($"{id} = {counter}");
}
