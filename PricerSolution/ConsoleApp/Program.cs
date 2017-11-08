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
            

            var pricer = new Pricer();
            Bond bond = new FixedRateBond();
            bond.Maturity = 2;
            bond.Périodicity = 6;
            bond.IssueDate = DateTime.Parse("26/02/1993");
            bond.Coupon = 2;
            bond.Nominal = 100;

            var bondPrice =pricer.Compute(new LinearInterpolation(), bond, new RateRepositoryCsv(),DateTime.Parse("20/08/1993"));//20/09/1993

            Console.ReadLine();
        }
    }
}
