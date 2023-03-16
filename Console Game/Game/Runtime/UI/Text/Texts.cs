using System;
using System.Collections.Generic;
using Console_Game.Group;
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

        public void Visualize(string text)
        {
            foreach (IText instance in All)
            {
                instance.Visualize(text);
            }
        }


        public void Add(IText instance) => _group.Add(instance);

        public void Remove(IText instance) => _group.Remove(instance);
        
    }
}