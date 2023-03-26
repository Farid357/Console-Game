using System;
using System.Collections.Generic;

namespace ConsoleGame.UI
{
    public sealed class Windows : IWindows
    {
        private readonly List<IWindow> _windows;

        public Windows(List<IWindow> windows)
        {
            _windows = windows ?? throw new ArgumentNullException(nameof(windows));
        }

        public Windows() : this(new List<IWindow>())
        {
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

        public void Add(IWindow instance) => _windows.Add(instance);

        public void Remove(IWindow instance) => _windows.Remove(instance);
        
    }
}