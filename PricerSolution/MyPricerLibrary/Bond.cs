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
        public DateTime IssueDate { get; set; }
        //Coupon
        public  double Coupon { get { return ComputeCoupon(); } }

        public double Rate { get; set; }

        public abstract  double ComputeCoupon();

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
    }
}
