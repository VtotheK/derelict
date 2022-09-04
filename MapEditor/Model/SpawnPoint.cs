using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace MapEditor.Model
{
    [Flags]
    public enum Anchor
    {
        Ceiling = 1,
        Right= 2,
        Floor = 4,
        Left = 8,
    }

    public class SpawnPoint : GameObject
    {
        public Anchor AnchorPoint { get; set; }
        public Vector2 OffSet { get; set; }
    }
}
