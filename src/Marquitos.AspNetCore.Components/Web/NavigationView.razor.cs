using Marquitos.AspNetCore.Components.Enums;
using Marquitos.AspNetCore.Components.Events;
using Marquitos.AspNetCore.Components.JSInterop;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Routing;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Marquitos.AspNetCore.Components.Web
{
    public sealed partial class NavigationView : ComponentBase, INavigationView, INavigationViewFrame, IDisposable
    {
        private const int _windowBreak = 734;

        private NavigationViewState _state = NavigationViewState.Closed;
        private NavigationViewDisplayMode _displayMode = NavigationViewDisplayMode.Left;
        private bool _isOpen = false;
        private bool _playNavigationAnimation = false;
        private ElementReference _panelElement;
        private ElementReference _frameElement;
        private List<INavigationViewItem> _list = new List<INavigationViewItem>();
        private INavigationViewItem _backButton;
        private INavigationViewHeader headerFrame;
        private int _windowWidth;         

        [Inject]
        private IJSAnimation JSAnimation { get; set; }

        [Inject]
        private IJSNavigation JSNavigation { get; set; }

        [Inject]
        private IJSUtils JSUtils { get; set; }

        [Inject]
        private NavigationManager NavigationManager { get; set; }

        [Parameter]
        public RenderFragment MenuItems { get; set; }

        [Parameter]
        public RenderFragment FooterItems { get; set; }

        [Parameter]
        public RenderFragment Frame { get; set; }

        [Parameter]
        public RenderFragment Header { get; set; }

        [Parameter]
        public bool IsOpened
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
                        _state = NavigationViewState.Open;
                    }
                    else
                    {
                        _state = NavigationViewState.Closed;
                    }
                }
            }
        }

        [Parameter]
        public bool IsBackButtonVisible { get; set; }

        [Parameter]
        public string BackButtonTitle { get; set; } = "Go back";

        public INavigationViewHeader HeaderFrame 
        { 
            get => headerFrame; 
            set 
            { 
                headerFrame = value; 
                StateHasChanged(); 
            }  
        }

        public INavigationViewItem ActiveMenu { get; private set; }

        public void Add(INavigationViewItem item)
        {
            _list.Add(item);
        }

        public void Remove(INavigationViewItem item)
        {
            if (ActiveMenu == item)
            {
                ActiveMenu = null;
            }

            _list.Remove(item);
        }

        public void Activate(INavigationViewItem item)
        {
            if (ActiveMenu != item)
            {
                ActiveMenu = item;
            }
        }

        public void NavigateTo(string uri, bool forceLoad = false)
        {
            NavigationManager.NavigateTo(uri, forceLoad);

            if (_displayMode == NavigationViewDisplayMode.LeftCompact && _isOpen)
            {
                Toggle();
            }
        }

        protected override void OnInitialized()
        {
            NavigationManager.LocationChanged += HandleLocationChanged;
            JSUtils.OnWindowResize += HandleWindowResize;
        }

        protected override async Task OnAfterRenderAsync(bool firstRender)
        {
            if (firstRender)
            {
                await JSAnimation.InitializeAsync();
                await JSNavigation.InitializeAsync();
                await JSUtils.InitializeAsync();

                _windowWidth = await JSUtils.GetWindowWidthAsync();

                if (_windowWidth <= _windowBreak)
                {
                    if (_displayMode != NavigationViewDisplayMode.LeftCompact)
                    {
                        _displayMode = NavigationViewDisplayMode.LeftCompact;
                        StateHasChanged();
                    }
                }
            }

            if (!firstRender)
            {
                if (_state == NavigationViewState.Openning)
                {
                    IsOpened = true;

                    if (_displayMode == NavigationViewDisplayMode.Left)
                    {
                        await JSAnimation.GrowAsync(_panelElement, 48);
                    }
                    else
                    {
                        await JSAnimation.GrowAsync(_panelElement, 0, 250);
                    }
                    
                }
                else if (_state == NavigationViewState.Closing)
                {
                    if (_displayMode == NavigationViewDisplayMode.Left)
                    {
                        await JSAnimation.CompactAsync(_panelElement, 48, async () =>
                        {
                            IsOpened = false;
                            StateHasChanged();

                            await Task.CompletedTask;
                        });
                    }
                    else
                    {
                        await JSAnimation.CompactAsync(_panelElement, 0, 250, async () =>
                        {
                            IsOpened = false;
                            StateHasChanged();

                            await Task.CompletedTask;
                        });
                    }      
                }

                if (_playNavigationAnimation)
                {
                    _playNavigationAnimation = false;
                    await JSAnimation.PlayAsync(AnimationType.SlideInFromBottom, _frameElement);
                }

                if (IsBackButtonVisible && _backButton != null)
                {
                    _backButton.Enabled = await JSNavigation.CanGoBackAsync();
                }
            }
        }

        private async Task BackAsync()
        {
            if (await JSNavigation.CanGoBackAsync())
            {
                await JSNavigation.BackAsync();
            }
        }

        private void Toggle()
        {
            if (_isOpen)
            {
                _state = NavigationViewState.Closing;
                StateHasChanged();
            }
            else
            {
                _state = NavigationViewState.Openning;
                StateHasChanged();
            }
        }

        private void HandleLocationChanged(object sender, LocationChangedEventArgs e)
        {
            _playNavigationAnimation = true;

            var relativeUrl = NavigationManager.ToBaseRelativePath(e.Location);
            var item = _list.FirstOrDefault(e => e.Uri == relativeUrl || (e.Uri != "" && relativeUrl.StartsWith(e.Uri)));

            if (ActiveMenu != item)
            {
                ActiveMenu = item;
                StateHasChanged();
            }
        }

        private void HandleWindowResize(object sender, ResizeArgs e)
        {
            _windowWidth = e.Width;

            if (_windowWidth <= _windowBreak)
            {
                if (_displayMode != NavigationViewDisplayMode.LeftCompact)
                {
                    _displayMode = NavigationViewDisplayMode.LeftCompact; 
                    StateHasChanged();
                }
            }
            else
            {
                if (_displayMode != NavigationViewDisplayMode.Left)
                {
                    _displayMode = NavigationViewDisplayMode.Left;
                    StateHasChanged();
                }
            }
        }

        public void Dispose()
        {
            NavigationManager.LocationChanged -= HandleLocationChanged;
            JSUtils.OnWindowResize -= HandleWindowResize;

            HeaderFrame = null;
            ActiveMenu = null;
            _list.Clear();
        }
    }
}
