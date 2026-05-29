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
    ///     Provides extension methods for configuring spinner in BootstrapBuilder components.
    /// </summary>
    public static class SpinnerExtensions
    {
        #region Static methods

        /// <summary>
        ///     Executes the BootstrapBuilder loading block operation.
        /// </summary>
        /// <param name="html">The Razor HTML helper used to access view context and services.</param>
        /// <returns>The configured <see cref="LoadingBlockBuilder" /> value or BootstrapBuilder result.</returns>
        public static LoadingBlockBuilder LoadingBlock(this IHtmlHelper html)
        {
            if (html == null)
            {
                throw new ArgumentNullException(nameof(html));
            }

            return new LoadingBlockBuilder(html.ViewContext.Writer, html);
        }

        /// <summary>
        ///     Executes the BootstrapBuilder spinner operation.
        /// </summary>
        /// <param name="html">The Razor HTML helper used to access view context and services.</param>
        /// <returns>The configured <see cref="SpinnerBuilder" /> value or BootstrapBuilder result.</returns>
        public static SpinnerBuilder Spinner(this IHtmlHelper html)
        {
            if (html == null)
            {
                throw new ArgumentNullException(nameof(html));
            }

            return new SpinnerBuilder(html.ViewContext.Writer, html);
        }

        #endregion
    }
}