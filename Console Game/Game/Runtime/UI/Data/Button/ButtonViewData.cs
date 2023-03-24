using System;
using System.Drawing;

namespace Console_Game.UI
{
    [Serializable]
    public struct ButtonViewData : IButtonViewData
    {
        public ButtonViewData(Color startColor, Color disableColor, Color pressedColor)
        {
            StartColor = startColor;
            DisabledColor = disableColor;
            PressedColor = pressedColor;
        }

        public Color StartColor { get; private set; }
        
        public Color DisabledColor { get; }
        
        public Color PressedColor { get; }
    }
}