using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MyClassLibrary.Interfaces;
using System.Collections;
using MyClassLibrary;

namespace MyConsole
{
    class Program
    {
        static void Main(string[] args)
        {



            //IMyLinkedList<int> list = new MyLinkedList<int>();

            //list.Add(-5);
            //list.Add(58);
            //list.Add(5);
            //list.Add(5148);
            //list.Add(528); list.Add(8945);
            //list.Add(5858); list.Add(453);
            //list.Add(578); list.Add(6);
            //list.Add(5148);
            //Console.WriteLine("Contenu de la Liste ");
            //list.PrintMyLinkedList();

            //Console.WriteLine("Suppression de 5148 ");

            //list.Remove(5148);
            //Console.WriteLine("Contenu de la Liste ");

            //list.PrintMyLinkedList();

            //var get=list.GetNode(453);
            //Console.WriteLine("Test méthode Get ");
            //Console.WriteLine(" la data est {0} et le suivant est {1}", get.data, get.Next.data);

            //list.PrintMyLinkedList();
            //Console.WriteLine("Suppression à partir du node de 5 ");

            //list.Remove(new Node<int>(5));
            //list.PrintMyLinkedList();

            //Console.WriteLine("Test My ArrayList\n ");
            //MyArrayList<string> myArray = new MyArrayList<string>();
            //myArray.Add("14");
            //myArray.Add("16");
            //myArray.Add("18");

            //foreach (var item in myArray)
            //{
            //    Console.WriteLine(item);
            //}

            //Console.WriteLine("Test AddAfter \n ");

            //myArray.AddAt(2, "586");
            //foreach (var item in myArray)
            //{
            //    Console.WriteLine(item);
            //}

            var myBinaryTree = new MyBinaryTree<int>();

            myBinaryTree.Add(50);
            myBinaryTree.Add(17);
            myBinaryTree.Add(23);
            myBinaryTree.Add(12);
            myBinaryTree.Add(9);
            myBinaryTree.Add(14);
            myBinaryTree.Add(23);
            myBinaryTree.Add(19);
            myBinaryTree.Add(72);
            myBinaryTree.Add(54);
            myBinaryTree.Add(67);
            myBinaryTree.Add(76);

            Console.WriteLine("parcours prefix \n ");
            myBinaryTree.PrefixCourse();

            Console.WriteLine("parcours infix \n ");
            myBinaryTree.InfixCourse();


            Console.WriteLine("parcours suffixe \n ");
            myBinaryTree.SuffixCourse();
            Console.WriteLine("Remove 17 \n ");
            myBinaryTree.Remove(17);
            Console.WriteLine("parcours prefix \n ");
            myBinaryTree.PrefixCourse();


            Console.ReadLine();

        }
    }
}
