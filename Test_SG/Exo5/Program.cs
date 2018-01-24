using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exo5
{
    class Program
    {
        static void Main(string[] args)
        {
           
            var imput = int.TryParse(Console.ReadLine(), out int i);

            Console.WriteLine("Position on step {0} is {1}",i,GetPositionAt(i));
            Console.ReadLine();

        }

        public static int GetPositionAt(int n)
        {
            if (n>0 && n<=1)
            {
                return n;
            }
            if (n==2)
            {
                return -1;
            }
            int lastMove = -2;
            int beforeLastMove = +1;
            int lastposition = -1;

            while (--n>=2)
            {
                var tmp = lastMove;
                lastMove = lastMove - beforeLastMove;
                beforeLastMove = lastMove;
                lastposition = lastposition + lastMove;

            }
            return lastposition;
        }
    }
}
