using CGA.Common.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CGA.Common.Models
{
    public class Table
    {
        public GameTypeEnum GameType { get; set; }
        public decimal MinimumBet { get; set; }
        public decimal MaximumBet { get; set; }
        public int MaximumHands { get; set; }
        public required List<Player> Players { get; set; }
        public required Game Game { get; set; }
    }
}
