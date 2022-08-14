using derelict.ECS.Components.Base;
using derelict.ECS.System;

namespace derelict.ECS.Components
{
    public class InputComponent : Component
    {
        public bool IsInvertedYAxis = false;
        public InputComponent(Entity entity) : base(entity)
        {
            InputSystem.RegisterComponent(this);
        }
    }
}
