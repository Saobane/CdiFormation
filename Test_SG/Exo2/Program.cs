using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exo2
{
    class Program
    {
        static void Main(string[] args)
        {


            Console.WriteLine(" Result for ([]()) is " + Checker("([]())"));
            Console.ReadLine();
            
        }

        public static bool Checker(String s)
        {
            Stack<char> st = new Stack<char>();
            Dictionary<char, char> myD = new Dictionary<char, char>() { {'(',')' }, {'[',']' } };

            bool result = true;
            foreach (var item in s)
            {
                if (myD.Keys.Contains<char>(item))
                {
                    st.Push(item);
                }
                else
                {
                    if (st.Count > 0 && item == myD[st.Pop()]  )
                    {
                        result = result && true;
                    }
                    else
                    {
                        result = false;
                        break;
                    }
                }
               
            }
            return result;
        }
    }
}
