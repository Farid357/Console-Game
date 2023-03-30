namespace ConsoleGame
{
    public interface IReadOnlyShooter<out TWeapon>
    {
        TWeapon Weapon { get; }
    }
}