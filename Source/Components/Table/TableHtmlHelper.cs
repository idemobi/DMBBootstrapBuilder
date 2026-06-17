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
    ///     Provides extension methods for configuring html table in BootstrapBuilder components.
    /// </summary>
    public static class TableHtmlHelper
    {
        #region Static methods

        /// <summary>
        ///     Executes the BootstrapBuilder table body builder operation.
        /// </summary>
        /// <param name="html">The Razor HTML helper used to access view context and services.</param>
        /// <returns>The configured <see cref="TableSectionBuilder" /> value or BootstrapBuilder result.</returns>
        public static TableSectionBuilder TableBodyBuilder(this IHtmlHelper html)
        {
            return new TableSectionBuilder(html.ViewContext.Writer, html, TableSectionKind.Body);
        }

        /// <summary>
        ///     Executes the BootstrapBuilder table builder operation.
        /// </summary>
        /// <param name="html">The Razor HTML helper used to access view context and services.</param>
        /// <returns>The configured <see cref="TableBuilder" /> value or BootstrapBuilder result.</returns>
        public static TableBuilder TableBuilder(this IHtmlHelper html)
        {
            return new TableBuilder(html.ViewContext.Writer, html);
        }

        /// <summary>
        ///     Executes the BootstrapBuilder table cell builder operation.
        /// </summary>
        /// <param name="html">The Razor HTML helper used to access view context and services.</param>
        /// <param name="isHeader">The is header value.</param>
        /// <returns>The configured <see cref="TableCellBuilder" /> value or BootstrapBuilder result.</returns>
        public static TableCellBuilder TableCellBuilder(this IHtmlHelper html, bool isHeader = false)
        {
            return new TableCellBuilder(html.ViewContext.Writer, html).SetIsHeader(isHeader);
        }

        /// <summary>
        ///     Executes the BootstrapBuilder table footer builder operation.
        /// </summary>
        /// <param name="html">The Razor HTML helper used to access view context and services.</param>
        /// <returns>The configured <see cref="TableSectionBuilder" /> value or BootstrapBuilder result.</returns>
        public static TableSectionBuilder TableFooterBuilder(this IHtmlHelper html)
        {
            return new TableSectionBuilder(html.ViewContext.Writer, html, TableSectionKind.Footer);
        }

        /// <summary>
        ///     Executes the BootstrapBuilder table header builder operation.
        /// </summary>
        /// <param name="html">The Razor HTML helper used to access view context and services.</param>
        /// <returns>The configured <see cref="TableSectionBuilder" /> value or BootstrapBuilder result.</returns>
        public static TableSectionBuilder TableHeaderBuilder(this IHtmlHelper html)
        {
            return new TableSectionBuilder(html.ViewContext.Writer, html, TableSectionKind.Header);
        }

        /// <summary>
        ///     Executes the BootstrapBuilder table row builder operation.
        /// </summary>
        /// <param name="html">The Razor HTML helper used to access view context and services.</param>
        /// <returns>The configured <see cref="TableRowBuilder" /> value or BootstrapBuilder result.</returns>
        public static TableRowBuilder TableRowBuilder(this IHtmlHelper html)
        {
            return new TableRowBuilder(html.ViewContext.Writer, html);
        }

        /// <summary>
        ///     Executes the BootstrapBuilder table section builder operation.
        /// </summary>
        /// <param name="html">The Razor HTML helper used to access view context and services.</param>
        /// <param name="section">The section value.</param>
        /// <returns>The configured <see cref="TableSectionBuilder" /> value or BootstrapBuilder result.</returns>
        public static TableSectionBuilder TableSectionBuilder(this IHtmlHelper html, TableSectionKind section)
        {
            return new TableSectionBuilder(html.ViewContext.Writer, html, section);
        }

        /// <summary>
        ///     Executes the BootstrapBuilder table td builder operation.
        /// </summary>
        /// <param name="html">The Razor HTML helper used to access view context and services.</param>
        /// <returns>The configured <see cref="TableCellBuilder" /> value or BootstrapBuilder result.</returns>
        public static TableCellBuilder TableTdBuilder(this IHtmlHelper html)
        {
            return new TableCellBuilder(html.ViewContext.Writer, html);
        }

        /// <summary>
        ///     Executes the BootstrapBuilder table th builder operation.
        /// </summary>
        /// <param name="html">The Razor HTML helper used to access view context and services.</param>
        /// <returns>The configured <see cref="TableCellBuilder" /> value or BootstrapBuilder result.</returns>
        public static TableCellBuilder TableThBuilder(this IHtmlHelper html)
        {
            return new TableCellBuilder(html.ViewContext.Writer, html).SetIsHeader(true);
        }

        /// <summary>
        ///     Executes the BootstrapBuilder table tr builder operation.
        /// </summary>
        /// <param name="html">The Razor HTML helper used to access view context and services.</param>
        /// <returns>The configured <see cref="TableRowBuilder" /> value or BootstrapBuilder result.</returns>
        public static TableRowBuilder TableTrBuilder(this IHtmlHelper html)
        {
            return new TableRowBuilder(html.ViewContext.Writer, html);
        }

        #endregion
    }
}