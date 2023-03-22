using System.Numerics;

namespace Console_Game.Physics
{
    public struct Box
    {
        public Box(Vector3 size)
        {
            Size = size;
        }

        public Vector3 Size { get; }

    }
}