using MyClassLibrary.Interfaces;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyClassLibrary
{
    public class MyLinkedList<T> : IMyLinkedList<T>
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

                count--;
            }

        }
        public void Remove(Node<T> element)
        {
            Node<T> tmp = Head;
            Node<T> precSearchNode = null;
            Node<T> suivSearchNode = null;

            while (tmp != null)
            {
                if (element.data.Equals(tmp.data))
                {

                    if (precSearchNode != null)
                    {
                        precSearchNode.Next = tmp.Next == null ? null:tmp.Next;
                       
                    }
                    else
                    {
                        Head = Head.Next;
                    }
                    count--;
                }
                precSearchNode = tmp;
                tmp = tmp.Next;
                suivSearchNode = tmp==null ? null:tmp.Next;

                
            }

        }

        public Node<T> GetNode(T element)

        {
            Node<T> searchNode = Head;
            Node<T> tmp = Head;
            while (tmp !=null)
            {
                if (tmp.data.Equals(element))
                {
                    searchNode = tmp;
                    break;
                }
                else
                {
                    tmp = tmp.Next;
                }
            }

            return searchNode;
        }

       
        public void PrintMyLinkedList()
        {
            int i = 0;

            foreach (var item in this)
            {
                Console.WriteLine("Index {0} Data : {1}", i, item);
                i++;
            }

        }

        public IEnumerator GetEnumerator()
        {
            var tmp = Head;
            while (tmp !=null)
            {
                yield return tmp.data;
                tmp = tmp.Next;
            }
        }

        public void AddAfter(T afterElement, T element)
        {
            Node<T> newNode = new Node<T>(element);
            Node<T> afterElementNode = GetNode(afterElement);

            newNode.Next = afterElementNode.Next;
            afterElementNode.Next = newNode;
            count++;
        }

        public void ReverseLinkedList()
        {
            Node<T> currNode = Head;
            Node<T> nextNode = null;
            Node<T> prevNode = null;

            while (currNode != null)
            {
                nextNode = currNode.Next;
                currNode.Next = prevNode;
                prevNode = currNode;
                currNode = nextNode;
            }
            Head = prevNode;
        }
    }
}
