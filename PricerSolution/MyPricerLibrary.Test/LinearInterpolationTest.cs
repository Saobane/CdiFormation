using System;
using System.Text;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace MyPricerLibrary.Test
{
    [TestClass]
    public class LinearInterpolationTest
    {
       

        [TestMethod]
        [ExpectedException(typeof(IllegalDenominatorException))]
        public void ComputeRateForInvalidEntries()
        {
            var linearInterpolation = new LinearInterpolation();

            var result = linearInterpolation.ComputeRate(4,4,4,4,3);
            
        }

        [TestMethod]
        public void ComputeRateForValidEntries()
        {
            var linearInterpolation = new LinearInterpolation();

            var result = linearInterpolation.ComputeRate(1, 2, 1, 1, 1.5);

            Assert.AreEqual(1, result);


        }

    }
}
