using MapEditor.Model;
using MapEditor.Extensions;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.IO;
using System.Drawing;
using System.Windows.Media;

namespace MapEditor.Service
{
    public static class MapEditorService
    {
        public static Bitmap LoadBitmapFromPath(string path)
        {
            if (!File.Exists(path)) { return null; }
            using(var file = File.Open(path, FileMode.Open))
            {
                if (!file.IsImageFile())
                {
                    return null;
                }
            }
            return new Bitmap(File.Open(path, FileMode.Open)); //Hacky stuff, rewrite later. Yeah right...
        }

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
                            MapRectangle = new System.Windows.Shapes.Rectangle
                            {
                                Height = height,
                                Width = width,
                                Fill = new SolidColorBrush(System.Windows.Media.Color.FromArgb(0, 0, 0, 0)),
                                Name = $"_{x}_{y}_"
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
                        MapRectangle = new System.Windows.Shapes.Rectangle
                        {
                            Height = TileHeight,
                            Width = TileWidth,
                            Fill = new SolidColorBrush(System.Windows.Media.Color.FromArgb(0, 0, 0, 0)),
                            Name = $"_{x}_{y}_"
                        }
                    };
                }
            }
            return map;
        }

        public static int GetXCoordinate(string s)
        {
            int ret;
            if(int.TryParse(s.Split('_')[1], out ret)) { return ret; }
            throw new ArgumentException("Invalid coordinate");
        }
        public static int GetYCoordinate(string s)
        {
            int ret;
            if(int.TryParse(s.Split('_')[2], out ret)) { return ret; }
            throw new ArgumentException("Invalid coordinate");
        }

        public static MeshState CheckClosedColliderMesh(Collider collider)
        {
            for(int i = 0; i < collider.VertexCount; ++i)
            {
                for(int j = 0; j < collider.VertexCount; ++j)
                {
                    if(j == i) { continue; }
                    var aX = collider.ColliderVertices[i].Vertex.X;
                    var aY = collider.ColliderVertices[i].Vertex.Y;
                    var bX = collider.ColliderVertices[j].Vertex.X;
                    var bY = collider.ColliderVertices[j].Vertex.Y;
                    if(aX == bX && aY == bY) { return MeshState.Closed; }
                }
            }
            return MeshState.Open;
        }
    }
}
