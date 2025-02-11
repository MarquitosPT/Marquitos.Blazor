﻿using Marquitos.AspNetCore.Components.JSInterop;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Web;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Marquitos.AspNetCore.Components.Web
{
    /// <summary>
    /// Toggle Button Component
    /// </summary>
    public partial class ToggleButton : ComponentBase, IToggleButton
    {
        private ElementReference _element;
        private bool _internalChecked = false;

        [Inject]
        private IJSAnimation JSAnimation { get; set; }

        [Inject]
        private IJSUtils JSUtils { get; set; }

        [CascadingParameter]
        private IToggleButtonGroup Container { get; set; }

        /// <summary>
        /// Title
        /// </summary>
        [Parameter]
        public string Title { get; set; }

        /// <summary>
        /// ChildContent
        /// </summary>
        [Parameter]
        public RenderFragment ChildContent { get; set; }

        /// <summary>
        /// Additional attributes
        /// </summary>
        [Parameter(CaptureUnmatchedValues = true)]
        public Dictionary<string, object> AdditionalAttributes { get; set; }

        /// <summary>
        /// Indicates if the button is checked
        /// </summary>
        [Parameter]
        public bool IsChecked { get; set; } = false;

        /// <summary>
        /// Indicates if the button is enabled
        /// </summary>
        [Parameter]
        public bool Enabled { get; set; } = true;

        /// <summary>
        /// Event that is fired when the button is clicked
        /// </summary>
        [Parameter]
        public EventCallback<MouseEventArgs> OnClick { get; set; }

        /// <summary>
        /// Toggles between checked or unchecked state
        /// </summary>
        public void Toggle()
        {
            if (!Enabled)
            {
                return;
            }

            _internalChecked = !_internalChecked;

            IsChecked = _internalChecked;

            if (Container != null && _internalChecked)
            {
                Container.Activate(this);
            }

            StateHasChanged();
        }

        public async Task ClickAsync()
        {
            await JSUtils.ClickAsync(_element);
        }

        public async Task FocusAsync()
        {
            await JSUtils.FocusAsync(_element);
        }

        protected override void OnInitialized()
        {
            if (Container != null)
            {
                Container.AddItem(this);
            }

            _internalChecked = IsChecked;
        }

        override protected async Task OnAfterRenderAsync(bool firstRender)
        {
            if (firstRender)
            {
                await JSAnimation.InitializeAsync();
                await JSUtils.InitializeAsync();
            }

            if (_internalChecked)
            {
                await JSUtils.AddClassAsync(_element, "active");
            }
            else
            {
                await JSUtils.RemoveClassAsync(_element, "active");
            }
        }

        private async Task HandleClick(MouseEventArgs e)
        {
            if (!Enabled)
            {
                return;
            }

            if (Container != null && !Container.AllowMultipleButtonsChecked && _internalChecked)
            {
                return;
            }

            await JSAnimation.ClickAnimationAsync(_element, 200);

            Toggle();

            if (OnClick.HasDelegate)
            {
                await OnClick.InvokeAsync(e);
            }
        }
    }
}
