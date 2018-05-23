using System;
using Assets.Libs.Logic.Interfaces.Player;

namespace Assets.Libs.Logic.Interfaces.Managers
{
    /// <summary>
    /// Input manager interface for manual registering 
    /// </summary>
    public interface IPlayerInput : IInput
    {
        void RegisterRock();
        void RegisterPaper();
        void RegisterScissors();
    }
}
