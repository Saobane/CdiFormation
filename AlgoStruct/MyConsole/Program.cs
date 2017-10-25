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
            
            

            var list = new MyLinkedList<int>();

            list.Add(45);
            list.Add(58);
            list.Add(5);
            list.Add(5148);
            list.Add(528); list.Add(8945);
            list.Add(5858); list.Add(453);
            list.Add(578); list.Add(6);
            list.Add(5148);
            Console.WriteLine("Contenu de la Liste ");
            list.PrintNodes();

            Console.WriteLine("Suppression de 5148 ");

            list.Remove(5148);
            Console.WriteLine("Contenu de la Liste ");

            list.PrintNodes();

            Console.ReadLine();

        }
    }
}
