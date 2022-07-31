using Marquitos.AspNetCore.Components.Enums;
using Marquitos.AspNetCore.Components.JSInterop;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Web;
using System;
using System.Threading.Tasks;

namespace Marquitos.AspNetCore.Components.Web
{
    public sealed partial class NavigationViewItem : ComponentBase, INavigationViewItem, IDisposable
    {
        private bool _selected;
        private bool _enabled = true;
        private bool _isOpen = false;
        private NavigationViewItemState _state = NavigationViewItemState.Closed;
        private ElementReference _panelElement;

        private MarkupString IconContent { get; set; }

        [Inject]
        private IJSAnimation JSAnimation { get; set; }

        [Inject]
        private IJSFile JSFile { get; set; }

        [CascadingParameter]
        private INavigationView NavigationView { get; set; }

        [Parameter]
        public string Uri { get; set; }

        [Parameter]
        public RenderFragment Icon { get; set; }

        [Parameter]
        public string IconSource { get; set; }

        [Parameter]
        public RenderFragment Content { get; set; }

        [Parameter]
        public RenderFragment ChildContent { get; set; }

        [Parameter]
        public RenderFragment MenuItems { get; set; }

        [Parameter]
        public string Tooltip { get; set; }

        [Parameter]
        public EventCallback<MouseEventArgs> OnClick { get; set; }

        [Parameter]
        public bool Selected
        {
            get
            {
                if (NavigationView != null && NavigationView.ActiveMenu != null)
                {
                    _selected = NavigationView.ActiveMenu == this;
                }

                return _selected;
            }
            set
            {
                _selected = value;
            }
        }

        [Parameter]
        public bool Enabled
        {
            get => _enabled;
            set
            {
                if (_enabled != value)
                {
                    _enabled = value;
                    StateHasChanged();
                }
            }
        }

        /// <summary>
        /// Gets or sets if the item is open or closed
        /// </summary>
        [Parameter]
        public bool IsOpen
        {
            get
            {
                return _isOpen;
            }

            set
            {

                if (_isOpen != value)
                {
                    _isOpen = value;

                    if (_isOpen)
                    {
                        _state = NavigationViewItemState.Open;
                    }
                    else
                    {
                        _state = NavigationViewItemState.Closed;
                    }
                }
            }
        }

        /// <summary>
        /// Toggles the item state between open and closed
        /// </summary>
        public void Toggle()
        {
            if (IsOpen)
            {
                _state = NavigationViewItemState.Closing;

                StateHasChanged();
            }
            else
            {
                _state = NavigationViewItemState.Openning;

                StateHasChanged();
            }

        }
        protected override void OnInitialized()
        {
            if (NavigationView != null)
            {
                NavigationView.Add(this);
            }
        }

        protected override void OnParametersSet()
        {
            if (NavigationView != null && NavigationView.ActiveMenu == null && _selected)
            {
                NavigationView.Activate(this);
            }
        }

        protected override async Task OnAfterRenderAsync(bool firstRender)
        {
            if (firstRender)
            {
                IconContent = await JSFile.LoadMarkupStringAsync(IconSource);
                await JSAnimation.InitializeAsync();
            }
            else
            {
                if (_state == NavigationViewItemState.Openning)
                {
                    IsOpen = true;

                    //Container.Activate(this);
                    await JSAnimation.PlayAsync(AnimationType.Expand, _panelElement, async () =>
                    {
                        StateHasChanged();

                        await Task.CompletedTask;
                    });
                }
                else if (_state == NavigationViewItemState.Closing)
                {
                    await JSAnimation.PlayAsync(AnimationType.Collapse, _panelElement, async () =>
                    {
                        IsOpen = false;
                        StateHasChanged();

                        await Task.CompletedTask;
                    });
                }
            }
        }

        private void HandleOnClick(MouseEventArgs args)
        {
            if (MenuItems != null)
            {
                Toggle();
            }
            else
            {
                if (OnClick.HasDelegate)
                {
                    OnClick.InvokeAsync(args);
                }
                else
                {
                    if (NavigationView != null && NavigationView.ActiveMenu != this)
                    {
                        NavigationView.Activate(this);
                        NavigationView.NavigateTo(Uri);
                    }
                }
            }
        }

        public void Dispose()
        {
            if (NavigationView != null)
            {
                NavigationView.Remove(this);
            }

            NavigationView = null;
        }
    }
}
