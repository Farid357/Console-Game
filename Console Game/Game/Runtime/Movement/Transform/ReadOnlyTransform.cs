using System.Numerics;

namespace Console_Game
{
    public sealed class ReadOnlyTransform : IReadOnlyTransform
    {
        public ReadOnlyTransform(Vector2 position, Quaternion rotation)
        {
            Position = position;
            Rotation = rotation;
        }

        public ReadOnlyTransform(Quaternion rotation) : this(Vector2.Zero, rotation)
        {
            
        }

        public ReadOnlyTransform(Vector2 position) : this(position, Quaternion.Identity)
        {
            
        }
        
        public ReadOnlyTransform() : this(Vector2.Zero, Quaternion.Identity)
        {
            
        }
        public Vector2 Position { get; }
        
        public Quaternion Rotation { get; }
    }
}