namespace Marquitos.AspNetCore.Components.Web
{
    /// <summary>
    /// Interface for Accordion Component
    /// </summary>
    public interface IAccordion
    {
        /// <summary>
        /// Gets the active item
        /// </summary>
        IAccordionItem ActiveItem { get; }

        /// <summary>
        /// Adds the provided item
        /// </summary>
        /// <param name="item"></param>
        void AddItem(IAccordionItem item);

        /// <summary>
        /// Removes the provided item
        /// </summary>
        /// <param name="item"></param>
        void RemoveItem(IAccordionItem item);

        /// <summary>
        /// Sets the provided item as the active item
        /// </summary>
        /// <param name="item"></param>
        void Activate(IAccordionItem item);
    }
}
