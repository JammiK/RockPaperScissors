using Assets.Libs.Logic.Interfaces.Player;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assets.Libs.Logic.Interfaces.Managers
{
    public delegate void OnRoundFinishLog(RoundResultType roundResult, StepType firstPlayerStep, StepType secondPlayerStep, int firstScore, int secondScore);
    interface ILoggerManager
    {
        event OnRoundFinishLog OnRoundLog;
    }
}
