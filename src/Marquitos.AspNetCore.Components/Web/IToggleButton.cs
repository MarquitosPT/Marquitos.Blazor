namespace Marquitos.AspNetCore.Components.Web
{
    /// <summary>
    /// Interface for Toggle Button
    /// </summary>
    public interface IToggleButton
    {
        /// <summary>
        /// Gets or sets if it is checked
        /// </summary>
        public bool IsChecked { get; set; }

        /// <summary>
        /// Toggles between checked or unchecked state
        /// </summary>
        /// <returns></returns>
        void Toggle();
    }
}
