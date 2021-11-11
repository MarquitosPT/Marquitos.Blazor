using Marquitos.AspNetCore.Components.Events;
using Microsoft.AspNetCore.Components;
using Microsoft.JSInterop;
using System;
using System.Drawing;
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

        private async Task HandleWindowResizeAsync(ResizeArgs e)
        {
            OnWindowResize.Invoke(this, e);

            await Task.CompletedTask;
        }

        public EventHandler<ResizeArgs> OnWindowResize { get; set; }

        public async ValueTask InitializeAsync()
        {
            if (!moduleTask.IsValueCreated)
            {
                var module = await moduleTask.Value;
                await module.InvokeVoidAsync("Utils.initialize", DotNetObjectReference.Create(new JSCallbackAction<ResizeArgs>(HandleWindowResizeAsync)));
            }
        }

        public async ValueTask DisposeAsync()
        {
            if (moduleTask.IsValueCreated)
            {
                var module = await moduleTask.Value;

                await module.InvokeVoidAsync("Utils.finalize");
                await module.DisposeAsync();
            }
        }

        public async ValueTask ClickAsync(ElementReference element)
        {
            var module = await moduleTask.Value;
            await module.InvokeVoidAsync("Utils.click", element);
        }

        public async ValueTask FocusAsync(ElementReference element)
        {
            var module = await moduleTask.Value;
            await module.InvokeVoidAsync("Utils.focus", element);
        }

        public async ValueTask<int> GetWindowWidthAsync()
        {
            var module = await moduleTask.Value;
            return await module.InvokeAsync<int>("Utils.getWindowWidth");
        }

        public async ValueTask<int> GetWindowHeightAsync()
        {
            var module = await moduleTask.Value;
            return await module.InvokeAsync<int>("Utils.getWindowHeight");
        }

        public async ValueTask<int> GetWidthAsync(ElementReference element)
        {
            var module = await moduleTask.Value;
            return await module.InvokeAsync<int>("Utils.getWidth", element);
        }

        public async ValueTask<int> GetHeightAsync(ElementReference element)
        {
            var module = await moduleTask.Value;
            return await module.InvokeAsync<int>("Utils.getHeight", element);
        }

        public async ValueTask<string> GetPropertyAsync(ElementReference element, string name)
        {
            var module = await moduleTask.Value;
            return await module.InvokeAsync<string>("Utils.getProperty", element, name);
        }

        public async ValueTask<Size> GetSizeAsync(ElementReference element)
        {
            var module = await moduleTask.Value;
            return await module.InvokeAsync<Size>("Utils.getSize", element);
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
