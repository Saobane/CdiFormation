using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PalindromeLib
{
    public class Palindrome
    {
        public static bool IsPalindrome(string v)
        {
            if (v.Count()==1)
            return true;

            var reverse = new String(v.ToUpper().Reverse().ToArray());
            if (v.ToUpper() == reverse)
                return true;

            return false;
        }

        public static bool IsPalindromeWithLoop(string v)
        {
            var imput = v.ToUpper();
            for (int i = 0; i < imput.Count()/2; i++)
            {
                if (imput[i] != imput[imput.Count() - i - 1]) return false ;
                
            }

            return true;
        }
    }
}
