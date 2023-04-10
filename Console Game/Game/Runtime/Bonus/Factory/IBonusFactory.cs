namespace ConsoleGame
{
    public interface IBonusFactory
    {
        IBonus Create(ITransform transform);
    }
}