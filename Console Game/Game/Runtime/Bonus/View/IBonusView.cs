using System;

namespace ConsoleGame.Bonus
{
    public interface IBonusView
    {
        void Destroy();
    }

    public sealed class FakeBonusView : IBonusView
    {
        public void Destroy()
        {
            Console.WriteLine($"Bonus is destroyed!");
        }
    }
}