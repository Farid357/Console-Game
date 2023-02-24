using System;
using Console_Game.Tools;

namespace Console_Game
{
    public sealed class HealableHealth : IHealableHealth
    {
        private readonly IHealth _health;

        public HealableHealth(IHealth health)
        {
            _health = health ?? throw new ArgumentNullException(nameof(health));
            Value = _health.MaxValue;
        }

        public int Value { get; private set; }

        public int MaxValue => _health.MaxValue;

        public bool IsAlive => _health.IsAlive;

        public bool CanTakeDamage(int damage) => _health.CanTakeDamage(damage);

        public void TakeDamage(int damage)
        {
            _health.TakeDamage(damage);
            Value = _health.Value;
        }

        public bool CanHeal(int value) => MaxValue >= Value + value;

        public void Heal(int value)
        {
            if (CanHeal(value) == false)
                throw new InvalidOperationException($"Can't heal!");

            Value += value.ThrowIfLessThanOrEqualsToZeroException();
        }
    }
}