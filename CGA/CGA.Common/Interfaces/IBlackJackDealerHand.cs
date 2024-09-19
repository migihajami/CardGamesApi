using CGA.Common.Models;

namespace CGA.Common.Interfaces
{
    public interface IBlackJackDealerHand: IBlackJackHand, IHand
    {
        Card GetFirstCard();
        int Hit(IShuffleMachine machine);
        int MakeHand(IShuffleMachine machine);
    }
}
