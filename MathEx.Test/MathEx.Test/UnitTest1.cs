using System;
using System.CodeDom;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace MathEx.Test
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestGetValueNodeNumber()
        {
            var a = new NodeValue(1);
            Assert.AreEqual(1, a.Compute());
        }

        [TestMethod]
        public void TestComputeNodeWhenAdd()
        {
            var a = new NodeValue(1);
            var b = new NodeValue(1);
            var c = new NodeOperator(Operator.ADD, a, b);

            Assert.AreEqual(2, c.Compute());
        }

        [TestMethod]
        public void TestComputeNodeWhenASub()
        {
            var a = new NodeValue(1);
            var b = new NodeValue(1);
            var c = new NodeOperator(Operator.SUB, a, b);

            Assert.AreEqual(0, c.Compute());
        }
        [TestMethod]
        public void TestComputeNodeWhenMult()
        {
            var a = new NodeValue(1);
            var b = new NodeValue(1);
            var c = new NodeOperator(Operator.MUL, a, b);

            Assert.AreEqual(1, c.Compute());
        }
        [TestMethod]
        public void TestComputeNodeWhenDiv()
        {
            var a = new NodeValue(4);
            var b = new NodeValue(2);
            var c = new NodeOperator(Operator.DIV, a, b);

            Assert.AreEqual(2, c.Compute());
        }
        [TestMethod]
        [ExpectedException(typeof(DivideByZeroException))]
        public void TestComputeNodeWhenDivByZero()
        {
            var a = new NodeValue(4);
            var b = new NodeValue(0);
            var c = new NodeOperator(Operator.DIV, a, b);

            c.Compute();
        }

        [TestMethod]
        public void TestComputeNodeWhitThreeValue()
        {

            var a = new NodeValue(1);
            var b = new NodeValue(1);
            var c = new NodeValue(1);
            var d = new NodeOperator(Operator.ADD, a, b);
            var e = new NodeOperator(Operator.ADD, d, c);

            Assert.AreEqual(3, e.Compute());
        }

        [TestMethod]
        public void TestComputeNodeWithCalculPriority()
        {
            
            var a = new NodeValue(1);
            var b = new NodeValue(2);
            var c = new NodeValue(3);
            var d = new NodeValue(4);
            var e = new NodeOperator(Operator.MUL, b, c);
            var f = new NodeOperator(Operator.SUB, a, d);
            var g = new NodeOperator(Operator.ADD, e, f);

            Assert.AreEqual(3, g.Compute());
        }

    }
}
