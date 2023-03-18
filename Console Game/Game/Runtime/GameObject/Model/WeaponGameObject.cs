using System;
using Console_Game.UI;

namespace Console_Game
{
    public sealed class WeaponGameObject : IGameObject
    {
        private readonly IGameObject _gameObject;
        private readonly IText _bulletsText;
        
        public WeaponGameObject(IGameObject gameObject, IText bulletsText)
        {
            _gameObject = gameObject ?? throw new ArgumentNullException(nameof(gameObject));
            _bulletsText = bulletsText ?? throw new ArgumentNullException(nameof(bulletsText));
        }

        public ITransform Transform => _gameObject.Transform;

        public bool IsActive => _gameObject.IsActive;

        public bool IsDestroyed => _gameObject.IsDestroyed;

        public void Enable()
        {
            _gameObject.Enable();
            _bulletsText.Enable();
        }

        public void Disable()
        {
            _gameObject.Disable();
            _bulletsText.Disable();
        }

        public void Destroy()
        {
            _gameObject.Destroy();
            _bulletsText.Disable();
        }
    }
}