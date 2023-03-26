using System;

namespace ConsoleGame
{
    public sealed class GamePauseView : IGamePauseView
    {
        public void Enable()
        {
            Console.WriteLine("Game is paused!");
        }

        public void Disable()
        {
            Console.WriteLine("Game is not paused");
        }
    }
}