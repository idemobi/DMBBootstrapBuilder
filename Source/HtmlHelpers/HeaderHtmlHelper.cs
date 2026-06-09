#region Copyright

// ©2002-2026 idéMobi
// www.idemobi.com

#endregion

#region

using DMBPageBuilder;
using Microsoft.AspNetCore.Mvc.Rendering;

#endregion

namespace DMBBootstrapBuilder
{
    /// <summary>
    ///     Represents the BootstrapBuilder header html helper component or support type.
    /// </summary>
    public static class HeaderHtmlHelper
    {
        #region Static methods

        /// <summary>
        ///     Executes the BootstrapBuilder header builder operation.
        /// </summary>
        /// <param name="html">The Razor HTML helper used to access view context and services.</param>
        /// <returns>The configured <see cref="HeaderBuilder" /> value or BootstrapBuilder result.</returns>
        public static HeaderBuilder HeaderBuilder(this IHtmlHelper html)
        {
            var context = HtmlRenderContextManager.Current(html);

            if (context == null)
            {
                throw new InvalidOperationException($"Html.{nameof(HeaderBuilder)} must be used inside a render context.");
            }

            return new HeaderBuilder(html.ViewContext.Writer, html, context);
        }

        #endregion
    }
}