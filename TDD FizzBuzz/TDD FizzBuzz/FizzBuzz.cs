using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TDD_FizzBuzz
{
    public class FizzBuzz
    {
        public static string Get(int min, int max=0)
        {
            if (min <0 || max <0)
            {
                throw new InvalidImputExeption();
            }
            int counter = max-min>0?max-min+1 :1;
            StringBuilder stg = new StringBuilder();
            while (counter>0)
            {

                stg.Append(GetFizzBuzzValue(min));
                counter--;
                min++;
               
            }
            return stg.ToString();
           
        }

        private static String GetFizzBuzzValue(int nb) {

            if (nb % 3 == 0 && nb % 5 == 0)
            {
                return "FizzBuzz";
            }
            else if (nb % 3 == 0)
            {
                return "Fizz";
            }
            else if (nb % 5 == 0)
            {
                return "Buzz";
            }
            else
            {
               return nb.ToString();
            }
        }
    }
}
