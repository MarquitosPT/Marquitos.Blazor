namespace Marquitos.AspNetCore.Components.Web
{
    public interface ITabSet
    {
        ITabPage ActivePage { get; }

        void AddPage(ITabPage page);

        void RemovePage(ITabPage page);

        void Activate(ITabPage page);
    }
}
