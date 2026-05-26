#region Copyright

// Game-Data-Forge Solution
// Written by CONTART Jean-François & BOULOGNE Quentin
// DMBBootstrapBuilder.csproj TextVariantExtensions.cs create at 2026/04/07 21:04:27
// ©2024-2026 idéMobi SARL FRANCE

#endregion

#region

using DMBPageBuilder;

#endregion

namespace DMBBootstrapBuilder
{
    /// <summary>
    ///     Provides extension methods for modifying text variant styles on objects implementing
    ///     <see cref="ICanUseTextVariant" /> and based on <see cref="HtmlBuilderBase{TBuilder}" />.
    /// </summary>
    public static class TextVariantExtensions
    {
        #region Static methods

        /// <summary>
        /// Configures text emphasize on the current BootstrapBuilder instance.
        /// </summary>
        /// <typeparam name="TBuilder">The BootstrapBuilder type configured by this member.</typeparam>
        /// <param name="builder">The BootstrapBuilder instance to configure.</param>
        /// <param name="emphasize">The emphasize value.</param>
        /// <returns>The configured <see cref="TBuilder"/> value or BootstrapBuilder result.</returns>
        [Documented]
        public static TBuilder SetTextEmphasize<TBuilder>(
            this TBuilder builder,
            bool emphasize
        )
            where TBuilder : HtmlBuilderBase<TBuilder>, ICanUseTextVariant
        {
            VariantComposer composer = builder.GetOrCreateCssComposer(() => new VariantComposer());
            composer.SetTextEmphasize(emphasize);
            return builder;
        }

        /// <summary>
        ///     Sets the text variant style for the specified builder instance.
        /// </summary>
        /// <typeparam name="TBuilder">
        ///     The builder type, which must derive from <see cref="HtmlBuilderBase{TBuilder}" />
        ///     and implement <see cref="ICanUseTextVariant" />.
        /// </typeparam>
        /// <param name="builder">
        ///     The instance of <see cref="HtmlBuilderBase{TBuilder}" /> on which the variant style will be applied.
        /// </param>
        /// <param name="variant">
        ///     The <see cref="VariantStyle" /> value representing the text variant to be set.
        /// </param>
        /// <returns>
        ///     The modified <see cref="TBuilder" /> instance with the specified text variant applied.
        /// </returns>
        [Documented]
        public static TBuilder SetTextVariant<TBuilder>(
            this TBuilder builder,
            VariantStyle variant
        )
            where TBuilder : HtmlBuilderBase<TBuilder>, ICanUseTextVariant
        {
            VariantComposer composer = builder.GetOrCreateCssComposer(() => new VariantComposer());
            composer.SetText(variant);
            return builder;
        }

        /// <summary>
        /// Configures text variant from background on the current BootstrapBuilder instance.
        /// </summary>
        /// <typeparam name="TBuilder">The BootstrapBuilder type configured by this member.</typeparam>
        /// <param name="builder">The BootstrapBuilder instance to configure.</param>
        /// <param name="autoTextVariant">The auto text variant value.</param>
        /// <returns>The configured <see cref="TBuilder"/> value or BootstrapBuilder result.</returns>
        [Documented]
        public static TBuilder SetTextVariantFromBackground<TBuilder>(
            this TBuilder builder,
            bool autoTextVariant
        )
            where TBuilder : HtmlBuilderBase<TBuilder>, ICanUseTextVariant
        {
            VariantComposer composer = builder.GetOrCreateCssComposer(() => new VariantComposer());
            composer.SetTextVariantFromBackground(autoTextVariant);
            return builder;
        }

        #endregion
    }
}