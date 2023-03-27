using System;
using System.Collections.Generic;
using System.Numerics;

namespace ConsoleGame.Weapons
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

        public void Throw(Vector3 direction)
        {
            foreach (IBullet bullet in _bullets)
            {
                bullet.Throw(direction);
            }
        }
    }
}