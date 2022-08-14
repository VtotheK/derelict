using System.Drawing;
using Microsoft.Xna.Framework.Graphics;
using derelict.ECS.Components.Base;
using derelict.ECS.System;

namespace derelict.ECS.Components
{
    public class SpriteComponent : Component
    {
        public string SpriteName { get; set; }
        public string SpritePath { get; set; }
        public Size SpriteSize { get; set; }
        public bool IsVisible { get; set; }
        public Texture2D Texture { get; set; }
        public int Zindex { get; set; } = 1; 

        public SpriteComponent(Entity entity) : base(entity)
        {
            SpriteSystem.RegisterComponent(this);
        }
    }
}
