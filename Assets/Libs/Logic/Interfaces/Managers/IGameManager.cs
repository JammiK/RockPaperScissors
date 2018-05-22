using Assets.Libs.Logic.Interfaces.Player;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Assets.Libs.Logic.Interfaces.Managers
{
    /// <summary>
    /// Game manager who register players and resolve rounds
    /// </summary>
    public interface IGameManager
    {
        IPlayer Human { get; }
        IPlayer AIPlayer { get; }
        RoundResultType LastRoundResult { get; }

        void ResolveRound();
    }
}
