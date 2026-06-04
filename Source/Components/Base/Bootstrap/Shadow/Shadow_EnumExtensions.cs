#region Copyright

// ©2002-2026 idéMobi
// www.idemobi.com

#endregion

namespace DMBBootstrapBuilder
{
    /// <summary>
    ///     Provides extension methods for configuring shadow enum in BootstrapBuilder components.
    /// </summary>
    public static class Shadow_EnumExtensions
    {
        #region Static methods

        /// <summary>
        ///     Gets css for BootstrapBuilder rendering or composition.
        /// </summary>
        /// <param name="shadow">The shadow value.</param>
        /// <returns>The generated CSS class string, HTML attribute string, or rendered text value.</returns>
        public static string GetCss(this Shadow shadow)
        {
            return shadow switch
            {
                Shadow.Normal => string.Empty,
                Shadow.None => "shadow-none",
                Shadow.Small => "shadow-sm",
                Shadow.Regular => "shadow",
                Shadow.Large => "shadow-lg",
                _ => string.Empty
            };
        }

        /// <summary>
        ///     Gets text css for BootstrapBuilder rendering or composition.
        /// </summary>
        /// <param name="shadow">The shadow value.</param>
        /// <returns>The generated CSS class string, HTML attribute string, or rendered text value.</returns>
        public static string GetTextCss(this Shadow shadow)
        {
            return shadow switch
            {
                Shadow.Normal => string.Empty,
                Shadow.None => "text-shadow-none",
                Shadow.Small => "text-shadow-sm",
                Shadow.Regular => "text-shadow",
                Shadow.Large => "text-shadow-lg",
                _ => string.Empty
            };
        }

        #endregion
    }
}