using CGA.Common.Enums;

namespace CGA.Common.Models
{
    public record Card
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
    }
}
