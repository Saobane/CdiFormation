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
         
        public ActionResult Index()
        {
            GC.Collect();
            var defaultBond = GetDefaultBond();

            var bondPrices = GetBondPrices(defaultBond);

            SetViewBagForShow(bondPrices);

            return View(defaultBond);

        }

        [HttpPost]
        public ActionResult Index(BondClient bondClient)
        {

            var bondPrices = GetBondPrices(bondClient);

            SetViewBagForShow(bondPrices);

            return View(bondClient);
        }

        private double MilliTimeStamp()
        {
            DateTime d1 = new DateTime(1970, 1, 1);
            DateTime d2 = GetFirstPricingDate().AddDays(1).ToUniversalTime();
            TimeSpan ts = new TimeSpan(d2.Ticks - d1.Ticks);

            return ts.TotalMilliseconds;
        }

        private List<string> GetPricingDates(Bond bond)
        {
            List<string> dates = new List<string>();
            DateTime firstPricingDate = GetFirstPricingDate();


            var lastDate = bond.GetLastDate();


            while (firstPricingDate != lastDate.AddDays(1))
            {
                dates.Add(firstPricingDate.ToString());
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
            bond.Coupon = 6;
            bond.Nominale = 100;
            return bond;
        }

        private Bond MapLibraryFixBondWithClientFixBond(BondClient clientBond)
        {
            // A revoir !!!
            var  bond= new FixRateBond();
            bond.Maturity = clientBond.Maturity;
            bond.Periodicity = clientBond.Periodicity;
            bond.IssueDate = clientBond.IssueDate;
            bond.Coupon = clientBond.Coupon;
            bond.Nominale = clientBond.Nominale;
            return bond;

        }

        private List<double> GetBondPrices(BondClient bond)
        {
            var defaultBond = MapLibraryFixBondWithClientFixBond(bond);
            var dates = GetPricingDates(defaultBond);
            List<double> prices = new List<double>();
            double bondPrice;
            var pricer = new Pricer();

            foreach (var item in dates)
            {
                bondPrice = pricer.Compute(defaultBond, DateTime.Parse(item));
                prices.Add(bondPrice);
            }

            return prices;
        }

        private void SetViewBagForShow(List<double> bondPrices)
        {
            List<AreaSeriesData> timeData = new List<AreaSeriesData>();
            bondPrices.ForEach(p => timeData.Add(new AreaSeriesData { Y = p }));
            ViewBag.TimeData = timeData;
            ViewBag.DateUTC = MilliTimeStamp();

        }
    }
}