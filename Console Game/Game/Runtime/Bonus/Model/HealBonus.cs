using System;
using ConsoleGame.Tools;

namespace ConsoleGame.Bonus
{
    public sealed class HealBonus : IBonus
    {
        private readonly IHealth _health;
        private readonly int _healAmount;

        public HealBonus(IHealth health, int healAmount = 10)
        {
            _health = health ?? throw new ArgumentNullException(nameof(health));
            _healAmount = healAmount.ThrowIfLessThanOrEqualsToZeroException();
        }

        public void Pick()
        {
            _health.Heal(_healAmount);
        }
    }
}