using DotNet.Highcharts;
using DotNet.Highcharts.Enums;
using DotNet.Highcharts.Helpers;
using DotNet.Highcharts.Options;
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

            var pricer = new Pricer();
            Bond bond = new FixedRateBond();
            bond.Maturity = 4;
            bond.Périodicity = 6;
            bond.IssueDate = DateTime.Parse("26/02/1993");
            bond.Coupon = 2;
            bond.Nominal = 100;
            var dates =GetPricingDate(bond);
            List<object> prices = new List<object>();
            //while (pricerDate != bond.IssueDate.AddYears(bond.Maturity))
            //{
            //    var bondPrice = pricer.Compute(new LinearInterpolation(), bond, new RateRepositoryCsv(), pricerDate);//20/09/1993
            //    prices.Add(bondPrice);
            //    pricerDate = pricerDate.AddDays(1);

            //}
            double bondPrice;
            foreach (var item in dates)
            {
                bondPrice = pricer.Compute(new LinearInterpolation(), bond, DateTime.Parse( item));//20/09/1993
                prices.Add(bondPrice);
            }


            Highcharts columnChart = new Highcharts("columnchart");

            columnChart.InitChart(new Chart()
            {
                Type = DotNet.Highcharts.Enums.ChartTypes.Column,
                BackgroundColor = new BackColorOrGradient(System.Drawing.Color.AliceBlue),
                Style = "fontWeight: 'bold', fontSize: '17px'",
                BorderColor = System.Drawing.Color.LightBlue,
                BorderRadius = 0,
                BorderWidth = 2

            });

            columnChart.SetTitle(new Title()
            {
                Text = "Sachin Vs Dhoni"
            });

            columnChart.SetSubtitle(new Subtitle()
            {
                Text = "Played 9 Years Together From 2004 To 2012"
            });

            columnChart.SetXAxis(new XAxis()
            {
                Type = AxisTypes.Category,
                Title = new XAxisTitle() { Text = "Years", Style = "fontWeight: 'bold', fontSize: '17px'" },
                Categories = new[] { "2004", "2005", "2006", "2007", "2008", "2009", "2010", "2011", "2012" }
            });

            columnChart.SetYAxis(new YAxis()
            {
                Title = new YAxisTitle()
                {
                    Text = "Runs",
                    Style = "fontWeight: 'bold', fontSize: '17px'"
                },
                ShowFirstLabel = true,
                ShowLastLabel = true,
                Min = 0
            });

            columnChart.SetLegend(new Legend
            {
                Enabled = true,
                BorderColor = System.Drawing.Color.CornflowerBlue,
                BorderRadius = 6,
                BackgroundColor = new BackColorOrGradient(ColorTranslator.FromHtml("#FFADD8E6"))
            });

            columnChart.SetSeries(new Series[]
            {
                new Series{

                    Name = "Sachin Tendulkar",
                    Data = new Data(new object[] { 812, 412, 628, 1425, 460, 972, 204, 513, 315 })
                },
                new Series()
                {
                    Name = "M S Dhoni",
                    Data = new Data(new object[] { 19, 895, 821, 1103, 1097, 1198, 600, 764, 524, })
                }
            }
            );

            return View(columnChart);
        }

        private List<string> GetPricingDate(Bond bond)
        {
            List<string> dates = new List<string>();

            var pricerDate = DateTime.Parse("01/01/1995");
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