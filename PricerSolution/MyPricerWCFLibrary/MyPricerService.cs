using MyPricerLibrary;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace MyPricerWCFLibrary
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "Service1" in both code and config file together.
    public class MyPricerService : IMyPricerService
    {
        IPricer pricer;
        public MyPricerService()
        {
            pricer = new Pricer();
        }
        public double Compute(BondWcf bondwcf, DateTime pricerDate)
        {
            var bond = MapBond(bondwcf);
            
            return pricer.Compute(bond, pricerDate.Date);
        }

        public Dictionary<DateTime, double> ComputeToBondLastDate(BondWcf bondwcf)
        {
            Dictionary<DateTime, double> prices = new Dictionary<DateTime, double>();
            DateTime date = DateTime.Parse("01/01/1993");
            var bond = MapBond(bondwcf);
            while (date <= bond.GetLastDate())
            {
                prices.Add( date,pricer.Compute(bond, date));
                date = date.AddDays(1);
            }
            return prices;
        }
        

        private Bond MapBond(BondWcf bondWcf)
        {
            return new FixRateBond() { Maturity=bondWcf.Maturity,IssueDate=bondWcf.IssueDate.Date,Nominal=bondWcf.Nominal,Periodicity=bondWcf.Periodicity,Rate=bondWcf.Rate} ;
               
        }
    }
}
