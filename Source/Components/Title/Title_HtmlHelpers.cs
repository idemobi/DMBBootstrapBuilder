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
    ///     Represents the BootstrapBuilder title html helpers component or support type.
    /// </summary>
    public static class Title_HtmlHelpers
    {
        #region Static methods

        /// <summary>
        ///     Executes the BootstrapBuilder title builder operation.
        /// </summary>
        /// <param name="html">The Razor HTML helper used to access view context and services.</param>
        /// <returns>The configured <see cref="TitleBuilder" /> value or BootstrapBuilder result.</returns>
        [Documented]
        public static TitleBuilder TitleBuilder(this IHtmlHelper html)
        {
            return new TitleBuilder(html.ViewContext.Writer, html);
        }

        #endregion
    }
}