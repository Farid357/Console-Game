using System;
using System.Collections.Generic;
using System.Numerics;
using ConsoleGame.Physics;

namespace ConsoleGame.Bonus
{
    public sealed class EnemiesKillBonusFactory : IBonusFactory
    {
        private readonly IReadOnlyList<IEnemy> _enemies;
        private readonly ICollidersWorld<IBonus> _bonusesWorld;

        public EnemiesKillBonusFactory(IReadOnlyList<IEnemy> enemies, ICollidersWorld<IBonus> bonusesWorld)
        {
            _enemies = enemies ?? throw new ArgumentNullException(nameof(enemies));
            _bonusesWorld = bonusesWorld ?? throw new ArgumentNullException(nameof(bonusesWorld));
        }

        public IBonus Create(IReadOnlyTransform transform)
        {
            IBonus bonus = new EnemiesKillBonus(_enemies);
            ICollider collider = new BoxCollider(new Box(Vector3.One), transform.Position);
            _bonusesWorld.Add(bonus, collider);
            return bonus;
        }
    }
}