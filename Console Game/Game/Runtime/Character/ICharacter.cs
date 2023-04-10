using System.Numerics;

namespace ConsoleGame
{
    public interface ICharacter : IReadOnlyCharacter
    {
        void Move(Vector3 direction);

        void Shoot();
    }
}