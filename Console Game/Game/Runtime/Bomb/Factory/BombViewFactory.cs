using System;

namespace ConsoleGame
{
    public sealed class BombViewFactory : IBombViewFactory
    {
        private readonly IEffectFactory _effectFactory;

        public BombViewFactory(IEffectFactory effectFactory)
        {
            _effectFactory = effectFactory ?? throw new ArgumentNullException(nameof(effectFactory));
        }

        public IBombView Create(ITransform transform)
        {
            return new BombView(_effectFactory, transform);
        }
    }
}