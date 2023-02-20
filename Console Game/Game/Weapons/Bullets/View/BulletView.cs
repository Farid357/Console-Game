using System;
using System.Numerics;

namespace Console_Game.Weapons
{
    public sealed class BulletView : IBulletView
    {
        public void VisualizePosition(Vector2 position)
        {
            Console.WriteLine(position);
        }
    }
}