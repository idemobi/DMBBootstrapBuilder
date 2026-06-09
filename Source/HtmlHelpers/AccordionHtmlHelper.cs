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
    ///     Represents the BootstrapBuilder accordion html helper component or support type.
    /// </summary>
    public static class AccordionHtmlHelper
    {
        #region Static methods

        /// <summary>
        ///     Executes the BootstrapBuilder accordion operation.
        /// </summary>
        /// <param name="html">The Razor HTML helper used to access view context and services.</param>
        /// <returns>The configured <see cref="AccordionBlockBuilder" /> value or BootstrapBuilder result.</returns>
        public static AccordionBlockBuilder Accordion(this IHtmlHelper html)
        {
            if (html == null)
            {
                throw new ArgumentNullException(nameof(html));
            }

            return new AccordionBlockBuilder(html.ViewContext.Writer, html);
        }

        /// <summary>
        ///     Executes the BootstrapBuilder accordion area builder operation.
        /// </summary>
        /// <param name="html">The Razor HTML helper used to access view context and services.</param>
        /// <returns>The configured <see cref="AccordionAreaBuilder" /> value or BootstrapBuilder result.</returns>
        public static AccordionAreaBuilder AccordionAreaBuilder(this IHtmlHelper html)
        {
            if (html == null)
            {
                throw new ArgumentNullException(nameof(html));
            }

            return new AccordionAreaBuilder(html.ViewContext.Writer, html);
        }

        /// <summary>
        ///     Executes the BootstrapBuilder accordion block builder operation.
        /// </summary>
        /// <param name="html">The Razor HTML helper used to access view context and services.</param>
        /// <returns>The configured <see cref="AccordionBlockBuilder" /> value or BootstrapBuilder result.</returns>
        public static AccordionBlockBuilder AccordionBlockBuilder(this IHtmlHelper html)
        {
            if (html == null)
            {
                throw new ArgumentNullException(nameof(html));
            }

            return new AccordionBlockBuilder(html.ViewContext.Writer, html);
        }

        /// <summary>
        ///     Executes the BootstrapBuilder accordions operation.
        /// </summary>
        /// <param name="html">The Razor HTML helper used to access view context and services.</param>
        /// <returns>The configured <see cref="AccordionAreaBuilder" /> value or BootstrapBuilder result.</returns>
        public static AccordionAreaBuilder Accordions(this IHtmlHelper html)
        {
            if (html == null)
            {
                throw new ArgumentNullException(nameof(html));
            }

            return new AccordionAreaBuilder(html.ViewContext.Writer, html);
        }

        #endregion
    }
}