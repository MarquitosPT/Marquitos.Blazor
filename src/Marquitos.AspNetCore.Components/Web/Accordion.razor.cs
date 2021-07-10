using Marquitos.AspNetCore.Components.Enums;
using Microsoft.AspNetCore.Components;

namespace Marquitos.AspNetCore.Components.Web
{
    /// <summary>
    /// Accordion Component
    /// </summary>
    public partial class Accordion : Component, IAccordion
    {
        /// <summary>
        /// ChildContent
        /// </summary>
        [Parameter]
        public RenderFragment ChildContent { get; set; }

        /// <summary>
        /// Accordion Style
        /// </summary>
        [Parameter]
        public AccordionStyle Style { get; set; } = AccordionStyle.Normal;

        /// <summary>
        /// Indicates if allow multiple panels open
        /// </summary>
        [Parameter]
        public bool AllowMultiplePanelsOpen { get; set; } = false;

        /// <summary>
        /// Gets the Active Item
        /// </summary>
        public IAccordionItem ActiveItem { get; private set; }

        /// <summary>
        /// Sets the provided item as active item
        /// </summary>
        /// <param name="item"></param>
        public void Activate(IAccordionItem item)
        {
            if (ActiveItem != item)
            {
                if (!AllowMultiplePanelsOpen)
                {
                    if (ActiveItem != null && ActiveItem.IsOpen)
                    {
                        ActiveItem.Toggle();
                    }
                }

                if (item != null && item.IsOpen)
                {
                    ActiveItem = item;
                }
                else
                {
                    ActiveItem = null;
                }
            }
        }

        /// <summary>
        /// Adds the provided Item
        /// </summary>
        /// <param name="item"></param>
        public void AddItem(IAccordionItem item)
        {
            if (ActiveItem == null && item.IsOpen)
            {
                ActiveItem = item;
            }
            else
            {
                if (!AllowMultiplePanelsOpen)
                {
                    item.IsOpen = false;
                }
            }
        }

        /// <summary>
        /// Removes the provided item
        /// </summary>
        /// <param name="item"></param>
        public void RemoveItem(IAccordionItem item)
        {
            if (ActiveItem == item)
            {
                ActiveItem = null;
            }
        }
    }
}
