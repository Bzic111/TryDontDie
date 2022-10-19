using System;
using System.Collections;

//Mutex mtx = new Mutex();
//for (int i = 0; i < 10; i++)
//{
//    Thread thr = new Thread(new ThreadStart(RunThread));
//    thr.Start();
//}

//void RunThread()
//{
//    mtx.WaitOne();
//    Console.WriteLine($"thread {Thread.CurrentThread.ManagedThreadId} start");
//    Thread.Sleep(1000);
//    Console.WriteLine($"thread {Thread.CurrentThread.ManagedThreadId} stop");
//    mtx.ReleaseMutex();
//}