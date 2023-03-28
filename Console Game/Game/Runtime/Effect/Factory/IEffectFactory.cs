namespace ConsoleGame
{
    public interface IEffectFactory
    {
        IEffect Create(ITransform transform);
    }
}