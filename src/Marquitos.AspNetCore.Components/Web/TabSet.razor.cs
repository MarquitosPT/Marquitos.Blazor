using Marquitos.AspNetCore.Components.Enums;
using Microsoft.AspNetCore.Components;

namespace Marquitos.AspNetCore.Components.Web
{
    /// <summary>
    /// TabSet Component
    /// </summary>
    public partial class TabSet : Component, ITabSet, IDisposable
    {
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
                ActivePage = page;
                StateHasChanged();
            }
        }

        public void Dispose()
        {
            ActivePage = null;
            ChildContent = null;
        }
    }
}
