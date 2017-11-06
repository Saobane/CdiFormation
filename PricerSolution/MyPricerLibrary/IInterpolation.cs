using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyPricerLibrary
{
   public  interface IInterpolation
    {
        //alpha : Durée entre la date de pricing et le prochain flux
        double ComputeRate(double alphaMin,double alphaMax,double tauxMin,double tauxMax,double alpha);
    }
}
