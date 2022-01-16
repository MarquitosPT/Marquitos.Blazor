using Marquitos.AspNetCore.Components.Enums;
using Marquitos.AspNetCore.Components.JSInterop;
using Microsoft.AspNetCore.Components;
using System;
using System.Threading.Tasks;

namespace Marquitos.AspNetCore.Components.Web
{
    /// <summary>
    /// CardTabSet Control
    /// </summary>
    public partial class CardTabSet : Component, ITabSet, IDisposable
    {
        private bool _playAnimation = false;
        private ElementReference _frameElement;

        [Inject]
        private IJSAnimation JSAnimation { get; set; }

        [Parameter]
        public RenderFragment ChildContent { get; set; }

        [Parameter]
        public TabSetStyle Style { get; set; } = TabSetStyle.Tabs;

        public ITabPage ActivePage { get; private set; }

        public void AddPage(ITabPage page)
        {
            if (ActivePage == null)
            {
                Activate(page);
            }
        }

        public void RemovePage(ITabPage page)
        {
            if (ActivePage == page)
            {
                Activate(null);
            }
        }

        public void Activate(ITabPage page)
        {
            if (ActivePage != page)
            {
                if (ActivePage != null && page != null)
                {
                    _playAnimation = true;
                }

                ActivePage = page;

                StateHasChanged();
            }
        }

        public void Dispose()
        {
            ActivePage = null;
            ChildContent = null;
        }

        protected override async Task OnAfterRenderAsync(bool firstRender)
        {
            if (firstRender)
            {
                await JSAnimation.InitializeAsync();
            }
            else
            {
                if (_playAnimation)
                {
                    _playAnimation = false;
                    await JSAnimation.PlayAsync(AnimationType.FadeIn, _frameElement);
                }
            }
        }
    }
}
