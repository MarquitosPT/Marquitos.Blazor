using Marquitos.AspNetCore.Components.Extensions.Configuration.Options;
using Marquitos.AspNetCore.Components.Services;
using Microsoft.Extensions.DependencyInjection;
using System;

namespace Marquitos.AspNetCore.Components.Extensions.Configuration
{
    public static class ServicesCollectionExtension
    {
        public static IServiceCollection AddMarquitosComponents(this IServiceCollection services, Action<ConfigurationOptions> options = null)
        {
            // Add Configuration Options
            if (options != null)
            {
                services.AddOptions();
                services.Configure(options);
            }
            else
            {
                services.AddOptions<ConfigurationOptions>();
            }

            // Services
            services.AddScoped<IConfigurationService, ConfigurationService>();

            // JSInterop Services
            services.AddMarquitosJSInterop();

            return services;
        }
    }
}
