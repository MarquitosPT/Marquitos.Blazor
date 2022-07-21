using System;
using Microsoft.AspNetCore.Components;

namespace Marquitos.AspNetCore.Components.Web
{
	public partial class ToggleSwitch : Component
	{
        [Parameter]
        public string Header { get; set; }

        [Parameter]
        public string OnContent { get; set; }

        [Parameter]
        public string OffContent { get; set; }

        [Parameter]
        public bool IsOn { get; set; }

        [Parameter]
        public EventCallback Toggled { get; set; }
    }
}

