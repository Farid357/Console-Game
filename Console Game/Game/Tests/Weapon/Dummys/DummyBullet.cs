using System.Numerics;
using ConsoleGame.Weapons;

namespace ConsoleGame.Tests
{
    public sealed class DummyBullet : IBullet
    {
        public bool WasThrew { get; private set; }

        public void Throw(Vector3 direction)
        {
            WasThrew = true;
        }
    }
}