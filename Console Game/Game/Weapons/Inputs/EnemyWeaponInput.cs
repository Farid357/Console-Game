using System;

namespace Console_Game
{
    public sealed class EnemyWeaponInput : IWeaponInput, IUpdateable
    {
        private readonly ITimer _cooldownTimer;

        public EnemyWeaponInput(ITimer cooldownTimer)
        {
            _cooldownTimer = cooldownTimer ?? throw new ArgumentNullException(nameof(cooldownTimer));
        }

        public bool IsUsing => _cooldownTimer.FinishedCountdown;

        public void Update(float deltaTime)
        {
            if (IsUsing)
                _cooldownTimer.Play();
        }
    }
}