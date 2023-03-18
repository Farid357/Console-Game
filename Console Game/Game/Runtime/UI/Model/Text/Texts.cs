using System;
using System.Collections.Generic;
using System.Linq;

namespace Console_Game.UI
{
    public sealed class Texts : ITexts
    {
        private readonly List<IText> _texts;

        public Texts(List<IText> texts)
        {
            _texts = texts ?? throw new ArgumentNullException(nameof(texts));
        }

        public Texts() : this(new List<IText>())
        {
        }

        public bool IsEnabled => _texts.First().IsEnabled;

        public IReadOnlyList<IText> All => _texts;
        
        public string Value { get; private set; }

        public void Visualize(string line)
        {
            Value = line;
            _texts.ForEach(text => text.Visualize(Value));
        }

        public void Add(IText instance) => _texts.Add(instance);

        public void Remove(IText instance) => _texts.Remove(instance);

        public void Enable()
        {
            _texts.ForEach(text => text.Enable());
        }

        public void Disable()
        {
            _texts.ForEach(text => text.Disable());
        }
    }
}