#region Copyright

// Game-Data-Forge Solution
// Written by CONTART Jean-François & BOULOGNE Quentin
// DMBBootstrapBuilder.csproj BackgroundVariantExtensions.cs create at 2026/04/07 21:04:27
// ©2024-2026 idéMobi SARL FRANCE

#endregion

#region

using DMBPageBuilder;

#endregion

namespace DMBBootstrapBuilder
{
    /// <summary>
    /// Provides extension methods for configuring background variant in BootstrapBuilder components.
    /// </summary>
    public static class BackgroundVariantExtensions
    {
        #region Static methods

        /// <summary>
        /// Configures background opacity on the current BootstrapBuilder instance.
        /// </summary>
        /// <typeparam name="TBuilder">The BootstrapBuilder type configured by this member.</typeparam>
        /// <param name="builder">The BootstrapBuilder instance to configure.</param>
        /// <param name="opacity">The opacity value.</param>
        /// <returns>The configured <see cref="TBuilder"/> value or BootstrapBuilder result.</returns>
        public static TBuilder SetBackgroundOpacity<TBuilder>(
            this TBuilder builder,
            Opacity opacity
        )
            where TBuilder : HtmlBuilderBase<TBuilder>, ICanUseBackgroundVariant
        {
            VariantComposer composer = builder.GetOrCreateCssComposer(() => new VariantComposer());
            composer.SetBackgroundOpacity(opacity);
            return builder;
        }

        /// <summary>
        /// Configures background subtle on the current BootstrapBuilder instance.
        /// </summary>
        /// <typeparam name="TBuilder">The BootstrapBuilder type configured by this member.</typeparam>
        /// <param name="builder">The BootstrapBuilder instance to configure.</param>
        /// <param name="subtle">The subtle value.</param>
        /// <returns>The configured <see cref="TBuilder"/> value or BootstrapBuilder result.</returns>
        public static TBuilder SetBackgroundSubtle<TBuilder>(
            this TBuilder builder,
            bool subtle
        )
            where TBuilder : HtmlBuilderBase<TBuilder>, ICanUseBackgroundVariant
        {
            VariantComposer composer = builder.GetOrCreateCssComposer(() => new VariantComposer());
            composer.SetBackgroundSubtle(subtle);
            return builder;
        }

        /// <summary>
        /// Configures background variant on the current BootstrapBuilder instance.
        /// </summary>
        /// <typeparam name="TBuilder">The BootstrapBuilder type configured by this member.</typeparam>
        /// <param name="builder">The BootstrapBuilder instance to configure.</param>
        /// <param name="variant">The variant value.</param>
        /// <param name="autoTextVariant">The auto text variant value.</param>
        /// <param name="opacity">The opacity value.</param>
        /// <param name="subtle">The subtle value.</param>
        /// <returns>The configured <see cref="TBuilder"/> value or BootstrapBuilder result.</returns>
        public static TBuilder SetBackgroundVariant<TBuilder>(
            this TBuilder builder,
            VariantStyle variant,
            bool autoTextVariant,
            Opacity opacity = Opacity.Normal,
            bool subtle = false
        )
            where TBuilder : HtmlBuilderBase<TBuilder>, ICanUseBackgroundVariant
        {
            VariantComposer composer = builder.GetOrCreateCssComposer(() => new VariantComposer());
            composer.SetBackgroundComplex(variant, autoTextVariant, opacity, subtle);
            return builder;
        }

        /// <summary>
        /// Configures background variant on the current BootstrapBuilder instance.
        /// </summary>
        /// <typeparam name="TBuilder">The BootstrapBuilder type configured by this member.</typeparam>
        /// <param name="builder">The BootstrapBuilder instance to configure.</param>
        /// <param name="variant">The variant value.</param>
        /// <returns>The configured <see cref="TBuilder"/> value or BootstrapBuilder result.</returns>
        public static TBuilder SetBackgroundVariant<TBuilder>(
            this TBuilder builder,
            VariantStyle variant
        )
            where TBuilder : HtmlBuilderBase<TBuilder>, ICanUseBackgroundVariant
        {
            VariantComposer composer = builder.GetOrCreateCssComposer(() => new VariantComposer());
            composer.SetBackgroundVariant(variant);
            return builder;
        }

        #endregion
    }
}