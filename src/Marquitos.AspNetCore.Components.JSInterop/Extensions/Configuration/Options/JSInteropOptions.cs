using Marquitos.AspNetCore.Components.JSInterop.Enums;

namespace Marquitos.AspNetCore.Components.JSInterop.Extensions.Configuration.Options
{
    public class JSInteropOptions
    {
        public FrameworkType Framework { get; set; } = FrameworkType.WebAssembly;
    }
}
