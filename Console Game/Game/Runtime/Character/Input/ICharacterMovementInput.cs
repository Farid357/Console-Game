using System.Numerics;

namespace ConsoleGame
{
    public interface ICharacterMovementInput
    {
        bool IsUsing { get; }

        Vector3 Direction();
    }
}