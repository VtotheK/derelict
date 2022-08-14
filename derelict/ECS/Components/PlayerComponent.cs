using Microsoft.Xna.Framework;
using derelict.ECS.Components.Base;
using derelict.ECS.System;

namespace derelict.ECS.Components
{
    public class PlayerComponent : Component
    {
        public int Health { get; set; }
        public float Speed { get; set; }
        public Vector2 InputDirection { get; set; }

        public PlayerComponent(Entity entity) : base(entity)
        {
            PlayerSystem.RegisterComponent(this);
        }
    }
}
