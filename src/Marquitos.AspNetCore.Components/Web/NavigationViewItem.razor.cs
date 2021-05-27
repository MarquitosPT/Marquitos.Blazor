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

        private MarkupString IconContent { get; set; }

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
            }
        }

        private void HandleOnClick(MouseEventArgs args)
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
