#region Copyright

// Game-Data-Forge Solution
// Written by CONTART Jean-François & BOULOGNE Quentin
// DMBBootstrapBuilder.csproj SectionBuilderExtensions.cs create at 2026/04/07 21:04:27
// ©2024-2026 idéMobi SARL FRANCE

#endregion

#region

using DMBPageBuilder;
using Microsoft.AspNetCore.Mvc.Rendering;

#endregion

namespace DMBBootstrapBuilder
{
    /// <summary>
    /// Provides extension methods for configuring section builder in BootstrapBuilder components.
    /// </summary>
    public static class SectionBuilderExtensions
    {
        #region Static methods

        /// <summary>
        /// Executes the BootstrapBuilder section builder operation.
        /// </summary>
        /// <param name="html">The Razor HTML helper used to access view context and services.</param>
        /// <returns>The configured <see cref="DMBBootstrapBuilder.SectionBuilder"/> value or BootstrapBuilder result.</returns>
        public static SectionBuilder SectionBuilder(this IHtmlHelper html)
        {
            return new SectionBuilder(html.ViewContext.Writer, html);
        }

        /// <summary>
        /// Executes the BootstrapBuilder section builder operation.
        /// </summary>
        /// <param name="html">The Razor HTML helper used to access view context and services.</param>
        /// <param name="additionalCss">The additional css value.</param>
        /// <returns>The configured <see cref="DMBBootstrapBuilder.SectionBuilder"/> value or BootstrapBuilder result.</returns>
        public static SectionBuilder SectionBuilder(this IHtmlHelper html, string additionalCss)
        {
            return html.SectionBuilder()
                .AddClass(additionalCss);
        }

        #endregion
    }
}
