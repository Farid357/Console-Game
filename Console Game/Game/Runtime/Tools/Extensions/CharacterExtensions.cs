using ConsoleGame.Tests;

namespace ConsoleGame.Tools
{
    public static class CharacterExtensions
    {
        private static readonly IWeapon _fakeWeapon = new DummyWeapon();

        public static IWeaponPartsData WeaponData(this ICharacter character)
        {
            return character.SelectedWeaponItem.WeaponPartsData;
        }

        public static bool IsDied(this IReadOnlyGameObject gameObject)
        {
            return !gameObject.IsAlive;
        }
    }
}