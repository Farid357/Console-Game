using System;
using System.Collections.Generic;
using System.Linq;
using Console_Game;
using Console_Game.Loop;

namespace Console_Game.UI
{
    public sealed class Texts : IText, IGroup<IText>
    {
        private readonly IGroup<IText> _group;

        public Texts(IGroup<IText> group)
        {
            _group = group ?? throw new ArgumentNullException(nameof(group));
        }
        
        public Texts() : this(new Group<IText>())
        {
        }
        
        public IReadOnlyList<IText> All => _group.All;

        public bool IsEnabled => All.First().IsEnabled;
        
        public string Value { get; private set; }

        public void Visualize(string value)
        {
            Value = value;
            All.ToList().ForEach(text => text.Visualize(Value));
        }

        public void Add(IText instance) => _group.Add(instance);

        public void Remove(IText instance) => _group.Remove(instance);

        public void Enable()
        {
            All.ToList().ForEach(text => text.Enable());
        }

        public void Disable()
        {
            All.ToList().ForEach(text => text.Disable());
        }
    }
}