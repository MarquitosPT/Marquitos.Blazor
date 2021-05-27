using Microsoft.AspNetCore.Components;

namespace Marquitos.AspNetCore.Components.Web
{
    public interface INavigationViewHeader
    {
        RenderFragment ChildContent { get; }
    }
}
