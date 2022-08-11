using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework.Graphics;

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
    }
}
