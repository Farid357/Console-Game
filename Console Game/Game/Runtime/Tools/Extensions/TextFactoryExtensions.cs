using System.Drawing;
using System.Numerics;
using ConsoleGame.UI;

namespace ConsoleGame.Tools
{
    public static class TextFactoryExtensions
    {
        private static readonly Font _standardFont;

        static TextFactoryExtensions()
        {
            _standardFont = new Font("Arial", 14);
        }

        public static IText Create(this ITextFactory textFactory, ITransform transform, Font font)
        {
            return textFactory.Create(transform, font, Color.Azure);
        }

        public static IText Create(this ITextFactory textFactory, Vector2 position, Font font, Color color)
        {
            return textFactory.Create(new Transform(position), font, color);
        }
        
        public static IText Create(this ITextFactory textFactory, Vector2 position)
        {
            return textFactory.Create(new Transform(position), _standardFont, Color.Azure);
        }
        
        public static IText Create(this ITextFactory textFactory, Vector2 position, Font font)
        {
            return Create(textFactory, new Transform(position), font);
        }
    }
}