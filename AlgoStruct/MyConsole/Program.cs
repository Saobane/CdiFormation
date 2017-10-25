using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MyClassLibrary;

namespace MyConsole
{
    class Program
    {
        static void Main(string[] args)
        {
            
            

            IMyList<int> list = new MyLinkedList<int>();

            list.Add(-5);
            list.Add(58);
            list.Add(5);
            list.Add(5148);
            list.Add(528); list.Add(8945);
            list.Add(5858); list.Add(453);
            list.Add(578); list.Add(6);
            list.Add(5148);
            Console.WriteLine("Contenu de la Liste ");
            list.PrintMyLinkedList();

            Console.WriteLine("Suppression de 5148 ");

            list.Remove(5148);
            Console.WriteLine("Contenu de la Liste ");

            list.PrintMyLinkedList();

            var get=list.GetNode(453);
            Console.WriteLine("Test méthode Get ");
            Console.WriteLine(" la data est {0} et le suivant est {1}", get.data, get.Next.data);

            Console.WriteLine("Suppression à partir du node de 58 ");

            list.Remove(new Node<int>(-5));
            list.PrintMyLinkedList();

            Console.ReadLine();

        }
    }
}
