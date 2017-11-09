using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyPricerLibrary
{
    public class FixRateBond : Bond
    {
        public override double ComputeCoupon()
        {
            return Rate * Nominal* DurationBeetweenTwoFlux();
        }
    }
}
