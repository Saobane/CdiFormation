using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyPricerLibrary
{
    public class LinearInterpolation : IInterpolation
    {

        public double ComputeRate(double alphaMin, double alphaMax, double RateMin, double RateMax, double alpha)
        {
            if ((alphaMax - alphaMin) == 0)
                throw new IllegalDenominatorException();

            double A = (alphaMax - alpha) / (alphaMax - alphaMin);
            double B = (alpha - alphaMin) / (alphaMax - alphaMin);
            return A * RateMin + B * RateMax;
        }
    }
}
