using System.Numerics;

namespace Console_Game.Weapons
{
    public sealed class BulletsFactory : IBulletsFactory
    {
        private readonly Vector2 _bulletDirection;

        public BulletsFactory()
        {
            _bulletDirection = new Vector2(1, 1);
        }

        public IBullet Create()
        {
            return new Bullet(_bulletDirection);
        }
    }
}