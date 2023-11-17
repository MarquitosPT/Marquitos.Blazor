using Microsoft.AspNetCore.Components;
using System.Threading.Tasks;

namespace Marquitos.AspNetCore.Components.JSInterop
{
    public interface IJSFile
    {
        ValueTask InitializeAsync();
        ValueTask<string> LoadAsync(string fileName);
        ValueTask<MarkupString> LoadMarkupStringAsync(string fileName);
    }
}
