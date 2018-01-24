using System;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;

namespace UnitTestProject1
{
    [TestClass]
    public class UnitTest1
    {
        //[TestMethod]
        //public void TestMethod1()
        //{
        //    var gen = new Generator();

        //    Assert.AreEqual(5, gen.GenerateNumbers(5).Count);
        //}

        [TestMethod]
        public void TestMethodMoq()
        {
            var mock = new Mock<IGenerator>();
            var list = new List<int> { 1, 2, 3, 9 };
            mock.Setup(x => x.GenerateNumbers(4)).Returns(list);

            IGenerator gen= mock.Object;

            Assert.AreEqual(list, gen.GenerateNumbers(4));

        }
    }
}
