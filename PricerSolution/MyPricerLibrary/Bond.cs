using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyPricerLibrary
{
    public abstract class Bond
    {
        //Le nominal 
        public Double Nominal { get; set; }
        //la maturité (nombre d'année)
        private int maturity;
        public int Maturity
        {
            get { return maturity; }
            set
            {
                if (value <=0)
                {
                    throw new IllegalEntryException();
                }
                else
                {
                    maturity = value;
                }
            } }
        //La périodicité (nombre de mois)
        private int periodicity;
        public int Periodicity
        {
            get { return periodicity; }
            set
            {
                if ((maturity*12) % value   !=0 || value==0)
                {
                    throw new IllegalEntryException();
                }
                else
                {
                    periodicity = value;
                }
            } }
        //Date d'émission
        public DateTime IssueDate { get; set;  }
        //Coupon
        public  double Coupon { get { return ComputeCoupon(); } }

        public double Rate { get; set; }

        protected abstract  double ComputeCoupon();

        public DateTime GetLastDate() {

            return IssueDate.AddYears(Maturity);

        }
        public int GetCouponsNumber()
        {

            return (Maturity * 12) / Periodicity;
        }
        public double DurationBeetweenTwoFlux()
        {

            return (double)Maturity/GetCouponsNumber();
        }

        public double GetCouponCouru(DateTime couponCouruDate)
        {
            if (couponCouruDate < IssueDate || couponCouruDate> GetLastDate()|| couponCouruDate==null)
            {
                return 0;
            }
            else
            {
                var days = GetDaysSinceLastFlux(couponCouruDate);
                var periodicityInDays = GetPeriodicityInDays();
                return Coupon*(days/ periodicityInDays);
            }
        }
        private double GetDaysSinceLastFlux(DateTime couponCouruDate)
        {
            var nbrCoupons = GetCouponsNumber();

            DateTime tmp = IssueDate;
            DateTime lastFlux;
            for (int i = 1; i <= nbrCoupons; i++)
            {
                if (couponCouruDate == tmp)
                {
                    return 0;
                }
                else if (couponCouruDate < tmp.AddMonths(Periodicity))
                {

                    lastFlux = tmp;
                    return (couponCouruDate - lastFlux).TotalDays;
                }
                tmp = tmp.AddMonths(Periodicity);

            }

            return 0;

        }
        private double GetPeriodicityInDays()
        {
            return (double) 365 * periodicity / 12;
        }
    }
}
