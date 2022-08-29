using MapEditor.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Shapes;

namespace MapEditor.Service
{
    public static class MapEditorService
    {
        public static void CopyMap(Rectangle[,] mapFrom, Rectangle[,] mapTo)
        {
            for (int y = 0; y < mapFrom.GetLength(0); ++y)
            {
                for (int x = 0; x < mapFrom.GetLength(1); ++x)
                {
                    mapTo[x, y] = mapFrom[x, y];
                }
            }
        }
    }
}
