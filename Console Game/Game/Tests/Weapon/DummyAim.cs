using System.Numerics;

namespace ConsoleGame.Tests
{
    public class DummyAim : IAim
    {
        public Vector3 Position { get; }
        
        public Vector3 Target { get; }
    }
}