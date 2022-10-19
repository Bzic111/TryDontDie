using System;
using System.Collections;

Random random = new Random();




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