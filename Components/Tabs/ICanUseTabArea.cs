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
    ///     Defines the contract for BootstrapBuilder components that can configure tab area.
    /// </summary>
    public interface ICanUseTabArea
    {
    }


    /// <summary>
    ///     Provides extension methods for configuring html tab in BootstrapBuilder components.
    /// </summary>
    public static class HtmlTabExtensions
    {
        #region Static methods

        /// <summary>
        ///     Executes the BootstrapBuilder tab area builder operation.
        /// </summary>
        /// <param name="html">The Razor HTML helper used to access view context and services.</param>
        /// <returns>The configured <see cref="TabAreaBuilder" /> value or BootstrapBuilder result.</returns>
        public static TabAreaBuilder TabAreaBuilder(this IHtmlHelper html)
        {
            if (html == null)
            {
                throw new ArgumentNullException(nameof(html));
            }

            return new TabAreaBuilder(html.ViewContext.Writer, html);
        }

        /// <summary>
        ///     Executes the BootstrapBuilder tab block builder operation.
        /// </summary>
        /// <param name="html">The Razor HTML helper used to access view context and services.</param>
        /// <returns>The configured <see cref="TabBlockBuilder" /> value or BootstrapBuilder result.</returns>
        public static TabBlockBuilder TabBlockBuilder(this IHtmlHelper html)
        {
            if (html == null)
            {
                throw new ArgumentNullException(nameof(html));
            }

            return new TabBlockBuilder(html.ViewContext.Writer, html);
        }

        #endregion
    }
}