using System;
using System.Runtime.Serialization;

namespace MyPricerWCFLibrary
{
    [DataContract]
    public class BondWcf
    {

            

        //Le nominal 
        private Double nominal;

        [DataMember]
        public Double Nominal
        {
            get { return nominal; }
            set { nominal = value; }
        }

        

        //la maturité (nombre d'année)
        private int maturity;
        [DataMember]
        public int Maturity
        {
            get { return maturity; }
            set
            {
                maturity = value;
            }
        }
        //La périodicité (nombre de mois)
        private int periodicity;

        [DataMember]
        public int Periodicity
        {
            get { return periodicity; }
            set { periodicity = value; }
        }

        //Date d'émission
        private DateTime issueDate;

        [DataMember]
        public DateTime IssueDate
        {
            get { return issueDate; }
            set { issueDate = value; }
        }


        //Le taux 
        private Double rate;

        [DataMember]
        public Double Rate
        {
            get { return rate; }
            set { rate = value; }
        }


    }
}