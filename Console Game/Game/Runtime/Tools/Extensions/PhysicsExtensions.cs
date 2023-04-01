using System.Numerics;
using ConsoleGame.Physics;

namespace ConsoleGame.Tools
{
    public static class PhysicsExtensions
    {
        public static RaycastHit<TTarget> Throw<TTarget>(this IRaycast<TTarget> raycast, Vector2 origin, Vector2 direction)
        {
            return raycast.Throw(origin.To3D(), direction.To3D());
        }
    }
}