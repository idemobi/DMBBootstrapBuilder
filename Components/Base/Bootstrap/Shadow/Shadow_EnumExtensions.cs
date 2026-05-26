#region Copyright

// Game-Data-Forge Solution
// Written by CONTART Jean-François & BOULOGNE Quentin
// DMBBootstrapBuilder.csproj Shadow_EnumExtensions.cs create at 2026/04/07 21:04:27
// ©2024-2026 idéMobi SARL FRANCE

#endregion

namespace DMBBootstrapBuilder
{
    /// <summary>
    /// Provides extension methods for configuring shadow enum in BootstrapBuilder components.
    /// </summary>
    public static class Shadow_EnumExtensions
    {
        #region Static methods

        /// <summary>
        /// Gets css for BootstrapBuilder rendering or composition.
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
        /// Gets text css for BootstrapBuilder rendering or composition.
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