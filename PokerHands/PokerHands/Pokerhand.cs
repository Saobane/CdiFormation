using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace PokerHands
{
    internal class Pokerhand : IEnumerable<Card>
    {
        List<Card> cardHand;
        public Pokerhand()
        {
            cardHand = new List<Card>();
        }

        public IEnumerator<Card> GetEnumerator()
        {
            return cardHand.GetEnumerator();
        }

        public void add(Card card)
        {
            cardHand.Add(card);
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return cardHand.GetEnumerator();
        }

        internal bool IsOnePair()
        {
            cardHand.Sort();

            for (int i = 0; i < cardHand.Count - 1; i++)
            {
                if (cardHand.ElementAt(i).value == cardHand.ElementAt(i + 1).value)
                    return true;

            }

            return false;
        }

        internal bool IsTwoPairs()
        {

            cardHand.Sort();
            int pairNumber = 0;
            for (int i = 0; i < cardHand.Count - 1; i++)
            {
                if (cardHand.ElementAt(i).value == cardHand.ElementAt(i + 1).value)
                    pairNumber++;

            }

            return pairNumber > 1;

        }

        public bool IsThreeOfKind()
        {

            cardHand.Sort();
            for (int i = 0; i < cardHand.Count - 2; i++)
            {
                if (cardHand.ElementAt(i).value == cardHand.ElementAt(i + 1).value && cardHand.ElementAt(i + 1).value == cardHand.ElementAt(i + 2).value)
                    return true;

            }

            return false;

        }

        public bool IsStraight()
        {
            cardHand.Sort();

            var init = 2;

            while (init <= 9)
            {
                var list = new List<int>();

                for (int i = init; i < init + 5; ++i)
                    list.Add(i);
                ++init;

                if (list.All(l => cardHand.Select(x => x.power).Contains(l)))
                    return true;
            }
            return false;
        }

        public bool IsFlush()
        {
            var _tmp = cardHand.GroupBy(x => x.cardType);
            foreach (var item in _tmp)
            {
                if (item.Count() >= 5)
                {
                    return true;
                }
            }
            return false;
        }

        public bool IsFullHouse()
        {
            var _tmp = cardHand.GroupBy(x => x.value);
            bool isThreeOfKind = false;
            bool isPair = false;

            foreach (var item in _tmp)
            {
                if (!isThreeOfKind && item.Count() == 3)
                {
                    isThreeOfKind = true;
                }
                else if (item.Count() >= 2)
                {
                    isPair = true;
                }

            }
            return isPair && isThreeOfKind;
        }

        public bool IsSquare()
        {
            var res = cardHand.GroupBy(x => x.power).Where(x => x.Count() == 4).Any();
            return res;
        }

        public bool IsStraightFlush()
        {
            cardHand.Sort();

            var init = 2;

            while (init <= 9)
            {
                var list = new List<int>();

                for (int i = init; i < init + 5; ++i)
                    list.Add(i);
                ++init;
                var tmp = cardHand.GroupBy(x => x.cardType);
                foreach (var item in tmp)
                {
                    if (list.All(l => item.Select(x => x.power).Contains(l)))
                        return true;
                }
            }
            return false;
        }

        public bool IsRoyalFlush()
        {
            cardHand.Sort();

            var init = 10;

            var list = new List<int>();

            for (int i = init; i < init + 5; ++i)
                list.Add(i);
            
            var tmp = cardHand.GroupBy(x => x.cardType);
            foreach (var item in tmp)
            {
                if (list.All(l => item.Select(x => x.power).Contains(l)))
                    return true;
            }

            return false;
        }
    }
}