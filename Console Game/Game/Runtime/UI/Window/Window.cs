using System;

namespace Console_Game.UI
{
    public sealed class Window : IWindow
    {
        public bool IsOpen { get; private set; }
        
        public void Open()
        {
            if (IsOpen)
                throw new InvalidOperationException($"Window is already open!");

            IsOpen = true;
            //open
        }

        public void Close()
        {
            if (IsOpen == false)
                throw new InvalidOperationException($"Window is already closed!");
            
            IsOpen = false;
            //TODO Window
        }
    }
}