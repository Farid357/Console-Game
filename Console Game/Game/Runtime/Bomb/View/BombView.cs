using System;

namespace ConsoleGame
{
    public sealed class BombView : IBombView
    {
        private readonly IEffectFactory _effectFactory;
        private readonly ITransform _transform;

        public BombView(IEffectFactory effectFactory, ITransform transform)
        {
            _effectFactory = effectFactory ?? throw new ArgumentNullException(nameof(effectFactory));
            _transform = transform ?? throw new ArgumentNullException(nameof(transform));
        }
        
        public bool IsActive { get; private set; }

        public void BlowUp()
        {
            IEffect effect = _effectFactory.Create(_transform);
            effect.Play();
        }

        public void Enable()
        {
            IsActive = true;
        }

        public void Disable()
        {
            IsActive = false;
        }
    }
}