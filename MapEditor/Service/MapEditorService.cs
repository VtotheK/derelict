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
        public static void CopyMap(MapObject[,] mapFrom, MapObject[,] mapTo)
        {
            int toX = mapTo.GetLength(0) - 1;
            int toY = mapTo.GetLength(1) - 1;
            int fromX = mapFrom.GetLength(0) - 1;
            int fromY = mapFrom.GetLength(1) - 1;
            int width = (int)mapFrom[0, 0].MapRectangle.Width;
            int height = (int)mapFrom[0, 0].MapRectangle.Height;

            for (int y = 0; y <= toY; ++y)
            {
                for (int x = 0; x <= toX; ++x)
                {
                    if (fromY < y || fromX < x)
                    {
                        mapTo[x, y] = new MapObject
                        {
                            MapRectangle = new Rectangle
                            {
                                Height = height,
                                Width = width,
                                Fill = new SolidColorBrush(Color.FromArgb(0, 0, 0, 0))
                            }
                        };
                    }
                    else
                    {
                        mapTo[x, y] = mapFrom[x, y];
                    }
                }
            }
        }

        internal static MapObject[,]? GetEmptyMap(EditorMap editorMap)
        {
            var map = new MapObject[editorMap.MapWidth, editorMap.MapHeight];
            int MapHeight = editorMap.MapHeight;
            int MapWidth = editorMap.MapWidth;
            int TileHeight = editorMap.TileHeight;
            int TileWidth = editorMap.TileWidth;

            for (int y = 0; y < MapHeight; ++y)
            {
                for (int x = 0; x < MapWidth; ++x)
                {
                    map[x, y] = new MapObject
                    {
                        MapRectangle = new Rectangle
                        {
                            Height = TileHeight,
                            Width = TileWidth,
                            Fill = new SolidColorBrush(Color.FromArgb(0, 0, 0, 0))
                        }
                    };
                }
            }
            return map;
        }
    }
}
