using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EventReview
{
    class StudentPerson :Person
    {
        public StudentPerson(string nom, string prenom, int age, DateTime birthDay) : base(nom, prenom, age, birthDay)
        {
            Statut = Statut.STUDENT;
        }
    }
}
