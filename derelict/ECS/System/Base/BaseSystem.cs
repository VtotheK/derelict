using System.Collections.Generic;
using derelict.ECS.Components.Base;

namespace derelict.ECS.System.Base
{
    public abstract class BaseSystem<T> where T : Component
    {
        private static List<T> Components = new List<T>();

        public static void RegisterComponent(T component)
        {
            Components.Add(component);
        }
    }
}
