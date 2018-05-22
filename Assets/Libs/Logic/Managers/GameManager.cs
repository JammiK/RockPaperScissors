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

            switch (CheckWinner(humanStep, aiStep))
            {
                case 1:
                    LastRoundResult = RoundResultType.Win;
                    Human.Win();
                    break;
                case 0:
                    LastRoundResult = RoundResultType.Draw;
                    break;
                case -1:
                    LastRoundResult = RoundResultType.Lose;
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
        /// 1 if first step win
        /// 0 if draw
        /// -1 if second step win
        /// </returns>
        int CheckWinner(StepType firstStep, StepType secondStep)
        {
            if (firstStep == secondStep)
            {
                return 0;
            }
            if ((int)firstStep == ((int)secondStep  + StepOptionsAmount - 1) % StepOptionsAmount)
            {
                return -1;
            }
            else
            {
                return 1;
            }
        }
    }
}
