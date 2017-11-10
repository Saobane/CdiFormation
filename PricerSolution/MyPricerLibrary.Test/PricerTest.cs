using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace MyPricerLibrary.Test
{
    [TestClass]
    public class PricerTest
    {
        FixRateBond FixBond;
        Pricer pricer;
       [TestInitialize]
        public void TestInitialize()
        {
            FixBond = new FixRateBond();
            FixBond.Periodicity = 6;

            FixBond.Maturity = 4;

            FixBond.IssueDate = DateTime.Parse("20/05/1996");
            FixBond.Rate = 0.06;
            FixBond.Nominal = 100;

            pricer = new Pricer();

        }



        [TestMethod]
        public void ComputeWithDateInOutOfCsvDatesRange()
        {
             
            var pricingDate = DateTime.Parse("20/08/2017");
            var bondprice = pricer.Compute(FixBond, pricingDate);

            Assert.AreEqual(bondprice, 0);

        }

        [TestMethod]
        public void ComputeWithDateInCsvDatesRangeThatHaveNaHasRate()
        {
            var prevBondprice = pricer.Compute(FixBond, DateTime.Parse("27/06/1996"));
            var pricingDate = DateTime.Parse("28/06/1996");
            var bondprice = pricer.Compute(FixBond, pricingDate);

            Assert.AreEqual(bondprice, prevBondprice);

        }

        [TestMethod]
        public void ComputeWithDateInCsvDatesRangeWhoDontHaveRate()
        {
            var pricingDate = DateTime.Parse("12/04/1997");
            var bondprice = pricer.Compute(FixBond, pricingDate);

            Assert.AreEqual(bondprice, 0);

        }
        [TestMethod]
        public void PricingDateIsOutOfBondDuraction()
        {
            var pricingDate = DateTime.Parse("03/08/2002");
            var bondprice = pricer.Compute(FixBond, pricingDate);

            Assert.AreEqual(bondprice, 0);

        }

        [TestMethod]
        public void AphaMinIsZero()
        {
            var pricingDate = DateTime.Parse("21/08/1996");
            var bondprice = pricer.Compute(FixBond, pricingDate);

            Assert.IsNotNull(bondprice);

        }
    }
}
