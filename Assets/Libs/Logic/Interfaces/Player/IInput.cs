using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Assets.Libs.Logic.Interfaces.Player
{
    interface IInput
    {
        StepType RegisteredStep { get;}

        void RegisterRock();
        void RegisterPaper();
        void RegisterScissors();
    }
}
