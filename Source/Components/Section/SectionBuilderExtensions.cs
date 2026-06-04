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
    ///     Provides extension methods for configuring section builder in BootstrapBuilder components.
    /// </summary>
    public static class SectionBuilderExtensions
    {
        #region Static methods

        /// <summary>
        ///     Executes the BootstrapBuilder section builder operation.
        /// </summary>
        /// <param name="html">The Razor HTML helper used to access view context and services.</param>
        /// <returns>The configured <see cref="DMBBootstrapBuilder.SectionBuilder" /> value or BootstrapBuilder result.</returns>
        public static SectionBuilder SectionBuilder(this IHtmlHelper html)
        {
            return new SectionBuilder(html.ViewContext.Writer, html);
        }

        /// <summary>
        ///     Executes the BootstrapBuilder section builder operation.
        /// </summary>
        /// <param name="html">The Razor HTML helper used to access view context and services.</param>
        /// <param name="additionalCss">The additional css value.</param>
        /// <returns>The configured <see cref="DMBBootstrapBuilder.SectionBuilder" /> value or BootstrapBuilder result.</returns>
        public static SectionBuilder SectionBuilder(this IHtmlHelper html, string additionalCss)
        {
            return html.SectionBuilder()
                .AddClass(additionalCss);
        }

        #endregion
    }
}