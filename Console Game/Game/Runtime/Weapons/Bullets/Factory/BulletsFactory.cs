using System;
using Console_Game.Loop;

namespace Console_Game.Weapons
{
    public sealed class BulletsFactory : IBulletsFactory
    {
        private readonly IReadOnlyTransform _transform;
        private readonly IGroup<IGameLoopObject> _gameLoopObjects;

        public BulletsFactory(IReadOnlyTransform transform, IGroup<IGameLoopObject> gameLoopObjects)
        {
            _transform = transform ?? throw new ArgumentNullException(nameof(transform));
            _gameLoopObjects = gameLoopObjects ?? throw new ArgumentNullException(nameof(gameLoopObjects));
        }

        public IBullet Create()
        {
            IMovement movement = new SmoothMovement(0.2f, 0.3f, new Transform(_transform));
            var bullet = new Bullet(movement, new GameObjectView());
            _gameLoopObjects.Add(bullet);
            return bullet;
        }
    }
}