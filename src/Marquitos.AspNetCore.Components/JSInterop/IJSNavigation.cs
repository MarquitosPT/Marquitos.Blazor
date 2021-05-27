using System.Threading.Tasks;

namespace Marquitos.AspNetCore.Components.JSInterop
{
    public interface IJSNavigation
    {
        ValueTask InitializeAsync();

        ValueTask<bool> CanGoBackAsync();

        ValueTask BackAsync();
        
        ValueTask ForwardAsync();
    }
}
