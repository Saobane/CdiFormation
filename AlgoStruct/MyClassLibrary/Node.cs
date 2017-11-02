using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyClassLibrary
{
    public class Node <T>
    {

        public T data { get; set; }

        public Node<T> Next { get; set; }

        public Node(T t)
        {
            Next = null;
            data = t;
           

        }
        
    }
}
