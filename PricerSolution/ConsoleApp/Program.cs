using MyPricerLibrary;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp
{
    class Program
    {
        static void Main(string[] args)
        {

            var df = new RateRepositoryCsv();

            var pricer = new Pricer();
            pricer.Compute(new LinearInterpolation(), null, new RateRepositoryCsv());

            var d = df.GetRatesCurve().Where(x=>x.RatesDate==DateTime.Parse("15/03/1993"));
        
        }
    }
}
