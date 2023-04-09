using ConsoleGame.Physics;
using ConsoleGame.Weapons;
using NUnit.Framework;

namespace ConsoleGame.Tests.Physics
{
    [TestFixture]
    public class CollidersWorldTest
    {
        private readonly Layer _layer = Layer.Bullet;
        private ICollidersWorld<IBullet> _collidersWorld;
        private IBullet _bullet;

        [SetUp]
        public void SetUp()
        {
            _collidersWorld = new CollidersWorld<IBullet>();
            _bullet = new DummyBullet();
        }
        
        [Test]
        public void AddsCorrectly()
        {
            _collidersWorld.Add(_bullet, new DummyCollider(), _layer);
            Assert.That(_collidersWorld.Colliders(_layer).ContainsKey(_bullet));
        }
        
        [Test]
        public void RemovesCorrectly()
        {
            AddsCorrectly();
            _collidersWorld.Remove(_bullet);
            Assert.That(_collidersWorld.Colliders(_layer).Count == 0);
        }
    }
}