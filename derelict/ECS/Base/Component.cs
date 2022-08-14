using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace derelict.ECS.Components.Base
{

    public abstract class Component
    {
        public Entity Entity { get; init; }
        public bool IsActive = true;
        public Component(Entity entity)
        {
            Entity = entity;
        }
    }
}
