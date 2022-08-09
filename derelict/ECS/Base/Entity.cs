using System;
using System.Linq;
using System.Collections.Generic;
using derelict.Extensions;

namespace derelict.ECS
{
    public class Entity
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public List<Component> Components;
        public void AttachComponent(Component component)
        {
            Components.CreateIfNull<Component>();
            Components.Add(component);
        }

        public T GetComponent<T>() where T : Component
        {
            return (T) Components
                .Where(comp => comp.GetType() == typeof(T))
                .Select(comp => comp);
        }
    }
}
