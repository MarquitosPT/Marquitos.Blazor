using Marquitos.AspNetCore.Components.JSInterop;
using Marquitos.AspNetCore.Components.JSInterop.Extensions.Configuration.Options;
using Microsoft.Extensions.DependencyInjection;
using System;

namespace Marquitos.AspNetCore.Components.Extensions.Configuration
{
    public static class ServicesCollectionExtension
    {
        public static IServiceCollection AddMarquitosJSInterop(this IServiceCollection services, Action<JSInteropOptions> options = null)
        {
            // Add Configuration Options
            if (options != null)
            {
                services.AddOptions();
                services.Configure(options);
            }
            else
            {
                services.AddOptions<JSInteropOptions>();
            }

            // JSInterop Services
            services.AddScoped<IJSAnimation, JSAnimation>();
            services.AddScoped<IJSFile, JSFile>();
            services.AddScoped<IJSNavigation, JSNavigation>();
            services.AddScoped<IJSUtils, JSUtils>();

            return services;
        }

        public static IServiceCollection AddMarquitosJSInteropServer(this IServiceCollection services)
        {
            // Add Configuration Options
            services.AddOptions<JSInteropOptions>()
                .Configure(o => o.Framework = JSInterop.Enums.FrameworkType.Server);

            // JSInterop Services
            services.AddScoped<IJSAnimation, JSAnimation>();
            services.AddScoped<IJSFile, JSFile>();
            services.AddScoped<IJSNavigation, JSNavigation>();
            services.AddScoped<IJSUtils, JSUtils>();

            return services;
        }

        public static IServiceCollection AddMarquitosJSInteropWebAssembly(this IServiceCollection services)
        {
            // Add Configuration Options
            services.AddOptions<JSInteropOptions>()
                .Configure(o => o.Framework = JSInterop.Enums.FrameworkType.WebAssembly);

            // JSInterop Services
            services.AddScoped<IJSAnimation, JSAnimation>();
            services.AddScoped<IJSFile, JSFile>();
            services.AddScoped<IJSNavigation, JSNavigation>();
            services.AddScoped<IJSUtils, JSUtils>();

            return services;
        }
    }
}
