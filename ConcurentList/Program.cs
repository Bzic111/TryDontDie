Console.WriteLine("Start");

ConcurentList<int> collection = new();

Console.WriteLine("Adding");
for (int i = 0; i < 100; i++)
{
    Thread thr = new Thread(new ThreadStart(() => collection.Add(i)));
    thr.Start();
    Thread.Sleep(100);
}

foreach (var item in collection)
{
    Console.Write(item + " ");
}

Console.WriteLine("Removing");
for (int i = 0; i < 50; i++)
{
    Thread thr = new Thread(new ThreadStart(() => collection.Remove(i)));
    thr.Start();
    Thread.Sleep(100);

}

Thread.Sleep(1000);
foreach (var item in collection)
{
    Console.Write(item + " ");
}
