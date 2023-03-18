using System;

namespace Console_Game
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