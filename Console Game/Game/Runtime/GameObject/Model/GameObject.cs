using System;

namespace Console_Game
{
    public sealed class GameObject : IGameObject
    {
        private bool _isDestroyed;
        private bool _isActive;

        public bool IsActive => _isActive && !_isDestroyed;

        public void Enable()
        {
            if (_isDestroyed)
                throw new InvalidOperationException($"GameObject is destroyed!");

            _isActive = true;
        }

        public void Disable()
        {
            if (_isDestroyed)
                throw new InvalidOperationException($"GameObject is destroyed!");

            _isActive = false;
        }

        public void Destroy()
        {
            if (_isDestroyed)
                throw new InvalidOperationException($"GameObject is destroyed!");
            
            _isDestroyed = true;
        }
    }
}