using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EventReview
{
    static class BankPricerRepo
    {
        private static Dictionary<Statut, IBankPricer> dictionaryOfPricer = new Dictionary<Statut, IBankPricer> { {Statut.EMPLOYED, new EmployedPricer() }, { Statut.UNEMPLOYED, new UnEmployedPricer() }, { Statut.STUDENT, new StudentPricer() } };
        public static IBankPricer GetPricer(Statut accountType)
        {
            return dictionaryOfPricer[accountType];
        }
    }
}
