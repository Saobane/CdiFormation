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
        //la maturité
        public int Maturity { get; set; }
        //La périodicité
        public int Périodicity { get; set; }
        //Date d'émission
        public DateTime IssueDate { get; set; }
        //Coupon
        public double Coupon { get; set; }
    }
}
