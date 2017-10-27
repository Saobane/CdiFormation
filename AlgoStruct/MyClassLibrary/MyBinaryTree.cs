using MyClassLibrary.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections;

namespace MyClassLibrary
{
   public  class MyBinaryTree<T> : IMyBinaryTree<T> where T :IComparable<T>
    {
        private NodeTree<T> rootNode;
        

        public MyBinaryTree(T rootData)
        {
          
            rootNode = new NodeTree<T>(rootData);
        }

        public MyBinaryTree()
        {

            rootNode = null;
        }

        public void Add(T element)
        {
            rootNode = Add(rootNode, new NodeTree<T>(element));
        }

        public NodeTree<T> Add(NodeTree<T> currentNode, NodeTree<T> newNode)
        {
            if (currentNode == null)
            {
                return newNode;
            }
            else if (newNode.data.CompareTo(currentNode.data)>0) //newNode.data > currentNode.data
            {
                currentNode.RightNode = Add(currentNode.RightNode, newNode);
            }
            else if (newNode.data.CompareTo(currentNode.data) < 0)//newNode.data < currentNode.data
            {
                currentNode.LeftNode = Add(currentNode.LeftNode, newNode);
            }

            return currentNode;
        }

        public void PrefixCourse()
        {
            PrefixCourse(this.rootNode);
        }

        public void PrefixCourse(NodeTree<T> rootNode)
        {
            Console.WriteLine(rootNode.data);
            if (rootNode.LeftNode != null) PrefixCourse(rootNode.LeftNode);
            if (rootNode.RightNode != null) PrefixCourse(rootNode.RightNode);
        }

        public void SuffixCourse()
        {
            SuffixCourse(this.rootNode);
        }

        public void SuffixCourse(NodeTree<T> rootNode)
        {
            
            if (rootNode.LeftNode != null) SuffixCourse(rootNode.LeftNode);
            if (rootNode.RightNode != null) SuffixCourse(rootNode.RightNode);
            Console.WriteLine(rootNode.data);
        }


        public void InfixCourse()
        {
            InfixCourse(this.rootNode);
        }

        public void InfixCourse(NodeTree<T> rootNode)
        {

            if (rootNode.LeftNode != null) InfixCourse(rootNode.LeftNode);
            Console.WriteLine(rootNode.data);
            if (rootNode.RightNode != null) InfixCourse(rootNode.RightNode);
            
        }

        public void Remove(T element)
        {
            rootNode = Remove(rootNode, element);
        }

        public NodeTree<T> Remove(NodeTree<T> node,T element)
        {
            NodeTree<T> cur = node;
            if (cur == null)
            {
                return cur;
            }
            if (cur.data.CompareTo(element) > 0)
            {
                cur.LeftNode = Remove(cur.LeftNode, element);
            }
            else if (cur.data.CompareTo(element) < 0)
            {
                cur.RightNode = Remove(cur.RightNode, element);
            }
            else
            {
                if (cur.LeftNode == null && cur.RightNode == null)
                {
                    cur = null;
                }
                else if (cur.RightNode == null)
                {
                    cur = cur.LeftNode;
                }
                else if (cur.LeftNode == null)
                {
                    cur = cur.RightNode;
                }
                else
                {
                    NodeTree<T> temp = findMinFromRight(cur.RightNode);
                    cur.data = temp.data;
                    cur.RightNode = Remove(cur.RightNode, temp.data);
                }
            }
            return cur;
        }

        private NodeTree<T> findMinFromRight(NodeTree<T> node)
        {
            while (node.LeftNode != null)
            {
                node = node.LeftNode;
            }
            return node;
        }
    }
}
