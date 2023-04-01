using System.Numerics;
using ConsoleGame.Physics;

namespace ConsoleGame.Tests.Physics
{
    public class DummyCollider : ICollider
    {
        public DummyCollider(Vector3 center)
        {
            Center = center;
        }

        public Vector3 Center { get; }
        
        public bool Contains(Vector3 point)
        {
            return Center == point;
        }
    }
}