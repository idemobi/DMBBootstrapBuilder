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
    ///     Provides extension methods for configuring row builder in BootstrapBuilder components.
    /// </summary>
    public static class RowBuilderExtensions
    {
        #region Static methods

        /// <summary>
        ///     Executes the BootstrapBuilder row builder operation.
        /// </summary>
        /// <param name="html">The Razor HTML helper used to access view context and services.</param>
        /// <returns>The configured <see cref="DMBBootstrapBuilder.RowBuilder" /> value or BootstrapBuilder result.</returns>
        public static RowBuilder RowBuilder(this IHtmlHelper html)
        {
            return new RowBuilder(html.ViewContext.Writer, html);
        }

        /// <summary>
        ///     Executes the BootstrapBuilder row builder operation.
        /// </summary>
        /// <param name="html">The Razor HTML helper used to access view context and services.</param>
        /// <param name="gap">The gap value.</param>
        /// <param name="additionalCss">The additional css value.</param>
        /// <returns>The configured <see cref="DMBBootstrapBuilder.RowBuilder" /> value or BootstrapBuilder result.</returns>
        public static RowBuilder RowBuilder(this IHtmlHelper html, int gap, string additionalCss = "")
        {
            return html.RowBuilder()
                .SetGap(ToGap(gap))
                .AddClass(additionalCss);
        }

        private static Gap ToGap(int gap)
        {
            if (gap < 0) return Gap.G0;

            if (gap > 5) return Gap.G5;

            return (Gap)gap;
        }

        #endregion
    }
}