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
        public static IEnumerable SortBySelection<T>(this IEnumerable<T> str) where T : IComparable
        {
            var min = 0;
            var list = str.ToList();
            for (int i = 0; i < list.Count; i++)
            {
                min = i;
                for (int j = i + 1; j < list.Count; j++)
                {
                    if (list[j].CompareTo(list[min]) < 0)
                    {
                        min = j;
                    }
                }
                if (min != i)
                {
                    T tmp;
                    tmp = list[i];
                    list[i] = list[min];
                    list[min] = tmp;
                }

            }
            return list; //Complexité O(n²)
        }

        public static IEnumerable SortByInsertion<T>(this IEnumerable<T> str) where T : IComparable
        {
            var list = str.ToList();
            T x;
            int j;
            for (int i = 0; i < list.Count; i++)
            {
                x = list[i];
                j = i;
                while (j > 0 && list[j - 1].CompareTo(x) > 0)
                {
                    list[j] = list[j - 1];
                    j = j - 1;
                }
                list[j] = x;

            }
            return list; //Complexité O(n²) dans le pire des cas 
        }

        public static IEnumerable BubbleSorting<T>(this IEnumerable<T> str) where T : IComparable
        {
            var list = str.ToList();
            for (int i = list.Count; i > 0; i--)
            {
                for (int j = 0; j < i - 1; j++)
                {
                    if (list[j + 1].CompareTo(list[j]) < 0)
                    {
                        T tmp;
                        tmp = list[j + 1];
                        list[j + 1] = list[j];
                        list[j] = tmp;
                    }
                }
            }
            return list; //Complexité O(n²) Trie à bulles non optimisé
        }


    }


    public class TriClass
    {
        private static void Fusion<T>(T[] t, int i1, int t1, int t2)  where T: IComparable
        {
            int deb = i1;
            int i2 = i1 + t1;
            int l = t1 + t2;
            int l1 = i1 + t1;
            int l2 = l1 + t2;
            T[] tf = new T[l];
            for (int i = 0; i < l; i++)
            {
                if (i1 == l1)
                {
                    tf[i] = t[i2];
                    i2++;
                }
                else
                {
                    if (i2 == l2)
                    {
                        tf[i] = t[i1];
                        i1++;
                    }
                    else
                    {
                        if (t[i1].CompareTo(t[i2]) <0)
                        {
                            tf[i] = t[i1];
                            i1++;
                        }
                        else
                        {
                            tf[i] = t[i2];
                            i2++;
                        }
                    }
                }
            }
            for (int i = 0; i < l; i++)
            {
                t[deb + i] = tf[i];
            }
        }

        /* Fonction de tri par fusion                    */
        /* par ordre croissant d'un tableau d'entiers    */
        /* des indices indi a indf compris               */

        private static void TriFusion<T>(T[] t, int indi, int indf) where T : IComparable
        {
            int iMedian;
            T aux;
            int nbVal = indf - indi + 1;
            if (nbVal > 1)
            {
                if (nbVal == 2)
                {
                    if (t[indf].CompareTo(t[indi]) <0 )
                    {
                        aux = t[indi];
                        t[indi] = t[indf];
                        t[indf] = aux;
                    }
                }
                else
                {
                    iMedian = (indi + indf) / 2;
                    TriFusion(t, indi, iMedian);
                    TriFusion(t, iMedian + 1, indf);
                    Fusion(t, indi, iMedian - indi + 1, indf - iMedian);
                }
            }
        }

        /* Fonction de tri par fusion                    */
        /* par ordre croissant d'un tableau d'entiers    */

        public static void TriFusion<T>(T[] t) where T : IComparable
        {
            TriFusion(t, 0, t.Length - 1);
            
        }

        public static void QuickSort<T>(T[] t) where T : IComparable
        {
            QuickSort(t, 0, t.Length - 1); //Complexité O(n²) dans le pire des cas et n log dans le cas moyen 

        }
        private static void QuickSort<T>(T[] t,int start, int end) where T : IComparable
        {
            if (start<end)
            {
                T pivot = t[end];
                int pIndex = start;
                T swap;

                for (int i = start; i < end; i++)
                {
                    if (t[i].CompareTo(pivot) <0)
                    {
                        swap = t[pIndex];
                        t[pIndex] = t[i];
                        t[i] = swap;
                        pIndex++;
                    }

                }


                t[end] = t[pIndex];
                t[pIndex] = pivot;
                QuickSort(t, start, pIndex - 1);
                QuickSort(t, pIndex+1, end);


            }
        }

    }
}
