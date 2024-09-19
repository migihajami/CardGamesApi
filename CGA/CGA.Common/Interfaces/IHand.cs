using System;
using System.Linq;
using CGA.Common.Models;

namespace CGA.Common.Interfaces
{
    public interface IHand
    {
        void AddCard(Card? card);
        void Flush();
        List<Card> GetCards();
    }
}
