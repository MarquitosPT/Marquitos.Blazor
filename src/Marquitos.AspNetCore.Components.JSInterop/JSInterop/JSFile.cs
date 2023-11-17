using Marquitos.AspNetCore.Components.JSInterop.Extensions.Configuration.Options;
using Microsoft.AspNetCore.Components;
using Microsoft.Extensions.Options;
using Microsoft.JSInterop;
using System;
using System.Threading.Tasks;

namespace Marquitos.AspNetCore.Components.JSInterop
{
    public class JSFile : IJSFile, IAsyncDisposable
    {
        private readonly JSInteropOptions _options;
        private readonly Lazy<Task<IJSObjectReference>> moduleTask;

        public JSFile(IOptions<JSInteropOptions> options, IJSRuntime jsRuntime)
        {
            _options = options.Value;

            var baseStr = _options.Framework == Enums.FrameworkType.WebAssembly ? "./" : "";

            moduleTask = new(() => jsRuntime.InvokeAsync<IJSObjectReference>(
               "import", baseStr + "_content/Marquitos.AspNetCore.Components.JSInterop/js/file.min.js").AsTask());
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

        public async ValueTask DownloadFileFromStreamAsync(string fileName, DotNetStreamReference dotNetStreamReference)
        {
            if (string.IsNullOrWhiteSpace(fileName) || dotNetStreamReference == null)
            {
                return;
            }

            try
            {
                var module = await moduleTask.Value;            
                await module.InvokeAsync<string>("File.downloadFileFromStream", fileName, dotNetStreamReference);
            }
            catch (Exception)
            {
                return;
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
