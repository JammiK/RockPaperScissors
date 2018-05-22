using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assets.Libs.Logic.Interfaces.Engine
{
    interface IActionView
    {
        void ShowAction(string enemyResult, string roundResult, int newPlayerScore, int newAiScore);
    }
}
