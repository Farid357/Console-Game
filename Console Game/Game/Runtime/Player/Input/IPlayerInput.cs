using System.Numerics;

namespace ConsoleGame
{
    public interface IPlayerInput
    {
        bool IsMoving { get; }

        bool IsReloading { get; }
       
        bool IsShooting { get; }

        Vector3 Direction();
    }
}