using System.Media;

namespace ConsoleGame.Audio
{
    public sealed class Sound : ISound
    {
        private readonly SoundPlayer _player;

        public Sound(string wavLocation)
        {
            _player = new SoundPlayer(wavLocation);
        }
        
        public bool IsPlaying => true;
        
        public void Play()
        {
            _player.PlaySync();
        }

        public void Stop()
        {
            _player.Stop();
        }
    }
}