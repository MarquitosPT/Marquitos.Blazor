using Marquitos.AspNetCore.Components.JSInterop.Extensions.Configuration.Options;
using Microsoft.Extensions.Options;
using Microsoft.JSInterop;
using System;
using System.Threading.Tasks;

namespace Marquitos.AspNetCore.Components.JSInterop
{
    public class JSNavigation : IJSNavigation, IAsyncDisposable
    {
        private readonly JSInteropOptions _options;
        private readonly Lazy<Task<IJSObjectReference>> moduleTask;

        public JSNavigation(IOptions<JSInteropOptions> options, IJSRuntime jsRuntime)
        {
            _options = options.Value;

            var baseStr = _options.Framework == Enums.FrameworkType.WebAssembly ? "./" : "";

            moduleTask = new(() => jsRuntime.InvokeAsync<IJSObjectReference>(
               "import", baseStr + "_content/Marquitos.AspNetCore.Components.JSInterop/js/navigation.min.js").AsTask());
        }

        public async ValueTask InitializeAsync()
        {
            if (!moduleTask.IsValueCreated)
            {
                var module = await moduleTask.Value;
                await module.InvokeVoidAsync("Navigation.initialize");
            }
        }

        public async ValueTask<bool> CanGoBackAsync()
        {
            var module = await moduleTask.Value;
            return await module.InvokeAsync<bool>("Navigation.canGoBack");
        }

        public async ValueTask BackAsync()
        {
            var module = await moduleTask.Value;
            await module.InvokeVoidAsync("Navigation.back");
        }

        public async ValueTask ForwardAsync()
        {
            var module = await moduleTask.Value;
            await module.InvokeVoidAsync("Navigation.forward");
        }

        public async ValueTask DisposeAsync()
        {
            if (moduleTask.IsValueCreated)
            {
                var module = await moduleTask.Value;
                await module.DisposeAsync();
            }
        }

    }
}
