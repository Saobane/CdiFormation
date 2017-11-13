using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace TDD_Markov
{
    [TestClass]
    public class UnitTest1
    {
        private MarkovChaine markovC { set; get; }
        private State roue, copeaux, mangeoire;

        [TestInitialize]
        public void TestCreateState()
        {
            markovC = new MarkovChaine();
            roue = new State("Roue");
            copeaux = new State("Copeaux");
            mangeoire = new State("Mangeoire");
            markovC.addState(roue);
            markovC.addState(copeaux);
            markovC.addState(mangeoire);

        }

        [TestMethod]
        [ExpectedException(typeof(InvalidNameException))]

        public void TestStateName()
        {
            var state = new State(null);

        }

        [TestMethod]
        [ExpectedException(typeof(InvalidNameException))]
        public void TestEmptyNameState()
        {
            var state = new State("");
        }

        [TestMethod]
        [ExpectedException(typeof(InvalidTransitionException))]
        public void TestStateToInvalidState()
        {
            var state = new State("Douche");

            markovC.setTransition(roue, state, 0.5);

        }

        [TestMethod]

        public void TestStateToValidState()
        {
            markovC.setTransition(roue, mangeoire, 0.5);
        }

        [TestMethod]
        [ExpectedException(typeof(OutOfRangeProbabilityException))]
        public void TestOutOfRangeProbability()
        {
            markovC.setTransition(roue, mangeoire, -1);
        }

        [TestMethod]
        [ExpectedException(typeof(InvalidMarkovChainException))]
        public void TestInValidityMarkovChain()
        {
            markovC.setTransition(roue, mangeoire, 0.4);
            markovC.setTransition(roue, copeaux, 0.7);
            markovC.CheckValid();
        }

        [TestMethod]
        public void TestHamsterChainValidity()
        {
            markovC.setTransition(roue, copeaux, 0.8);
            markovC.setTransition(roue, roue, 0.2);
            markovC.setTransition(copeaux, copeaux, 0.9);
            markovC.setTransition(copeaux, roue, 0.05);
            markovC.setTransition(copeaux, mangeoire, 0.05);
            markovC.setTransition(mangeoire, roue, 0.3);
            markovC.setTransition(mangeoire, copeaux, 0.7);

            markovC.CheckValid();
        }

        [TestMethod]
        [ExpectedException(typeof(InvalidCurrentStateException))]
        public void TestInvalidCurrentState()
        {
            markovC.setTransition(roue, copeaux, 0.8);
            markovC.setTransition(roue, roue, 0.2);
            markovC.setTransition(copeaux, copeaux, 0.9);
            markovC.setTransition(copeaux, roue, 0.05);
            markovC.setTransition(copeaux, mangeoire, 0.05);
            markovC.setTransition(mangeoire, roue, 0.3);
            markovC.setTransition(mangeoire, copeaux, 0.7);

            markovC.CurrentState = new State("dummy");
        }

        [TestMethod]

        public void TestValidCurrentState()
        {
            markovC.setTransition(roue, copeaux, 0.8);
            markovC.setTransition(roue, roue, 0.2);
            markovC.setTransition(copeaux, copeaux, 0.9);
            markovC.setTransition(copeaux, roue, 0.05);
            markovC.setTransition(copeaux, mangeoire, 0.05);
            markovC.setTransition(mangeoire, roue, 0.3);
            markovC.setTransition(mangeoire, copeaux, 0.7);

            markovC.CurrentState = mangeoire;
        }

        [TestMethod]

        public void TestSimulateTransition()
        {
            markovC.setTransition(roue, copeaux, 0.8);
            markovC.setTransition(roue, roue, 0.2);
            markovC.setTransition(copeaux, copeaux, 0.9);
            markovC.setTransition(copeaux, roue, 0.05);
            markovC.setTransition(copeaux, mangeoire, 0.05);
            markovC.setTransition(mangeoire, roue, 0.3);
            markovC.setTransition(mangeoire, copeaux, 0.7);

            markovC.CurrentState = mangeoire;
            markovC.onCurrentStateChanged += MarkovCOnOnCurrentStateChanged;
            Enumerable.Range(0, 10000).ToList().ForEach(x => markovC.Simulate());

             var disp = reports.ToList().Select(x => (double)x.Value/10000).ToList();


        }

        private IDictionary<State,int> reports = new Dictionary<State, int>();
        private void MarkovCOnOnCurrentStateChanged(State current)
        {
            if (reports.ContainsKey(current))
            {
                reports[current]++;
            }
            else
            {
                reports.Add(current,1);
            }

        }


    }
}
