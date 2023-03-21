using System;

namespace Console_Game.Weapons
{
    public sealed class BulletsFactory : IBulletsFactory
    {
        private readonly ITransform _transform;
        private readonly IGroup<IGameLoopObject> _gameLoopObjects;

        public BulletsFactory(ITransform transform, IGroup<IGameLoopObject> gameLoopObjects)
        {
            _transform = transform ?? throw new ArgumentNullException(nameof(transform));
            _gameLoopObjects = gameLoopObjects ?? throw new ArgumentNullException(nameof(gameLoopObjects));
        }

        public IBullet Create()
        {
            IMovement movement = new SmoothMovement(0.2f, 0.3f, _transform);
            var bullet = new Bullet(movement);
            _gameLoopObjects.Add(bullet);
            return bullet;
        }
    }
}