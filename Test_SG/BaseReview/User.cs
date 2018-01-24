using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BaseReview
{
    public class User 
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }

        public User(string firstName, string lastName)
        {
            FirstName = firstName;
            LastName = lastName;
        }
        public override bool Equals(object obj)
        {
            if (obj is User)
                return ((User)obj).FirstName == FirstName && ((User)obj).LastName == LastName;
            return false;
        }

        public override int GetHashCode()
        {
            var hashCode = 1938039292;
            hashCode = hashCode * -1521134295 + EqualityComparer<string>.Default.GetHashCode(FirstName);
            hashCode = hashCode * -1521134295 + EqualityComparer<string>.Default.GetHashCode(LastName);
            return hashCode;
        }
    }

    public class Singleton
    {
        private static Singleton singleton;

        protected Singleton()
        {

        }
        public static Singleton GetSingleton()
        {
            if (singleton == null)
                singleton = new Singleton();

            return singleton;
        }
    }
}
