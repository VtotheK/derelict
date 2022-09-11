using System;
using System.Windows;

namespace MapEditor.Model
{
    public class ColliderVertex
    {
        public Collider Parent { get; init; }
        public int Order { get; set; }
        public Point Vertex { get; set; }
    }
}
