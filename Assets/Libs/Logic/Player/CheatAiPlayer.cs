using UnityEngine;
using Assets.Libs.Logic.Interfaces.Player;

namespace Assets.Libs.Logic.Player
{
    class CheatAiPlayer : Player, IPlayer
    {
        IInput _inputManager;
        float _chanceWin;
        public CheatAiPlayer(IInput inputManager, float chanceWin)
        {
            _inputManager = inputManager;
            _chanceWin = chanceWin;
        }

        public StepType NextStep()
        {
            StepType step;
            if (IsWin)
            {
                step = (StepType)(((int)_inputManager.RegisteredStep + 1) % StepOptionsAmount);
            }
            else
            {
                step = (StepType)(((int)_inputManager.RegisteredStep + StepOptionsAmount - 1) % StepOptionsAmount);
            }

            LastStep = step;
            return step;
        }

        bool IsWin
        {
            get
            {
                return Random.value < _chanceWin;
            }
        }

        public StepType LastStep { get; private set; }
    }
}
