using Console_Game.Weapons;

namespace Console_Game.Tests
{
    public sealed class DummyBullet : IBullet
    {
        public bool WasThrew { get; private set; }

        public void Throw()
        {
            WasThrew = true;
        }
    }
}