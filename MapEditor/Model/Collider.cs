using System;
using System.Collections.Generic;
using System.Windows;

namespace MapEditor.Model
{
    [Flags]
    public enum MeshState
    {
        Open = 1,
        Closed = 2
    }

    public class Collider : GameObject
    {
        public List<ColliderVertex> ColliderVertices { get; set; }
        private int VertexOrder;
        public Collider() : base()
        {
            ColliderVertices = new List<ColliderVertex>();
            VertexOrder = 0;
        }

        public void AddColliderVertex(Point point)
        {
            var roundedX = Math.Round(point.X,0);
            var roundedY = Math.Round(point.Y,0);
            ColliderVertices.Add(new ColliderVertex
            {
                Parent = this,
                Vertex = new Point
                {
                    X = roundedX,
                    Y = roundedY
                },
                Order = VertexOrder++
            });
        }
        public int VertexCount { get => ColliderVertices.Count; }
    }
}
