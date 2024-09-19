using CGA.Common.Enums;
using System;
using System.Linq;

namespace CGA.Common.Interfaces
{
    public interface IGameFactory
    {
        IGame CreateGame(GameTypeEnum gameType);
    }
}
