using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Web;

namespace Marquitos.AspNetCore.Components.Web
{
    public partial class ToggleSwitch : Component
	{
        private bool _isOn = false;

        [Parameter]
        public string OnContent { get; set; } = "On";

        [Parameter]
        public string OffContent { get; set; } = "Off";

        [Parameter]
        public bool IsOn 
        { 
            get { return _isOn; }
            set
            {
                if (_isOn != value)
                {
                    _isOn = value;

                    if (Toggled.HasDelegate)
                    {
                        Toggled.InvokeAsync();
                    }
                }
            }
        }

        [Parameter]
        public bool Enabled { get; set; } = true;

        [Parameter]
        public EventCallback Toggled { get; set; }

        private void CheckChange(ChangeEventArgs args)
        {
            IsOn = (bool)args.Value;
        }

        private void LabelClick(MouseEventArgs args)
        {
            if (Enabled)
            {
                IsOn = !IsOn;
            }
        }
    }
}

