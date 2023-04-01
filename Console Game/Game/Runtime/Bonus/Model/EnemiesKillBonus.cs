using System;
using System.Collections.Generic;
using ConsoleGame.Tools;

namespace ConsoleGame.Bonus
{
    public sealed class EnemiesKillBonus : IBonus
    {
        private readonly IReadOnlyList<IEnemy> _enemies;

        public EnemiesKillBonus(IReadOnlyList<IEnemy> enemies)
        {
            _enemies = enemies ?? throw new ArgumentNullException(nameof(enemies));
        }

        public void Pick()
        {
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