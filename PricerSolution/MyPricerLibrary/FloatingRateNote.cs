using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyPricerLibrary
{
    public class FloatingRateNote : Bond
    {
        protected override double ComputeCoupon()
        {
            throw new NotImplementedException();
        }
    }
}
