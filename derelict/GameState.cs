using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace derelict
{
    public enum RunningState
    {
        StartUp,
        LoadMap,
        ExitGame
    }
    internal class GameState
    {
        public RunningState CurrentState { get; set; }
    }
}
