using System;

namespace ConsoleGame
{
    public sealed class FakeEffect : IEffect
    {
        public FakeEffect(ITransform transform)
        {
            Transform = transform ?? throw new ArgumentNullException(nameof(transform));
        }

        public ITransform Transform { get; }
     
        public bool IsPlaying { get; }

        public void Play()
        {
            Console.WriteLine($"Effect played in point: {Transform.Position}");
        }

        public void Stop()
        {
            Console.WriteLine("Effect stopped!");
        }
    }
}