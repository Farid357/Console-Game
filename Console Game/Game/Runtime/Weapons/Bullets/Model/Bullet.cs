using System;
using System.Numerics;

namespace Console_Game.Weapons
{
    public sealed class Bullet : IGameLoopObject, IBullet
    {
        private readonly IMovement _movement;
        private bool _isThrowing;
        private Vector2 _direction;

        public Bullet(IMovement movement)
        {
            _movement = movement ?? throw new ArgumentNullException(nameof(movement));
        }

        public void Throw(Vector2 direction)
        {
            _direction = direction;
            _isThrowing = true;
        }

        public void Destroy()
        {
            //TODO Destroy
        }

        public void Update(float deltaTime)
        {
            if(!_isThrowing)
                return;
            
            _movement.Move(_direction);
        }
    }
}