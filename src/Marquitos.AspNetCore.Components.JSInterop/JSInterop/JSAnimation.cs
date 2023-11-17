using Marquitos.AspNetCore.Components.Enums;
using Marquitos.AspNetCore.Components.JSInterop.Extensions.Configuration.Options;
using Microsoft.AspNetCore.Components;
using Microsoft.Extensions.Options;
using Microsoft.JSInterop;
using System;
using System.Threading.Tasks;

namespace Marquitos.AspNetCore.Components.JSInterop
{
    public class JSAnimation : IJSAnimation, IAsyncDisposable
    {
        private readonly JSInteropOptions _options;
        private readonly Lazy<Task<IJSObjectReference>> moduleTask;

        public JSAnimation(IOptions<JSInteropOptions> options, IJSRuntime jsRuntime)
        {
            _options = options.Value;

            var baseStr = _options.Framework == Enums.FrameworkType.WebAssembly ? "./" : "";

            moduleTask = new(() => jsRuntime.InvokeAsync<IJSObjectReference>(
               "import", baseStr + "_content/Marquitos.AspNetCore.Components.JSInterop/js/animation.min.js").AsTask());
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

        public async ValueTask FadeInAsync(ElementReference element, Func<Task> callback = null)
        {
            await FadeInAsync(element, 250, callback);
        }

        public async ValueTask FadeInAsync(ElementReference element, int duration, Func<Task> callback = null)
        {
            var module = await moduleTask.Value;
            await module.InvokeVoidAsync("Animation.fadeIn", element, DotNetObjectReference.Create(new JSCallbackAction(callback)), duration);
        }

        public async ValueTask FadeOutAsync(ElementReference element, Func<Task> callback = null)
        {
            await FadeOutAsync(element, 150, callback);
        }

        public async ValueTask FadeOutAsync(ElementReference element, int duration, Func<Task> callback = null)
        { 
            var module = await moduleTask.Value; 
            await module.InvokeVoidAsync("Animation.fadeOut", element, DotNetObjectReference.Create(new JSCallbackAction(callback)), duration);
        }

        public async ValueTask ExpandAsync(ElementReference element, int from, Func<Task> callback = null)
        {
            await ExpandAsync(element, from, 300, callback);
        }

        public async ValueTask ExpandAsync(ElementReference element, int from, int duration, Func<Task> callback = null)
        {
            var module = await moduleTask.Value;
            await module.InvokeVoidAsync("Animation.expand", element, DotNetObjectReference.Create(new JSCallbackAction(callback)), from, duration);
        }

        public async ValueTask CollapseAsync(ElementReference element, int to, Func<Task> callback = null)
        {
            await CollapseAsync(element, to, 300, callback);
        }

        public async ValueTask CollapseAsync(ElementReference element, int to, int duration, Func<Task> callback = null)
        {
            var module = await moduleTask.Value;
            await module.InvokeVoidAsync("Animation.collapse", element, DotNetObjectReference.Create(new JSCallbackAction(callback)), to, duration);
        }

        public async ValueTask GrowAsync(ElementReference element, int from, Func<Task> callback = null)
        {
            await GrowAsync(element, from, 300, callback);
        }

        public async ValueTask GrowAsync(ElementReference element, int from, int duration, Func<Task> callback = null)
        {
            var module = await moduleTask.Value;
            await module.InvokeVoidAsync("Animation.grow", element, DotNetObjectReference.Create(new JSCallbackAction(callback)), from, duration);
        }

        public async ValueTask CompactAsync(ElementReference element, int to, Func<Task> callback = null)
        {
            await CompactAsync(element, to, 300, callback);
        }

        public async ValueTask CompactAsync(ElementReference element, int to, int duration, Func<Task> callback = null)
        {
            var module = await moduleTask.Value;
            await module.InvokeVoidAsync("Animation.compact", element, DotNetObjectReference.Create(new JSCallbackAction(callback)), to, duration);
        }

        public async ValueTask GrowAndExpandAsync(ElementReference element, int fromWidth, int fromHeight, Func<Task> callback = null)
        {
            await GrowAndExpandAsync(element, fromWidth, fromHeight, 300, callback);
        }

        public async ValueTask GrowAndExpandAsync(ElementReference element, int fromWidth, int fromHeight, int duration, Func<Task> callback = null)
        {
            var module = await moduleTask.Value;
            await module.InvokeVoidAsync("Animation.growAndExpand", element, DotNetObjectReference.Create(new JSCallbackAction(callback)), fromWidth, fromHeight, duration);
        }

        public async ValueTask CompactAndCollapseAsync(ElementReference element, int toWidth, int toHeight, Func<Task> callback = null)
        {
            await CompactAndCollapseAsync(element, toWidth, toHeight, 300, callback);
        }

        public async ValueTask CompactAndCollapseAsync(ElementReference element, int toWidth, int toHeight, int duration, Func<Task> callback = null)
        {
            var module = await moduleTask.Value;
            await module.InvokeVoidAsync("Animation.compactAndCollapse", element, DotNetObjectReference.Create(new JSCallbackAction(callback)), toWidth, toHeight, duration);
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
