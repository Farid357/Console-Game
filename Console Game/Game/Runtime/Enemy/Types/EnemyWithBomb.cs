using System;
using ConsoleGame.Tools;

namespace ConsoleGame
{
    public sealed class EnemyWithBomb : IEnemy, IGameObject
    {
        private readonly IEnemy _enemy;
        private readonly IBomb _bomb;
        private bool _isAlive = true;
        
        public EnemyWithBomb(IEnemy enemy, IBomb bomb)
        {
            _enemy = enemy ?? throw new ArgumentNullException(nameof(enemy));
            _bomb = bomb ?? throw new ArgumentNullException(nameof(bomb));
        }

        public bool IsAlive => _enemy.IsAlive && _isAlive;

        public IHealth Health => _enemy.Health;
        
        public void Update(float deltaTime)
        {
            if (!IsAlive)
                throw new Exception($"Enemy is not alive!");
            
            if (_bomb.IsBlownUp)
            {
                Health.Kill();
                _isAlive = false;
            }
        }
    }
}