using System;
using System.Text;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using MyClassLibrary;

namespace MyClassLibraryTest
{
    /// <summary>
    /// Summary description for MyBinaryTreeTest
    /// </summary>
    [TestClass]
    public class MyBinaryTreeTest
    {
        [TestMethod]
        public void AddTest()
        {
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

            
            //
            // TODO: Add test logic here
            //
        }



        
    }
}
