using System;

namespace ConsoleGame.Rendering
{
    public sealed class Mesh : IMesh
    {
        public Mesh(IMeshData data)
        {
            Data = data ?? throw new ArgumentNullException(nameof(data));
        }

        public bool IsAlive { get; private set; } = true;

        public IMeshData Data { get; }

        public void Destroy()
        {
            if (!IsAlive)
                throw new Exception($"Mesh is already destroyed!");

            IsAlive = false;
        }
    }
}