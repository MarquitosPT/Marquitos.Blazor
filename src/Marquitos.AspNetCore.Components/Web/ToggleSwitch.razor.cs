using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Web;

namespace Marquitos.AspNetCore.Components.Web
{
    /// <summary>
    /// Toggle switch component
    /// </summary>
    public partial class ToggleSwitch : Component
	{
        private bool _isOn = false;

        /// <summary>
        /// The content to display when the switch is on.
        /// </summary>
        [Parameter]
        public string OnContent { get; set; } = "On";

        /// <summary>
        /// The content to display when the switch is off.
        /// </summary>
        [Parameter]
        public string OffContent { get; set; } = "Off";

        /// <summary>
        /// Gets or sets whether the switch is on or off.
        /// </summary>
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
                        Toggled.InvokeAsync().Wait();
                    }
                }
            }
        }

        /// <summary>
        /// Gets or sets whether the switch is enabled or disabled. 
        /// When disabled the switch becomes read only.
        /// </summary>
        [Parameter]
        public bool Enabled { get; set; } = true;

        /// <summary>
        /// The event that is fired when the switch is turned on or turned off.
        /// </summary>
        [Parameter]
        public EventCallback Toggled { get; set; }

        /// <summary>
        /// Toggles the switch state between on or off.
        /// </summary>
        public void Toggle()
        {
            if (Enabled)
            {
                IsOn = !IsOn;
            }
        }

        private void CheckChange(ChangeEventArgs args)
        {
            IsOn = (bool)args.Value;
        }

        private void LabelClick(MouseEventArgs args)
        {
            Toggle();
        }
    }
}

