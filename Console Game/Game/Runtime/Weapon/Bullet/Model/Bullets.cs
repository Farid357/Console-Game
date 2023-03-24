using System;
using System.Collections.Generic;
using System.Numerics;

namespace Console_Game.Weapons
{
    public sealed class Bullets : IBullet
    {
        private readonly List<IBullet> _bullets;

        public Bullets(List<IBullet> all)
        {
            if (all.Count == 0)
                throw new ArgumentException("Value cannot be an empty collection.", nameof(all));
            
            _bullets = all ?? throw new ArgumentNullException(nameof(all));
        }

        public bool IsActive { get; private set; } = true;

        public Vector2 Position => _bullets[0].Position;

        public void Throw(Vector2 direction)
        {
            foreach (IBullet bullet in _bullets)
            {
                bullet.Throw(direction);
            }
        }

        public void Destroy()
        {
            IsActive = false;
            _bullets.ForEach(bullet => bullet.Destroy());
        }

        public void Update(float deltaTime)
        {
            _bullets.ForEach(bullet => bullet.Update(deltaTime));
        }
    }
}