    using System;
using System.Threading;

public class Producer_Consumer
{
    private int[] Widgets = new int[100];
    private int WidgetIndex = 0;
    private AutoResetEvent NewWidgetEvent = new AutoResetEvent(false);

    protected void Producer()
    {
        while (true)
        {
            lock (this)
            {
                if (WidgetIndex < 100)
                {
                    Widgets[WidgetIndex] = 1;
                    Console.WriteLine("Widget {0} Produced by {1}", WidgetIndex++,Thread.CurrentThread.ManagedThreadId);
                    NewWidgetEvent.Set();
                }
            }
            Thread.Sleep((new Random()).Next(5) * 1000);
        }
    }

    protected void Consumer()
    {
        while (true)
        {
            NewWidgetEvent.WaitOne();
            int iWidgetIndex = 0;

            lock (this)
            {
                iWidgetIndex = --this.WidgetIndex;
                Console.WriteLine("Consuming widget {0} by {1}", iWidgetIndex, Thread.CurrentThread.ManagedThreadId);
                Widgets[iWidgetIndex--] = 0;
            }
        }
    }

    public void Run()
    {
        for (int i = 0; i < 4; i++)
        {
            Thread producer = new Thread(new ThreadStart(Producer));
            producer.Start();
        }
        for (int i = 0; i < 4; i++)
        {
            Thread consumer = new Thread(new ThreadStart(Consumer));
            consumer.Start();
        }
    }


    public static void Main()
    {
        Producer_Consumer factory = new Producer_Consumer();
        factory.Run();
    }
}