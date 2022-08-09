using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace derelict.Levels
{
    public class Map
    {
        public int Hash { get; set; }
        public string Name { get; set; }
        public int Height { get; init; }
        public int Width { get; init; }
        public MapMatrix Matrix { get; init; }
    }
}
