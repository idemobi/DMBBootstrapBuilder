#region Copyright

// Game-Data-Forge Solution
// Written by CONTART Jean-François & BOULOGNE Quentin
// DMBBootstrapBuilder.csproj TableRowExtensions.cs create at 2026/04/07 21:04:27
// ©2024-2026 idéMobi SARL FRANCE

#endregion

#region

using DMBPageBuilder;

#endregion

namespace DMBBootstrapBuilder
{
    /// <summary>
    /// Provides extension methods for configuring table row in BootstrapBuilder components.
    /// </summary>
    public static class TableRowExtensions
    {
        #region Static methods

        private static TableRowComposer GetTableRowComposer<TBuilder>(TBuilder builder)
            where TBuilder : HtmlBuilderBase<TBuilder>, ICanUseTableRow
        {
            return builder.GetOrCreateCssComposer(() => new TableRowComposer());
        }

        /// <summary>
        /// Configures table row active on the current BootstrapBuilder instance.
        /// </summary>
        /// <typeparam name="TBuilder">The BootstrapBuilder type configured by this member.</typeparam>
        /// <param name="builder">The BootstrapBuilder instance to configure.</param>
        /// <param name="value">The value to apply.</param>
        /// <returns>The configured <see cref="TBuilder"/> value or BootstrapBuilder result.</returns>
        public static TBuilder SetTableRowActive<TBuilder>(
            this TBuilder builder,
            bool value = true
        )
            where TBuilder : HtmlBuilderBase<TBuilder>, ICanUseTableRow
        {
            GetTableRowComposer(builder).SetActive(value);
            return builder;
        }

        /// <summary>
        /// Configures table row variant on the current BootstrapBuilder instance.
        /// </summary>
        /// <typeparam name="TBuilder">The BootstrapBuilder type configured by this member.</typeparam>
        /// <param name="builder">The BootstrapBuilder instance to configure.</param>
        /// <param name="style">The style value.</param>
        /// <returns>The configured <see cref="TBuilder"/> value or BootstrapBuilder result.</returns>
        public static TBuilder SetTableRowVariant<TBuilder>(
            this TBuilder builder,
            VariantStyle style
        )
            where TBuilder : HtmlBuilderBase<TBuilder>, ICanUseTableRow
        {
            GetTableRowComposer(builder).SetVariant(style);
            return builder;
        }

        #endregion
    }
}