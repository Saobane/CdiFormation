using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp
{
    delegate int Triple(int[] a);
    public delegate String[] TestDel(int a, int b);
    delegate T TripleGen<T>(T[] tabGen);

    class Program
    {
        static void Main(string[] args)
        {
            int[] tableauEntier = {1,2,4,5,8,7,89,6,35,47,85 };

            tableauEntier.Select(e => e * e * e).ToList().ForEach(x=>Console.WriteLine(x));

            Console.WriteLine("Fin expression Fluent");
            IEnumerable <string> s= new []{"tata","toto","tete" };


            
           var r = from e in s where e.EndsWith("") select e;
           
            IEnumerable dr = tableauEntier.Where(e => e % 2 == 0).Select(e => e);

            TestDel testDel = new TestDel(DelOut);

            TestDel de = delegate (int a, int b)
            {
                return new String[] { };
            };

            int[] tabInt = { 1,2,2,4};

            tabInt.ToList().ForEach(x=> {

                

            });

            System.GC.Collect();

            var d = Console.ReadLine();

            Console.WriteLine(d);

            var tsts = new { Nom = "Sao", Prenom = "Thug" };
            Triple test = x =>
            {
                int i = 4;
                foreach (var item in x)
                {
                    i = i * item;
                }
                return i;
            };

            Triple tesft = delegate(int[] gt) {

                return 4;

            };
            Console.WriteLine("Triple = {0}", tesft(new int[] { 1,2,14}));

            Console.WriteLine("{0} {1}", tsts.Nom, tsts.Prenom);
            int[] tabIent = { 1, 2, 12, 1, 2, 5 };

            tabIent.ToList().ForEach(x => Console.WriteLine(x * x * x * x));

            foreach (var item in tabIent)
            {

            }

            tabInt.ToList().ForEach(x => Console.WriteLine(x * x * x * x));
            
             Console.WriteLine("{0} {1}", tsts.Nom, tsts.Prenom);

            foreach (int i in Power(2, 8))
            {
                Console.Write("{0} ", i);
            }

            Console.ReadLine();

        }

       public static String[] DelOut(int a, int b)
        {

            return new String[] { };
        }

        public static System.Collections.IEnumerable Power(int number, int exponent)
        {
            int counter = 0;
            int result = 1;
            while (counter++ < exponent)
            {
                result = result * number;
                yield return result;
            }
        }
    }

    public class GeneTest<T> where T : IEnumerable
    {
       // T[] tab;

        public T Test(T rt)
        {
            return rt;
        }

    }

    class MyClass :Voiture
    {
        public override void Add(int b)
        {

        }

        public sealed override int getIndex()
        {
            return 4;
        }

    }

    public  class Voiture : IInterface
    {
        public virtual void Add(int a)
        {
            throw new NotImplementedException();
        }
        public  virtual int getIndex()
        {
            return 0;
        }
    }

    interface IInterface
    {
        void Add(int a);
    }
}
