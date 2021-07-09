using Marquitos.AspNetCore.Components.Enums;

namespace Marquitos.AspNetCore.Components.Extensions.Configuration.Options
{
    /// <summary>
    /// Configuration options
    /// </summary>
    public class ConfigurationOptions
    {
        /// <summary>
        /// Get or Set the default theme for all components
        /// </summary>
        /// <remarks>The theme can be overriden by components if needed.</remarks>
        public Theme GlobalTheme { get; set; } = Theme.Default;
    }
}
