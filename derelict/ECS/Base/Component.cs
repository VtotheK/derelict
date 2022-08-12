using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace derelict.ECS
{
    enum ComponentBitField
    {
        AIComponent = 1,
        NPCComponent = 2,
        PlayerComponent = 4,
        PositionComponent = 8,
        SpriteComponent = 16
    }

    public class Component
    {
        public Entity entity;
    }
}
