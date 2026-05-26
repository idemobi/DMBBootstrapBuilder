#region Copyright

// Game-Data-Forge Solution
// Written by CONTART Jean-François & BOULOGNE Quentin
// DMBBootstrapBuilder.csproj TableSectionExtensions.cs create at 2026/04/07 21:04:27
// ©2024-2026 idéMobi SARL FRANCE

#endregion

#region

using DMBPageBuilder;

#endregion

namespace DMBBootstrapBuilder
{
    /// <summary>
    /// Provides extension methods for configuring table section in BootstrapBuilder components.
    /// </summary>
    public static class TableSectionExtensions
    {
        #region Static methods

        private static TableSectionComposer GetTableSectionComposer<TBuilder>(TBuilder builder)
            where TBuilder : HtmlBuilderBase<TBuilder>, ICanUseTableSection
        {
            return builder.GetOrCreateCssComposer(() => new TableSectionComposer());
        }

        /// <summary>
        /// Configures table section divider on the current BootstrapBuilder instance.
        /// </summary>
        /// <typeparam name="TBuilder">The BootstrapBuilder type configured by this member.</typeparam>
        /// <param name="builder">The BootstrapBuilder instance to configure.</param>
        /// <param name="value">The value to apply.</param>
        /// <returns>The configured <see cref="TBuilder"/> value or BootstrapBuilder result.</returns>
        public static TBuilder SetTableSectionDivider<TBuilder>(
            this TBuilder builder,
            bool value = true
        )
            where TBuilder : HtmlBuilderBase<TBuilder>, ICanUseTableSection
        {
            GetTableSectionComposer(builder).SetDivider(value);
            return builder;
        }

        /// <summary>
        /// Configures table section variant on the current BootstrapBuilder instance.
        /// </summary>
        /// <typeparam name="TBuilder">The BootstrapBuilder type configured by this member.</typeparam>
        /// <param name="builder">The BootstrapBuilder instance to configure.</param>
        /// <param name="variant">The variant value.</param>
        /// <returns>The configured <see cref="TBuilder"/> value or BootstrapBuilder result.</returns>
        public static TBuilder SetTableSectionVariant<TBuilder>(
            this TBuilder builder,
            VariantStyle variant
        )
            where TBuilder : HtmlBuilderBase<TBuilder>, ICanUseTableSection
        {
            GetTableSectionComposer(builder).SetVariant(variant);
            return builder;
        }

        #endregion
    }
}