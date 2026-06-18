#region Copyright

// ©2002-2026 idéMobi
// www.idemobi.com

#endregion

#region

using Microsoft.AspNetCore.Mvc.Rendering;

#endregion

namespace DMBBootstrapBuilder
{
    /// <summary>
    ///     Provides Razor HTML helper extensions for Bootstrap pagination components.
    /// </summary>
    public static class PaginationHtmlHelper
    {
        #region Static methods

        /// <summary>
        ///     Creates a Bootstrap pagination builder for the current Razor view.
        /// </summary>
        /// <param name="html">The Razor HTML helper used to access view context and services.</param>
        /// <returns>The configured <see cref="PaginationBuilder" /> value or BootstrapBuilder result.</returns>
        public static PaginationBuilder PaginationBuilder(this IHtmlHelper html)
        {
            ArgumentNullException.ThrowIfNull(html);

            return new PaginationBuilder(html.ViewContext.Writer, html);
        }

        #endregion
    }
}
