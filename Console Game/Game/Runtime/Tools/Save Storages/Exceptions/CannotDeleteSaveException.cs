using System;

namespace Console_Game
{
    [Serializable]
    public sealed class CannotDeleteSaveException : Exception
    {
        public CannotDeleteSaveException(string message, string pathName) : base($"Hasn't save for {message} with path: {pathName}. You can't delete save!")
        {
          
        }
    }
}