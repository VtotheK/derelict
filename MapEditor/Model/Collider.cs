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
        private List<ColliderVertex> ColliderVertices;
        private int VertexOrder;
        public Collider() : base()
        {
            ColliderVertices = new List<ColliderVertex>();
            VertexOrder = 0;
        }

        public void AddColliderVertex(Point point)
        {
            ColliderVertices.Add(new ColliderVertex
            {
                Parent = this,
                Vertex = point,
                Order = VertexOrder++
            });
        }
    }
}
