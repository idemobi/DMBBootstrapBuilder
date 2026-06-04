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
    ///     Provides extension methods for configuring html layout in BootstrapBuilder components.
    /// </summary>
    public static partial class HtmlLayoutExtensions
    {
        #region Static methods

        /// <summary>
        ///     Executes the BootstrapBuilder navbar builder operation.
        /// </summary>
        /// <param name="html">The Razor HTML helper used to access view context and services.</param>
        /// <returns>The configured <see cref="NavbarBuilder" /> value or BootstrapBuilder result.</returns>
        public static NavbarBuilder NavbarBuilder(this IHtmlHelper html)
        {
            return new NavbarBuilder(html.ViewContext.Writer, html);
        }

        #endregion
    }
}