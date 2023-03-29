using System;
using System.Collections.Generic;

namespace ConsoleGame.UI
{
    public sealed class Buttons : IPressOnlyButton
    {
        private readonly List<IButton> _buttons;

        public Buttons(List<IButton> buttons)
        {
            _buttons = buttons ?? throw new ArgumentNullException(nameof(buttons));
        }

        public void Press()
        {
            _buttons.ForEach(button => button.Press());
        }
    }
}