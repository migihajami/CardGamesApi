using System.Threading.Tasks.Dataflow;

namespace CGA.Common.Models
{
    public interface IBlackJackPlayerHand: IBlackJackHand, IHand
    {
        int Double(IShuffleMachine machine);
        int Hit(IShuffleMachine machine);

        decimal BetAmount { get; set; }
        bool IsDoubled { get; set; }
    }
}
