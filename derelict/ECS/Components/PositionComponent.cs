using derelict.ECS.Components.Base;
using derelict.ECS.System;
using Microsoft.Xna.Framework;

namespace derelict.ECS.Components
{
    public class PositionComponent : Component
    {
        public Vector2 EntityPosition { get; set; }
        public PositionComponent(Entity entity) : base(entity)
        {
            PositionSystem.RegisterComponent(this);
        }
    }
}
