using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyPricerLibrary
{
    public class Pricer : IPricer
    {
         
        public double Compute(IInterpolation interpolation, Bond bond, IRateRepository rateRepository,DateTime pricerDate)
        {

            var RatesCurves = rateRepository.GetRatesCurve();
            double Po=0;
            RateCurve pricerRateCurve;
            var RateCurveDatePricer = RatesCurves.Where(x => x.RatesDate == pricerDate);
            if (RateCurveDatePricer.Count()==0)
            {
                return default(double);
            }
            else
            {
                 pricerRateCurve = RateCurveDatePricer.First();
            }
            if (pricerRateCurve != null)
            {
                var nextFluxDate = GetNextFluxDate(bond, pricerDate);

                var durations = rateRepository.GetHeaderDurations();
                var reelDurations = GetReelDurations(durations);
                var alpha = ComputeAlpha(pricerDate, nextFluxDate);
                var alphaMin = GetAlphaMin(reelDurations, alpha);
                var alphaMax = GetAlphaMax(reelDurations, alpha);
                var alphaMinRate = Convert.ToDouble(pricerRateCurve.Rates[alphaMin * 100]);
                var alphaMaxRate = Convert.ToDouble(pricerRateCurve.Rates[alphaMax*100]);
                var alphaRate = interpolation.ComputeRate(alphaMin, alphaMax, alphaMinRate, alphaMaxRate, alpha);

                var nbrCoupons = GetCouponsNumber(bond);
                 Po=0;
                double k = alpha;
                double dynAlpha = alphaRate;
                var nbr = GetNbrFluxRestant(bond, nextFluxDate);
                for (int i = 1; i <= nbr; i++)
                {
                    if (i != nbr)
                    {
                        Po += bond.Coupon / Math.Pow((1 + dynAlpha), k);
                        k += (double)bond.Maturity / nbrCoupons;
                        var alphaMinV = GetAlphaMin(reelDurations, k);
                        var alphaMaxV = GetAlphaMax(reelDurations, k);
                        var alphaMinRateV = Convert.ToDouble(pricerRateCurve.Rates[alphaMinV * 100]);
                        var alphaMaxRateV = Convert.ToDouble(pricerRateCurve.Rates[alphaMaxV * 100]);
                        dynAlpha = interpolation.ComputeRate(alphaMinV, alphaMaxV, alphaMinRateV, alphaMaxRateV, k);
                    }
                    else
                    {
                        Po += (bond.Coupon + bond.Nominal) / Math.Pow((1 + dynAlpha), k);
                    }
                    
                }

               
            }
            return Po;


        }

        private double GetAlphaMin(IEnumerable<double> durations,double alpha)
        {
            var minsAlpha = durations.Where(x => x < alpha);

            if (minsAlpha.Count()==0)
            {
                return 0;
            }
            else
            {
                return minsAlpha.Max();

            }
        }
        private double GetAlphaMax(IEnumerable<double> durations, double alpha)
        {
            return durations.Where(x => x > alpha).Min();
        }

        private double ComputeAlpha(DateTime pricerDate,DateTime nextFlux)
        {

            return (nextFlux-pricerDate).TotalDays/365;
        }

        private DateTime GetNextFluxDate(Bond bond,DateTime pricerdate)
        {
            var issueDate = bond.IssueDate;
            var nbrCoupons = GetCouponsNumber(bond);
            if (pricerdate < issueDate)
                return default(DateTime);

            DateTime tmp= issueDate;
            for (int i = 1; i <= nbrCoupons; i++)
            {
                tmp = tmp.AddMonths(bond.Périodicity);
                if (tmp > pricerdate)
                {
                    break;
                }
            }

            return tmp;


        }
        private int GetNbrFluxRestant(Bond bond, DateTime nextFluxdate)
        {
            var issueDate = bond.IssueDate;
            var lastCoupon = issueDate.AddYears(bond.Maturity);
            int i = 1;
            while (nextFluxdate != lastCoupon)
            {
                i++;
                nextFluxdate = nextFluxdate.AddMonths(bond.Périodicity);
            }

            return i;


        }
        private int GetCouponsNumber(Bond bond)
        {

            return (bond.Maturity * 12) / bond.Périodicity;
        }

        private List<double> GetReelDurations(List<double> durations)
        {
            var tmp = new List<double>(durations.Count);

            for (int i = 0; i < durations.Count; i++)
            {
                double dbtmp = (double)durations[i] / 100;
                tmp.Add(dbtmp) ;
            }

            return tmp;
        }
    }
}
