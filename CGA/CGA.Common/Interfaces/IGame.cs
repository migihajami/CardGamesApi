using CGA.Common.Enums;
using CGA.Common.Models;

namespace CGA.Common.Interfaces
{
    public interface IGame
    {
        void Init();
        void StartRound();
        void FinishRound();

    }
}
