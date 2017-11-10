using Highsoft.Web.Mvc.Charts;
using MyPricerLibrary;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MyPricerClient.Controllers
{
    public class HomeController : Controller
    {
        IPricer pricer;


         public HomeController()
        {
            pricer = new Pricer();
        }
        public ActionResult Index()
        {
            GC.Collect();
            var defaultBond = GetDefaultBond();

            var bondPrices = GetBondPrices(defaultBond);
            var couponsCouru = GetCouponsCouru(defaultBond);

            SetViewBagForShow(bondPrices,couponsCouru);

            return View(defaultBond);

        }

        [HttpPost]
        public ActionResult Index(BondClient bondClient)
        {

            var bondPrices = GetBondPrices(bondClient);

            var couponsCouru = GetCouponsCouru(bondClient);

            SetViewBagForShow(bondPrices, couponsCouru);

            return View(bondClient);
        }

        private double MilliTimeStamp()
        {
            DateTime d1 = new DateTime(1970, 1, 1);
            DateTime d2 = GetFirstPricingDate().AddDays(1).ToUniversalTime();
            TimeSpan ts = new TimeSpan(d2.Ticks - d1.Ticks);

            return ts.TotalMilliseconds;
        }

        private List<DateTime> GetPricingDates(Bond bond)
        {
            List<DateTime> dates = new List<DateTime>();
            DateTime firstPricingDate = GetFirstPricingDate();


            var lastDate = bond.GetLastDate();


            while (firstPricingDate != lastDate.AddDays(1))
            {
                dates.Add(firstPricingDate);
                firstPricingDate = firstPricingDate.AddDays(1);

            }
            return dates;

        }
        private DateTime GetFirstPricingDate()
        {

            return new DateTime(1993, 1, 1);
        }

        private BondClient GetDefaultBond()
        {
            BondClient bond = new BondClient();
            bond.Maturity = 4;
            bond.Periodicity = 6;
            bond.IssueDate = DateTime.Parse("20/05/1996");
            bond.Rate = 0.06;
            bond.Nominal = 100;
            return bond;
        }

        private Bond MapClientFixBondWithLibraryFixBond(BondClient clientBond)
        {
            // A revoir !!!
            var  bond= new FixRateBond();
            bond.Maturity = clientBond.Maturity;
            bond.Periodicity = clientBond.Periodicity;
            bond.IssueDate = clientBond.IssueDate;
            bond.Rate = clientBond.Rate;
            bond.Nominal = clientBond.Nominal;

            // A revoir !!!
            clientBond.Coupon = bond.Coupon;
            return bond;

        }

        private List<double> GetBondPrices(BondClient bond)
        {
            var libraryBond = MapClientFixBondWithLibraryFixBond(bond);

            var dates = GetPricingDates(libraryBond);
            List<double> prices = new List<double>();
            double bondPrice;
            

            foreach (var item in dates)
            {
                bondPrice = pricer.Compute(libraryBond, item);
                prices.Add(bondPrice);
            }

            return prices;
        }

        private List<double> GetCouponsCouru(BondClient bond)
        {
            var libraryBond = MapClientFixBondWithLibraryFixBond(bond);

            var dates = GetPricingDates(libraryBond);
            List<double> couponsCouru = new List<double>();

            foreach (var item in dates)
            {
                couponsCouru.Add(libraryBond.GetCouponCouru(item));
            }

            return couponsCouru;
        }

        private void SetViewBagForShow(List<double> bondPrices, List<double> couponsCouru)
        {
            List<AreaSeriesData> timeData = new List<AreaSeriesData>();
            bondPrices.ForEach(p => timeData.Add(new AreaSeriesData { Y = p }));

            List<AreaSeriesData> timeData1 = new List<AreaSeriesData>();
            couponsCouru.ForEach(p => timeData1.Add(new AreaSeriesData { Y = p }));
            ViewBag.TimeData = timeData;
            ViewBag.TimeData1 = timeData1;

            ViewBag.DateUTC = MilliTimeStamp();

        }
    }
}