using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;

namespace TDD_Markov
{
    delegate void CurrentStateChangeEvent(State current);

    class MarkovChaine
    {
        public event CurrentStateChangeEvent onCurrentStateChanged;
        private IList<State> States { get; set; }
        private IDictionary<State, IList<Transition>> Transitions { get; set; }
        private Random rdm = new Random();
        private State _currentState;
        public State CurrentState {
            set
            {
                if (!States.Contains(value))
                    throw new InvalidCurrentStateException();
                if (onCurrentStateChanged != null)
                    onCurrentStateChanged(value);
                _currentState = value;
            }
            get { return _currentState; }
            
        }
   
        

        public MarkovChaine()
        {
            States = new List<State>();
            Transitions = new Dictionary<State, IList<Transition>>();
        }
        internal void addState(State roue)
        {
            States.Add(roue);
            
        }

        internal void setTransition(State begin, State end, double p)
        {
            if (!States.Contains(begin) || !States.Contains(end))
                throw new InvalidTransitionException();

            if (p < 0 || p > 1)
                throw new OutOfRangeProbabilityException();


            var transition = new Transition(begin, end, p);
            if(Transitions.ContainsKey(begin))
                Transitions[begin].Add(transition);
            else
            {
                Transitions.Add(begin, new List<Transition>(){transition});
            }
        }


        internal void CheckValid()
        {
            if (States.Count != Transitions.Count)
            {
                throw  new InvalidMarkovChainException();
            }

            foreach (var item in Transitions)
            {
                if (item.Value.Sum(x => x.Probability) != 1)
                {
                    throw  new InvalidMarkovChainException();
                }
            }
        }

        internal void Simulate()
        {
            double p = rdm.NextDouble();
            var transitions = Transitions[CurrentState];
            var OrdTransitions = transitions.OrderBy(x => x.Probability).ToList();

            double start = 0;
            foreach (var item in OrdTransitions)
            {
                start += item.Probability;
                if (start >= p)
                {
                    CurrentState = item.End;
                    break;
                }
            }
        }
    }
}
