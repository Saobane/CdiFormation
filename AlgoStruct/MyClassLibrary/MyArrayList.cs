using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyClassLibrary
{
    public class MyArrayList<T> : IEnumerable
    {
        private int count;
        public int Count { get { return count; } }

        private int tabCapacity;
        private T[] TTab;

        public MyArrayList()
        {
            tabCapacity = 20;
            TTab = new T[tabCapacity];
            count = 0;
        }

        public void Add(T element)
        {
            if (count >= tabCapacity)
            {
                tabCapacity *= 2;
                T[] TTabCopy = new T[tabCapacity];
                for (int i = 0; i < TTab.Length; i++)
                {
                    TTabCopy[i] = TTab[i];
                }

                TTab = TTabCopy;
                //On augmente la taille du tableau

            }
            else
                TTab[count] = element;
                count++;
            

        }

        public IEnumerator GetEnumerator()
        {
            for (int i = 0; i < count; i++)
            {
                yield return TTab[i];
            }
        }
    }
}
