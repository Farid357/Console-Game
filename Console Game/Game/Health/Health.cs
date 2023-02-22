using System;
using Console_Game.Tools.Extensions;

namespace Console_Game
{
    public sealed class Health : IHealth
    {
        private readonly IHealthView _view;

        public Health(IHealthView view, int value)
        {
            _view = view ?? throw new ArgumentNullException(nameof(view));
            Value = value.ThrowIfLessThanOrEqualsToZeroException();
            MaxValue = Value;
        }

        public int Value { get; private set; }

        public int MaxValue { get; }

        public bool IsAlive => Value > 0;

        private bool IsDied => !IsAlive;

        public bool CanHeal(int value) => MaxValue >= Value + value;

        public void TakeDamage(int damage)
        {
            if (IsDied)
                throw new InvalidOperationException($"Health can't take damage! It's not alive!");

            Value = Math.Min(0, Value - damage.ThrowIfLessThanOrEqualsToZeroException());
            _view.Visualize(MaxValue, Value);

            if (IsDied)
                _view.VisualizeDeath();
        }

        public void Heal(int value)
        {
            if (CanHeal(value) == false)
                throw new InvalidOperationException($"Can't heal!");

            Value += value.ThrowIfLessThanOrEqualsToZeroException();
            _view.Visualize(MaxValue, Value);
        }
    }

    public sealed class Armor : IHealth
    {
        private readonly IHealth _health;
        private readonly int _maxProtection;
        private int _protection;

        public Armor(IHealth health, int protection)
        {
            _health = health ?? throw new ArgumentNullException(nameof(health));
            _maxProtection = protection.ThrowIfLessThanOrEqualsToZeroException();
            _protection = _maxProtection;
        }

        public int Value => _health.Value;

        public int MaxValue => _health.MaxValue;

        public bool IsAlive => _health.IsAlive;

        public bool CanHeal(int value) => false;

        public void TakeDamage(int damage)
        {
            damage.ThrowIfLessThanOrEqualsToZeroException();
            
            if (_protection > 0)
            {
                _protection -= damage;
                damage = _protection;
            }

            if (damage > 0)
                _health.TakeDamage(damage);
        }

        public void Heal(int value)
        {
            throw new InvalidOperationException($"Can't heal armor!");
        }
    }
}