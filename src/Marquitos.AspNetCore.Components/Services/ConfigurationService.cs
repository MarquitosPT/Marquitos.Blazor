using Marquitos.AspNetCore.Components.Extensions.Configuration.Options;
using Microsoft.Extensions.Options;

namespace Marquitos.AspNetCore.Components.Services
{
    internal class ConfigurationService : IConfigurationService
    {
        public ConfigurationService(IOptions<ConfigurationOptions> options)
        {
            Options = options.Value;
        }

        public ConfigurationOptions Options { get; private set; }
    }
}
