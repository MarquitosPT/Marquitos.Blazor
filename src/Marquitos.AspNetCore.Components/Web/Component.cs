using Marquitos.AspNetCore.Components.Enums;
using Marquitos.AspNetCore.Components.Services;
using Microsoft.AspNetCore.Components;
using System.Threading.Tasks;

namespace Marquitos.AspNetCore.Components.Web
{
    public abstract class Component : ComponentBase
    {
        [Inject]
        private IConfigurationService ConfigurationService { get; set; }

        [Parameter]
        public Theme Theme { get; set; }

        public override async Task SetParametersAsync(ParameterView parameters)
        {
            Theme = parameters.GetValueOrDefault(nameof(Theme), ConfigurationService.Options.GlobalTheme);

            await base.SetParametersAsync(parameters);
        }
    }
}
