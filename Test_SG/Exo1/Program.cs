using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exo1
{
    class Program
    {
        public event Action<bool, int> DiagnosticsEvent;
        public void OnRaise(bool i,int u)
        {
        //    if (DiagnosticsEvent)
        //    {

        //    }
        }
        public void OnDiag(bool obj,int eventArgs)
        {
            if (DiagnosticsEvent != null)
                DiagnosticsEvent(obj, eventArgs);
        }
        static void Main(string[] args)
        {

            

        int[] mytab = {1,4,2,3};
            var fr = mytab.GroupBy(x => x).Where(x=>x.Count()==1).Select(x=> x.Key).ToArray();
            Console.WriteLine("Le plus petit "+String.Join("\t",fr));
            String s = "Rodeur nu : un rue d'or";

            var f =new String( s.Reverse().ToArray());
            char[] revers = new char[s.Count()];
            for (int i = 0; i < s.Count(); i++)
            {
                revers[i] = s[s.Count() -(i+ 1)];
            }

            Console.WriteLine(" MY REV IS "+new string(revers));
            var imp=Console.ReadLine();
            var t = s.ToCharArray();
            Array.Reverse(t);
            foreach (var item in t)
            {
                Console.WriteLine(item +" \t"+imp);
            }
            Console.WriteLine(" Normal : " + s.ToUpper());
            Console.WriteLine(" REVERSE : "+ new string(s.ToUpper().Reverse().ToArray()));
            Console.WriteLine(" Mytab max value is :"+ mytab.Max());
            Console.WriteLine(" Occur is :" + mytab.GroupBy(x=>x).OrderByDescending(x=>x.Count()).FirstOrDefault().Key);
            Console.ReadLine();
        }

        public static bool IsPalindrome(string value)
        {
            int min = 0;
            int max = value.Length - 1;
            while (true)
            {
                if (min > max)
                {
                    return true;
                }
                char a = value[min];
                char b = value[max];
                if (char.ToLower(a) != char.ToLower(b))
                {
                    return false;
                }
                min++;
                max--;
            }
        }

        public static int fiboIte(int n)
        {
            if (n==0)
            {
                return 0;
            }
            if (n==1)
            {
                return 1;
            }
            var lastLastFibo = 0;
            var lastFibo = 1;
            var result = 0;
            while ((--n) >=2)
            {
                result = lastFibo + lastLastFibo;


            }

            throw new  NotImplementedException();
        }
    }

    public sealed  class Singleton
    {
        private static Singleton _singleton;
        private static readonly Object obj = new Object();
        protected Singleton() { }

        public static Singleton GetInstance()
        {
            if (_singleton == null)
            {
                lock (obj)
                {
                    if (_singleton == null) _singleton = new Singleton();
                }

            }


            return _singleton;
        }
    }
}
