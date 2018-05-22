using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assets.Libs.Logic.Interfaces.Engine
{    

    interface IGameManagerProvider
    {
        void RegisterRock();
        void RegisterPaper();
        void RegisterScissors();
    }
}
