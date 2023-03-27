using System.Numerics;
using ConsoleGame.Weapons;

namespace ConsoleGame.Tests
{
    public sealed class DummyBullet : IBullet
    {
        public bool WasThrew { get; private set; }

        public Vector2 Position { get; }

        public bool IsActive { get; }

        public void Throw()
        {
            WasThrew = true;
        }


        public void Throw(Vector3 direction)
        {
            
        }


        public void Destroy()
        {
            
        }

        public void Update(float deltaTime)
        {
        }
    }
}