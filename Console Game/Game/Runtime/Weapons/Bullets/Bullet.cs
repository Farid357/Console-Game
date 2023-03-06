using System;
using System.Numerics;

namespace Console_Game.Weapons
{
    public sealed class Bullet : IGameLoopObject, IBullet
    {
        private readonly IMovement _movement;
        private readonly IGameObjectView _view;
        private bool _isThrowing;
        
        public Bullet(IMovement movement, IGameObjectView view)
        {
            _movement = movement ?? throw new ArgumentNullException(nameof(movement));
            _view = view ?? throw new ArgumentNullException(nameof(view));
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
            _view.Destroy();
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