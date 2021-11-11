using Marquitos.AspNetCore.Components.Enums;
using Marquitos.AspNetCore.Components.JSInterop;
using Microsoft.AspNetCore.Components;
using System;
using System.Threading.Tasks;

namespace Marquitos.AspNetCore.Components.Web
{
    public partial class Dialog : Component, IDisposable
    {
        private DialogState _state = DialogState.Closed;
        private ElementReference _windowElement;
        private bool _showEvent = false;

        [Inject]
        private IJSAnimation JSAnimation { get; set; }

        [Inject]
        private IJSUtils JSUtils { get; set; }

        public DialogState State
        {
            get { return _state; }
            private set 
            {
                if (_state != value)
                {
                    _state = value;
                    StateHasChanged();
                }
            }
        }

        [Parameter]
        public RenderFragment DialogHeader { get; set; } = null;

        [Parameter]
        public RenderFragment DialogBody { get; set; } = null;

        [Parameter]
        public RenderFragment DialogFooter { get; set; } = null;

        [Parameter]
        public DialogSize Size { get; set; } = DialogSize.Default;

        [Parameter]
        public EventCallback OnShow { get; set; }

        public void Show()
        {
            _showEvent = true;
            State = DialogState.Openning;
        }

        public async Task ShowAsync()
        {
            _showEvent = true;
            State = DialogState.Openning;
            
            await Task.CompletedTask;
        }

        public void Hide()
        {
            State = DialogState.Closing;
        }

        public async Task HideAsync()
        {
            State = DialogState.Closing;

            await Task.CompletedTask;
        }

        public void Dispose()
        {
            DialogHeader = null;
            DialogBody = null;
            DialogFooter = null;
        }

        protected async Task HandleOnShowAsync()
        {
            _showEvent = false;

            if (OnShow.HasDelegate)
            {
                await OnShow.InvokeAsync();
            }
        }

        protected override async Task OnAfterRenderAsync(bool firstRender)
        {
            if (firstRender)
            {
                await JSUtils.InitializeAsync();
                await JSAnimation.InitializeAsync();
            }
            else
            {
                if (_state == DialogState.Openning)
                {       
                    await JSAnimation.PlayAsync(AnimationType.SlideInFromTop, _windowElement, async () =>
                    {
                        State = DialogState.Open;

                        await Task.CompletedTask;
                    });

                    if (_showEvent)
                    {
                        await HandleOnShowAsync();
                    }
                }
                else if (_state == DialogState.Open)
                {
                    
                }
                else if (_state == DialogState.Closing)
                {
                    await JSAnimation.PlayAsync(AnimationType.SlideOutToTop, _windowElement, async () =>
                    {
                        State = DialogState.Closed;

                        await Task.CompletedTask;
                    });
                }
            }
        }

    }
}
