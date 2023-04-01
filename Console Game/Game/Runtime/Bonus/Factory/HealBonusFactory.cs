using System;
using System.Numerics;
using ConsoleGame.Physics;

namespace ConsoleGame.Bonus
{
    public sealed class HealBonusFactory : IBonusFactory
    {
        private readonly IHealth _health;
        private readonly ICollidersWorld<IBonus> _bonusesWorld;
        private readonly Random _random;
        
        public HealBonusFactory(IHealth health, ICollidersWorld<IBonus> bonusesWorld)
        {
            _health = health ?? throw new ArgumentNullException(nameof(health));
            _bonusesWorld = bonusesWorld ?? throw new ArgumentNullException(nameof(bonusesWorld));
            _random = new Random();
        }
        public IBonus Create(IReadOnlyTransform transform)
        {
            int healAmount = _random.Next(10, 25);
            IBonus bonus = new HealBonus(_health, healAmount);
            ICollider bonusCollider = new BoxCollider(new Box(Vector3.One), transform.Position);
            _bonusesWorld.Add(bonus, bonusCollider);
            return bonus;
        }
    }
}