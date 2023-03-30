using System.Numerics;

namespace ConsoleGame
{
    public interface ICharacter : IReadOnlyGameObject, IReadOnlyCharacter
    {
        void SwitchWeapons(IWeapon firstWeapon, IWeapon secondWeapon);

        void Move(Vector3 direction);

        void Shoot();
    }
}