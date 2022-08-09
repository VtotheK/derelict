using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace derelict.Levels
{
    public class MapManager
    {
        private List<Map> availableMaps = new List<Map>();
        private Map currentMap;
        public Map GetInitialMap()
        {
            if (!availableMaps.Any())
            {
                currentMap = MapGenerator.GenerateMap();
                return currentMap;
            }
            else
            {
                return availableMaps[0]; 
            }
        }
    }
}
