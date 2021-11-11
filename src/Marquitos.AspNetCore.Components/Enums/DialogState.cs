using Marquitos.AspNetCore.Components.Web;

namespace Marquitos.AspNetCore.Components.Enums
{
    /// <summary>
    /// State of <see cref="Dialog"/> component
    /// </summary>
    public enum DialogState
    {
        /// <summary>
        /// The Dialog is openning
        /// </summary>
        Openning,

        /// <summary>
        /// The Dialog is open
        /// </summary>
        Open,

        /// <summary>
        /// The Dialog is closing
        /// </summary>
        Closing,

        /// <summary>
        /// The Dialog is closed
        /// </summary>
        Closed
    }
}
