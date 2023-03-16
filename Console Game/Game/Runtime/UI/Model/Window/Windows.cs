using System;
using System.Collections.Generic;
using System.Linq;
using Console_Game;
using Console_Game.Loop;

namespace Console_Game.UI
{
    public sealed class Windows : IWindow, IGroup<IWindow>
    {
        private readonly IGroup<IWindow> _group;

        public Windows(IGroup<IWindow> group)
        {
            _group = group ?? throw new ArgumentNullException(nameof(group));
        }

        public Windows() : this(new Group<IWindow>())
        {
        }

        public IReadOnlyList<IWindow> All => _group.All;

        public bool IsOpen { get; private set; }
        
        public bool IsEnabled => IsOpen;

        public void Open()
        {
            All.ToList().ForEach(window => window.Open());
            IsOpen = true;
        }

        public void Close()
        {
            All.ToList().ForEach(window => window.Close());
            IsOpen = false;
        }
        
        public void Add(IWindow instance) => _group.Add(instance);

        public void Remove(IWindow instance) => _group.Remove(instance);
        
        public void Enable() => Open();

        public void Disable() => Close();
        
    }
}