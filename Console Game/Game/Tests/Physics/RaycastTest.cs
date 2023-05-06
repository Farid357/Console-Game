using System;
using System.Numerics;
using ConsoleGame.Physics;
using NUnit.Framework;

namespace ConsoleGame.Tests.Physics
{
    [TestFixture]
    public sealed class RaycastTest
    {
        [Test]
        public void HitsCorrectly()
        {
            ICollidersWorld<ICharacter> characterWorld = new CollidersWorld<ICharacter>();
            IRaycast<ICharacter> raycast = new Raycast<ICharacter>(characterWorld, maxDistance: 10);
            ICollider collider = new BoxCollider(Vector3.One, new Transform());
            characterWorld.Add(new DummyCharacter(), collider);
            RaycastHit<ICharacter> raycastHit = raycast.Throw(Vector3.Zero / 2f, new Vector3(1, 0, 0));
            Assert.That(raycastHit.Occurred);
            Console.WriteLine(raycastHit.HitPoint);
        }
        
        [Test]
        public void HitsWithLayerCorrectly()
        {
            ICollidersWorld<ICharacter> characterWorld = new CollidersWorld<ICharacter>();
            IRaycast<ICharacter> raycast = new Raycast<ICharacter>(characterWorld, maxDistance: 10);
            ICollider collider = new BoxCollider(Vector3.One, new Transform());
            characterWorld.Add(new DummyCharacter(), collider);
            RaycastHit<ICharacter> raycastHit = raycast.Throw(Vector3.Zero / 2f, new Vector3(1, 0, 0));
            Assert.That(raycastHit.Occurred);
            Console.WriteLine(raycastHit.HitPoint);
        }
    }
}