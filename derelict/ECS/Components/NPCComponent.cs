using derelict.ECS.Components.Base;
using derelict.ECS.System;

namespace derelict.ECS.Components
{
    public class NPCComponent : Component
    {
        public NPCComponent(Entity entity) : base(entity)
        {
            NPCSystem.RegisterComponent(this);
        }
    }
}
