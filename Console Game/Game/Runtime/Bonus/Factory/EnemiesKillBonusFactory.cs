using System;
using System.Collections.Generic;

namespace ConsoleGame
{
    public sealed class EnemiesKillBonusFactory : IBonusFactory
    {
        private readonly IReadOnlyList<IEnemy> _enemies;
        private readonly IBonusFactory _bonusFactory;
        
        public EnemiesKillBonusFactory(IBonusFactory bonusFactory, IReadOnlyList<IEnemy> enemies)
        {
            _enemies = enemies ?? throw new ArgumentNullException(nameof(enemies));
            _bonusFactory = bonusFactory ?? throw new ArgumentNullException(nameof(bonusFactory));
        }

        public IBonus Create(ITransform transform)
        {
            IBonus bonus = _bonusFactory.Create(transform);
            return new EnemiesKillBonus(bonus, _enemies);
        }
    }
}