using System;
using System.Numerics;
using ConsoleGame.Physics;
using ConsoleGame.Tests.Physics;

namespace ConsoleGame
{
    public interface IPhysicsHealthFactory
    {
        IHealth Create(Vector3 position);
    }
    
    //TODO
    public sealed class PhysicsHealthFactory : IPhysicsHealthFactory
    {
        private readonly IHealthFactory _healthFactory;
        private readonly ICollidersWorld<IHealth> _collidersWorld;
        private readonly Layer _layer;

        public PhysicsHealthFactory(IHealthFactory healthFactory, ICollidersWorld<IHealth> collidersWorld, Layer layer)
        {
            _healthFactory = healthFactory ?? throw new ArgumentNullException(nameof(healthFactory));
            _collidersWorld = collidersWorld ?? throw new ArgumentNullException(nameof(collidersWorld));
            _layer = layer;
        }

        public IHealth Create(Vector3 position)
        {
            IHealth health = _healthFactory.Create();
            ICollider collider = new DummyCollider();
            _collidersWorld.Add(health, collider, _layer);
            return health;
        }
    }
}