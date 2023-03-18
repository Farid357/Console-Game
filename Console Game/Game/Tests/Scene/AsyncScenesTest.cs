using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Console_Game.LoadSystem;
using NUnit.Framework;

namespace Console_Game.Tests
{
    [TestFixture]
    public sealed class AsyncScenesTest
    {
        [Test]
        public async Task LoadsRealCorrectly()
        {
            IAsyncScene scene = new AsyncScene(new LoadSystem.Scene());
            IAsyncScenes asyncScenes = new AsyncScenes(new List<IAsyncScene>{scene, scene});
            asyncScenes.Load();
            await Task.Delay(TimeSpan.FromSeconds(0.3f));
            Assert.That(asyncScenes.IsLoaded);
            Assert.That((int)asyncScenes.LoadingProgress == 1);

        }
    }
}