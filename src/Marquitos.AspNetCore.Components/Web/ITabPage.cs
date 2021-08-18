using Microsoft.AspNetCore.Components;

namespace Marquitos.AspNetCore.Components.Web
{
    public interface ITabPage
    {
        void Activate();

        RenderFragment ChildContent { get; }
    }
}
