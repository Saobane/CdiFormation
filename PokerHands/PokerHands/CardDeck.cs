using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace PokerHands
{
    internal class CardDeck : IEnumerable<Card>
    {
        public List<Card> deck { get; set; }
        public CardDeck()
        {
            deck = new List<Card>();
            int power = 2;
            var cards = "2 3 4 5 6 7 8 9 10 J Q K A";
            var cardsTab = cards.Split(' ');

            foreach (string card in cardsTab)
            {
               deck.Add(new Card(card, CardType.COEUR,power));
               deck.Add(new Card(card, CardType.PIQUE,power));
               deck.Add(new Card(card, CardType.TREFLE, power));
               deck.Add(new Card(card, CardType.CARREAU, power));
                power++;
            }
        }


        public IEnumerator<Card> GetEnumerator()
        {
            return deck.GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return deck.GetEnumerator();
        }

        public void Shuffle()
        {
           var random = new Random();
            List<Card> CardShuffle = new List<Card>();
           
            while(deck.Any())
            {
                int val = random.Next(0, deck.Count);
                CardShuffle.Add(deck.ElementAt(val));
                deck.RemoveAt(val);
            }

            deck = CardShuffle;
        }
    }
}