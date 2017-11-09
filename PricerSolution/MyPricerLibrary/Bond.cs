﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyPricerLibrary
{
    public abstract class Bond
    {
        //Le nominal 
        public Double Nominale { get; set; }
        //la maturité (nombre d'année)
        public int Maturity { get; set; }
        //La périodicité (nombre de mois)
        public int Periodicity { get; set; }
        //Date d'émission
        public DateTime IssueDate { get; set; }
        //Coupon
        public double Coupon { get; set; }

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
