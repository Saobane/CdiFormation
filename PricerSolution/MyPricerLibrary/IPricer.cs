using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyPricerLibrary
{
   public  interface IPricer
    {
        void Compute(IInterpolation interpolation, Bond bond, IRateRepository rateRepository);
    }
}
