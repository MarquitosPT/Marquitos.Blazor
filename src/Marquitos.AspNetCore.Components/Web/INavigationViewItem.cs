using Microsoft.AspNetCore.Components;

namespace Marquitos.AspNetCore.Components.Web
{
    public interface INavigationViewItem
    {
        string Uri { get; }
        public bool Enabled { get; set; }
        RenderFragment ChildContent { get; }
        RenderFragment Content { get; }
    }
}
