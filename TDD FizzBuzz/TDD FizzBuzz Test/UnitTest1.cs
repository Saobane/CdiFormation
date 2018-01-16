using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using TDD_FizzBuzz;

namespace TDD_FizzBuzz_Test
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void ShouldReturn1IfInputIs1()
        {
            //²Tesdtcase
            Assert.AreEqual("1", FizzBuzz.Get(1));
        }
        [TestMethod]
        public void ShouldReturn2IfInputIs2()
        {
            Assert.AreEqual("2", FizzBuzz.Get(2));
        }
        [TestMethod]
        public void ShouldReturnFizzIfInputIs3()
        {
            Assert.AreEqual("Fizz", FizzBuzz.Get(3));
        }
        [TestMethod]
        public void ShouldReturn4IfInputIs4()
        {
            Assert.AreEqual("4", FizzBuzz.Get(4));
        }
        [TestMethod]
        public void ShouldReturnBuzzIfInputIs5()
        {
            Assert.AreEqual("Buzz", FizzBuzz.Get(5));
        }
        [TestMethod]
        public void ShouldReturnFizzIfInputIs6()
        {
            Assert.AreEqual("Fizz", FizzBuzz.Get(6));
        }
        [TestMethod]
        public void ShouldReturnBuzzIfInputIs10()
        {
            Assert.AreEqual("Buzz", FizzBuzz.Get(10));
        }
        [TestMethod]
        public void ShouldReturnFizzBuzzIfInputIs15()
        {
            Assert.AreEqual("FizzBuzz", FizzBuzz.Get(15));
        }
        [TestMethod]
        public void ShouldReturnFizzBuzzIfInputIs30()
        {
            Assert.AreEqual("FizzBuzz", FizzBuzz.Get(30));
        }
        [TestMethod]
        public void ShouldReturn12IfInputIs12()
        {
            Assert.AreEqual("12", FizzBuzz.Get(1,2));
        }
        [TestMethod]
        public void ShouldReturn12FizzIfInputIs123()
        {
            Assert.AreEqual("12Fizz", FizzBuzz.Get(1, 3));
        }
        [TestMethod]
        public void ShouldReturn4IfInputIs42()
        {
            Assert.AreEqual("4", FizzBuzz.Get(4, 2));
        }
        [TestMethod]
        public void ShouldReturn12Fizz4BuzzFizz78FizzIfInputIs123456789()
        {
            Assert.AreEqual("12Fizz4BuzzFizz78Fizz", FizzBuzz.Get(1, 9));
        }
        [TestMethod]
        [ExpectedException(typeof(InvalidImputExeption))]
        public void ShouldReturnInvalidImputExeptionIfInputsIsNegative()
        { 
            FizzBuzz.Get(-1);
        }
    }
}
