#region Copyright

// Game-Data-Forge Solution
// Written by CONTART Jean-François & BOULOGNE Quentin
// DMBBootstrapBuilder.csproj AlignItemsExtension.cs create at 2026/04/08 22:04:28
// ©2024-2026 idéMobi SARL FRANCE

#endregion

namespace DMBBootstrapBuilder
{
    /// <summary>
    /// Provides extension methods for configuring align items in BootstrapBuilder components.
    /// </summary>
    public static class AlignItemsExtension
    {
        #region Static methods

        /// <summary>
        /// Gets align items css for BootstrapBuilder rendering or composition.
        /// </summary>
        /// <param name="align">The align value.</param>
        /// <returns>The generated CSS class string, HTML attribute string, or rendered text value.</returns>
        public static string GetAlignItemsCss(this AlignItems align)
        {
            return align switch
            {
                AlignItems.Start => "align-items-start",
                AlignItems.Center => "align-items-center",
                AlignItems.End => "align-items-end",
                AlignItems.Stretch => "align-items-stretch",
                _ => string.Empty
            };
        }

        #endregion
    }
}