using CGA.Common.Enums;
using CGA.Common.Models;

namespace CGA.Common.Interfaces
{
    public interface ITable
    {
        bool IsBetAllowed(decimal betAmount);
        int GetFreeBoxesCount();
        int GetFreeSeatsCount();
        decimal GetMinBet();
        decimal GetMaxBet();
        bool AddPlayer(Player player);
        bool RemovePlayer(Guid playerId);
        bool AddHand(Guid playerId, int boxId);
        bool RemoveHand(Guid playerId, int boxId);
        bool MakeBet(Guid playerId, int boxId, decimal betAmount);
        void MakePayOuts();
    }
}
