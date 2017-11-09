using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace MyPricerLibrary.Test
{
    [TestClass]
    public class RateRepositoryCsvTest
    {
        [TestMethod]
        public void RatesCurvesIsNotNullTest()
        {
            IRateRepository repo = new RateRepositoryCsv();

            var contents = repo.GetRatesCurves();

            Assert.IsNotNull(contents);

        }

        [TestMethod]
        public void DurationsIsNotNullTest()
        {
            IRateRepository repo = new RateRepositoryCsv();

            var contents = repo.GetDurations();

            Assert.IsNotNull(contents);

        }
    }
}
