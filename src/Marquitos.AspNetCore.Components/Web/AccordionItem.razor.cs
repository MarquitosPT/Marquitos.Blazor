using Marquitos.AspNetCore.Components.Enums;
using Marquitos.AspNetCore.Components.JSInterop;
using Microsoft.AspNetCore.Components;
using System;
using System.Threading.Tasks;

namespace Marquitos.AspNetCore.Components.Web
{
    /// <summary>
    /// Accordion Item Component
    /// </summary>
    public partial class AccordionItem : Component, IAccordionItem
    {
        private AccordionItemState _state = AccordionItemState.Closed;
        private bool _isOpen = false;
        private ElementReference _panelElement;

        [Inject]
        private IJSAnimation JSAnimation { get; set; }

        [CascadingParameter]
        private IAccordion Container { get; set; }

        /// <summary>
        /// Accordion header content
        /// </summary>
        [Parameter]
        public RenderFragment Header { get; set; }

        /// <summary>
        /// Accordion body content
        /// </summary>
        [Parameter]
        public RenderFragment Body { get; set; }

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
                        _state = AccordionItemState.Open;
                    }
                    else
                    {
                        _state = AccordionItemState.Closed;
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
                _state = AccordionItemState.Closing;

                StateHasChanged();
            }
            else
            {
                _state = AccordionItemState.Openning;

                StateHasChanged();
            }

        }

        /// <inheritdoc />
        protected override void OnInitialized()
        {
            base.OnInitialized();

            if (Container == null)
            {
                throw new Exception("The 'AccordionItem' must be created inside an IAccordion container!");
            }

            Container.AddItem(this);
        }

        /// <inheritdoc />
        protected override async Task OnAfterRenderAsync(bool firstRender)
        {
            if (firstRender)
            {
                await JSAnimation.InitializeAsync();
            }
            else
            {
                if (_state == AccordionItemState.Openning)
                {
                    IsOpen = true;

                    Container.Activate(this);
                    await JSAnimation.PlayAsync(AnimationType.Expand, _panelElement, async () =>
                    {
                        StateHasChanged();

                        await Task.CompletedTask;
                    });
                }
                else if (_state == AccordionItemState.Closing)
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
    }
}
