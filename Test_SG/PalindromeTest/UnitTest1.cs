using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using PalindromeLib;

namespace PalindromeTest
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void ShouldReturnTrueIfImputIsA()
        {
            Assert.IsTrue(Palindrome.IsPalindromeWithLoop("A"));
            
        }
        [TestMethod]
        public void ShouldReturnfalseIfImputIsARET()
        {
            Assert.IsFalse(Palindrome.IsPalindromeWithLoop("ARET"));

        }
        [TestMethod]
        public void ShouldReturntrueIfImputIsAXA()
        {
            Assert.IsTrue(Palindrome.IsPalindromeWithLoop("AXA"));

        }
        [TestMethod]
        public void ShouldReturntrueIfImputIsAXa()
        {
            Assert.IsTrue(Palindrome.IsPalindromeWithLoop("AXa"));

        }
        [TestMethod]
        public void ShouldReturntrueIfImputIsSenones()
        {
            Assert.IsTrue(Palindrome.IsPalindromeWithLoop("SeNoNEs"));

        }
        [TestMethod]
        public void ShouldReturntrueIfImputIsMonnom()
        {
            Assert.IsTrue(Palindrome.IsPalindromeWithLoop("Mon nom"));

        }
        [TestMethod]
        public void ShouldReturntrueIfImputIsLamaladepédalamal()
        {
            Assert.IsTrue(Palindrome.IsPalindromeWithLoop("La malade pédala mal"));

        }
    }
}
