namespace Marquitos.AspNetCore.Components.Web
{
    /// <summary>
    /// Interface for Accordion Item
    /// </summary>
    public interface IAccordionItem
    {
        /// <summary>
        /// Gets or sets if it is open
        /// </summary>
        public bool IsOpen { get; set; }

        /// <summary>
        /// Toggles between open or closed state
        /// </summary>
        /// <returns></returns>
        void Toggle();
    }
}
