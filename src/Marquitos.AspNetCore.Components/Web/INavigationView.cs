namespace Marquitos.AspNetCore.Components.Web
{
    public interface INavigationView
    {
        INavigationViewItem ActiveMenu { get; }

        void Add(INavigationViewItem item);
        void Remove(INavigationViewItem item);
        void Activate(INavigationViewItem item);
        void NavigateTo(string uri, bool forceLoad = false);
    }
}
