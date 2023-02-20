using System;
using Console_Game.Tools.Extensions;

namespace Console_Game
{
    public sealed class EnemyWithWeapon : IUpdateable
    {
        private readonly IWeapon _weapon;
        private readonly IWeaponInput _weaponInput;

        public EnemyWithWeapon(IWeapon weapon, IWeaponInput weaponInput)
        {
            _weapon = weapon ?? throw new ArgumentNullException(nameof(weapon));
            _weaponInput = weaponInput ?? throw new ArgumentNullException(nameof(weaponInput));
        }

        public void Update(float deltaTime)
        {
            if (_weaponInput.IsUsing && _weapon.CanShoot)
                _weapon.Shoot();
        }
    }

    public interface IHealth
    {
        int Value { get; }

        bool IsAlive { get; }
        
        bool IsDied { get; }

        void TakeDamage(int damage);

        void Heal(int value);
    }

    public sealed class Health : IHealth
    {
        private readonly IHealthView _view;

        public Health(IHealthView view, int value)
        {
            _view = view ?? throw new ArgumentNullException(nameof(view));
            Value = value.ThrowIfLessThanOrEqualsToZeroException();
        }

        public int Value { get; private set; }

        public bool IsAlive => Value > 0;

        public bool IsDied => Value == 0;

        public void TakeDamage(int damage)
        {
            if (IsDied)
                throw new InvalidOperationException($"Health can't take damage! It's not alive!");

            Value = Math.Min(0, Value - damage.ThrowIfLessThanOrEqualsToZeroException());
            _view.Visualize(Value);

            if (IsDied)
                _view.VisualizeDeath();
        }

        public void Heal(int value)
        {
            Value += value.ThrowIfLessThanOrEqualsToZeroException();
        }
    }
    
    public interface IHealthView
    {
        void Visualize(int value);

        void VisualizeDeath();
    }

    public sealed class HealthView : IHealthView
    {
        public void Visualize(int value)
        {
            Console.WriteLine($"Health: {value}");
        }

        public void VisualizeDeath()
        {
            Console.WriteLine($"I'm died!");
        }
    }
}