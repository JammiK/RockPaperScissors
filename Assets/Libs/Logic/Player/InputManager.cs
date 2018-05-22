using Assets.Libs.Logic.Interfaces.Player;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assets.Libs.Logic.Player
{
    class InputManager : IInput
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
