using System;

namespace Console_Game.Weapons
{
    public sealed class BulletWithLifeTime : IGameLoopObject, IBullet
    {
        private readonly IBullet _bullet;
        private readonly ITimer _lifeTime;

        public BulletWithLifeTime(IBullet bullet, ITimer lifeTime)
        {
            _bullet = bullet ?? throw new ArgumentNullException(nameof(bullet));
            _lifeTime = lifeTime ?? throw new ArgumentNullException(nameof(lifeTime));
        }
        
        public bool IsDestroyed => _bullet.IsDestroyed;

        public void Update(float deltaTime)
        {
            if (_lifeTime.IsEnded)
            {
                _bullet.Destroy();
            }
        }

        public void Throw()
        {
            _lifeTime.Play();
            _bullet.Throw();
        }

        public void Destroy() => _bullet.Destroy();
        
    }
}