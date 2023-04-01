using System.Numerics;

namespace ConsoleGame
{
    public interface ICharacter : IReadOnlyCharacter
    {
        void SwitchWeapon(IWeapon weapon);

        void Move(Vector3 direction);

        void Shoot();
    }
}