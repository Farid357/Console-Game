using System;
using System.Numerics;
using ConsoleGame.Tools;

namespace ConsoleGame
{
    public sealed class Transform : ITransform
    {
        public Transform(Vector3 position, Quaternion rotation)
        {
            Position = position;
            Rotation = rotation;
        }

        public Transform(Vector3 position) : this(position, Quaternion.Identity)
        {
        }

        public Transform(Vector2 position) : this(position.To3D())
        {
            
        }
        public Transform(Quaternion rotation) : this(Vector3.Zero, rotation)
        {
        }

        public Transform() : this(Vector3.Zero, Quaternion.Identity)
        {
        }

        public Vector3 Position { get; private set; }
        
        public Quaternion Rotation { get; private set; }
        
        public void Teleport(Vector3 position)
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