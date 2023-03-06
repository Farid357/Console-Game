using System;
using Console_Game.Loop;
using Console_Game.Tools;

namespace Console_Game
{
    public sealed class EnemyFactory : IEnemyFactory
    {
        private readonly int _healthCount;
        private readonly IEnemyData _data;
        private readonly IGroup<IGameLoopObject> _gameLoopObjects;

        public EnemyFactory(int healthCount, IEnemyData data, IGroup<IGameLoopObject> gameLoopObjects)
        {
            _data = data ?? throw new ArgumentNullException(nameof(data));
            _gameLoopObjects = gameLoopObjects ?? throw new ArgumentNullException(nameof(gameLoopObjects));
            _healthCount = healthCount.ThrowIfLessThanOrEqualsToZeroException();
        }

        public IEnemy Create(IReadOnlyTransform transform)
        {
            IHealth health = new Health(new HealthView(), _healthCount);
            var movement = new SmoothMovement(0.1f, 0.1f, new Transform(transform));
            _gameLoopObjects.Add(movement);
            return new Enemy(health, new AdjustableMovement(movement, new GamePause(new NullGamePauseView())), _data);
        }
    }
}