using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework.Graphics;

namespace derelict.ECS
{
    public class Sprite : Component
    {
        public string SpriteName { get; set; }
        public string SpritePath { get; set; }
        public int Height { get; set; }
        public int Width { get; set; }
        public bool IsVisible { get; set; }
        public Texture2D Texture { get; set; }
    }
}
