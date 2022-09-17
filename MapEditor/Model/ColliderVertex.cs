using System;
using System.Windows;

namespace MapEditor.Model
{
    public class ColliderVertex : GameObject
    {
        public ColliderVertex() : base(typeof(ColliderVertex))
        {

        }
        public Collider Parent { get; init; }
        public int Order { get; set; }
        public Point Vertex { get; set; }
    }
}
