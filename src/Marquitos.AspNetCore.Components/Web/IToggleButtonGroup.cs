namespace Marquitos.AspNetCore.Components.Web
{
    public interface IToggleButtonGroup
    {
        /// <summary>
        /// Gets the active item
        /// </summary>
        IToggleButton ActiveItem { get; }

        /// <summary>
        /// Adds the provided item
        /// </summary>
        /// <param name="item"></param>
        void AddItem(IToggleButton item);

        /// <summary>
        /// Removes the provided item
        /// </summary>
        /// <param name="item"></param>
        void RemoveItem(IToggleButton item);

        /// <summary>
        /// Sets the provided item as the active item
        /// </summary>
        /// <param name="item"></param>
        void Activate(IToggleButton item);

        /// <summary>
        /// Indicates if allow multiple buttons checked
        /// </summary>
        bool AllowMultipleButtonsChecked { get; set; }
    }
}
