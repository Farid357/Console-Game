using System;
using System.Numerics;

namespace Console_Game.Weapons
{
    public sealed class Bullet : IBullet
    {
        private readonly IMovement _movement;
        private readonly Vector2 _up = new Vector2(0, 1);
        
        public Bullet(IMovement movement)
        {
            _movement = movement ?? throw new ArgumentNullException(nameof(movement));
        }

        public void Throw()
        {
            _movement.Move(_up);
        }
    }
}