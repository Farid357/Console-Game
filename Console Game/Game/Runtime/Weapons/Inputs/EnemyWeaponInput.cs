using System;

namespace Console_Game
{
    public sealed class EnemyWeaponInput : IWeaponInput
    {
        private readonly ITimer _cooldownTimer;

        public EnemyWeaponInput(ITimer cooldownTimer)
        {
            _cooldownTimer = cooldownTimer ?? throw new ArgumentNullException(nameof(cooldownTimer));
        }

        public bool IsUsing => _cooldownTimer.IsEnded;
    }
}