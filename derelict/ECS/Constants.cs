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
            public const int MaxComponentCount = 5;

            public const int AIComponent = 0;
            public const int NPCComponent = 1;
            public const int PlayerComponent = 2;
            public const int PositionComponent = 3;
            public const int SpriteComponent = 4;
        }
    }
}
