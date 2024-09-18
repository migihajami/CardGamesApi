namespace CGA.Common.Models
{
    public interface IBlackJackPlayerHand
    {
        int Double(IShuffleMachine machine);
        int Hit(IShuffleMachine machine);

        decimal BetAmount { get; set; }
        bool IsDoubled { get; set; }
    }
}
