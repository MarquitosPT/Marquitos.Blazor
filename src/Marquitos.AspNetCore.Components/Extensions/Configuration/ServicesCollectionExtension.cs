using Marquitos.AspNetCore.Components.Extensions.Configuration.Options;
using Marquitos.AspNetCore.Components.JSInterop;
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

            // JSInterop Services
            services.AddScoped<IJSAnimation, JSAnimation>();
            services.AddScoped<IJSFile, JSFile>();
            services.AddScoped<IJSNavigation, JSNavigation>();
            services.AddScoped<IJSUtils, JSUtils>();

            return services;
        }
    }
}
