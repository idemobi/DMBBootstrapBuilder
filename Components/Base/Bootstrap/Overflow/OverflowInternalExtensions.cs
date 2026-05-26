#region Copyright

// Game-Data-Forge Solution
// Written by CONTART Jean-François & BOULOGNE Quentin
// DMBBootstrapBuilder.csproj OverflowInternalExtensions.cs create at 2026/04/07 21:04:27
// ©2024-2026 idéMobi SARL FRANCE

#endregion

namespace DMBBootstrapBuilder
{
    /// <summary>
    /// Provides extension methods for configuring overflow internal in BootstrapBuilder components.
    /// </summary>
    public static class OverflowInternalExtensions
    {
        #region Static methods

        /// <summary>
        /// Gets css for BootstrapBuilder rendering or composition.
        /// </summary>
        /// <param name="overflowValue">The overflow value value.</param>
        /// <returns>The generated CSS class string, HTML attribute string, or rendered text value.</returns>
        public static string GetCss(this OverflowValue overflowValue)
        {
            return overflowValue switch
            {
                OverflowValue.None => string.Empty,
                OverflowValue.Auto => "auto",
                OverflowValue.Hidden => "hidden",
                OverflowValue.Visible => "visible",
                OverflowValue.Scroll => "scroll",
                _ => string.Empty
            };
        }

        #endregion
    }
}