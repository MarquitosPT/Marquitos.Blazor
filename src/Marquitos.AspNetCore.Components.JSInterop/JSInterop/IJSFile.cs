using Microsoft.AspNetCore.Components;
using Microsoft.JSInterop;
using System.Threading.Tasks;

namespace Marquitos.AspNetCore.Components.JSInterop
{
    public interface IJSFile
    {
        ValueTask InitializeAsync();
        ValueTask<string> LoadAsync(string fileName);
        ValueTask<MarkupString> LoadMarkupStringAsync(string fileName);

        /// <summary>
        /// Downloads a file from a DotNetStreamReference
        /// </summary>
        /// <param name="fileName"></param>
        /// <param name="dotNetStreamReference"></param>
        /// <returns></returns>
        ValueTask DownloadFileFromStreamAsync(string fileName, DotNetStreamReference dotNetStreamReference);
    }
}
