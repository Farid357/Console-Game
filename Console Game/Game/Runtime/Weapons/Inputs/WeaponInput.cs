using System;

namespace Console_Game
{
    public sealed class WeaponInput : IWeaponInput
    {
        private readonly IKey _key;

        public WeaponInput(IKey key)
        {
            _key = key ?? throw new ArgumentNullException(nameof(key));
        }

        public bool IsUsing => _key.IsPressed();
    }
}