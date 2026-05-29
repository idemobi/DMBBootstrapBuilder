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
    ///     Represents the BootstrapBuilder logo html helper component or support type.
    /// </summary>
    public static class LogoHtmlHelper
    {
        #region Static methods

        /// <summary>
        ///     Executes the BootstrapBuilder logo builder operation.
        /// </summary>
        /// <param name="html">The Razor HTML helper used to access view context and services.</param>
        /// <param name="source">The source value.</param>
        /// <returns>The configured <see cref="LogoBuilder" /> value or BootstrapBuilder result.</returns>
        public static LogoBuilder LogoBuilder(this IHtmlHelper html, string? source = "/logo/logo.svg")
        {
            if (html == null)
            {
                throw new ArgumentNullException(nameof(html));
            }

            return new LogoBuilder(html.ViewContext.Writer, html)
                .SetSource(source);
        }

        #endregion
    }
}