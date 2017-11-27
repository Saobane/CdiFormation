using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    delegate int Triple(int a);
    class Program
    {
        static void Main(string[] args)
        {
            

            var n = new { A="dededed",dedede=4};
          
            IInterface test1 = new MyClass1();
            IInterface test2 = new MyClass2();
            MyClass test3 = new MyClass();
            test1.MethodTest();
            test2.MethodTest();
            test3.MethodTest();//ff

            Console.WriteLine("exemple somme= {0}", test3.Add<String>("DA SILVA", "FRED"));

            Triple test = delegate (int i) { return 8; };

            Console.WriteLine(test(5));


            MyClass<MyClass1> fr = new MyClass<MyClass1>();
            fr.Maclasse = (MyClass1)test1;
            Console.WriteLine( fr.ToString());


            int[] tab = { 1, 4, 2, 5, 8, 5, 48, 4 };

            Array.ForEach<int>(tab, delegate (int a) { Console.WriteLine(a * a); });
           // tab.ForEach<int>(delegate (int a) { Console.WriteLine(a * a); });

            Console.ReadLine();
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
    }
}
