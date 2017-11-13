using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TDD_Markov
{
    class Transition
    {
        public double Probability { get; private set; }
        public State Begin { get; private set; }
        public State End { get; private set; }

        public Transition(State begin, State end, double probability)
        {
            Begin = begin;
            End = end;
            Probability = probability;
        }
    }
}
