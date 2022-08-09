using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using derelict.Utils;
using derelict.Levels;

namespace derelict
{
    internal class GameManager
    {
        private Map currentMap;
        private MapManager mapManager;

        public GameManager()
        {
            mapManager = new MapManager();
            currentMap = mapManager.GetInitialMap();
        }

        public Map GetCurrentMap()
        {
            return currentMap;
        }
    }
}
