using System.Numerics;
using ConsoleGame.Physics;

namespace ConsoleGame.Tools
{
    public static class PhysicsExtensions
    {
        public static void Throw<TTarget>(this IRaycast<TTarget> raycast, Vector2 origin, Vector2 direction)
        {
            raycast.Throw(origin.To3D(), direction.To3D());
        }

        public static TTarget HitTarget<TTarget>(this IRaycast<TTarget> raycast)
        {
            return raycast.Hit().Target;
        }
    }
}