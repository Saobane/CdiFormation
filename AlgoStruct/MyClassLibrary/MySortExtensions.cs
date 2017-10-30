using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyClassLibrary
{
    public static class MySortExtensions
    {
        public static IEnumerable WordCount<T>(this IEnumerable<T> str) where T : IComparable
        {
            var min=0;
            var list = str.ToList();
            for (int i = 0; i < list.Count; i++)
            {
                min = i;
                for (int j = i+1; j < list.Count; j++)
                {
                    if (list[j].CompareTo( list[min])<0)
                    {
                        min = j;
                    }
                }
                if (min !=i)
                {
                    list[i]=list[min];
                }
               
            }
            return list;
        }
    }
}
