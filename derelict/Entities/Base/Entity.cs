using System;
using System.Collections.Generic;

namespace derelict.Entities.Base
{
    public class Entity
    {
        public List<Component> Components;
        public string Name { get; set; }
    }
}
