using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace derelict.ECS.Components
{
    public class PlayerComponent : Component
    {
        public int Health { get; set; }
        public float Speed { get; set; }
        public Vector2 Direction { get; set; }
    }
}
