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
    ///     Represents the BootstrapBuilder footer html helper component or support type.
    /// </summary>
    public static class FooterHtmlHelper
    {
        #region Static methods

        /// <summary>
        ///     Executes the BootstrapBuilder footer builder operation.
        /// </summary>
        /// <param name="html">The Razor HTML helper used to access view context and services.</param>
        /// <returns>The configured <see cref="FooterBuilder" /> value or BootstrapBuilder result.</returns>
        public static FooterBuilder FooterBuilder(this IHtmlHelper html)
        {
            var context = HtmlRenderContextManager.Current(html);

            if (context == null)
            {
                throw new InvalidOperationException($"Html.{nameof(FooterBuilder)} must be used inside a supported render context.");
            }

            return new FooterBuilder(html.ViewContext.Writer, html, context);
        }

        #endregion
    }
}