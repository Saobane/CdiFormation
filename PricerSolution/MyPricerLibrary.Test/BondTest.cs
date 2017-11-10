using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace MyPricerLibrary.Test
{
    [TestClass]
    public class BondTest
    {
        FixRateBond FixBond;

        [TestInitialize]
        public void TestInitialize()
        {
            FixBond = new FixRateBond();
            FixBond.Periodicity = 6;

            FixBond.Maturity = 4;

            FixBond.IssueDate = DateTime.Parse("20/05/1996");
            FixBond.Rate = 0.06;
            FixBond.Nominal = 100;

        }
        [TestMethod]
        public void LastBondDateIsOK()
        {
            Assert.AreEqual(FixBond.GetLastDate(), DateTime.Parse("20/05/2000"));
        }
        [TestMethod]
        public void GetCouponsNumberIsOK()
        {
            Assert.AreEqual(FixBond.GetCouponsNumber(), 8);
        }
        [TestMethod]
        public void DurationBeetweenTwoFluxIsOK()
        {
            Assert.AreEqual(FixBond.DurationBeetweenTwoFlux(), 0.5);
        }
        [TestMethod]
        public void ComputeFixBondCouponIsOK()
        {
            Assert.AreEqual(FixBond.ComputeCoupon(),3);
        }
    }
}
