using System.Numerics;

namespace ConsoleGame
{
    public interface IPlayerInput
    {
        bool IsMoving { get; }
        Vector3 MoveDirection();

        bool IsReloading { get; }
       
        bool IsShooting { get; }

        bool IsShootingBurst { get; }

    }
}