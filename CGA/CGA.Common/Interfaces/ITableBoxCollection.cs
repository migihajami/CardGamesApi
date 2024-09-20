namespace CGA.Common.Interfaces
{
    public interface ITableBoxCollection
    {
        void Free(int handId);
        IEnumerable<int> GetFreeBoxes();
        bool Occupy(Guid playerId, int handId);
        int FreeBoxCount();
        int TotalBoxCount();
        void MakeBet(int boxId, decimal betAmount);
    }
}
