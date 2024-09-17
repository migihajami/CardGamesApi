using CGA.Common.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CGA.Common.Models
{
    public interface IGame
    {
        void Init();
        void StartRound();
        void FinishRound();

    }

    public abstract class Game: IGame
    {
        public GameTypeEnum GameType { get; set; }
        protected List<Player> Players { get; set; }

        public abstract void FinishRound();
        public abstract void Init();
        public abstract void StartRound();


    }

    public class BlackJackGame : Game
    {
        public override void FinishRound()
        {
            throw new NotImplementedException();
        }

        public override void Init()
        {
            throw new NotImplementedException();
        }

        public override void StartRound()
        {
            throw new NotImplementedException();
        }
    }
}
