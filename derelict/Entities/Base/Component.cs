using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace derelict.Entities.Base
{
    public class Component
    {
        public Texture2D Texture { get; set; }
        public Vector2 Position { get;set; }
        public bool IsVisible { get;set; }
        public float Weight { get;set; }
        public string Name { get;set; }

    }
}
