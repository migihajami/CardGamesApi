using System.Threading.Tasks.Dataflow;
using CGA.Common.Models;

namespace CGA.Common.Interfaces
{
    public interface IBlackJackPlayerHand : IBlackJackHand, IHand
    {
        int Double(IShuffleMachine machine);

        decimal BetAmount { get; set; }
        bool IsDoubled { get; set; }
    }
}
