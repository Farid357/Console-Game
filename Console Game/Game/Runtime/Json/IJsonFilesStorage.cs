using System.Threading.Tasks;
using Console_Game.Save_Storages.Paths;

namespace Console_Game.Json
{
    public interface IJsonFilesStorage
    {
        bool ContainsFile(IPath path);
        
        TFile LoadFile<TFile>(IPath path);

        ValueTask<TFile> LoadFileAsync<TFile>(IPath path);
    }
}