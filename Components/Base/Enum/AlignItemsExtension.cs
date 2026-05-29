#region Copyright

// ©2002-2026 idéMobi
// www.idemobi.com

#endregion

namespace DMBBootstrapBuilder
{
    /// <summary>
    ///     Provides extension methods for configuring align items in BootstrapBuilder components.
    /// </summary>
    public static class AlignItemsExtension
    {
        #region Static methods

        /// <summary>
        ///     Gets align items css for BootstrapBuilder rendering or composition.
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