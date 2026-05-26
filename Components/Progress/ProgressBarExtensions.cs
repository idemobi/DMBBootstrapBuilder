using DMBPageBuilder;

namespace DMBBootstrapBuilder
{
    /// <summary>
    /// Provides extension methods for configuring progress bar in BootstrapBuilder components.
    /// </summary>
    public static class ProgressBarExtensions
    {
        #region Static methods

        private static ProgressBarComposer GetProgressBarComposer<TBuilder>(TBuilder builder)
            where TBuilder : HtmlBuilderBase<TBuilder>, ICanUseProgressBar
        {
            return builder.GetOrCreateCssComposer(() => new ProgressBarComposer());
        }

        /// <summary>
        /// Configures animated on the current BootstrapBuilder instance.
        /// </summary>
        /// <typeparam name="TBuilder">The BootstrapBuilder type configured by this member.</typeparam>
        /// <param name="builder">The BootstrapBuilder instance to configure.</param>
        /// <param name="value">The value to apply.</param>
        /// <returns>The configured <see cref="TBuilder"/> value or BootstrapBuilder result.</returns>
        public static TBuilder SetAnimated<TBuilder>(
            this TBuilder builder,
            bool value = true)
            where TBuilder : HtmlBuilderBase<TBuilder>, ICanUseProgressBar
        {
            GetProgressBarComposer(builder).SetAnimated(value);
            return builder;
        }

        /// <summary>
        /// Configures striped on the current BootstrapBuilder instance.
        /// </summary>
        /// <typeparam name="TBuilder">The BootstrapBuilder type configured by this member.</typeparam>
        /// <param name="builder">The BootstrapBuilder instance to configure.</param>
        /// <param name="value">The value to apply.</param>
        /// <returns>The configured <see cref="TBuilder"/> value or BootstrapBuilder result.</returns>
        public static TBuilder SetStriped<TBuilder>(
            this TBuilder builder,
            bool value = true)
            where TBuilder : HtmlBuilderBase<TBuilder>, ICanUseProgressBar
        {
            GetProgressBarComposer(builder).SetStriped(value);
            return builder;
        }

        /// <summary>
        /// Configures variant on the current BootstrapBuilder instance.
        /// </summary>
        /// <typeparam name="TBuilder">The BootstrapBuilder type configured by this member.</typeparam>
        /// <param name="builder">The BootstrapBuilder instance to configure.</param>
        /// <param name="variant">The variant value.</param>
        /// <returns>The configured <see cref="TBuilder"/> value or BootstrapBuilder result.</returns>
        public static TBuilder SetVariant<TBuilder>(
            this TBuilder builder,
            VariantStyle variant)
            where TBuilder : HtmlBuilderBase<TBuilder>, ICanUseProgressBar
        {
            GetProgressBarComposer(builder).SetVariant(variant);
            return builder;
        }

        #endregion
    }
}