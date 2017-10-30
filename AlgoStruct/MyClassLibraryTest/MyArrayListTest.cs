using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using MyClassLibrary;

namespace MyClassLibraryTest
{
    [TestClass]
    public class MyArrayListTest
    {
        [TestMethod]
        public void MyArrayListIsWellCreate()
        {
            var myArrayList = new MyArrayList<int>();

            Assert.AreEqual(0, myArrayList.Count);
        
        }

        [TestMethod]
        public void AddTest()
        {
            var myArrayList = new MyArrayList<int>();
            myArrayList.Add(58);
            myArrayList.Add(48);
            Assert.AreEqual(2, myArrayList.Count);
        }
        [TestMethod]
        public void AddAtTest()
        {
            var myArrayList = new MyArrayList<int>();
            myArrayList.Add(58);
            myArrayList.Add(48);

            myArrayList.AddAt(1, 66);
            Assert.AreEqual(3, myArrayList.Count);

        }


        [TestMethod]
        public void RemoveTest()
        {
            var myArrayList = new MyArrayList<int>();
            myArrayList.Add(14);
            myArrayList.Add(18);
            //Suppression 
            myArrayList.Remove(14);
            Assert.AreEqual(1, myArrayList.Count);
        }

        [TestMethod]
        public void GetTest()
        {
            var myArrayList = new MyArrayList<int>();
            myArrayList.Add(14);
            myArrayList.Add(18);
            myArrayList.Add(77);
            myArrayList.Add(69);
            //Suppression 
           ;
            Assert.AreEqual(77, myArrayList.get(2));
        }

        [TestMethod]
        [ExpectedException(typeof(IndexOutOfRangeException))]
        public void badGetMethodeUseTest()
        {
            var myArrayList = new MyArrayList<int>();
            myArrayList.Add(14);
            myArrayList.Add(18);
            myArrayList.Add(77);
            myArrayList.Add(69);
            //Suppression 
            ;
            Assert.AreEqual(77, myArrayList.get(-1));
        }



    }
}
