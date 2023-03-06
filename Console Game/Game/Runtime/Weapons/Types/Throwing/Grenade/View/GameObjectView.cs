using System;

namespace Console_Game
{
    public sealed class GameObjectView : IGameObjectView
    {
        public void Destroy()
        {
            Console.WriteLine("Game Object Destroyed!");
        }
    }
}