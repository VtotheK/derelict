using System;
using System.Linq;
using System.Collections.Generic;
using derelict.Extensions;
using derelict.ECS.Components;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;

namespace derelict.ECS
{
    [Flags]
    public enum ComponentBitField
    {
        AIComponent = 1,
        NPCComponent = 2,
        PlayerComponent = 4,
        PositionComponent = 8,
        SpriteComponent = 16
    }

    public class Entity
    {
        public string ID { get; set; }
        public List<Component> Components;
        public ComponentBitField ComponentBits { get; set; }
        public Entity()
        {
            ID = Guid.NewGuid().ToString();
            Components = new List<Component>();
        }
        public void AttachComponent(Component component)
        {
            Components.CreateIfNull<Component>();
            Components.Add(component);
        }

        public void AttachComponents(params Component[] components)
        {
            Components.AddRange(components);
        }

        public T GetComponent<T>() where T : Component
        {
            return (T) Components
                .Where(comp => comp.GetType() == typeof(T))
                .Select(comp => comp)
                .FirstOrDefault();
        }

        public void Render(SpriteBatch spriteBatch, int deltaTime)
        {
            var spriteComp = Components.Where(t => t.GetType() == typeof(SpriteComponent)).FirstOrDefault();
            var posComp = Components.Where(t => t.GetType() == typeof(PositionComponent)).FirstOrDefault();
            if(spriteComp != null || posComp == null)
            {
                var sprite = spriteComp as SpriteComponent;
                var position = posComp as PositionComponent;
                spriteBatch.Draw(sprite.Texture, position.EntityPosition, Color.White);
            }
        }
    }
}
