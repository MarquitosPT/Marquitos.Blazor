using Microsoft.AspNetCore.Components;
using System;

namespace Marquitos.AspNetCore.Components.Web
{
    public partial class TabPage : Component, ITabPage, IDisposable
    {
        protected readonly Action _activateDelegate;

        public TabPage()
        {
            _activateDelegate = Activate;
        }

        [CascadingParameter]
        public ITabSet Container { get; set; }

        [Parameter]
        public string Title { get; set; }

        [Parameter]
        public RenderFragment ChildContent { get; set; }

        [Inject]
        private NavigationManager NavigationManager { get; set; }

        public void Activate()
        {
            Container.Activate(this);
            StateHasChanged();
        }

        public void Dispose()
        {
            Container.RemovePage(this);

            NavigationManager = null;
            ChildContent = null;
            Container = null;
        }


        protected override void OnInitialized()
        {
            base.OnInitialized();

            Container.AddPage(this);
        }
    }
}
