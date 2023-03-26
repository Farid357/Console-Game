using System;

namespace ConsoleGame.Weapons
{
    public sealed class GameObjectWithLifeTime : IGameObject
    {
        private readonly IGameObject _gameObject;
        private readonly ITimer _lifeTime;

        public GameObjectWithLifeTime(IGameObject gameObject, ITimer lifeTime)
        {
            _gameObject = gameObject ?? throw new ArgumentNullException(nameof(gameObject));
            _lifeTime = lifeTime ?? throw new ArgumentNullException(nameof(lifeTime));
        }

        public bool IsActive => _lifeTime.IsEnded == false;
        
        public void Update(float deltaTime)
        {
            _gameObject.Update(deltaTime);
        }
    }
}