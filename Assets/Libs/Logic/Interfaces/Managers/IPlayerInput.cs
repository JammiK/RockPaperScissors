using System;
using Assets.Libs.Logic.Interfaces.Player;

namespace Assets.Libs.Logic.Interfaces.Managers
{
    public interface IPlayerInput : IInput
    {
        void RegisterRock();
        void RegisterPaper();
        void RegisterScissors();
    }
}
