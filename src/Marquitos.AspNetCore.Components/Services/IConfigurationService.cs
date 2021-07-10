using Marquitos.AspNetCore.Components.Extensions.Configuration.Options;

namespace Marquitos.AspNetCore.Components.Services
{
    public interface IConfigurationService
    {
        ConfigurationOptions Options { get; }
    }
}
