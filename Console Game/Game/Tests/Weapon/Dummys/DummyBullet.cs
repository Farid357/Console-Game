using System.Numerics;
using Console_Game.Weapons;

namespace Console_Game.Tests
{
    public sealed class DummyBullet : IBullet
    {
        public bool WasThrew { get; private set; }

        public bool IsDestroyed { get; }

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
    }
}