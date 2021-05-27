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
        ValueTask CompactAsync(ElementReference element, int to, Func<Task> callback = null);
    }
}
