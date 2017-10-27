using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyClassLibrary
{
    public class NodeTree<T> 
    {
        public T data;
        private int niveau;
        public int Niveau { get { return niveau; } private set { niveau = value; } }

        public NodeTree<T> RightNode { get; set; }
        public NodeTree<T> LeftNode { get; set; }


        public NodeTree(T inputData)
        {

            data = inputData;
            RightNode = null;
            LeftNode = null;
            niveau =0;
        }
    }
}
