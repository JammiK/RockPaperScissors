using UnityEngine;
using Assets.Libs.Logic.Interfaces.Player;

namespace Assets.Libs.Logic.Managers
{
    public class HonestAiInputManager : IInput
    {
        const int StepOptionsAmount = 3;

        public StepType RegisteredStep => (StepType)Random.Range(0, StepOptionsAmount);
    }
}
