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
            var pricer = new Pricer();
            Bond bond = new FixedRateBond();
            bond.Maturity = 4;
            bond.Périodicity = 6;
            bond.IssueDate = DateTime.Parse("26/02/1993");
            bond.Coupon = 12;
            bond.Nominal = 100;
            var dates =GetPricingDate(bond,DateTime.Parse("01/01/1993"));
            List<double> prices = new List<double>();
            //while (pricerDate != bond.IssueDate.AddYears(bond.Maturity))
            //{
            //    var bondPrice = pricer.Compute(new LinearInterpolation(), bond, new RateRepositoryCsv(), pricerDate);//20/09/1993
            //    prices.Add(bondPrice);
            //    pricerDate = pricerDate.AddDays(1);

            //}
            double bondPrice;
            foreach (var item in dates)
            {
                bondPrice = pricer.Compute( bond, DateTime.Parse( item));//20/09/1993
                prices.Add(bondPrice);
            }



            List<AreaSeriesData> timeData = new List<AreaSeriesData>();
            prices.ForEach(p => timeData.Add(new AreaSeriesData { Y = p }));
            ViewBag.TimeData = timeData;
            ViewBag.DateUTC = MilliTimeStamp(new System.DateTime(1993, 1, 2));

            return View();

        }

        private double MilliTimeStamp(DateTime dateTime)
        {
            DateTime d1 = new DateTime(1970, 1, 1);
            DateTime d2 = dateTime.ToUniversalTime();
            TimeSpan ts = new TimeSpan(d2.Ticks - d1.Ticks);

            return ts.TotalMilliseconds;
        }

        private List<string> GetPricingDate(Bond bond,DateTime pricerDate)
        {
            List<string> dates = new List<string>();

            var lastDate = bond.IssueDate.AddYears(bond.Maturity);


            while (pricerDate != lastDate)
            {
                dates.Add(pricerDate.ToString());
                pricerDate = pricerDate.AddDays(1);

            }
            return dates;

        }
    }
}