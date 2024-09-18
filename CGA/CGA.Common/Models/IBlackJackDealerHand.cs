namespace CGA.Common.Models
{
    public interface IBlackJackDealerHand
    {
        Card GetFirstCard();
        int Hit(IShuffleMachine machine);
        int MakeHand(IShuffleMachine machine);
        bool HasBlackJack {  get; }
    }
}
