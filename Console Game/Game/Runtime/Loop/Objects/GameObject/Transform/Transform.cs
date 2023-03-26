using System;
using System.Numerics;

namespace ConsoleGame
{
    public sealed class Transform : ITransform
    {
        public Transform(Vector2 position, Quaternion rotation)
        {
            Position = position;
            Rotation = rotation;
        }

        public Transform(Vector2 position) : this(position, Quaternion.Identity)
        {
        }

        public Transform(Quaternion rotation) : this(Vector2.Zero, rotation)
        {
        }

        public Transform() : this(Vector2.Zero, Quaternion.Identity)
        {
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