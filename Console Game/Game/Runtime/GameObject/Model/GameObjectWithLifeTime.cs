using System;

namespace Console_Game.Weapons
{
    public sealed class GameObjectWithLifeTime : IGameLoopObject, IGameObject
    {
        private readonly IGameObject _gameObject;
        private readonly ITimer _lifeTime;

        public GameObjectWithLifeTime(IGameObject gameObject, ITimer lifeTime)
        {
            _gameObject = gameObject ?? throw new ArgumentNullException(nameof(gameObject));
            _lifeTime = lifeTime ?? throw new ArgumentNullException(nameof(lifeTime));
        }

        public bool IsActive => _gameObject.IsActive;

        public void Enable() => _gameObject.Enable();

        public void Disable() => _gameObject.Disable();

        public void Destroy() => _gameObject.Destroy();

        public void Update(float deltaTime)
        {
            if (_lifeTime.IsEnded && _gameObject.IsActive)
            {
                _gameObject.Destroy();
            }
        }
    }
}