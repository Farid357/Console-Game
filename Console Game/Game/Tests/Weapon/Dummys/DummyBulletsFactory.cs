using Console_Game.Weapons;

namespace Console_Game.Tests
{
    public sealed class DummyBulletsFactory : IBulletsFactory
    {
        public DummyBullet CreatedBullet { get; private set; }

        public IBullet Create(int damage)
        {
            CreatedBullet = new DummyBullet();
            return CreatedBullet;
        }
    }
}