using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp
{
    delegate int Triple(int[] a);
    delegate T TripleGen<T>(T[] tabGen);

    class Program
    {
        static void Main(string[] args)
        {
            GeneTest<String> t;
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

            int[] tabInt = { 1, 2, 12, 1, 2, 5 };
            
             Console.WriteLine("{0} {1}", tsts.Nom, tsts.Prenom);
            int[] tz ;

            foreach (int i in Power(2, 8))
            {
                Console.Write("{0} ", i);
            }

            Console.ReadLine();

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
        T[] tab;

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
