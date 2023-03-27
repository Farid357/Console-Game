using System;
using ConsoleGame.Tools;

namespace ConsoleGame
{
    public sealed class Armor : IHealth
    {
        private readonly IHealth _health;
        private readonly IArmorView _view;
        private int _protection;

        public Armor(IHealth health, IArmorView view, int protection)
        {
            _health = health ?? throw new ArgumentNullException(nameof(health));
            _view = view ?? throw new ArgumentNullException(nameof(view));
            _protection = protection.ThrowIfLessThanOrEqualsToZeroException();
        }

        public int Value => _health.Value;

        public bool IsAlive => _health.IsAlive;

        public bool CanHeal(int value) => false;

        public void TakeDamage(int damage)
        {
            damage.ThrowIfLessThanOrEqualsToZeroException();
            
            if (_protection > 0 && _protection - damage >= 0)
            {
                _protection -= damage;
                _view.Visualize(_protection);
                return;
            }

            if(_protection > 0)
                damage -= _protection;

            _health.TakeDamage(damage);
        }

        public void Heal(int value)
        {
            throw new InvalidOperationException($"Can't heal armor!");
        }
    }
}