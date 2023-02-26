using System;

namespace Console_Game.Weapons
{
    public sealed class BulletsFactory : IBulletsFactory
    {
        private readonly IReadOnlyTransform _transform;

        public BulletsFactory(IReadOnlyTransform transform)
        {
            _transform = transform ?? throw new ArgumentNullException(nameof(transform));
        }

        public IBullet Create()
        {
            return new Bullet(new SmoothMovement(0.2f, 0.3f, new Transform(_transform)));
        }
    }
}