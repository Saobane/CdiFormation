using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyPricerLibrary
{
    public class Pricer : IPricer
    {
        private IRateRepository rateRepository;
        private IEnumerable<RateCurve> RatesCurves;
        private IInterpolation interpolation;
        private double nextCompute = 0;

        public  Pricer()
        {
            rateRepository = new RateRepositoryCsv();
            RatesCurves = rateRepository.GetRatesCurve();
            interpolation = new LinearInterpolation();
        }


        public double Compute( Bond bond,DateTime pricerDate)
        {
            
            double Po=1;
            RateCurve pricerRateCurve;
            var RateCurveDatePricer = RatesCurves.Where(x => x.RatesDate == pricerDate);
            if (pricerDate==DateTime.Parse("10/03/1993"))
            {
                var gty = 05;
            }
           
            if ( pricerDate < bond.IssueDate || pricerDate>bond.GetLastDate())
            {
                return default(double);
            }
            else
            {
                 pricerRateCurve = RateCurveDatePricer.First();
            }
            if (pricerDate >= bond.IssueDate && pricerDate <= bond.GetLastDate() && RateCurveDatePricer.Count() == 0 )
            {
                return nextCompute;
            }


            if (pricerRateCurve != null)
            {
                var nextFluxDate = GetNextFluxDate(bond, pricerDate);

                var reelDurations = GetReelDurations(rateRepository.GetHeaderDurations());
                var alpha = ComputeAlpha(pricerDate, nextFluxDate);
                //var alphaMin = GetAlphaMin(reelDurations, alpha);
                //var alphaMax = GetAlphaMax(reelDurations, alpha);
                //var alphaMinRate = Convert.ToDouble(pricerRateCurve.Rates[alphaMin * 100]);
                //var alphaMaxRate = Convert.ToDouble(pricerRateCurve.Rates[alphaMax*100]);
                //var alphaRate = interpolation.ComputeRate(alphaMin, alphaMax, alphaMinRate, alphaMaxRate, alpha);

                var nbrCoupons = GetCouponsNumber(bond);
                 Po=0;
                double k = alpha;
                double dynAlpha = 0;
                var nbr = GetNbrFluxRestant(bond, nextFluxDate);


                #region VAR
                double alphaMinV ;
                double alphaMaxV ;
                double alphaMinRateV ;
                double alphaMaxRateV;
                #endregion
                for (int i = 1; i <= nbr; i++)
                {
                    if (i != nbr)
                    {
                        alphaMinV = GetAlphaMin(reelDurations, k);
                        alphaMaxV = GetAlphaMax(reelDurations, k);
                        alphaMinRateV = Convert.ToDouble(pricerRateCurve.Rates[alphaMinV * 100]);
                        alphaMaxRateV = Convert.ToDouble(pricerRateCurve.Rates[alphaMaxV * 100]);
                        dynAlpha = interpolation.ComputeRate(alphaMinV, alphaMaxV, alphaMinRateV, alphaMaxRateV, k);
                        //Calcule du Prix
                        Po += bond.Coupon / Math.Pow((1 + dynAlpha), k);

                        k += (double)bond.Maturity / nbrCoupons;
                         
                    }
                    else
                    {
                        alphaMinV = GetAlphaMin(reelDurations, k);
                        alphaMaxV = GetAlphaMax(reelDurations, k);
                        alphaMinRateV = Convert.ToDouble(pricerRateCurve.Rates[alphaMinV * 100]);
                        alphaMaxRateV = Convert.ToDouble(pricerRateCurve.Rates[alphaMaxV * 100]);
                        dynAlpha = interpolation.ComputeRate(alphaMinV, alphaMaxV, alphaMinRateV, alphaMaxRateV, k);
                        Po += (bond.Coupon + bond.Nominal) / Math.Pow((1 + dynAlpha), k);
                    }
                    
                }

               
            }

           

           
            nextCompute = Po;
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
