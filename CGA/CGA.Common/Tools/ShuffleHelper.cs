using CGA.Common.Enums;
using CGA.Common.Models;

namespace CGA.Common.Tools
{
    public class ShuffleHelper
    {
        private static Dictionary<string, int> CardNames = new Dictionary<string, int> {
            {"Two", 2}, { "Three", 3 }, { "Four", 4 }, { "Five", 5 }, { "Six", 6 }, { "Seven", 7 },
            { "Eight", 8 }, { "Nine", 9 }, { "Ten", 10 }, { "Jack", 10 }, { "Queen", 10 }, { "King", 10 }, { "Ace", 11 }
        };

        public static List<Card> GetDeck()
        {
            var cards = new List<Card>();
            foreach (SuitEnum suit in (SuitEnum[])Enum.GetValues(typeof( SuitEnum)))
                foreach (var cardName in CardNames)
                    cards.Add(new Card(cardName.Key, cardName.Value, GetNick(cardName.Key, cardName.Value), suit));
                
            return cards;
        }

        protected static string GetNick(string name, int value)
        {
            if (!CardNames.ContainsKey(name) || value < 2 || value > 11)
                throw new ArgumentException($"Invalid card name or value - {name}:{value}");

            if (value < 10)
                return value.ToString();

            if (name == "Ten")
                return "10";

            if (name == "Ace")
                return "A";

            return name.Substring(0, 1);
        }
    }
}
