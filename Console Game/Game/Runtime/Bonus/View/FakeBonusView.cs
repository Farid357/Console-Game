using System;

namespace ConsoleGame
{
    public sealed class FakeBonusView : IBonusView
    {
        public void Destroy()
        {
            Console.WriteLine($"Bonus is destroyed!");
        }
    }
}