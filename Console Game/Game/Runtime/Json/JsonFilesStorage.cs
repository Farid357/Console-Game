using System;
using System.IO;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using Console_Game.Save_Storages.Paths;
using Newtonsoft.Json;
using JsonSerializer = System.Text.Json.JsonSerializer;

namespace Console_Game.Json
{
    public sealed class JsonFilesStorage : IJsonFilesStorage
    {
        public bool ContainsFile(IPath path) => true;

        public TFile LoadFile<TFile>(IPath path)
        {
            if (ContainsFile(path) == false)
                throw new InvalidOperationException($"Storage doesn't contain file with path {path.Name}");

            string text = File.ReadAllText(path.Name);
            return JsonConvert.DeserializeObject<TFile>(text);
        }

        public ValueTask<TFile> LoadFileAsync<TFile>(IPath path)
        {
            if (ContainsFile(path) == false)
                throw new InvalidOperationException($"Storage doesn't contain file with path {path.Name}");

            using (var fileStream = new FileStream(path.Name, FileMode.Open))
                return JsonSerializer.DeserializeAsync<TFile>(fileStream);
        }
    }
}