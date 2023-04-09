using System;
using ConsoleGame.Stats;

namespace ConsoleGame.Bonus
{
    public sealed class IncreaseFactorBonusFactory : IBonusFactory
    {
        private readonly IBonusFactory _bonusFactory;
        private readonly IFactor _factor;

        public IncreaseFactorBonusFactory(IBonusFactory bonusFactory, IFactor factor)
        {
            _bonusFactory = bonusFactory ?? throw new ArgumentNullException(nameof(bonusFactory));
            _factor = factor ?? throw new ArgumentNullException(nameof(factor));
        }

        public IBonus Create(ITransform transform)
        {
            IBonus bonus = _bonusFactory.Create(transform);
            return new IncreaseFactorBonus(bonus, _factor, 30);;
        }
    }
}