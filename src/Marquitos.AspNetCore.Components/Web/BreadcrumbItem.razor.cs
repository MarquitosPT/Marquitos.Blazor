using Microsoft.AspNetCore.Components;
using System;

namespace Marquitos.AspNetCore.Components.Web
{
    /// <summary>
    /// Breadcrumb Item component
    /// </summary>
    public partial class BreadcrumbItem : Component, IBreadcrumbItem, IDisposable
    {
        /// <summary>
        /// Destination Url
        /// </summary>
        [Parameter]
        public string Uri { get; set; }

        /// <summary>
        /// Child Content
        /// </summary>
        [Parameter]
        public RenderFragment ChildContent { get; set; }

        public void Dispose()
        {
            Uri = null;
            ChildContent = null;
        }
    }
}
