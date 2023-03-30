namespace ConsoleGame.SaveSystem
{
    public static class Paths
    {
        public static IPath CharacterMovementSpeed { get; }
        
        public static IPath CharacterHealthCount { get; }

        static Paths()
        {
            CharacterMovementSpeed = new Path(nameof(ICharacter) + nameof(IAdjustableMovement));
            CharacterHealthCount = new Path(nameof(ICharacter) + nameof(IHealth));
        }

    }
}