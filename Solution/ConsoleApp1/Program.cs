using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    delegate int Triple(int a);
    class Program
    {
        static void Main(string[] args)
        {


            //var n = new { A="dededed",dedede=4};

            //IInterface test1 = new MyClass1();
            //IInterface test2 = new MyClass2();
            //MyClass test3 = new MyClass();
            //test1.MethodTest();
            //test2.MethodTest();
            //test3.MethodTest();//ff

            //Console.WriteLine("exemple somme= {0}", test3.Add<String>("DA SILVA", "FRED"));

            //Triple test = delegate (int i) { return 8; };

            //Console.WriteLine(test(5));

            //Console.WriteLine("Core :"+Environment.ProcessorCount);

            //for (int i = 0; i < Environment.ProcessorCount; i++)
            //{
            //    while (true)
            //    {
            //        Thread thr = new Thread(test);

            //        thr.Start();
            //    }
            //}
            MyClass<MyClass1> fr = new MyClass<MyClass1>();
            //fr.Maclasse = (MyClass1)test1;
            //Console.WriteLine(fr.ToString());
            for (int i = 0; i < 100; i++)
            {
                Console.WriteLine("Facto de "+i+" : "+fr.Facto(i) + "\n");
            }
           
            //foreach (var item in fr.YielD(10))
            //{
            //    Console.WriteLine(item);

            //}


            //int[] tab = { 1, 4, 2, 5, 8, 5, 48, 4 };

            //Array.ForEach<int>(tab, delegate (int a) { Console.WriteLine(a * a); });
            // tab.ForEach<int>(delegate (int a) { Console.WriteLine(a * a); });
            

            Console.ReadLine();
        }
        private bool CheckString(String s)
        {
            s.Max();
            return true;
        }
        public static void test()
        {
            while (true)
            {
               

                Console.WriteLine("This thread" + Thread.CurrentThread.ManagedThreadId + " is on test");
            }
        }
    }


    class MyClass :MyClass1
    {
        public override void MethodTest() {

            Console.WriteLine("THUG");
        }

        public T Add<T> (T a, T b)
        {
           

             return (dynamic) a + b;
        }
    }

    class MyClass2 : IInterface
    {
        public virtual void MethodTest()
        {
            Console.WriteLine("Myclass2");
        }
    }

    class MyClass1 : IInterface
    {
        public virtual void MethodTest()
        {
            Console.WriteLine("Myclass1");
        }
    }

    interface IInterface
    {
        void MethodTest();
    }

    class MyClass<T> where T :IInterface
    {
        private T maclass;

        public T Maclasse { get { return maclass; } set { maclass = value; } }

        public int MyProperty { get; private set; }

        public override string ToString()
        {
            return "T est de type :"+maclass.GetType();
        }

        public   int fibo(int n)
        {
            if (n == 0)
                return 0;
            if (n == 1)
                return 1;


            return fibo(n - 2) + fibo(n - 1);

        }
        public int fiboIte(int n)
        {
            int a = 0;
            int b = 1;
            // In N steps compute Fibonacci sequence iteratively.
            for (int i = 0; i < n; i++)
            {
                int temp = a;
                a = b;
                b = temp + b;
            }
            return a;

        }
        public int Facto(int n)
        {
            if (n==0)
            {
                return 1;
            }

            return n*Facto(n-1);

        }
        public IEnumerable<int> YielD(int n)
        {
            while (n>0)
            {
                yield return n * 2;
            }
            

        }
    }
}
