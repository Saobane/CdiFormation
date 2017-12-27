using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Linq;

namespace PokerHands
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestCardDeck()
        {
            var mydeck = new CardDeck();
            Assert.AreEqual(52, mydeck.Count());
        }
        [TestMethod]
        public void TestCreateNewDeck()
        {

            var mydeck = new CardDeck();
            var cards = "2 3 4 5 6 7 8 9 10 J Q K A";
            var cardsTab = cards.Split(' ');
             int pwer = 2;
            foreach (string card in cardsTab)
            {
                Assert.IsTrue(mydeck.Contains(new Card(card, CardType.COEUR, pwer)));
                Assert.IsTrue(mydeck.Contains(new Card(card, CardType.PIQUE, pwer)));
                Assert.IsTrue(mydeck.Contains(new Card(card, CardType.TREFLE, pwer)));
                Assert.IsTrue(mydeck.Contains(new Card(card, CardType.CARREAU, pwer)));
                pwer++;
            }

        }


        [TestMethod]
        public void TestCard_shuffle()
        {
            bool IsShuffle = false;
            var mydeck = new CardDeck();
            var mydeckTwo = new CardDeck();
            mydeck.Shuffle();

            for (int i = 0; i < mydeck.Count(); i++)
            {
                if (mydeck.ElementAt(i) != mydeckTwo.ElementAt(i))
                {
                    IsShuffle = true;
                    break;
                }

            }
            Assert.IsTrue(IsShuffle);
        }

    


    [TestMethod]
    public void TestPokerHandOnePair()
    {

        Pokerhand hand = new Pokerhand();

        hand.add(new Card("6", CardType.TREFLE, 6));
        hand.add(new Card("6", CardType.COEUR, 6));
        hand.add(new Card("3", CardType.TREFLE, 3));
        hand.add(new Card("Q", CardType.CARREAU, 12));
        hand.add(new Card("10", CardType.CARREAU, 10));

            Assert.IsTrue(hand.IsOnePair());
    }
        [TestMethod]
        public void TestPokerHandTwoPairs()
        {

            Pokerhand hand = new Pokerhand();

            hand.add(new Card("6", CardType.TREFLE, 6));
            hand.add(new Card("6", CardType.COEUR, 6));
            hand.add(new Card("3", CardType.TREFLE, 3));
            hand.add(new Card("3", CardType.CARREAU,3));
            hand.add(new Card("10", CardType.CARREAU,10));

            Assert.IsTrue(hand.IsTwoPairs());
        }

        [TestMethod]
        public void TestPokerHandThreeOfKind()
        {

            Pokerhand hand = new Pokerhand();

            hand.add(new Card("9", CardType.TREFLE,9));
            hand.add(new Card("9", CardType.COEUR,9));
            hand.add(new Card("3", CardType.TREFLE,3));
            hand.add(new Card("9", CardType.CARREAU,9));
            hand.add(new Card("10", CardType.CARREAU,10));

            Assert.IsTrue(hand.IsThreeOfKind());
        }

        [TestMethod]
        public void TestPokerHandStraight()
        {

            Pokerhand hand = new Pokerhand();

            hand.add(new Card("7", CardType.PIQUE,7));
            hand.add(new Card("3", CardType.COEUR,3));
            hand.add(new Card("4", CardType.TREFLE,4));
            hand.add(new Card("5", CardType.CARREAU,5));
            hand.add(new Card("6", CardType.TREFLE,6));

            Assert.IsTrue(hand.IsStraight());
        }
        [TestMethod]
        public void TestPokerHandFlush()
        {

            Pokerhand hand = new Pokerhand();

            hand.add(new Card("7", CardType.COEUR, 7));
            hand.add(new Card("3", CardType.COEUR, 3));
            hand.add(new Card("4", CardType.COEUR, 4));
            hand.add(new Card("Q", CardType.COEUR, 12));
            hand.add(new Card("K", CardType.COEUR, 13));

            Assert.IsTrue(hand.IsFlush());
        }

        [TestMethod]
        public void TestPokerHandFullHouse()
        {

            Pokerhand hand = new Pokerhand();

            hand.add(new Card("7", CardType.COEUR, 7));
            hand.add(new Card("7", CardType.TREFLE, 7));
            hand.add(new Card("7", CardType.CARREAU, 7));
            hand.add(new Card("J", CardType.PIQUE, 11));
            hand.add(new Card("J", CardType.COEUR, 11));

            Assert.IsTrue(hand.IsFullHouse());
        }
        [TestMethod]
        public void TestPokerHandSquare()
        {

            Pokerhand hand = new Pokerhand();

            hand.add(new Card("7", CardType.COEUR, 7));
            hand.add(new Card("7", CardType.TREFLE, 7));
            hand.add(new Card("7", CardType.CARREAU, 7));
            hand.add(new Card("7", CardType.PIQUE, 7));
            hand.add(new Card("J", CardType.COEUR, 11));

            Assert.IsTrue(hand.IsSquare());
        }
        [TestMethod]
        public void TestPokerHandStraightFlush()
        {

            Pokerhand hand = new Pokerhand();

            hand.add(new Card("2", CardType.COEUR, 2));
            hand.add(new Card("3", CardType.COEUR, 3));
            hand.add(new Card("4", CardType.COEUR, 4));
            hand.add(new Card("5", CardType.COEUR, 5));
            hand.add(new Card("6", CardType.COEUR, 6));

            Assert.IsTrue(hand.IsStraightFlush());
        }

        [TestMethod]
        public void TestPokerHandRoyalFlush()
        {

            Pokerhand hand = new Pokerhand();

            hand.add(new Card("A", CardType.COEUR, 14));
            hand.add(new Card("K", CardType.COEUR, 13));
            hand.add(new Card("Q", CardType.COEUR, 12));
            hand.add(new Card("J", CardType.COEUR, 11));
            hand.add(new Card("10", CardType.COEUR, 10));

            Assert.IsTrue(hand.IsRoyalFlush());
        }
    }
}
