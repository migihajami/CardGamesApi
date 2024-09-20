namespace CGA.Common.Models
{
    public class TableBox
    {
        public int TableBoxId { get; set; }
        public Guid? PlayerId { get; set; }
        public decimal BetAmount { get; set; }
        public bool IsFree => PlayerId == null;
    }
}
