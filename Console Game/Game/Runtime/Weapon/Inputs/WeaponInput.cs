using System;

namespace ConsoleGame
{
    public sealed class WeaponInput : IWeaponInput
    {
        private readonly IKey _key;

        public WeaponInput(IKey key)
        {
            _key = key ?? throw new ArgumentNullException(nameof(key));
        }

        public WeaponInput() : this(new Key(ConsoleKey.P))
        {
            
        }

        public bool IsUsing => _key.IsPressed();
    }
}