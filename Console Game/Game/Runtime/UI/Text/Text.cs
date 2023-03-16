using System;

namespace Console_Game.UI
{
    public sealed class Text : IText
    {
        public void Visualize(string text)
        {
            Console.WriteLine(text);
        }
    }
}