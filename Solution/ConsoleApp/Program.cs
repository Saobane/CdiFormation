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
            var e = new[] { "sdds", "dfdfsdf" };

            var d = from et in e
                    where et != "dfdff"
                    select e;


            Person magnus = new Person { FirstName = "Magnus", LastName = "Hedlund" };
            Person terry = new Person { FirstName = "Terry", LastName = "Adams" };
            Person charlotte = new Person { FirstName = "Charlotte", LastName = "Weiss" };
            Person arlene = new Person { FirstName = "Arlene", LastName = "Huff" };
            Person rui = new Person { FirstName = "Rui", LastName = "Raposo" };

            Pet barley = new Pet { Name = "Barley", Owner = terry };
            Pet boots = new Pet { Name = "Boots", Owner = terry };
            Pet whiskers = new Pet { Name = "Whiskers", Owner = charlotte };
            Pet bluemoon = new Pet { Name = "Blue Moon", Owner = rui };
            Pet daisy = new Pet { Name = "Daisy", Owner = magnus };

            // Create two lists.
            List<Person> people = new List<Person> { magnus, terry, charlotte, arlene, rui };
            List<Pet> pets = new List<Pet> { barley, boots, whiskers, bluemoon, daisy };


            var resultInner = from person in people
                              where person.FirstName == "SAO"
                              join pet in pets on person.FirstName equals pet.Owner.FirstName
                              select new { Name = person.FirstName, PetName = pet.Name };


            var restInnerFluent=people.Join(pets,
                person=>person.FirstName,
                pet=>pet.Owner.FirstName,
                (person, pet) =>new { Name = person.FirstName, PetName = pet.Name });

            var resultOuterJdoin= from person in people
                                  join pet in pets on person.FirstName equals pet.Owner.FirstName into test
                                  from fr in test.DefaultIfEmpty()
                                  select new { Name = person.FirstName, PetNames = fr };

            var y = 4;
            int[] tableauEntier = {1,2,4,5,8,7,89,6,35,47,85 };

            var t=tableauEntier.Select(er => er * er * er).Where(ee => ee > 0);

            var td = from uh in tableauEntier
                    where uh % 2 == 0
                    orderby uh
                    select uh * uh;


             // IEnumerable <string> s= new []{"tata","toto","tete" };



             //var r = from e in s where e.EndsWith("") select e;

             // IEnumerable dr = tableauEntier.Where(e => e % 2 == 0).Select(e => e);

             // TestDel testDel = new TestDel(DelOut);

             // TestDel de = delegate (int a, int b)
             // {
             //     return new String[] { };
             // };

             // int[] tabInt = { 1,2,2,4};

             // tabInt.ToList().ForEach(x=> {



             // });

             // System.GC.Collect();

             // var d = Console.ReadLine();

             // Console.WriteLine(d);

             // var tsts = new { Nom = "Sao", Prenom = "Thug" };
             // Triple test = x =>
             // {
             //     int i = 4;
             //     foreach (var item in x)
             //     {
             //         i = i * item;
             //     }
             //     return i;
             // };

             // Triple tesft = delegate(int[] gt) {

             //     return 4;

             // };
             // Console.WriteLine("Triple = {0}", tesft(new int[] { 1,2,14}));

             // Console.WriteLine("{0} {1}", tsts.Nom, tsts.Prenom);
             // int[] tabIent = { 1, 2, 12, 1, 2, 5 };

             // tabIent.ToList().ForEach(x => Console.WriteLine(x * x * x * x));

             // foreach (var item in tabIent)
             // {

             // }

             // tabInt.ToList().ForEach(x => Console.WriteLine(x * x * x * x));

             //  Console.WriteLine("{0} {1}", tsts.Nom, tsts.Prenom);

             // foreach (int i in Power(2, 8))
             // {
             //     Console.Write("{0} ", i);
             // }

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
