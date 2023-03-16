using System;
using System.Drawing;

namespace Console_Game.UI
{
    [Serializable]
    public struct ButtonViewData
    {
        public ButtonViewData(Color startColor, Color disableColor, Color pressedColor)
        {
            StartColor = startColor;
            DisableColor = disableColor;
            PressedColor = pressedColor;
        }

        public Color StartColor { get; private set; }
        
        public Color DisableColor { get; }
        
        public Color PressedColor { get; }
    }
}