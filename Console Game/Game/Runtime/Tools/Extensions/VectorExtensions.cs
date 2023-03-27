using System.Drawing;
using System.Numerics;

namespace ConsoleGame.Tools
{
    public static class VectorExtensions
    {
        public static Point ToPoint(this Vector3 vector)
        {
            return new Point((int)vector.X, (int)vector.Y);
        }

        public static Vector3 To3D(this Vector2 vector)
        {
            return new Vector3(vector.X, vector.Y, 0);
        }
        
        public static Vector2 To2D(this Vector3 vector)
        {
            return new Vector2(vector.X, vector.Y);
        }
    }
}