using System;
using System.Collections.Generic;
using System.Numerics;

namespace Console_Game.Weapons
{
    public sealed class Bullets : IBullet
    {
        private readonly List<IBullet> _all;

        public Bullets(List<IBullet> all)
        {
            if (all.Count == 0)
                throw new ArgumentException("Value cannot be an empty collection.", nameof(all));
            
            _all = all ?? throw new ArgumentNullException(nameof(all));
        }

        public void Throw(Vector2 direction)
        {
            foreach (IBullet bullet in _all)
            {
                bullet.Throw(direction);
            }
        }

        public void Destroy()
        {
            throw new NotImplementedException();
        }
    }
}