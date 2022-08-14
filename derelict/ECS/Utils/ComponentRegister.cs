using System;
using derelict.ECS.Components.Base;
using derelict.ECS.Components;
using derelict.ECS;

namespace derelict.ECS.Utils
{
    public static class ComponentRegister
    {
        public static int GetComponentIndex(Component component)
        {
            switch (component)
            {
                case (AIComponent): return Constants.Components.AIComponent;
                case (NPCComponent): return Constants.Components.NPCComponent;
                case (PlayerComponent): return Constants.Components.PlayerComponent;
                case (PositionComponent): return Constants.Components.PositionComponent;
                case (SpriteComponent): return Constants.Components.SpriteComponent;
                case (InputComponent): return Constants.Components.InputComponent;
                default: return -1;
            }
        }

        public static int GetComponentIndex(Type type)
        {
            if (type == typeof(AIComponent)) { return Constants.Components.AIComponent; }
            else if (type == typeof(NPCComponent)) { return Constants.Components.AIComponent; }
            else if (type == typeof(PlayerComponent)) { return Constants.Components.PlayerComponent; }
            else if (type == typeof(PositionComponent)) { return Constants.Components.PositionComponent; }
            else if (type == typeof(SpriteComponent)) { return Constants.Components.SpriteComponent; }
            else if (type == typeof(InputComponent)) { return Constants.Components.InputComponent; }
            else { return -1; }
            }

        public static int RegisterComponent(int index, int bitfield)
        {
            return bitfield ^ (1 << index);
        }
        public static int UnregisterComponent(int index, int bitfield)
        {
            return bitfield ^ (1 << index);
        }
    }
}
