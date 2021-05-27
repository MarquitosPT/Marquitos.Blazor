using Microsoft.AspNetCore.Components;
using System;

namespace Marquitos.AspNetCore.Components.Web
{
    public sealed partial class NavigationViewHeader : ComponentBase, INavigationViewHeader, IDisposable
    {
        [CascadingParameter]
        private INavigationViewFrame NavigationViewFrame { get; set; }

        [Parameter]
        public RenderFragment ChildContent { get; set; }

        protected override void OnInitialized()
        {
            if (NavigationViewFrame != null)
            {
                //if (NavigationViewFrame.HeaderFrame != null)
                //{
                //    throw new Exception("Can only have one NavigationViewHeader on same page.");
                //}

                NavigationViewFrame.HeaderFrame = this;
            }
        }

        public void Dispose()
        {
            if (NavigationViewFrame != null && NavigationViewFrame.HeaderFrame == this)
            {
                NavigationViewFrame.HeaderFrame = null;
            }

            NavigationViewFrame = null;
        }
    }
}
