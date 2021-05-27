using Microsoft.AspNetCore.Components;
using Microsoft.JSInterop;
using System;
using System.Threading.Tasks;

namespace Marquitos.AspNetCore.Components.JSInterop
{
    public class JSFile : IJSFile, IAsyncDisposable
    {
        private readonly Lazy<Task<IJSObjectReference>> moduleTask;

        public JSFile(IJSRuntime jsRuntime)
        {
            moduleTask = new(() => jsRuntime.InvokeAsync<IJSObjectReference>(
               "import", "./_content/Marquitos.AspNetCore.Components/js/file.min.js").AsTask());
        }

        public async ValueTask InitializeAsync()
        {
            if (!moduleTask.IsValueCreated)
            {
                await moduleTask.Value;
            }
        }

        public async ValueTask<string> LoadAsync(string fileName)
        {
            if (string.IsNullOrWhiteSpace(fileName))
            {
                return default;
            }

            try
            {
                var module = await moduleTask.Value;
                return await module.InvokeAsync<string>("File.load", fileName);
            }
            catch (Exception)
            {
                return default;
            }
        }

        public async ValueTask<MarkupString> LoadMarkupStringAsync(string fileName)
        {
            if (string.IsNullOrWhiteSpace(fileName))
            {
                return default;
            }

            try
            {
                var module = await moduleTask.Value;
                var result = await module.InvokeAsync<string>("File.load", fileName);

                return new MarkupString(result);
            }
            catch (Exception)
            {
                return default;
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

    }
}
