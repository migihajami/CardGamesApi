using System;
using System.Linq;
using CGA.Common.Models;

namespace CGA.Common.Interfaces
{
    public interface IBlackJackHand
    {
        int GetValue();
        int Hit(IShuffleMachine machine);

        bool HasBlackJack { get; }
    }
}
