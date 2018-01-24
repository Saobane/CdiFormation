using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TETE
{
    class Program
    {
        static void Main(string[] args)
        {
            var  dic = GetImputsWithImpairOccur();
            var tab = new List<int> { 1, 1, 1, 2, 4, 5, 5, 8 };

            foreach (var item in GetImputsWithImpairOccurOptim(tab))
            {
                Console.WriteLine(item);
            }

            Console.ReadKey();
        }

        private static Dictionary<int, int> GetImputsWithImpairOccur()
        {
            Dictionary<int, int> dic = new Dictionary<int, int>();
            var tab = new List<int> { 1, 1, 1, 2, 4, 5, 5, 8 };


            for (int i = 0; i < tab.Count; i++)
            {
                if (!dic.ContainsKey(tab[i]))
                {
                    dic.Add(tab[i], 1);
                }
                else
                {
                    if (dic[tab[i]] % 2 != 0)
                    {
                        dic.Remove(tab[i]);
                    }
                    else
                    {
                        dic[tab[i]] += 1;

                    }
                }
            }

            return dic;
        }

        private static List<int> GetImputsWithImpairOccurOptim(List<int> tab)
        {
            HashSet< int> tmpHash = new HashSet<int>();


            for (int i = 0; i < tab.Count; i++)
            {
                if (!tmpHash.Contains(tab[i]))
                {
                    tmpHash.Add(tab[i]);
                }
                else
                {
                    tmpHash.Remove(tab[i]);
                }
            }

            return tmpHash.ToList();
        }
    }
}
