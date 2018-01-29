using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EventReview
{
    public class UnemployedPerson : Person
    {
        public UnemployedPerson(string nom, string prenom, int age, DateTime birthDay):base(nom,prenom,age,birthDay)
        {

            Statut = Statut.UNEMPLOYED;
        }
    }
}
