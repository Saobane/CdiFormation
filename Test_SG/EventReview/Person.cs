using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EventReview
{
    public abstract class Person
    {
        public string Nom { get; private set; }
        public string Prenom { get; private set; }
        public int Age { get; private set; }
        public DateTime BirthDay { get; private set; }
        public Adresse Adresse { get; private set; }
        public Statut Statut { get; protected    set; }

        protected Person(string nom, string prenom, int age, DateTime birthDay)
        {
            Nom = nom;
            Prenom = prenom;
            Age = age;
            BirthDay = birthDay;
        }
  
        public override bool Equals(object obj)
        {
            if (obj is Person)
                return ((Person)obj).ToString()==ToString();

            return false;
        }
        public override int GetHashCode()
        {
            return base.GetHashCode();  
        }
        public override string ToString()
        {
            return Prenom+"-"+Nom ; 
        }


    }
}
