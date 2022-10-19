using System;

int count = 1;
object lockObject = new object();

Console.WriteLine("Start");

class ConcurentList<T> where T:class
{
	object locker = new();
    private List<T> container { get; set; }
	public int Count {get => container.Count;}
	public ConcurentList(int counter = 0)
	{
		container = new List<T>(counter);
	}
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
}


//for (int i = 0; i < 5; i++)
//{
//    Thread thr = new Thread(new ThreadStart(()=>CountMethod(i)));
//    thr.Start();
//}
//Thread.Sleep(1000);
//Console.WriteLine("Stop");
//void CountMethod(int threadId)
//{
//    lock (lockObject)
//    {
//        count = 1;
//        for (int i = 0; i < 10; i++)
//        {
//            Console.WriteLine($"{count} in {threadId}");
//            count++;
//            Thread.Sleep(250);
//        }
//    }
//}
////Thread thr = new Thread(new ThreadStart(Method));
////thr.Start();
////Thread.Sleep(9000);
////Console.WriteLine("Stop");


////    void Method(){
////	for (int i = 0; i < 1000; i++)
////	{
////		Console.WriteLine(i);
////		Thread.Sleep(250);
////	}
////}