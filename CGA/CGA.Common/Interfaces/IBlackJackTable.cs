using CGA.Common.Enums;

namespace CGA.Common.Interfaces
{
    public interface IBlackJackTable : ITable
    {
        public BlackJackTableStateEnum BlackJackTableStateEnum { get; }
    }
}
