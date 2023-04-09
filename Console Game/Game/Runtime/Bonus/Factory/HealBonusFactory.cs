using System;

namespace ConsoleGame.Bonus
{
    public sealed class HealBonusFactory : IBonusFactory
    {
        private readonly IBonusFactory _bonusFactory;
        private readonly IHealth _health;
        private readonly Random _random;
        
        public HealBonusFactory(IBonusFactory bonusFactory, IHealth health)
        {
            _bonusFactory = bonusFactory ?? throw new ArgumentNullException(nameof(bonusFactory));
            _health = health ?? throw new ArgumentNullException(nameof(health));
            _random = new Random();
        }
        
        public IBonus Create(ITransform transform)
        {
            int healAmount = _random.Next(10, 25);
            IBonus bonus = _bonusFactory.Create(transform);
            return new HealBonus(bonus, _health, healAmount);;
        }
    }
}