namespace Marquitos.AspNetCore.Components.Web
{
    /// <summary>
    /// Interface for a BreadcrumbItem compoment
    /// </summary>
    public interface IBreadcrumbItem
    {
        /// <summary>
        /// Destination Url
        /// </summary>
        public string Uri { get; set; }
    }
}
