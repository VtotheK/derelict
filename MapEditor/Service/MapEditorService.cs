using MapEditor.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media;
using System.Windows.Shapes;

namespace MapEditor.Service
{
    public static class MapEditorService
    {
        public static void CopyMap(Rectangle[,] mapFrom, Rectangle[,] mapTo)
        {
            int toX = mapTo.GetLength(0) - 1;
            int toY = mapTo.GetLength(1) - 1;
            int fromX = mapFrom.GetLength(0) - 1;
            int fromY = mapFrom.GetLength(1) - 1;
            int width = (int)mapFrom[0, 0].Width;
            int height = (int)mapFrom[0, 0].Height;

            for (int y = 0; y <= toY; ++y)
            {
                for (int x = 0; x <= toX; ++x)
                {
                    if(fromY < y || fromX < x)
                    {
                        mapTo[x, y] = new Rectangle
                        {
                            Height = height,
                            Width = width,
                            Fill = new SolidColorBrush(Color.FromArgb(0, 0, 0, 0))
                        };
                    }
                    else
                    {
                        mapTo[x, y] = mapFrom[x, y];
                    }
                }
            }
        }
    }
}
