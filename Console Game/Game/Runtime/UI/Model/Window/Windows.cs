using System;
using System.Collections.Generic;

namespace ConsoleGame.UI
{
    public sealed class Windows : IWindow
    {
        private readonly List<IWindow> _windows;

        public Windows(List<IWindow> windows)
        {
            if (windows == null) 
                throw new ArgumentNullException(nameof(windows));
            
            _windows = windows ?? throw new ArgumentNullException(nameof(windows));
        }

        public bool IsOpen { get; private set; }

        public void Open()
        {
            _windows.ForEach(window => window.Open());
            IsOpen = true;
        }

        public void Close()
        {
            _windows.ForEach(window => window.Close());
            IsOpen = false;
        }
    }
}