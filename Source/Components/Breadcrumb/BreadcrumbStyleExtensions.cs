#region Copyright

// ©2002-2026 idéMobi
// www.idemobi.com

#endregion

namespace DMBBootstrapBuilder
{
    /// <summary>
    ///     Provides extension methods for configuring breadcrumb style in BootstrapBuilder components.
    /// </summary>
    public static class BreadcrumbStyleExtensions
    {
        #region Static methods

        /// <summary>
        ///     Gets css class for BootstrapBuilder rendering or composition.
        /// </summary>
        /// <param name="style">The style value.</param>
        /// <returns>The generated CSS class string, HTML attribute string, or rendered text value.</returns>
        public static string GetCssClass(this BreadcrumbStyle style)
        {
            return style switch
            {
                BreadcrumbStyle.Default => string.Empty,
                BreadcrumbStyle.Subtle => "breadcrumb-minimal",
                _ => string.Empty
            };
        }

        #endregion
    }
}