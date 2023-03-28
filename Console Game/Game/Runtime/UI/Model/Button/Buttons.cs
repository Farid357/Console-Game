using System;
using System.Collections.Generic;

namespace ConsoleGame.UI
{
    public sealed class Buttons : IButtons
    {
        private readonly List<IButton> _buttons;

        public Buttons(List<IButton> buttons)
        {
            _buttons = buttons ?? throw new ArgumentNullException(nameof(buttons));
        }

        public Buttons() : this(new List<IButton>())
        {
        }

        
        public bool IsEnabled { get; private set; }

        public void Press()
        {
            _buttons.ForEach(button => button.Press());
        }

        public void Enable()
        {
            _buttons.ForEach(button => button.Enable());
            IsEnabled = true;
        }

        public void Disable()
        {
            _buttons.ForEach(button => button.Disable());
            IsEnabled = false;
        }


        public void Add(IButton instance) => _buttons.Add(instance);

        public void Remove(IButton instance) => _buttons.Remove(instance);
        
    }
}