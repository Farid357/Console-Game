using System;
using System.Collections.Generic;
using ConsoleGame.Tools;

namespace ConsoleGame
{
    public sealed class KillsStreak : IGameLoopObject, IKillsStreak
    {
        private readonly IReadOnlyList<IEnemy> _allEnemies;
        private readonly IKillsStreakView _view;
        private readonly IHealth _characterHealth;
        private readonly List<IEnemy> _alreadyKilledEnemies;
        private int _lastCharacterHealth;
        
        public KillsStreak(IReadOnlyList<IEnemy> allEnemies, IKillsStreakView view, IHealth character)
        {
            _allEnemies = allEnemies ?? throw new ArgumentNullException(nameof(allEnemies));
            _view = view ?? throw new ArgumentNullException(nameof(view));
            _characterHealth = character ?? throw new ArgumentNullException(nameof(character));
            _alreadyKilledEnemies = new List<IEnemy>();
            _lastCharacterHealth = _characterHealth.Value;
        }
        
        public int Factor { get; private set; }
        
        public void Update(float deltaTime)
        {
            TryIncrease();

            if (_characterHealth.Value < _lastCharacterHealth)
            {
                Reset();
                _lastCharacterHealth = _characterHealth.Value;
            }
        }

        private void Reset()
        {
            Factor = 0;
            _view.Reset();
        }

        private void TryIncrease()
        {
            foreach (IEnemy enemy in _allEnemies)
            {
                if (enemy.Health.IsDied() && _alreadyKilledEnemies.Contains(enemy) == false)
                {
                    Factor++;
                    _view.Visualize(Factor);
                    _alreadyKilledEnemies.Add(enemy);
                }
            }
        }
    }
}