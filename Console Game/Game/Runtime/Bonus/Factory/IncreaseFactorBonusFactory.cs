using System;
using System.Numerics;
using ConsoleGame.Physics;
using ConsoleGame.Stats;

namespace ConsoleGame.Bonus
{
    public sealed class IncreaseFactorBonusFactory : IBonusFactory
    {
        private readonly ICollidersWorld<IBonus> _bonusesWorld;
        private readonly IFactor _factor;

        public IncreaseFactorBonusFactory(ICollidersWorld<IBonus> bonusesWorld, IFactor factor)
        {
            _bonusesWorld = bonusesWorld ?? throw new ArgumentNullException(nameof(bonusesWorld));
            _factor = factor ?? throw new ArgumentNullException(nameof(factor));
        }

        public IBonus Create(IReadOnlyTransform transform)
        {
            IBonus bonus = new IncreaseFactorBonus(_factor, 30);
            ICollider collider = new BoxCollider(Vector3.One, transform.Position);
            _bonusesWorld.Add(bonus, collider);
            return bonus;
        }
    }
}