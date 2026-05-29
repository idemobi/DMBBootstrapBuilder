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
    ///     Provides extension methods for configuring col builder in BootstrapBuilder components.
    /// </summary>
    public static class ColBuilderExtensions
    {
        #region Static methods

        /// <summary>
        ///     Executes the BootstrapBuilder col builder operation.
        /// </summary>
        /// <param name="html">The Razor HTML helper used to access view context and services.</param>
        /// <returns>The configured <see cref="DMBBootstrapBuilder.ColBuilder" /> value or BootstrapBuilder result.</returns>
        public static ColBuilder ColBuilder(this IHtmlHelper html)
        {
            return new ColBuilder(html.ViewContext.Writer, html);
        }

        /// <summary>
        ///     Executes the BootstrapBuilder col builder operation.
        /// </summary>
        /// <param name="html">The Razor HTML helper used to access view context and services.</param>
        /// <param name="col">The col value.</param>
        /// <param name="colSm">The col sm value.</param>
        /// <param name="colMd">The col md value.</param>
        /// <param name="colLg">The col lg value.</param>
        /// <param name="colXl">The col xl value.</param>
        /// <param name="colXxl">The col xxl value.</param>
        /// <param name="additionalClasses">The additional classes value.</param>
        /// <returns>The configured <see cref="DMBBootstrapBuilder.ColBuilder" /> value or BootstrapBuilder result.</returns>
        public static ColBuilder ColBuilder(
            this IHtmlHelper html,
            int col,
            int colSm,
            int colMd,
            int colLg,
            int colXl,
            int colXxl,
            string additionalClasses = ""
        )
        {
            return html.ColBuilder()
                .SetCol(ToColSize(col))
                .SetCol(ToColSize(colSm), ResponsiveBreakpoint.Sm)
                .SetCol(ToColSize(colMd), ResponsiveBreakpoint.Md)
                .SetCol(ToColSize(colLg), ResponsiveBreakpoint.Lg)
                .SetCol(ToColSize(colXl), ResponsiveBreakpoint.Xl)
                .SetCol(ToColSize(colXxl), ResponsiveBreakpoint.Xxl)
                .AddClass(additionalClasses);
        }

        /// <summary>
        ///     Executes the BootstrapBuilder col central builder operation.
        /// </summary>
        /// <param name="html">The Razor HTML helper used to access view context and services.</param>
        /// <returns>The configured <see cref="DMBBootstrapBuilder.ColBuilder" /> value or BootstrapBuilder result.</returns>
        public static ColBuilder ColCentralBuilder(this IHtmlHelper html)
        {
            return html.ColBuilder()
                .AddClasses("d-flex", "justify-content-center", "align-items-center");
        }

        private static ColSize ToColSize(int size)
        {
            if (size < 1) return ColSize.None;

            if (size > 12) return ColSize.Col12;

            return (ColSize)size;
        }

        #endregion
    }
}