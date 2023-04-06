using System;
using ConsoleGame.Tools;

namespace ConsoleGame
{
    public sealed class HealthFactory : IHealthFactory
    {
        private readonly IHealthViewFactory _viewFactory;
        private readonly int _value;

        public HealthFactory(IHealthViewFactory viewFactory, int value)
        {
            _viewFactory = viewFactory ?? throw new ArgumentNullException(nameof(viewFactory));
            _value = value.ThrowIfLessThanZeroException();
        }

        public IHealth Create()
        {
            IHealthView view = _viewFactory.Create();
            view.Visualize(_value, _value);
            return new Health(view, _value);
        }
    }
}