using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyClassLibrary
{
    public class MyLinkedList<T> 
    {

        private int count;
        public int Count { get { return count; }  }
        private Node<T> Head;
        private Node<T> Tail;



        public MyLinkedList()
        {
            count = 0;
            Head = null;
            Tail = null;

        }

         public void Add(T element)
        {
            Node<T> nodeElement = new Node<T>(element);

            if (Head ==null)
            {
                Head = nodeElement;
                Tail = nodeElement;
            }
            else
            {
                Tail.Next = nodeElement;
                Tail = nodeElement;
            }
                
            count++;

        }

        public void Remove(T element)
        {
            Node<T> tmp = Head;
            Node<T> searchNode = Head;
            Node<T> precSearchNode = null;

            while (tmp != null)
            {
                searchNode = tmp;
                if (element.Equals(tmp.data))
                {

                    if (precSearchNode != null)
                    {
                        precSearchNode.Next = tmp.Next;
                    }
                    else
                    {
                        Head = Head.Next;
                    }
                    //break;  pour supprimer tout les x "element"
                }
                precSearchNode = searchNode;
                tmp = tmp.Next;
               

            }

        }

        public T GetNode()
        {

            throw new NotImplementedException();
        }

       
        public void PrintNodes()
        {
            int i = 0;
            var tmp = Head;
            while (tmp != null)
            {
                Console.WriteLine("Index {0} Data : {1}",i, tmp.data);
                tmp = tmp.Next;
                i++;
            }

        }

        
       
    }
}
