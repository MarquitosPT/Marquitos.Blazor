using Microsoft.AspNetCore.Components;
using System.Threading.Tasks;

namespace Marquitos.AspNetCore.Components.JSInterop
{
    public interface IJSUtils
    {
        ValueTask InitializeAsync();
        ValueTask ResizeAsync(ElementReference element, string width, string height);
        ValueTask SetWidthAsync(ElementReference element, string width);
        ValueTask SetHeightAsync(ElementReference element, string height);

        ValueTask SetPropertyAsync(ElementReference element, string name, string value);
    }
}
