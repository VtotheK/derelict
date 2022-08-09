using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace derelict.Levels
{
    public enum TileType
    {
        Normal = 1,
        Soft,
        Hard
    }

    public class MapMatrix
    {
        public int[,] Matrix;
        public MapMatrix()
        {

        }
    }
}
