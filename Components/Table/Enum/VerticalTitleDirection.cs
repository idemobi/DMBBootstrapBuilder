#region Copyright

// Game-Data-Forge Solution
// Written by CONTART Jean-François & BOULOGNE Quentin
// DMBBootstrapBuilder.csproj VerticalTitleDirection.cs create at 2026/04/07 21:04:27
// ©2024-2026 idéMobi SARL FRANCE

#endregion

namespace DMBBootstrapBuilder
{
    /// <summary>
    /// Defines BootstrapBuilder values for vertical title direction.
    /// </summary>
    public enum VerticalTitleDirection
    {
        /// <summary>
        /// Disables the related BootstrapBuilder option.
        /// </summary>
        None = 0,
        /// <summary>
        /// Represents the bottom to top BootstrapBuilder option.
        /// </summary>
        BottomToTop = 1,
        /// <summary>
        /// Represents the top to bottom BootstrapBuilder option.
        /// </summary>
        TopToBottom = 2
    }


    /// <summary>
    /// Provides extension methods for configuring vertical title direction in BootstrapBuilder components.
    /// </summary>
    public static class VerticalTitleDirectionExtension
    {
        #region Static methods

        /// <summary>
        /// Gets css for BootstrapBuilder rendering or composition.
        /// </summary>
        /// <param name="direction">The direction value.</param>
        /// <returns>The generated CSS class string, HTML attribute string, or rendered text value.</returns>
        public static string GetCss(this VerticalTitleDirection direction)
        {
            return direction switch
            {
                VerticalTitleDirection.BottomToTop => "th-vertical-cell th-vertical-btt",
                VerticalTitleDirection.TopToBottom => "th-vertical-cell th-vertical-ttb",
                _ => string.Empty
            };
        }

        #endregion
    }
}