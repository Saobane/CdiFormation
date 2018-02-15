using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fibo
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] values = new[] { 1, 2, 3, 4 };
            List<Action> actions = new List<Action>();
            foreach (int v in values)
            {
                actions.Add(() => Console.WriteLine(v));
            }
            foreach (Action a in actions)
            {
                a();
            }
            Console.WriteLine(" finonacci de 45 est : "+Fibo(1));
            Console.ReadLine();
        }
        public static  double Fibo(double v)
        {
            if (v == 0) return 0;

            double prev = 0;
            double cur = 1;
            double r = 1;
            for (int i = 2; i <= v; i++)
            {
                r = prev + cur;
                prev = cur;
                cur = r;
            }
            return r;
           
        }
    }
}
