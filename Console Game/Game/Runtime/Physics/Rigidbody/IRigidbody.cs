using System.Numerics;

namespace Console_Game
{
    public interface IRigidbody : IReadOnlyTransform
    {
        float Mass { get; }
        
        float Gravity { get; }
        
        float MoveSpeed { get; }

        void AddForce(Vector3 direction, float force);
    }
}