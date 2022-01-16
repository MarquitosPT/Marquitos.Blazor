using Microsoft.AspNetCore.Components;

namespace Marquitos.AspNetCore.Components.Web
{
    public interface IGridItem
    {
        RenderFragment ChildContent { get; }
    }
}
