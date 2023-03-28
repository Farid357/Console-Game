namespace ConsoleGame
{
    public sealed class EffectFactory : IEffectFactory
    {
        public IEffect Create(ITransform transform)
        {
            return new FakeEffect(transform);
        }
    }
}