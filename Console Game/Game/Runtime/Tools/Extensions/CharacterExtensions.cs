using ConsoleGame.Tests;

namespace ConsoleGame.Tools
{
    public static class CharacterExtensions
    {
        private static readonly IWeapon _fakeWeapon = new DummyWeapon();

        public static void TakeAwayWeapons(this ICharacter character)
        {
            character.SwitchWeapon(_fakeWeapon);
        }

        public static bool IsDied(this IReadOnlyGameObject gameObject)
        {
            return !gameObject.IsAlive;
        }
    }
}