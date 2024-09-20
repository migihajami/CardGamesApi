using CGA.Common.Enums;

namespace CGA.Common.Models
{
    public class BlackJackGame : Game
    {
        public BlackJackGameStateEnum GameState { get; protected set; }

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
