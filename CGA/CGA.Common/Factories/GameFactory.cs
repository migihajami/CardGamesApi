using CGA.Common.Enums;
using CGA.Common.Interfaces;
using CGA.Common.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CGA.Common.Factories
{
    public class GameFactory : IGameFactory
    {
        public IGame CreateGame(GameTypeEnum gameType)
        {
            switch (gameType)
            {
                case GameTypeEnum.BlackJack: return new BlackJackGame();
                default: throw new ArgumentException($"Unknown game - '{gameType}'");
            }
        }
    }
}
