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
            Bond bond = new FixRateBond();
            bond.Maturity = 4;
            bond.Periodicity = 6;
            bond.IssueDate = DateTime.Parse("26/02/1993");
            bond.Coupon = 8;
            bond.Nominale = 100;
            var pricerDate = DateTime.Parse("01/01/1993");
            while (pricerDate !=bond.IssueDate.AddYears(bond.Maturity).AddDays(2))
            {
              
                var bondPrice = pricer.Compute( bond, pricerDate);//20/09/1993
               
                Console.WriteLine("Pricer Date {0} => Price : {1}", pricerDate, bondPrice);
                pricerDate = pricerDate.AddDays(1);

            }

            Console.ReadLine();
        }
    }
}
