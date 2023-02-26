using System;
using System.Numerics;

namespace Console_Game
{
    public sealed class TransformView : ITransformView
    {
        public void Teleport(Vector2 position)
        {
            Console.WriteLine($"Position: {position}");
        }

        public void Rotate(Quaternion rotation)
        {
            Console.WriteLine($"Rotation: {rotation}");
        }
    }
}