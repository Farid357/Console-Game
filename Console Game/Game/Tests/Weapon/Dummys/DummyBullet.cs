using System.Numerics;
using Console_Game.Weapons;

namespace Console_Game.Tests
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


        public void Throw(Vector2 direction)
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