using System.Numerics;

namespace ConsoleGame
{
    public interface IPlayerInput
    {
        bool IsUsing { get; }

        Vector3 Direction();
    }
}