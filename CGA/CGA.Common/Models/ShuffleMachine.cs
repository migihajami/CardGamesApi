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

        public ShuffleMachine(int deckAmount)
        {
            _deckAmount = deckAmount;
            Cards = new List<Card>();
        }

        public void Stir()
        {
            throw new NotImplementedException();
        }

        public void StirFreeCards()
        {
            throw new NotImplementedException();
        }

        public Card Hit()
        {
            var result = Cards.First();
            Cards.RemoveAt(0);
            return result;
        }
    }
}
