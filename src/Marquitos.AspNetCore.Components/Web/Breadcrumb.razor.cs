using Microsoft.AspNetCore.Components;
using System;

namespace Marquitos.AspNetCore.Components.Web
{
    /// <summary>
    /// Breadcrumb component
    /// </summary>
    public partial class Breadcrumb : Component, IBreadcrumb, IDisposable
    {
        /// <summary>
        /// Content
        /// </summary>
        [Parameter]
        public RenderFragment ChildContent { get; set; }

        public void Dispose()
        {
            ChildContent = null;
        }
    }
}
