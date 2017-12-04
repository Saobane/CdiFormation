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
        public double Compute(BondWcf bondwcf, DateTime pricerDate)
        {
            var bond = MapBond(bondwcf);
            IPricer pricer = new Pricer();
            return pricer.Compute(bond, pricerDate.Date);
        }

        private Bond MapBond(BondWcf bondWcf)
        {
            return new FixRateBond() { Maturity=bondWcf.Maturity,IssueDate=bondWcf.IssueDate.Date,Nominal=bondWcf.Nominal,Periodicity=bondWcf.Periodicity,Rate=bondWcf.Rate} ;
               
        }
    }
}
