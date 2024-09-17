using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CGA.Common.Models
{
    public class Player
    {
        public Guid PlayerId { get; set; }
        public required string NickName { get; set; }
        public required string PlayerName { get; set; }
        public decimal Balance { get; set; }
        public required string ReferenceId { get; set; }
        public bool IsBlocked { get; set; }

        public bool WithdrawCoins(decimal amount)
        {
            if (Balance > amount)
                return false;
                
            Balance -= amount;
            return true;
        }

        public void AddCoins(decimal amount)
        {
            Balance += amount;
        }
    }
}
