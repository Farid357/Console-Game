using System.Numerics;

namespace ConsoleGame.Physics
{
    public interface IRigidbody : IReadOnlyTransform
    {
        float Mass { get; }
        
        float Gravity { get; }
        
        float MoveSpeed { get; }

        void AddForce(Vector3 direction, float force);
    }
}