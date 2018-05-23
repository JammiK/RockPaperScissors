using UnityEngine;
using Assets.Libs.Logic.Interfaces.Player;

namespace AssemblyCSharp.Assets.Libs.Logic.Managers
{
    /// <summary>
    /// Cheater player input manager, who can win always
    /// </summary>
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
                if (IsWin)
                {
                    return (StepType)(((int)_enemy.LastStep + 1) % StepOptionsAmount);
                }

                return (StepType)(((int)_enemy.LastStep + StepOptionsAmount - 1) % StepOptionsAmount);
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
