using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assets.Libs.Logic.Interfaces.Player
{
    public interface IHaveScore
    {
        int Score { get; }

        void Win();
    }
}
