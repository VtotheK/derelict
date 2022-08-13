using System;
using System.Linq;
using derelict.ECS.Utils;
using derelict.ECS.Components;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;

namespace derelict.ECS
{

    public class Entity
    {
        public string ID { get; set; }
        public Component[] Components;
        private int AttachedComponents { get; set; }

        public Entity()
        {
            ID = Guid.NewGuid().ToString();
            Components = new Component[Constants.Components.MaxComponentCount];
        }
        public void AttachComponent(Component component)
        {
            var index = ComponentRegister.GetComponentIndex(component);
            AttachedComponents = ComponentRegister.RegisterComponent(index, AttachedComponents);
            Components[index] = component;
        }

        public void AttachComponents(params Component[] components)
        {
            foreach(var component in components)
            {
                var index = ComponentRegister.GetComponentIndex(component);
                AttachedComponents = ComponentRegister.RegisterComponent(index, AttachedComponents);
                Components[index] = component;
            }
        }

        public T GetComponent<T>() where T : Component
        {
            //TODO Fix
            return (T) Components
                .Where(comp => comp.GetType() == typeof(T))
                .Select(comp => comp)
                .FirstOrDefault();
        }

        public bool HasComponent<T>() where T : Component
        {
            int index = ComponentRegister.GetComponentIndex(typeof(T));
            return (AttachedComponents & (1 << index)) != 0;
        }

        public void Render(SpriteBatch spriteBatch, int deltaTime)
        {
            //TODO Make this not stupid
            //var spriteComp = Components.Where(t => t.GetType() == typeof(SpriteComponent)).FirstOrDefault();
            var spriteComp = Components[4];
            var posComp = Components[3];
            //var posComp = Components.Where(t => t.GetType() == typeof(PositionComponent)).FirstOrDefault();
            if(spriteComp != null || posComp == null)
            {
                var sprite = spriteComp as SpriteComponent;
                var position = posComp as PositionComponent;
                spriteBatch.Draw(sprite.Texture, position.EntityPosition, Color.White);
            }
        }
    }
}
