using MyClassLibrary.Interfaces;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyClassLibrary
{
    public class MyArrayList<T> : IMyArrayList<T>
    {
        private int count;
        public int Count { get { return count;  } private set { count = value; } }

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

        public void  AddAt(int index,T element)
        {
            var tabTemp = new T[tabCapacity];

            for (int i = 0; i < index; i++)
            {
                tabTemp[i] = TTab[i];
            }
            tabTemp[index] = element;
            count++;

            for (int i = index; i < count; i++)
            {
                tabTemp[i+1] = TTab[i];

            }
            TTab = tabTemp;

        }

        //Supprime element du tableau 
        public void Remove(T element)
        {
            if (element != null)
            {
                for (int i = 0; i < count; i++)
                {
                    if (TTab[i].Equals(element))
                    {
                        TTab[i] = TTab[i + 1];
                        count--;
                    }
                }
            }
        }

        public IEnumerator GetEnumerator()
        {
            for (int i = 0; i < count; i++)
            {
                yield return TTab[i];
            }
        }

        public T get(int index)
        {
            if (index >= 0)
            {
                return TTab[index];
            }

            else
                throw new Exception();                
            
        }
    }
}
