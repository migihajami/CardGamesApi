using CGA.Common.Enums;
using CGA.Common.Factories;
using CGA.Common.Interfaces;
using CGA.Common.Models;
using FluentAssertions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CGA.Testing.Common.Factories
{
    [TestClass]
    public class GameFactoryTests
    {
        private IGameFactory _gameFactory = new GameFactory();

        [TestMethod]
        public void CreateGame_Success()
        {
            var game = _gameFactory.CreateGame(GameTypeEnum.BlackJack);
            game.Should().NotBeNull();
            game.Should().BeOfType(typeof(BlackJackGame));
        }
    }
}
