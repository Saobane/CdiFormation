using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace UnitTestProject1
{
   public  class Generator : IGenerator
    {

        private  List<Thread> threadsList = new List<Thread>();
        private  Object baton = new object();
        private  int Process()
        {
            Thread.Sleep(1500);
            return new Random().Next(1, 100);
        }

        public  List<int> GenerateNumbers(int numbers)
        {
            List<int> tab = new List<int>();

            for (int i = 0; i < numbers; i++)
            {
                var thrd = new Thread(() => tab.Add(Process()));
                thrd.Start();
                threadsList.Add(thrd);
                thrd.Join();
            }
            return tab;


        }
    }
}
