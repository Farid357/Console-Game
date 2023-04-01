namespace ConsoleGame.Bonus
{
    public interface IBonusFactory
    {
        IBonus Create(IReadOnlyTransform transform);
    }
}