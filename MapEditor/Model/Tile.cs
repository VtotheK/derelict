using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MapEditor.Model
{
    public enum TileType
    {
        Foreground = 1,
        Background = 2
    }

    public class Tile : GameObject
    {
        public TileType TileType { get; set; }

    }
}
