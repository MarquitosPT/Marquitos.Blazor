using Marquitos.AspNetCore.Components.Enums;
using Microsoft.AspNetCore.Components;
using System;
using System.Threading.Tasks;

namespace Marquitos.AspNetCore.Components.JSInterop
{
    public interface IJSAnimation
    {
        ValueTask InitializeAsync();
        ValueTask PlayAsync(AnimationType animation, ElementReference element, Func<Task> callback = null);

        ValueTask GrowAsync(ElementReference element, int from, Func<Task> callback = null);
        ValueTask GrowAsync(ElementReference element, int from, int duration, Func<Task> callback = null);
        ValueTask GrowAndExpandAsync(ElementReference element, int fromWidth, int fromHeight, Func<Task> callback = null);
        ValueTask CompactAsync(ElementReference element, int to, Func<Task> callback = null);
        ValueTask CompactAsync(ElementReference element, int to, int duration, Func<Task> callback = null);
        ValueTask CompactAndCollapseAsync(ElementReference element, int toWidth, int toHeight, Func<Task> callback = null);
    }
}
