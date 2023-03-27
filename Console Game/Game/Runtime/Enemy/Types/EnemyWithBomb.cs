using System;
using ConsoleGame.Explosion;
using ConsoleGame.Tools;

namespace ConsoleGame
{
    public sealed class EnemyWithBomb : IEnemy, IGameObject
    {
        private readonly IEnemy _enemy;
        private readonly IBombFactory _bombFactory;
        private readonly ITransform _transform;
        private readonly ITimer _blowUpTimer;
        private bool _isAlive = true;
        
        public EnemyWithBomb(IEnemy enemy, IBombFactory bombFactory, ITransform transform, ITimer blowUpTimer)
        {
            _enemy = enemy ?? throw new ArgumentNullException(nameof(enemy));
            _bombFactory = bombFactory ?? throw new ArgumentNullException(nameof(bombFactory));
            _transform = transform ?? throw new ArgumentNullException(nameof(transform));
            _blowUpTimer = blowUpTimer ?? throw new ArgumentNullException(nameof(blowUpTimer));
        }

        public bool IsAlive => _enemy.IsAlive && _isAlive;

        public IHealth Health => _enemy.Health;
        
        public void Update(float deltaTime)
        {
            if (_blowUpTimer.IsEnded)
            {
                Health.Kill();
                IBomb bomb = _bombFactory.Create(_transform.Position);
                bomb.BlowUp();
                _isAlive = false;
            }
        }
    }
}