using System.Drawing;

namespace ConsoleGame.UI
{
    public interface ITextFactory
    {
        IText Create(ITransform transform, Font font, Color color);
    }
}