using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace derelict.ECS
{
    public static class Constants
    {
        public static class Components
        {
            //TODO Replace with function call to return the amount of flags
            public const int MaxComponentCount = 6;

            public const int AIComponent = 0;
            public const int NPCComponent = 1;
            public const int PlayerComponent = 2;
            public const int PositionComponent = 3;
            public const int SpriteComponent = 4;
            public const int InputComponent = 5;
        }
    }
}
