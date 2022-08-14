using derelict.ECS.Components.Base;
using derelict.ECS.System;

namespace derelict.ECS.Components
{
    public class AIComponent : Component
    {
        public AIComponent(Entity entity) : base(entity)
        {
            AISystem.RegisterComponent(this);
        }
    }
}
