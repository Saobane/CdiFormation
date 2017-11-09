using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyPricerClient
{
    public  class BondClient
    {
        //Le nominal 
        [Required]
        public Double Nominale { get; set; }
        //la maturité (nombre d'année)
        [Required]
        public int Maturity { get; set; }
        //La périodicité (nombre de mois)
        [Required]
        public int Periodicity { get; set; }
        //Date d'émission
        [Required]
        public DateTime IssueDate { get; set; }
        //Coupon
        [Required]
        public double Coupon { get; set; }

       
    }
}
