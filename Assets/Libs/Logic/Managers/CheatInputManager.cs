using UnityEngine;
using Assets.Libs.Logic.Interfaces.Player;

namespace AssemblyCSharp.Assets.Libs.Logic.Managers
{
    public class CheatInputManager : IInput
    {
        const int StepOptionsAmount = 3;

        IPlayer _enemy;
        float _chanceWin;

        public CheatInputManager(IPlayer enemy, float chanceWin)
        {
            _enemy = enemy;
            _chanceWin = chanceWin;
        }

        public StepType RegisteredStep
        {
            get
            {
                StepType step;
                if (IsWin)
                {
                    step = (StepType)(((int)_enemy.LastStep + 1) % StepOptionsAmount);
                }
                else
                {
                    step = (StepType)(((int)_enemy.LastStep + StepOptionsAmount - 1) % StepOptionsAmount);
                }
                return step;
            }
        }

        bool IsWin
        {
            get
            {
                return Random.value < _chanceWin;
            }
        }
    }
}
