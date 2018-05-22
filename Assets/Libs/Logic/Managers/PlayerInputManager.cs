using Assets.Libs.Logic.Interfaces.Managers;
using Assets.Libs.Logic.Interfaces.Player;

namespace Assets.Libs.Logic.Managers
{
    public class PlayerInputManager : IPlayerInput
    {
        public StepType RegisteredStep { get; private set; }

        public void RegisterPaper()
        {
            RegisteredStep = StepType.Paper;
        }

        public void RegisterRock()
        {
            RegisteredStep = StepType.Rock;
        }

        public void RegisterScissors()
        {
            RegisteredStep = StepType.Scissors;
        }
    }
}
