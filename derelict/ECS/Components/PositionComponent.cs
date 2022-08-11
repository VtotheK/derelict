using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace derelict.ECS.Components
{
    public class PositionComponent : Component
    {
        public Vector2 EntityPosition { get; set; }
    }
}
