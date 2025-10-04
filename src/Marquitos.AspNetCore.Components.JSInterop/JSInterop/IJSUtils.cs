using Marquitos.AspNetCore.Components.Events;
using Microsoft.AspNetCore.Components;
using System;
using System.Drawing;
using System.Threading.Tasks;

namespace Marquitos.AspNetCore.Components.JSInterop
{
    public interface IJSUtils
    {
        ValueTask InitializeAsync();
        ValueTask ClickAsync(ElementReference element);
        ValueTask FocusAsync(ElementReference element);
        ValueTask<int> GetWindowWidthAsync();
        ValueTask<int> GetWindowHeightAsync();
        ValueTask<int> GetWidthAsync(ElementReference element);
        ValueTask<int> GetHeightAsync(ElementReference element);
        ValueTask<string> GetPropertyAsync(ElementReference element, string name);
        ValueTask<Size> GetSizeAsync(ElementReference element);

        ValueTask ResizeAsync(ElementReference element, string width, string height);
        ValueTask SetWidthAsync(ElementReference element, string width);
        ValueTask SetHeightAsync(ElementReference element, string height);

        ValueTask SetPropertyAsync(ElementReference element, string name, string value);

        /// <summary>
        /// Add the class name to element class list
        /// </summary>
        /// <param name="element"></param>
        /// <param name="name"></param>
        /// <returns></returns>
        ValueTask AddClassAsync(ElementReference element, string name);

        /// <summary>
        /// Remove the class name from the element class list
        /// </summary>
        /// <param name="element"></param>
        /// <param name="name"></param>
        /// <returns></returns>
        ValueTask RemoveClassAsync(ElementReference element, string name);

        /// <summary>
        /// Add or Remove the clas name from the element class list
        /// </summary>
        /// <param name="element"></param>
        /// <param name="name"></param>
        /// <returns></returns>
        ValueTask ToggleClassAsync(ElementReference element, string name);

        /// <summary>
        /// Checks if the class name exists in element calss list
        /// </summary>
        /// <param name="element"></param>
        /// <param name="name"></param>
        /// <returns></returns>
        ValueTask<bool> HasClassAsync(ElementReference element, string name);

        /// <summary>
        /// Checks if the element has focus
        /// </summary>
        /// <param name="element"></param>
        /// <returns></returns>
        ValueTask<bool> HasFocusAsync(ElementReference element);

        EventHandler<ResizeArgs> OnWindowResize { get; set; }
    }
}
