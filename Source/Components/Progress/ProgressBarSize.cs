#region Copyright

// ©2002-2026 idéMobi
// www.idemobi.com

#endregion

namespace DMBBootstrapBuilder
{
    /// <summary>
    ///     Defines BootstrapBuilder values for progress bar size.
    /// </summary>
    public enum ProgressBarSize
    {
        /// <summary>
        ///     Represents the thin BootstrapBuilder option.
        /// </summary>
        Thin = 0,

        /// <summary>
        ///     Represents the small BootstrapBuilder option.
        /// </summary>
        Small,

        /// <summary>
        ///     Represents the medium BootstrapBuilder option.
        /// </summary>
        Medium,

        /// <summary>
        ///     Represents the large BootstrapBuilder option.
        /// </summary>
        Large,

        /// <summary>
        ///     Represents the thick BootstrapBuilder option.
        /// </summary>
        Thick
    }

    /// <summary>
    ///     Provides extension methods for configuring progress bar size in BootstrapBuilder components.
    /// </summary>
    public static class ProgressBarSizeExtensions
    {
        #region Static methods

        /// <summary>
        ///     Gets size and unit style for BootstrapBuilder rendering or composition.
        /// </summary>
        /// <param name="barSize">The bar size value.</param>
        /// <returns>The generated CSS class string, HTML attribute string, or rendered text value.</returns>
        public static string GetSizeAndUnitStyle(this ProgressBarSize barSize)
        {
            return barSize switch
            {
                ProgressBarSize.Thin => "1px",
                ProgressBarSize.Small => "0.375rem",
                ProgressBarSize.Medium => "1rem",
                ProgressBarSize.Large => "1.5rem",
                ProgressBarSize.Thick => "2rem",
                _ => "1rem"
            };
        }

        #endregion
    }
}