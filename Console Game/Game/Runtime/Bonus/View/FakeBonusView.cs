using System;

namespace ConsoleGame.Bonus
{
    public sealed class FakeBonusView : IBonusView
    {
        public void Destroy()
        {
            Console.WriteLine($"Bonus is destroyed!");
        }
    }
}