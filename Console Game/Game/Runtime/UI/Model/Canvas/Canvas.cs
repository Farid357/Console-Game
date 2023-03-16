using System;
using System.Collections.Generic;
using Console_Game.Loop;

namespace Console_Game.UI
{
    public sealed class Canvas : ICanvas
    {
        private readonly IGroup<IUiElement> _group;

        public Canvas(IGroup<IUiElement> group)
        {
            _group = group ?? throw new ArgumentNullException(nameof(group));
        }

        public Canvas() : this(new Group<IUiElement>())
        {
            
        }
        
        public bool IsEnabled { get; private set; }
        
        public IReadOnlyList<IUiElement> All => _group.All;

        public void Add(IUiElement instance) => _group.Add(instance);

        public void Remove(IUiElement instance) => _group.Remove(instance);

        public void Enable()
        {
            IsEnabled = true;
            
            foreach (IUiElement uiElement in All)
            {
                uiElement.Enable();
            }
        }

        public void Disable()
        {
            IsEnabled = false;
            
            foreach (IUiElement uiElement in All)
            {
                uiElement.Disable();
            }
        }
    }
}