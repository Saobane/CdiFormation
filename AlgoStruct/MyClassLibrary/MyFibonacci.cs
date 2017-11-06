using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyClassLibrary
{
    public static class MyFibonacci
    {
        public static int FibonacciIterative(int n)
        {
            int a = 0;
            int b = 1;
          
            for (int i = 0; i < n; i++)
            {
                int temp = a;
                a = b;
                b = temp + b;
            }
            return a;
        }
        public static int FibonacciRecursive(int n)
        {
            if (n == 0) return 0; 
            if (n == 1) return 1;  
            return FibonacciRecursive(n - 1) + FibonacciRecursive(n - 2);
        }

    }
}
