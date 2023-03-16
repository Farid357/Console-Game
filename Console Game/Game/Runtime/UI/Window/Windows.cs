using System;
using System.Collections.Generic;
using Console_Game.Group;
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

        public void Open()
        {
            foreach (IWindow window in All)
            {
                window.Open();
            }

            IsOpen = true;
        }

        public void Close()
        {
            foreach (IWindow window in All)
            {
                window.Close();
            }

            IsOpen = false;
        }
        
        public void Add(IWindow instance) => _group.Add(instance);

        public void Remove(IWindow instance) => _group.Remove(instance);
    }
}