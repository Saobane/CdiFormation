using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyPricerLibrary
{
    public class Pricer : IPricer
    {
         
        public void Compute(IInterpolation interpolation, Bond bond, IRateRepository rateRepository)
        {

            var RatesCurves = rateRepository.GetRatesCurve();
            var durations = rateRepository.GetHeaderDurations();
            var alpha = 140;
            var alphaMin = GetAlphaMin(durations, alpha);
            var alphaMax = GetAlphaMax(durations, alpha);
            throw new NotImplementedException();
        }

        private int GetAlphaMin(IEnumerable<int> durations,int alpha)
        {
            return durations.Where(x=>x<alpha).Max();
        }
        private int GetAlphaMax(IEnumerable<int> durations, int alpha)
        {
            return durations.Where(x => x > alpha).Min();
        }

        private double ComputeAlpha(DateTime pricerDate,DateTime nextFlux)
        {

            return (nextFlux-pricerDate).TotalDays;
        } 
    }
}
