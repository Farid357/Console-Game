namespace ConsoleGame.SaveSystem
{
    public static class Paths
    {
        public static IPath CharacterMovementSpeed { get; }
        
        public static IPath CharacterMaxHealthCount { get; }

        static Paths()
        {
            CharacterMovementSpeed = new Path(nameof(ICharacter) + nameof(IAdjustableMovement));
            CharacterMaxHealthCount = new Path(nameof(ICharacter) + nameof(IHealth));
        }

    }
}