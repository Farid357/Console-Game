using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;

namespace ConsoleGame.UI
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

        public ITransform Transform { get; } = new Transform();

        public bool IsEnabled => _texts.First().IsEnabled;

        public Color Color => _texts.First().Color;

        public string Line { get; private set; }

        public void Visualize(string line)
        {
            Line = line;
            _texts.ForEach(text => text.Visualize(Line));
        }

        public void SwitchColor(Color color)
        {
            _texts.ForEach(text => text.SwitchColor(color));
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