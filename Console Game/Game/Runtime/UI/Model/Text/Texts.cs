using System;
using System.Collections.Generic;

namespace ConsoleGame.UI
{
    public sealed class Texts : IOnlyVisualizeText
    {
        private readonly List<IText> _texts;

        public Texts(List<IText> texts)
        {
            if (texts.Count == 0)
                throw new ArgumentException("Value cannot be an empty collection.", nameof(texts));
            
            _texts = texts ?? throw new ArgumentNullException(nameof(texts));
        }
        
        public string Line { get; private set; }

        public void Visualize(string line)
        {
            Line = line;
            _texts.ForEach(text => text.Visualize(Line));
        }
    }
}