using Microsoft.AspNetCore.Components;

namespace Marquitos.AspNetCore.Components.Web
{
    public interface ICard
    {
        RenderFragment CardHeader { get; set; }

        RenderFragment CardBody { get; set; }

        RenderFragment CardFooter { get; set; }
    }
}
