using CGA.Common.Enums;

namespace CGA.Common.Models
{
    public class Table
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

        public Table(decimal minBet, decimal maxBet, int maxHands, int maxPlayers)
        {
            MinimumBet = minBet;
            MaximumBet = maxBet;
            MaximumHands = maxHands;
            MaximumPlayers = maxPlayers;
        }
    }
}
