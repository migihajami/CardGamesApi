using CGA.Common.Enums;
using CGA.Common.Exceptions;
using CGA.Common.Interfaces;

namespace CGA.Common.Models
{

    public class Table : ITable
    {
        public Guid TableId { get; set; }
        public GameTypeEnum GameType { get; set; }
        public decimal MinimumBet { get; protected set; }
        public decimal MaximumBet { get; protected set; }
        public int MaximumHands { get; protected set; }
        public int MaximumPlayers { get; protected set; }
        public List<Player>? Players { get; protected set; }
        public Game? Game { get; protected set; }
        public IShuffleMachine? ShuffleMachine { get; protected set; }
        protected ITableBoxCollection TableBoxes { get; set; }


        public Table(decimal minBet, decimal maxBet, int maxHands, int maxPlayers, ITableBoxCollection tableBoxCollection)
        {
            MinimumBet = minBet;
            MaximumBet = maxBet;
            MaximumHands = maxHands;
            MaximumPlayers = maxPlayers;
            TableBoxes = tableBoxCollection;
        }

        public bool IsBetAllowed(decimal betAmount)
        {
            return betAmount >= MinimumBet && betAmount <= MaximumBet;
        }

        public int GetFreeBoxesCount()
        {
            throw new NotImplementedException();
        }

        public int GetFreeSeatsCount()
        {
            throw new NotImplementedException();
        }

        public decimal GetMinBet()
        {
            throw new NotImplementedException();
        }

        public decimal GetMaxBet()
        {
            throw new NotImplementedException();
        }

        public bool AddPlayer(Player player)
        {
            throw new NotImplementedException();
        }

        public bool RemovePlayer(Guid playerId)
        {
            throw new NotImplementedException();
        }

        public bool AddHand(Guid playerId, int boxId)
        {
            throw new NotImplementedException();
        }

        public bool RemoveHand(Guid playerId, int handNumber)
        {
            throw new NotImplementedException();
        }

        public bool MakeBet(Guid playerId, int handNuumber, decimal betAmount)
        {
            throw new NotImplementedException();
        }

        public void MakePayOuts()
        {
            throw new NotImplementedException();
        }
    }
}
