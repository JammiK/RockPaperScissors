using Assets.Libs.Logic.Interfaces.Player;
using UnityEngine;

namespace Assets.Libs.Logic.Player
{
    class AiPlayer : Player, IPlayer
    {
        public StepType LastStep { get; private set; }

        public StepType NextStep()
        {
            StepType step = (StepType)Random.Range(0, StepOptionsAmount);
            LastStep = step;
            return step;
        }
    }
}
