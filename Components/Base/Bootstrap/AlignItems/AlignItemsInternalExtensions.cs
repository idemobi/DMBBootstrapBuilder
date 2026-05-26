#region Copyright

// Game-Data-Forge Solution
// Written by CONTART Jean-François & BOULOGNE Quentin
// DMBBootstrapBuilder.csproj AlignItemsInternalExtensions.cs create at 2026/04/07 21:04:27
// ©2024-2026 idéMobi SARL FRANCE

#endregion

namespace DMBBootstrapBuilder
{
    /// <summary>
    /// Provides extension methods for configuring align items internal in BootstrapBuilder components.
    /// </summary>
    public static class AlignItemsInternalExtensions
    {
        #region Static methods

        /// <summary>
        /// Gets css for BootstrapBuilder rendering or composition.
        /// </summary>
        /// <param name="alignItems">The align items value.</param>
        /// <returns>The generated CSS class string, HTML attribute string, or rendered text value.</returns>
        public static string GetCss(this AlignItems alignItems)
        {
            return alignItems switch
            {
                AlignItems.Start => "start",
                AlignItems.End => "end",
                AlignItems.Center => "center",
                AlignItems.Baseline => "baseline",
                AlignItems.Stretch => "stretch",
                _ => "start"
            };
        }

        #endregion
    }
}