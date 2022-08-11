using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace derelict.ECS
{
    public class EntityManager
    {
        readonly string contentPath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Content");
        public Entity GetPlayer()
        {
            var player = new Entity();
            player.AttachComponent(new Sprite
            {
                SpriteName = "Slime",
                SpritePath = Path.Combine(contentPath, "Player", "slime.png"),
                Height = 
            });
        }
    }
}
