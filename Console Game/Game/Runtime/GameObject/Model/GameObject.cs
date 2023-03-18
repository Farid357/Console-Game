using System;

namespace Console_Game
{
    public sealed class GameObject : IGameObject
    {
        private readonly IGameObjectView _view;
        private bool _isActive;

        public GameObject(ITransform transform, IGameObjectView view)
        {
            _view = view ?? throw new ArgumentNullException(nameof(view));
            Transform = transform ?? throw new ArgumentNullException(nameof(transform));
        }

        public GameObject() : this(new Transform(), new GameObjectView())
        {
        }

        public ITransform Transform { get; }

        public bool IsActive => _isActive && !IsDestroyed;

        public bool IsDestroyed { get; private set; }

        public void Enable()
        {
            if (IsDestroyed)
                throw new InvalidOperationException($"GameObject is destroyed!");

            _isActive = true;
            _view.Enable();
        }

        public void Disable()
        {
            if (IsDestroyed)
                throw new InvalidOperationException($"GameObject is destroyed!");

            _isActive = false;
            _view.Disable();
        }

        public void Destroy()
        {
            if (IsDestroyed)
                throw new InvalidOperationException($"GameObject is destroyed!");
            
            IsDestroyed = true;
            _view.Destroy();
        }
    }
}