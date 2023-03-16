using System;
using System.Collections.Generic;
using Console_Game.Group;
using Console_Game.Loop;

namespace Console_Game.Shop
{
    public sealed class Buttons : IButton, IGroup<IButton>
    {
        private readonly IGroup<IButton> _group;

        public Buttons(IGroup<IButton> group)
        {
            _group = group ?? throw new ArgumentNullException(nameof(group));
        }

        public Buttons() : this(new Group<IButton>())
        {
        }
        
        public IReadOnlyList<IButton> All => _group.All;

        public void Press()
        {
            foreach (IButton button in All)
            {
                button.Press();
            }
        }

        public void Add(IButton instance) => _group.Add(instance);

        public void Remove(IButton instance) => _group.Remove(instance);
        
    }
}