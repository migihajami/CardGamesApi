using CGA.Common.Enums;
using CGA.Common.Interfaces;

namespace CGA.Common.Models
{
    public class BlackjackTable : Table, IBlackJackTable
    {
        public BlackjackTable(decimal minBet, decimal maxBet, int maxHands, int maxPlayers, ITableBoxCollection tableHandsCollection)
            : base(minBet, maxBet, maxHands, maxPlayers, tableHandsCollection)
        {

        }

        public BlackJackTableStateEnum BlackJackTableStateEnum => throw new NotImplementedException();
    }
}
