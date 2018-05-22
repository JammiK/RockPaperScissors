using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assets.Libs.Logic.Interfaces.Engine
{
    public delegate void ScoreUpdateHandler(int firstScore, int secondScore);
    public interface IScoreProvider
    {
        event ScoreUpdateHandler OnScoreUpdate;
    }
}
