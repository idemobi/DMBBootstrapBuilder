#region Copyright

// Game-Data-Forge Solution
// Written by CONTART Jean-François & BOULOGNE Quentin
// DMBBootstrapBuilder.csproj HtmlProgressExtensions.cs create at 2026/04/07 21:04:27
// ©2024-2026 idéMobi SARL FRANCE

#endregion

#region

using Microsoft.AspNetCore.Mvc.Rendering;

#endregion

namespace DMBBootstrapBuilder
{
    /// <summary>
    /// Provides extension methods for configuring html progress in BootstrapBuilder components.
    /// </summary>
    public static class HtmlProgressExtensions
    {
        #region Static methods

        /// <summary>
        /// Executes the BootstrapBuilder progress bar operation.
        /// </summary>
        /// <param name="html">The Razor HTML helper used to access view context and services.</param>
        /// <returns>The configured <see cref="ProgressBarBuilder"/> value or BootstrapBuilder result.</returns>
        public static ProgressBarBuilder ProgressBar(this IHtmlHelper html)
        {
            if (html == null)
            {
                throw new ArgumentNullException(nameof(html));
            }

            return new ProgressBarBuilder(html.ViewContext.Writer, html);
        }

        /// <summary>
        /// Executes the BootstrapBuilder progress bar stack operation.
        /// </summary>
        /// <param name="html">The Razor HTML helper used to access view context and services.</param>
        /// <returns>The configured <see cref="ProgressBarStackBuilder"/> value or BootstrapBuilder result.</returns>
        public static ProgressBarStackBuilder ProgressBarStack(this IHtmlHelper html)
        {
            if (html == null)
            {
                throw new ArgumentNullException(nameof(html));
            }

            return new ProgressBarStackBuilder(html.ViewContext.Writer, html);
        }

        #endregion
    }
}