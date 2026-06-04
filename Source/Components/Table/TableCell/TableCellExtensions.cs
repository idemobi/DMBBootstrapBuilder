#region Copyright

// ©2002-2026 idéMobi
// www.idemobi.com

#endregion

#region

using DMBPageBuilder;

#endregion

namespace DMBBootstrapBuilder
{
    /// <summary>
    ///     Provides extension methods for configuring table cell in BootstrapBuilder components.
    /// </summary>
    public static class TableCellExtensions
    {
        #region Static methods

        private static TableCellComposer GetTableCellComposer<TBuilder>(TBuilder builder)
            where TBuilder : HtmlBuilderBase<TBuilder>, ICanUseTableCell
        {
            return builder.GetOrCreateCssComposer(() => new TableCellComposer());
        }

        /// <summary>
        ///     Configures sortable on the current BootstrapBuilder instance.
        /// </summary>
        /// <typeparam name="TBuilder">The BootstrapBuilder type configured by this member.</typeparam>
        /// <param name="builder">The BootstrapBuilder instance to configure.</param>
        /// <param name="value">The value to apply.</param>
        /// <returns>The configured <typeparamref name="TBuilder" /> value or BootstrapBuilder result.</returns>
        public static TBuilder SetSortable<TBuilder>(
            this TBuilder builder,
            bool value = true
        )
            where TBuilder : HtmlBuilderBase<TBuilder>, ICanUseTableCell
        {
            GetTableCellComposer(builder).SetSortableHeader(value);
            return builder;
        }

        /// <summary>
        ///     Configures variant on the current BootstrapBuilder instance.
        /// </summary>
        /// <typeparam name="TBuilder">The BootstrapBuilder type configured by this member.</typeparam>
        /// <param name="builder">The BootstrapBuilder instance to configure.</param>
        /// <param name="variant">The variant value.</param>
        /// <returns>The configured <typeparamref name="TBuilder" /> value or BootstrapBuilder result.</returns>
        public static TBuilder SetVariant<TBuilder>(
            this TBuilder builder,
            VariantStyle variant
        )
            where TBuilder : HtmlBuilderBase<TBuilder>, ICanUseTableCell
        {
            GetTableCellComposer(builder).SetVariant(variant);
            return builder;
        }

        /// <summary>
        ///     Configures vertical title on the current BootstrapBuilder instance.
        /// </summary>
        /// <typeparam name="TBuilder">The BootstrapBuilder type configured by this member.</typeparam>
        /// <param name="builder">The BootstrapBuilder instance to configure.</param>
        /// <param name="direction">The direction value.</param>
        /// <returns>The configured <typeparamref name="TBuilder" /> value or BootstrapBuilder result.</returns>
        public static TBuilder SetVerticalTitle<TBuilder>(
            this TBuilder builder,
            VerticalTitleDirection direction = VerticalTitleDirection.BottomToTop
        )
            where TBuilder : HtmlBuilderBase<TBuilder>, ICanUseTableCell
        {
            GetTableCellComposer(builder).SetVerticalTitle(direction);
            return builder;
        }

        #endregion
    }
}