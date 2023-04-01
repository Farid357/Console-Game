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
            var characterWorld = new CollidersWorld<ICharacter>();
            IRaycast<ICharacter> raycast = new Raycast<ICharacter>(characterWorld, 10);
            characterWorld.Add(new DummyCharacter(), new BoxCollider(Vector3.One, new Vector3(1, 0, 0)));
            RaycastHit<ICharacter> raycastHit = raycast.Throw(Vector3.Zero / 2f, new Vector3(1, 0, 0));
            Assert.That(raycastHit.Occurred);
            Console.WriteLine(raycastHit.HitPoint);
        }
    }
}