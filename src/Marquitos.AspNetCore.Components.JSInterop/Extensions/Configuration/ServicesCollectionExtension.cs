using Marquitos.AspNetCore.Components.JSInterop;
using Microsoft.Extensions.DependencyInjection;

namespace Marquitos.AspNetCore.Components.Extensions.Configuration
{
    public static class ServicesCollectionExtension
    {
        public static IServiceCollection AddMarquitosJSInterop(this IServiceCollection services)
        {
            // JSInterop Services
            services.AddScoped<IJSAnimation, JSAnimation>();
            services.AddScoped<IJSFile, JSFile>();
            services.AddScoped<IJSNavigation, JSNavigation>();
            services.AddScoped<IJSUtils, JSUtils>();

            return services;
        }
    }
}
