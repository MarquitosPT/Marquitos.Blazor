using Microsoft.AspNetCore.Components;
using System;

namespace Marquitos.AspNetCore.Components.Web
{
    /// <summary>
    /// Card component
    /// </summary>
    public partial class Card : Component, ICard, IDisposable
    {
        /// <summary>
        /// Card Header
        /// </summary>
        [Parameter]
        public RenderFragment CardHeader { get; set; }

        /// <summary>
        /// Card Body
        /// </summary>
        [Parameter]
        public RenderFragment CardBody { get; set; }

        /// <summary>
        /// Card Footer
        /// </summary>
        [Parameter]
        public RenderFragment CardFooter { get; set; }

        public void Dispose()
        {
            CardHeader = null;
            CardBody = null;
            CardFooter = null;
        }
    }
}
