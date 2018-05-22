using Assets.Libs.Logic.Interfaces.Player;

namespace Assets.Libs.Logic.Player
{
    abstract class Player : IHaveScore
    {
        protected const int StepOptionsAmount = 3;

        public int Score { get; protected set; }

        public void Win()
        {
            Score++;
        }
    }
}
