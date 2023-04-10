using System;
using ConsoleGame.Tools;

namespace ConsoleGame
{
    public sealed class HealBonus : IBonus
    {
        private readonly IBonus _bonus;
        private readonly IHealth _health;
        private readonly int _healAmount;

        public HealBonus(IBonus bonus, IHealth health, int healAmount = 10)
        {
            _bonus = bonus ?? throw new ArgumentNullException(nameof(bonus));
            _health = health ?? throw new ArgumentNullException(nameof(health));
            _healAmount = healAmount.ThrowIfLessThanOrEqualsToZeroException();
        }
        
        public bool IsAlive => _bonus.IsAlive;

        public void Pick()
        {
            _bonus.Pick();
            _health.Heal(_healAmount);
        }
    }
}