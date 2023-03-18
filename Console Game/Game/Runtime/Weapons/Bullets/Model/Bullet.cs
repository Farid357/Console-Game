using System;
using System.Numerics;
using Console_Game;

namespace Console_Game.Weapons
{
    public sealed class Bullet : IGameLoopObject, IBullet
    {
        private readonly IMovement _movement;
        private readonly IGameObject _gameObject;
        private bool _isThrowing;
        
        public Bullet(IMovement movement, IGameObject gameObject)
        {
            _movement = movement ?? throw new ArgumentNullException(nameof(movement));
            _gameObject = gameObject ?? throw new ArgumentNullException(nameof(gameObject));
        }

        public bool IsDestroyed { get; private set; }
        
        public void Throw()
        {
            if (IsDestroyed)
                throw new InvalidOperationException($"Can't throw, bullet is destroyed!");
            
            _isThrowing = true;
        }

        public void Destroy()
        {
            IsDestroyed = true;
            _gameObject.Destroy();
        }

        public void Update(float deltaTime)
        {
            if(!_isThrowing)
                return;
            
            //TODO: Replace Movement
            _movement.Move(new Vector2(1, 1));
        }
    }
}