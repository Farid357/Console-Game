using System;
using System.Collections.Generic;
using ConsoleGame.Tools;

namespace ConsoleGame
{
    public sealed class EnemiesKillBonus : IBonus
    {
        private readonly IReadOnlyList<IEnemy> _enemies;
        private readonly IBonus _bonus;
        
        public EnemiesKillBonus(IBonus bonus, IReadOnlyList<IEnemy> enemies)
        {
            _enemies = enemies ?? throw new ArgumentNullException(nameof(enemies));
            _bonus = bonus ?? throw new ArgumentNullException(nameof(bonus));
        }
        
        public bool IsAlive => _bonus.IsAlive;

        public void Pick()
        {
            _bonus.Pick();
            KillAllEnemies();
        }

        private void KillAllEnemies()
        {
            foreach (IEnemy enemy in _enemies)
            {
                if (enemy.Health.IsAlive)
                {
                    enemy.Health.Kill();
                }
            }
        }
    }
}