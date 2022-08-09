using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace derelict.Levels
{
    public static class MapGenerator
    {
        public static Map GenerateMap()
        {
            var matrix = GenerateMatrix();

            return new Map
            {
                Hash = DateTime.Now.GetHashCode(),
                Name = "TempName",
                Height = matrix.GetLength(0),
                Width = matrix.GetLength(1),
                Matrix = new MapMatrix
                {
                    Matrix = matrix
                }
            };
        }

        private static int[,] GenerateMatrix()
        {
            return new int[,]{{1,2}, {1,2}};
        }
    }
}
