using CGA.Common.Models;

namespace CGA.Common.Interfaces
{
    public interface IBlackJackDealerHand: IBlackJackHand, IHand
    {
        Card GetFirstCard();
        int MakeHand(IShuffleMachine machine);
    }
}
