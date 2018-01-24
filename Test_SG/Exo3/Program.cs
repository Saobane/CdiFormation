using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exo3
{
    class Program
    {
        static void Main(string[] args)
        {

            foreach (var item in Alphabet())
            {
                Console.WriteLine(item+"\t");
            }
            Console.ReadLine();
        }

        public static  IEnumerable<char> Alphabet()
        {
            for (char i = 'A'; i <= 'Z'; i++)
            {
                yield return i;
            }

        }
    }
}
