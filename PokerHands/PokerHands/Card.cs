using System;

namespace PokerHands
{
    internal class Card : IEquatable<Card> , IComparable<Card>
    {
        public  string value;
        public CardType cardType;
        public int power;

        public Card(string card, CardType type, int _power)
        {
            this.value = card;
            this.cardType = type;
            power = _power;
        }

        public bool Equals(Card other)
        {
            return (this.value == other.value &&
                this.cardType == other.cardType);
        }

        public override string ToString()
        {
            return value + cardType.ToString();
        }

        public int CompareTo(Card other)
        {
            return (power.CompareTo(other.power));
        }
    }
}