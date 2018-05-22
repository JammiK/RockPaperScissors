using Assets.Libs.Logic.Interfaces.Player;

namespace Assets.Libs.Logic.Player
{
    public class Player : IPlayer
    {

        public Player(IInput inputManager)
        {
            _inputManager = inputManager;
        }

        IInput _inputManager;

        public int Score { get; protected set; }
        public StepType LastStep { get; private set; }

        public StepType NextStep()
        {
            StepType step = _inputManager.RegisteredStep;
            LastStep = step;
            return step;
        }

        public void Win()
        {
            Score++;
        }
    }
}
