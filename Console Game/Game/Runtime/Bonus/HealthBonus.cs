using System;
using ConsoleGame.Tools;

namespace ConsoleGame.Bonus
{
    public sealed class HealthBonus : IBonus
    {
        private readonly IHealth _health;
        private readonly int _healAmount;

        public HealthBonus(IHealth health, int healAmount = 10)
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