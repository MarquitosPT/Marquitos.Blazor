using Marquitos.AspNetCore.Components.Enums;
using Marquitos.AspNetCore.Components.JSInterop;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Web;
using System.Threading.Tasks;

namespace Marquitos.AspNetCore.Components.Web
{
    public partial class Button : Component
    {
        private ElementReference _element;

        [Inject]
        private IJSUtils JSUtils { get; set; }

        [Parameter]
        public RenderFragment ChildContent { get; set; }

        [Parameter]
        public ButtonSize Size { get; set; } = ButtonSize.Normal;

        [Parameter]
        public ButtonStyle Style { get; set; } = ButtonStyle.Primary;

        [Parameter]
        public bool Enabled { get; set; } = true;

        [Parameter]
        public EventCallback<MouseEventArgs> OnClick { get; set; }

        public async Task ClickAsync()
        {
            await JSUtils.ClickAsync(_element);
        }

        public async Task FocusAsync()
        {
            await JSUtils.FocusAsync(_element);
        }

        protected override async Task OnAfterRenderAsync(bool firstRender)
        {
            if (firstRender)
            {
                await JSUtils.InitializeAsync();
            }
        }
    }
}
