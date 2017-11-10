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
        private double prevBondPrice = 0;

        public  Pricer() :this(new RateRepositoryCsv(), new LinearInterpolation())
        {
        }

        public Pricer(IRateRepository _rateRepository, IInterpolation _interpolation)
        {
            rateRepository= _rateRepository;
            RatesCurves = rateRepository.GetRatesCurves();
            interpolation = _interpolation;
        }
        public double Compute( Bond bond,DateTime pricerDate)
        {

            #region Objects

            double Po = 1;
            RateCurve pricerRateCurve;
            var RateCurveDatePricer = RatesCurves.Where(x => x.RatesDate == pricerDate);
            #endregion
            if (!PricingDateIsInCsvDateRange(pricerDate))
            {
                return default(double);
            }

            if (pricerDate >= bond.IssueDate && pricerDate <= bond.GetLastDate() && RateCurveDatePricer.Count() == 0)
            {
                return prevBondPrice;
            }
            if ( pricerDate < bond.IssueDate || pricerDate>bond.GetLastDate() )
            {
                return default(double);
            }
            else
            {
                 pricerRateCurve = RateCurveDatePricer.First();
            }
            


            if (pricerRateCurve != null)
            {
                
                #region Objects
                var nextFluxDate = GetNextFluxDate(bond, pricerDate);

                var reelDurations = GetReelDurations(rateRepository.GetDurations());
                var alpha = ComputeAlpha(pricerDate, nextFluxDate);

                var nbrCoupons = bond.GetCouponsNumber();
                Po = 0;
                double k = alpha;
                double dynAlpha = 0;
                var nbr = GetNbrFluxRestant(bond, nextFluxDate);
                double alphaMin ;
                double alphaMax ;
                double alphaMinRate ;
                double alphaMaxRate;
                #endregion
                for (int i = 1; i <= nbr; i++)
                {

                    #region Objects

                    alphaMin = GetAlphaMin(reelDurations, k);
                    alphaMax = GetAlphaMax(reelDurations, k);
                    alphaMinRate = Convert.ToDouble(pricerRateCurve.Rates[alphaMin * 100]);
                    alphaMaxRate = Convert.ToDouble(pricerRateCurve.Rates[alphaMax * 100]);
                    dynAlpha = interpolation.ComputeRate(alphaMin, alphaMax, alphaMinRate, alphaMaxRate, k);
                    #endregion
                    if (i != nbr)
                    {
                        if (dynAlpha==0)
                        {
                            return prevBondPrice;
                        }
                        //Calcule du Prix
                        Po += bond.Coupon / Math.Pow((1 + dynAlpha), k);

                        k += bond.DurationBeetweenTwoFlux();
                         
                    }
                    else
                    {
                        Po += (bond.Coupon + bond.Nominal) / Math.Pow((1 + dynAlpha), k);
                    }
                    
                }

               
            }

           

           
            prevBondPrice = Po;
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
            var nbrCoupons = bond.GetCouponsNumber();

            DateTime tmp= issueDate;
            for (int i = 1; i <= nbrCoupons; i++)
            {
                tmp = tmp.AddMonths(bond.Periodicity);
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
                nextFluxdate = nextFluxdate.AddMonths(bond.Periodicity);
            }

            return i;


        }
       

        private List<double> GetReelDurations(List<double> durations)
        {
            var tmp = new List<double>();

            for (int i = 0; i < durations.Count; i++)
            {
                double dbtmp = (double)durations[i] / 100;
                tmp.Add(dbtmp) ;
            }

            return tmp;
        }

        private bool PricingDateIsInCsvDateRange(DateTime pricingDate)
        {
            var dates = RatesCurves.Select(x => x.RatesDate);
            DateTime maxCsvDate = dates.Max();
            DateTime minCsvDate = dates.Min();


            return pricingDate>= minCsvDate && pricingDate<= maxCsvDate;
        }



    }
}
