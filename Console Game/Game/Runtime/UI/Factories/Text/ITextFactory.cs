using System.Drawing;

namespace Console_Game.UI
{
    public interface ITextFactory
    {
        IText Create(ITransform transform, Font font, Color color);
    }
}