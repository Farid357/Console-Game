using System.Numerics;

namespace ConsoleGame.Physics
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