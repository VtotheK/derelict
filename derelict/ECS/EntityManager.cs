using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;

namespace derelict.ECS
{
    public class EntityManager
    {
        public Entity SetPlayer()
        {
            var player = new Entity();
            player.AttachComponent(new Sprite
            {
                SpriteName = "Slime",
                Texture = 
            });
            return player;
        }
    }
}
