using UnityEngine;
using Assets.Libs.Logic.Interfaces.Player;
using Assets.Libs.Logic.Interfaces.Managers;
using System;

namespace Assets.Libs.Logic.Player
{
    class HumanPlayer : Player, IPlayer
    {
        IInput _inputManager;

        public HumanPlayer(IInput inputManager)
        {
            _inputManager = inputManager;
        }

        public StepType LastStep { get; private set; }

        public StepType NextStep()
        {
            LastStep = _inputManager.RegisteredStep;
            return _inputManager.RegisteredStep;
        }

    }
}
