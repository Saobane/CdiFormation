using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Producer_Consumer_Console
{
   public  class MyProducerConsumer
    {
        static Object baton = new Object();
        static Queue<int> myQueue = new Queue<int>();

        static Random rnd = new Random();

        public static void Produce()
        {
            int tmp;
            while (true)
            {
                lock (baton)
                {
                    tmp = rnd.Next(20);
                    Console.WriteLine("Producer Thread {0} produced : {1} ", Thread.CurrentThread.ManagedThreadId, tmp);
                    Monitor.Wait(baton);
                    myQueue.Enqueue(tmp);
                    Monitor.Pulse(baton);
                }
               
                Thread.Sleep(4000);
            }

        }

        public static void Consume()
        {
            while (true)
            {
                lock (baton)
                {
                    Monitor.Pulse(baton);

                    if (myQueue.Count >0)
                    {
                        try
                        {
                            Console.WriteLine("Thread {0} consumed {1} ", Thread.CurrentThread.ManagedThreadId, myQueue.Dequeue());
                            Thread.Sleep(1000);
                        }
                        catch (Exception)
                        {

                            Console.WriteLine("Thread {0} crash!!!", Thread.CurrentThread.ManagedThreadId);
                            throw;
                        }


                    }
                    else
                    {
                        Console.WriteLine("Thread {0} try to get a value", Thread.CurrentThread.ManagedThreadId);
                    }
                }
            
            }
        }

        //public static void Main(String[] args)
        //{
        //    Console.WriteLine("This is Main Thread {0}", Thread.CurrentThread.ManagedThreadId);

            
           

        //    for (int i = 0; i < 4; i++)
        //    {
        //        new Thread(new ThreadStart(Produce)).Start();
        //    }
        //    for (int i = 0; i < 20; i++)
        //    {
        //        new Thread(new ThreadStart(Consume)).Start();
        //    }

        //    Console.ReadLine();
        //}
    }
}
