using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using MyClassLibrary;

namespace MyClassLibraryTest
{
    [TestClass]
    public class MyLinkedListTest
    {
        [TestMethod]
        public void AddTest()
        {
            var linkedList = new MyLinkedList<int>();
            linkedList.Add(50);
            linkedList.Add(100);

            Assert.AreEqual(2, linkedList.Count);
        }
    }
}
