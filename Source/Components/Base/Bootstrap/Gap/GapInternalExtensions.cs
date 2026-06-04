#region Copyright

// ©2002-2026 idéMobi
// www.idemobi.com

#endregion

namespace DMBBootstrapBuilder
{
    /// <summary>
    ///     Provides extension methods for configuring gap internal in BootstrapBuilder components.
    /// </summary>
    public static class GapInternalExtensions
    {
        #region Static methods

        /// <summary>
        ///     Gets css for BootstrapBuilder rendering or composition.
        /// </summary>
        /// <param name="gap">The gap value.</param>
        /// <returns>The generated CSS class string, HTML attribute string, or rendered text value.</returns>
        public static string GetCss(this Gap gap)
        {
            return ((int)gap).ToString();
        }

        #endregion
    }
}