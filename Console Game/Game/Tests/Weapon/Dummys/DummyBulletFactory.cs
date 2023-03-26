using ConsoleGame.Weapons;

namespace ConsoleGame.Tests
{
    public sealed class DummyBulletFactory : IBulletFactory
    {
        public DummyBullet CreatedBullet { get; private set; }

        public IBullet Create(int damage)
        {
            CreatedBullet = new DummyBullet();
            return CreatedBullet;
        }
    }
}