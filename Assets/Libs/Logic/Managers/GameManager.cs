using Assets.Libs.Logic.Interfaces.Managers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Assets.Libs.Logic.Interfaces.Player;
using UnityEngine;
using UnityEditor;

namespace Assets.Libs.Logic.Managers
{
    public class GameManager : IGameManager
    {
        const int StepOptionsAmount = 3;

        public IPlayer AIPlayer { get; }
        public IPlayer Human { get; }
        public RoundResultType LastRoundResult { get; private set; }

        public GameManager(IPlayer firstPlayer, IPlayer secondPlayer)
        {
            Human = firstPlayer;
            AIPlayer = secondPlayer;
        }

        public void ResolveRound()
        {
            StepType humanStep = Human.NextStep();
            StepType aiStep = AIPlayer.NextStep();
            LastRoundResult = GetFirstPlayerResult(humanStep, aiStep);
            switch (LastRoundResult)
            {
                case RoundResultType.Win:
                    Human.Win();
                    break;
                case RoundResultType.Lose:
                    AIPlayer.Win();
                    break;
            }
        }

        /// <summary>
        /// Compare two steps for win
        /// </summary>
        /// <param name="firstStep"></param>
        /// <param name="secondStep"></param>
        /// <returns>
        /// RoundResultType
        /// </returns>
        RoundResultType GetFirstPlayerResult(StepType firstStep, StepType secondStep)
        {
            if (firstStep == secondStep)
            {
                return RoundResultType.Draw;
            }
            if ((int)firstStep == ((int)secondStep  + StepOptionsAmount - 1) % StepOptionsAmount)
            {
                return RoundResultType.Lose;
            }
            else
            {
                return RoundResultType.Win;
            }
        }
    }
}
