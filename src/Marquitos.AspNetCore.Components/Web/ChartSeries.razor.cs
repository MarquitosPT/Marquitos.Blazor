using System;
using Microsoft.AspNetCore.Components;

namespace Marquitos.AspNetCore.Components.Web
{
	public partial class ChartSeries : Component
	{
        [Parameter]
        public RenderFragment ChildContent { get; set; }
    }
}

