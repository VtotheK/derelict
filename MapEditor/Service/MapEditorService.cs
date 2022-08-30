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
            int lenX = mapTo.GetLength(0);
            int lenY = mapTo.GetLength(1);
            for (int y = 0; y < mapFrom.GetLength(1); ++y)
            {
                for (int x = 0; x < mapFrom.GetLength(0); ++x)
                {
                    if(lenX >= x || lenY >= y) { continue; }
                    mapTo[x, y] = mapFrom[x, y];
                }
            }
        }
    }
}
