using Microsoft.AspNetCore.Components;
using System.Collections.Generic;

namespace Marquitos.AspNetCore.Components.Web
{
    public partial class ToggleButtonGroup : ComponentBase, IToggleButtonGroup
    {
        /// <summary>
        /// ChildContent
        /// </summary>
        [Parameter]
        public RenderFragment ChildContent { get; set; }

        /// <summary>
        /// Indicates if allow multiple buttons checked
        /// </summary>
        [Parameter]
        public bool AllowMultipleButtonsChecked { get; set; } = false;

        /// <summary>
        /// Additional attributes
        /// </summary>
        [Parameter(CaptureUnmatchedValues = true)]
        public Dictionary<string, object> AdditionalAttributes { get; set; }


        /// <summary>
        /// Gets the Active Item
        /// </summary>
        public IToggleButton ActiveItem { get; private set; }

        /// <summary>
        /// Sets the provided item as active item
        /// </summary>
        /// <param name="item"></param>
        public void Activate(IToggleButton item)
        {
            if (ActiveItem != item)
            {
                if (!AllowMultipleButtonsChecked)
                {
                    if (ActiveItem != null && ActiveItem.IsChecked)
                    {
                        ActiveItem.Toggle();
                    }
                }

                if (item != null && item.IsChecked)
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
        public void AddItem(IToggleButton item)
        {
            if (ActiveItem == null && item.IsChecked)
            {
                ActiveItem = item;
            }
            else
            {
                if (!AllowMultipleButtonsChecked)
                {
                    item.IsChecked = false;
                }
            }
        }

        /// <summary>
        /// Removes the provided item
        /// </summary>
        /// <param name="item"></param>
        public void RemoveItem(IToggleButton item)
        {
            if (ActiveItem == item)
            {
                ActiveItem = null;
            }
        }
    }
}
