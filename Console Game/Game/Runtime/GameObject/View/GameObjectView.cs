using System;

namespace Console_Game
{
    public sealed class GameObjectView : IGameObjectView
    {
        public void Destroy()
        {
            Console.WriteLine("Game Object Destroyed!");
        }

        public void Enable()
        {
            Console.WriteLine("Game Object Enabled!");
        }

        public void Disable()
        {
            Console.WriteLine("Game Object Disabled!");
        }
    }
}