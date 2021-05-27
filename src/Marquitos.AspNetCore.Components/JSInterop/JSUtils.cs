using Microsoft.AspNetCore.Components;
using Microsoft.JSInterop;
using System;
using System.Threading.Tasks;

namespace Marquitos.AspNetCore.Components.JSInterop
{
    public class JSUtils : IJSUtils, IAsyncDisposable
    {
        private readonly Lazy<Task<IJSObjectReference>> moduleTask;

        public JSUtils(IJSRuntime jsRuntime)
        {
            moduleTask = new(() => jsRuntime.InvokeAsync<IJSObjectReference>(
               "import", "./_content/Marquitos.AspNetCore.Components/js/utils.min.js").AsTask());
        }

        public async ValueTask InitializeAsync()
        {
            if (!moduleTask.IsValueCreated)
            {
                await moduleTask.Value;
            }
        }

        public async ValueTask DisposeAsync()
        {
            if (moduleTask.IsValueCreated)
            {
                var module = await moduleTask.Value;
                await module.DisposeAsync();
            }
        }

        public async ValueTask ResizeAsync(ElementReference element, string width, string height)
        {
            var module = await moduleTask.Value;
            await module.InvokeVoidAsync("Utils.resize", element, width, height);
        }

        public async ValueTask SetHeightAsync(ElementReference element, string height)
        {
            var module = await moduleTask.Value;
            await module.InvokeVoidAsync("Utils.setHeight", element, height);
        }

        public async ValueTask SetWidthAsync(ElementReference element, string width)
        {
            var module = await moduleTask.Value;
            await module.InvokeVoidAsync("Utils.setWidth", element, width);
        }

        public async ValueTask SetPropertyAsync(ElementReference element, string name, string value)
        {
            var module = await moduleTask.Value;
            await module.InvokeVoidAsync("Utils.setProperty", element, name, value);
        }
    }
}
