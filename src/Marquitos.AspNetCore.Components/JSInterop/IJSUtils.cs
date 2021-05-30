using Marquitos.AspNetCore.Components.Events;
using Microsoft.AspNetCore.Components;
using System;
using System.Drawing;
using System.Threading.Tasks;

namespace Marquitos.AspNetCore.Components.JSInterop
{
    public interface IJSUtils
    {
        ValueTask InitializeAsync();
        ValueTask<int> GetWindowWidthAsync();
        ValueTask<int> GetWindowHeightAsync();
        ValueTask<int> GetWidthAsync(ElementReference element);
        ValueTask<int> GetHeightAsync(ElementReference element);
        ValueTask<string> GetPropertyAsync(ElementReference element, string name);
        ValueTask<Size> GetSizeAsync(ElementReference element);

        ValueTask ResizeAsync(ElementReference element, string width, string height);
        ValueTask SetWidthAsync(ElementReference element, string width);
        ValueTask SetHeightAsync(ElementReference element, string height);

        ValueTask SetPropertyAsync(ElementReference element, string name, string value);

        EventHandler<ResizeArgs> OnWindowResize { get; set; }
    }
}
