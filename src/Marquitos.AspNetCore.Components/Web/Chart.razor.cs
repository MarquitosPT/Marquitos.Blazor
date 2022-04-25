using System;
using Microsoft.AspNetCore.Components;

namespace Marquitos.AspNetCore.Components.Web
{
	public partial class Chart : Component, IChart
	{
        [Parameter]
        public RenderFragment ChildContent { get; set; }
    }
}

