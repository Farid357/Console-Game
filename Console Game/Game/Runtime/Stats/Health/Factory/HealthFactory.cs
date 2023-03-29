using System;

namespace ConsoleGame
{
    public sealed class HealthFactory : IHealthFactory
    {
        private readonly IHealthViewFactory _viewFactory;
        private readonly int _value;

        public HealthFactory(IHealthViewFactory viewFactory, int value)
        {
            _viewFactory = viewFactory ?? throw new ArgumentNullException(nameof(viewFactory));
            _value = value;
        }

        public IHealth Create()
        {
            return new Health(_viewFactory.Create(), _value);
        }
    }
}