using System;
using System.Numerics;

namespace Console_Game
{
    public sealed class Transform : ITransform
    {
        public Transform(IReadOnlyTransform transform)
        {
            Position = transform.Position;
            Rotation = transform.Rotation;
        }

        public Vector2 Position { get; private set; }
        
        public Quaternion Rotation { get; private set; }
        
        public void Teleport(Vector2 position)
        {
            if (Position == position)
                throw new ArgumentOutOfRangeException($"Transform already in {position}");
            
            Position = position;
        }

        public void Rotate(Quaternion rotation)
        {
            if (Rotation == rotation)
                throw new ArgumentOutOfRangeException($"Transform already in {rotation}");

            Rotation = rotation;
        }
    }
}