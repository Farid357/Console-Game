using System;
using Console_Game.UI;

namespace Console_Game.Tools
{
    public static class TextExtensions
    {
        public static void Visualize(this IText text, int count)
        {
            text.Visualize(count.ToString());
        }
        
        public static void Visualize(this IText text, float count)
        {
            text.Visualize(count.ToString());
        }
        
        public static void Visualize(this IText text, float count, IFormatProvider formatProvider)
        {
            text.Visualize(count.ToString(formatProvider));
        }
        
        public static void Visualize(this IText text, int count, IFormatProvider formatProvider)
        {
            text.Visualize(count.ToString(formatProvider));
        }

        public static void Clear(this IText text)
        {
            text.Visualize(string.Empty);
        }
    }
}