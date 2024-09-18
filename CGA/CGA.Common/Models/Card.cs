using CGA.Common.Enums;

namespace CGA.Common.Models
{
    public class Card
    {
        public Card(string name, int value, string nick, SuitEnum suit)
        {
            Name = name;
            Value = value;
            Nick = nick;
            Suit = suit;
        }

        public string Name { get; set; }
        public int Value { get; set; }
        public string Nick { get; set; }
        public SuitEnum Suit { get; set; }

        public override bool Equals(object? obj)
        {
            return obj is Card card &&
                   Name == card.Name &&
                   Value == card.Value &&
                   Nick == card.Nick &&
                   Suit == card.Suit;
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(Name, Value, Nick, Suit);
        }

        public override string ToString() 
        {
            return $"{Name} of {Suit}";
        }
    }
}
