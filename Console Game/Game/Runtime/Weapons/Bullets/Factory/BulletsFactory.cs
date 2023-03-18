using System;

namespace Console_Game.Weapons
{
    public sealed class BulletsFactory : IBulletsFactory
    {
        private readonly ITransform _transform;
        private readonly IGroup<IGameLoopObject> _gameLoopObjects;
        private readonly IGameObjectsFactory _gameObjectsFactory;

        public BulletsFactory(ITransform transform, IGroup<IGameLoopObject> gameLoopObjects, IGameObjectsFactory gameObjectsFactory)
        {
            _transform = transform ?? throw new ArgumentNullException(nameof(transform));
            _gameLoopObjects = gameLoopObjects ?? throw new ArgumentNullException(nameof(gameLoopObjects));
            _gameObjectsFactory = gameObjectsFactory ?? throw new ArgumentNullException(nameof(gameObjectsFactory));
        }

        public IBullet Create()
        {
            IMovement movement = new SmoothMovement(0.2f, 0.3f, _transform);
            var bullet = new Bullet(movement, _gameObjectsFactory.Create(_transform));
            _gameLoopObjects.Add(bullet);
            return bullet;
        }
    }
}