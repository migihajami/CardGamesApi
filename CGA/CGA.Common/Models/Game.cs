using CGA.Common.Enums;
using CGA.Common.Interfaces;

namespace CGA.Common.Models
{

    public abstract class Game: IGame
    {
        public GameTypeEnum GameType { get; set; }
        protected List<Player> Players { get; set; } = new List<Player>();

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
