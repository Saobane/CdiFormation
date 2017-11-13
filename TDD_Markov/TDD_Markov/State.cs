using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TDD_Markov
{
    class State : IEquatable<State>
    {
        private String name { get; set; }

        public State(String name)
        {
            if (string.IsNullOrEmpty(name))
            {
                throw new InvalidNameException();
            }
            this.name = name;
        }

        public override int GetHashCode()
        {
            return (name != null ? name.GetHashCode() : 0);
        }

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            if (ReferenceEquals(this, obj)) return true;
            if (obj.GetType() != this.GetType()) return false;
            return Equals((State) obj);
        }

        public bool Equals(State other)
        {
            if (ReferenceEquals(null, other)) return false;
            if (ReferenceEquals(this, other)) return true;
            return string.Equals(name, other.name);
        }
    }
}
