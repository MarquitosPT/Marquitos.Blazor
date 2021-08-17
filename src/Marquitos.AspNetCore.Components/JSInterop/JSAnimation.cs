using Marquitos.AspNetCore.Components.Enums;
using Microsoft.AspNetCore.Components;
using Microsoft.JSInterop;
using System;
using System.Threading.Tasks;

namespace Marquitos.AspNetCore.Components.JSInterop
{
    public class JSAnimation : IJSAnimation, IAsyncDisposable
    {
        private readonly Lazy<Task<IJSObjectReference>> moduleTask;

        public JSAnimation(IJSRuntime jsRuntime)
        {
            moduleTask = new(() => jsRuntime.InvokeAsync<IJSObjectReference>(
               "import", "./_content/Marquitos.AspNetCore.Components/js/animation.min.js").AsTask());
        }

        public async ValueTask InitializeAsync()
        {
            if (!moduleTask.IsValueCreated)
            {
                await moduleTask.Value;
            }
        }

        public async ValueTask PlayAsync(AnimationType animation, ElementReference element, Func<Task> callback = null)
        {
            string method = animation switch
            {
                AnimationType.None => "",
                AnimationType.FadeIn => "Animation.fadeIn",
                AnimationType.FadeOut => "Animation.fadeOut",
                AnimationType.SlideInFromTop => "Animation.slideInFromTop",
                AnimationType.SlideInFromBottom => "Animation.slideInFromBottom",
                AnimationType.SlideInFromLeft => "Animation.slideInFromLeft",
                AnimationType.SlideInFromRight => "Animation.slideInFromRight",
                AnimationType.SlideOutToTop => "Animation.slideOutToTop",
                AnimationType.SlideOutToBottom => "Animation.slideOutToBottom",
                AnimationType.SlideOutToLeft => "Animation.slideOutToLeft",
                AnimationType.SlideOutToRight => "Animation.slideOutToRight",
                AnimationType.Expand => "Animation.expand",
                AnimationType.Collapse => "Animation.collapse",
                AnimationType.Grow => "Animation.grow",
                AnimationType.Compact => "Animation.compact",
                _ => throw new Exception($"Animation '{nameof(animation)}' not suported."),
            };

            if (animation == AnimationType.None)
            {
                await callback.Invoke();
            }
            else
            {
                var module = await moduleTask.Value;
                await module.InvokeVoidAsync(method, element, DotNetObjectReference.Create(new JSCallbackAction(callback)));
            }
        }

        public async ValueTask GrowAsync(ElementReference element, int from, Func<Task> callback = null)
        {
            var module = await moduleTask.Value;
            await module.InvokeVoidAsync("Animation.grow", element, DotNetObjectReference.Create(new JSCallbackAction(callback)), from);
        }

        public async ValueTask GrowAsync(ElementReference element, int from, int duration, Func<Task> callback = null)
        {
            var module = await moduleTask.Value;
            await module.InvokeVoidAsync("Animation.grow", element, DotNetObjectReference.Create(new JSCallbackAction(callback)), from, duration);
        }

        public async ValueTask GrowAndExpandAsync(ElementReference element, int fromWidth, int fromHeight, Func<Task> callback = null)
        {
            var module = await moduleTask.Value;
            await module.InvokeVoidAsync("Animation.growAndExpand", element, DotNetObjectReference.Create(new JSCallbackAction(callback)), fromWidth, fromHeight);
        }

        public async ValueTask CompactAsync(ElementReference element, int to, Func<Task> callback = null)
        {
            var module = await moduleTask.Value;
            await module.InvokeVoidAsync("Animation.compact", element, DotNetObjectReference.Create(new JSCallbackAction(callback)), to);
        }

        public async ValueTask CompactAndCollapseAsync(ElementReference element, int toWidth, int toHeight, Func<Task> callback = null)
        {
            var module = await moduleTask.Value;
            await module.InvokeVoidAsync("Animation.compactAndCollapse", element, DotNetObjectReference.Create(new JSCallbackAction(callback)), toWidth, toHeight);
        }

        public async ValueTask DisposeAsync()
        {
            if (moduleTask.IsValueCreated)
            {
                var module = await moduleTask.Value;
                await module.DisposeAsync();
            }
        }

    }
}
