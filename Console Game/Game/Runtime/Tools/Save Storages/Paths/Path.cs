using System;

namespace ConsoleGame.Save_Storages.Paths
{
    public sealed class Path : IPath
    {
        public Path(string name)
        {
            if (name == null) 
                throw new ArgumentNullException(nameof(name));

            Name = $@"D:\{name}.json";
        }

        public string Name { get; }
    }
}