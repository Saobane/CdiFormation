using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace ConsoleApp2
{
    class Program
    {
        private static List<Thread> threadsList = new List<Thread>();
        private static Object baton = new object();

        static void Main(string[] args)
        {
            Console.WriteLine("Programme start ");
            Console.WriteLine("Liste des entiers :\t" + String.Join("\t", GenerateNumbers(10)));
            Console.ReadLine();
        }

        private static int Process()
        {
            Thread.Sleep(500);
            return new Random().Next(1, 100);
        }

        public static List<int> GenerateNumbers(int numbers)
        {

            List<Task<int>> tasks = new List<Task<int>>();
            for (int i = 0; i < numbers; i++)
            {
                var tmpTask = new Task<int>(() => Process());
                tasks.Add(tmpTask);
                tmpTask.Start();

               // tasks.Add(Task<int>.Factory.StartNew(Process));
            }

            Task.WaitAll(tasks.ToArray());

            List<int> ok = new List<int>();
            foreach (var item in tasks)
            {
                ok.Add(item.Result);
            }
           


            Task<int> task1 = Task<int>.Factory.StartNew(() => 1);
            int ie = task1.Result;
            Console.WriteLine("Complete");
            return ok;


        }
    }
}
