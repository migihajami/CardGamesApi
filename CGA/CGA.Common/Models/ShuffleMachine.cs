using CGA.Common.Exceptions;
using CGA.Common.Tools;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CGA.Common.Models
{
    public interface IShuffleMachine
    {
        void Stir();
        void StirFreeCards();
        Card Hit();

    }
    public class ShuffleMachine: IShuffleMachine
    {
        private int _deckAmount;
        protected List<Card> Cards;
        protected List<Card> FreeCards;

        public ShuffleMachine(int deckAmount)
        {
            _deckAmount = deckAmount;
            Cards = new List<Card>();
            FreeCards = new List<Card>();
            for (int i = 0; i < _deckAmount; i++)
                FreeCards.AddRange(ShuffleHelper.GetDeck());
        }

        public void Stir()
        {
            var rand = new Random(DateTime.UtcNow.Millisecond);          

            while (FreeCards.Count > 0)
            {
                var index = rand.Next(0, FreeCards.Count -1);
                Cards.Add(FreeCards[index]);
                FreeCards.RemoveAt(index);
            }
        }

        public void StirFreeCards()
        {
            var rand = new Random(DateTime.UtcNow.Millisecond);
            while (FreeCards.Count > 0)
            {
                var index = rand.Next(0, Cards.Count -1);
                var card = FreeCards[0];
                FreeCards.RemoveAt(0);
                Cards.Insert(index, card);
            }
        }

        public Card Hit()
        {
            if (Cards.Count == 0)
                throw new EmptyBoxException();

            var result = Cards.First();
            Cards.RemoveAt(0);
            FreeCards.Add(result);
            return result;
        }
    }
}
