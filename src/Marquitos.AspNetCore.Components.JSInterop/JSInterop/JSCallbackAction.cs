using Microsoft.JSInterop;
using System;
using System.Threading.Tasks;

namespace Marquitos.AspNetCore.Components.JSInterop
{
    public class JSCallbackAction
    {
        private readonly Func<Task> _callback;

        public JSCallbackAction(Func<Task> callback)
        {
            _callback = callback;
        }

        [JSInvokable]
        public async ValueTask CallbackAsync()
        {
            if (_callback != null)
            {
                await _callback.Invoke();
            }
        }
    }

    public class JSCallbackAction<T>
    {
        private readonly Func<T, Task> _callback;

        public JSCallbackAction(Func<T, Task> callback)
        {
            _callback = callback;
        }

        [JSInvokable]
        public async ValueTask CallbackAsync(T arg)
        {
            if (_callback != null)
            {
                await _callback.Invoke(arg);
            }
        }
    }

    public class JSCallbackAction<T,TResult>
    {
        private readonly Func<T, Task<TResult>> _callback;

        public JSCallbackAction(Func<T, Task<TResult>> callback)
        {
            _callback = callback;
        }

        [JSInvokable]
        public async ValueTask<TResult> CallbackAsync(T arg)
        {
            if (_callback != null)
            {
                return await _callback.Invoke(arg);
            }

            return default;
        }
    }
}
