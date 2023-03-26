using System.Drawing;

namespace ConsoleGame.Tools
{
    public static class BitmapExtensions
    {
        public static void SwitchColor(this Bitmap bitmap, Color newColor)
        {
            for (var x = 0; x < bitmap.Width; x++)
            {
                for (var y = 0; y < bitmap.Height; y++)
                {
                    Color actualColor = bitmap.GetPixel(x, y);
                    bitmap.SetPixel(x, y, actualColor.A > 150 ? newColor : actualColor);
                }
            }
        }
    }
}