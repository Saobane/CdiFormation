using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyPricerClientWPF.Model
{
    public  class BondClient
    {
        //Le nominal 
        public Double Nominal { get; set; }
        //la maturité (nombre d'année)
        public int Maturity { get; set; }
        //La périodicité (nombre de mois)
        public int Periodicity { get; set; }
        //Date d'émission
        public DateTime IssueDate { get; set; }
        //Coupon
        //public double Coupon { get; set; }

        public double Rate { get; set; }
    }
}
