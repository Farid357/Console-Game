using System;

namespace Console_Game.Weapons
{
    public sealed class BulletsFactory : IBulletsFactory
    {
        private readonly ITransform _transform;

        public BulletsFactory(ITransform transform)
        {
            _transform = transform ?? throw new ArgumentNullException(nameof(transform));
        }

        public IBullet Create()
        {
            return new Bullet(new SmoothMovement(0.2f, 0.3f, _transform));
        }
    }
}