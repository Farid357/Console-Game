using System;

namespace Console_Game.UI
{
    public sealed class Text : IText
    {
        public string Value { get; private set; }

        public void Visualize(string value)
        {
            Value = value;
            Console.WriteLine(value);
        }
    }
}