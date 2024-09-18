using CGA.Common.Exceptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CGA.Common.Models
{
    public abstract class Hand
    {
        public Guid HandId { get; set; }
        protected List<Card> Cards { get; set; } = new List<Card>();

        public void AddCard(Card? card)
        {
            if (card == null)
                throw new ArgumentNullException();

            Cards.Add(card);
        }

        public void Flush()
        {
            Cards.Clear();
        }

        public List<Card> GetCards()
        {
            return Cards.ToList();
        }
    }

    public abstract class BlackJackHand : Hand
    {
        public bool HasBlackJack => GetValue() == 21 && Cards.Count == 2;

        public int GetValue()
        {
            bool? isSoft = null;
            var result = 0;

            foreach (var card in Cards)
            {
                if (card.Nick == "A")
                {
                    var value = 1;
                    if (isSoft == null)
                    {
                        value = 11;
                        isSoft = true;
                    }
                    result += value;
                }
                else
                {
                    result += card.Value;
                }

                if (isSoft == true && result > 21)
                {
                    isSoft = false;
                    result -= 10;
                }
            }

            return result;
        }

        public virtual int Hit(IShuffleMachine machine)
        {
            AddCard(machine.Hit());
            return GetValue();
        }
    }

    public class BlackJackPlayerHand : BlackJackHand, IBlackJackPlayerHand
    {
        public decimal BetAmount { get; set; }
        public bool IsDoubled { get; set; }

        public int Double(IShuffleMachine machine)
        {
            BetAmount *= 2;
            var result = Hit(machine);
            IsDoubled = true;

            return result;
        }

        public override int Hit(IShuffleMachine machine)
        {
            if (IsDoubled)
                throw new HitOnDoubledHandException();

            if (GetValue() == 21)
                throw new HitOn21Exception();

            return base.Hit(machine);
        }

    }

    public class BlackJackDealerHand : BlackJackHand, IBlackJackDealerHand
    {
        public int MakeHand(IShuffleMachine machine)
        {
            while (GetValue() < 17)
                Hit(machine);

            return GetValue();
        }

        public Card GetFirstCard()
        {
            return Cards.First();
        }
    }
}
